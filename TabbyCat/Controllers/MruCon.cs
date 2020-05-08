namespace TabbyCat.Controllers
{
    using CustomControls;
    using Properties;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using Win32 = Microsoft.Win32;

    /// <summary>
    /// "Most Recently Used" Controller.
    /// 
    /// Use the Windows Register to keep track of an application's recently used files.
    /// Display recently used file paths on a dedicated submenu in the application.
    /// Allow these recently used files to be invoked via a virtual "Reopen" method.
    /// Provide a "Clear" subitem to reset the content of this submenu to (empty).
    /// Note: unsafe code is used to abbreviate long paths (see the implementation
    /// of the  CompactMenuText method).
    /// </summary>
    public class MruCon : LocalizationCon
    {
        protected MruCon(WorldCon worldCon, string subKeyName) : base(worldCon)
        {
            if (string.IsNullOrWhiteSpace(subKeyName))
                throw new ArgumentNullException(nameof(subKeyName));
            SubKeyName = string.Format(
                CultureInfo.InvariantCulture,
                @"Software\{0}\{1}\{2}",
                Application.CompanyName,
                Application.ProductName,
                subKeyName);
            RefreshRecentMenu();
        }

        private readonly string SubKeyName;

        protected ToolStripDropDownItem RecentMenu => WorldCon.WorldForm.FileReopen;

        public virtual void Reopen(ToolStripItem menuItem) { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "Multiple exception types can be thrown, all can be ignored.")]
        protected void AddItem(string item)
        {
            try
            {
                var key = CreateSubKey();
                if (key == null)
                    return;
                try
                {
                    DeleteItem(key, item);
                    key.SetValue(DateTime.Now.ToString("yyyyMMddHHmmssFF", CultureInfo.CurrentCulture), item);
                }
                finally
                {
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            RefreshRecentMenu();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "Multiple exception types can be thrown, all can be ignored.")]
        protected void RemoveItem(string item)
        {
            try
            {
                var key = OpenSubKey(true);
                if (key == null)
                    return;
                try
                {
                    DeleteItem(key, item);
                }
                finally
                {
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            RefreshRecentMenu();
        }

        private Win32.RegistryKey CreateSubKey() => Win32.Registry.CurrentUser.CreateSubKey(SubKeyName, Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);

        private static void DeleteItem(Win32.RegistryKey key, string item)
        {
            var name = key.GetValueNames()
                .Where(n => key.GetValue(n, null) as string == item)
                .FirstOrDefault();
            if (name != null)
                key.DeleteValue(name);
        }

        private Win32.RegistryKey OpenSubKey(bool writable) => Win32.Registry.CurrentUser.OpenSubKey(SubKeyName, writable);

        private void RecentItemClick(object sender, EventArgs e) => Reopen((ToolStripItem)sender);

        private void RecentClear_Click(object sender, EventArgs e)
        {
            var key = OpenSubKey(true);
            if (key == null)
                return;
            foreach (var name in key.GetValueNames())
                key.DeleteValue(name, true);
            key.Close();
            if (RecentMenu != null)
            {
                RecentMenu.DropDownItems.Clear();
                RecentMenu.Enabled = false;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "Multiple exception types can be thrown, all can be ignored.")]
        private void RefreshRecentMenu()
        {
            if (RecentMenu == null)
                return;
            var items = RecentMenu.DropDownItems;
            items.Clear();
            Win32.RegistryKey key = null;
            try
            {
                key = OpenSubKey(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            var ok = key != null;
            if (ok)
            {
                foreach (var name in key.GetValueNames().OrderByDescending(n => n))
                    if (key.GetValue(name, null) is string value)
                        try
                        {
                            var text = value.Split('|')[0].CompactMenuText();
                            var item = items.Add(text, null, RecentItemClick);
                            item.Tag = value;
                            item.ToolTipText = value.Replace('|', '\n');
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                ok = items.Count > 0;
                if (ok)
                {
                    items.Add(new ToolStripSeparator());
                    var item = items.Add(string.Empty);
                    Localize(Resources.WorldForm_FileClearThisList, item);
                    item.Click += RecentClear_Click;
                }
            }
            RecentMenu.Enabled = ok;
        }
    }
}
