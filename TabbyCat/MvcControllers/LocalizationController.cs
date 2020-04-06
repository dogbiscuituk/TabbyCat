namespace TabbyCat.MvcControllers
{
    using System;
    using System.Windows.Forms;
    using TabbyCat.MvcViews;

    internal abstract class LocalizationController
    {
        #region Constructors

        internal LocalizationController(WorldController worldCon) => _WorldCon = worldCon;

        #endregion

        #region Protected Properties

        protected CommandProcessor CommandProcessor { get; private set; }
        protected PropertiesController PropertiesController => WorldCon.PropertiesController;
        protected ToolTip ToolTip => WorldForm.ToolTip;
        protected WorldForm WorldForm => WorldCon.WorldForm;
        protected virtual WorldController WorldCon => _WorldCon;

        #endregion

        #region Protected Internal Methods

        protected internal virtual void Connect(bool connect)
        {
            if (connect)
            {
                Localize();
            }
            else
            {

            }
        }

        #endregion

        #region Protected Methods

        protected abstract void Localize();

        protected void Localize(string info, params Control[] controls)
        {
            string hint, text = Parse(info, out hint, out _, out _);
            foreach (var control in controls)
            {
                if (!string.IsNullOrWhiteSpace(text))
                    control.Text = text;
                ToolTip.SetToolTip(control, hint);
            }
        }

        protected void Localize(string info, params ToolStripItem[] items)
        {
            string text = Parse(info, out string hint, out string keys, out Keys shortcut);
            foreach (var item in items)
            {
                item.Text = text;
                item.ToolTipText = hint;
                if (shortcut != Keys.None && item is ToolStripMenuItem menuItem)
                {
                    menuItem.ShortcutKeys = shortcut;
                    menuItem.ShortcutKeyDisplayString = keys;
                }
            }
        }

        #endregion

        #region Private Fields

        private readonly WorldController _WorldCon;

        #endregion

        #region Private Properties

        private ToolTip ToolTip => WorldForm.ToolTip;

        #endregion

        #region Private Methods

        private static string Parse(string info, out string hint, out string keys, out Keys shortcut)
        {
            var infos = info.Split('|');
            hint = string.Empty;
            keys = string.Empty;
            shortcut = Keys.None;
            if (infos.Length > 2)
            {
                keys = infos[2];
                if (!string.IsNullOrWhiteSpace(keys))
                    try
                    {
                        shortcut = (Keys)new KeysConverter().ConvertFrom(keys.Replace("^", "Control+"));
                    }
                    catch (ArgumentException ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"InitMenuItems(\"{info}\", ...): {ex.Message}");
                    }
            }
            if (infos.Length > 1)
            {
                hint = infos[1];
                if (shortcut != Keys.None)
                    hint = $"{hint} ({keys})";
            }
            return infos[0];
        }

        #endregion
    }
}
