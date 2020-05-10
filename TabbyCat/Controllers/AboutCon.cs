namespace TabbyCat.Controllers
{
    using System.Globalization;
    using System.Reflection;
    using System.Windows.Forms;
    using Properties;
    using Views;

    public class AboutCon : LocalizationCon
    {
        public AboutCon(WorldCon worldCon) : base(worldCon)
        {
            var asm = Assembly.GetExecutingAssembly();
            AboutDialog.Text = string.Format(CultureInfo.CurrentCulture, Resources.AboutDialog, Application.ProductName);
            AboutDialog.lblProductName.Text = Application.ProductName;
            AboutDialog.lblDescription.Text = asm.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            AboutDialog.lblVersion.Text = Application.ProductVersion;
            AboutDialog.lblAuthor.Text = Application.CompanyName;
            AboutDialog.lblCopyright.Text = asm.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            var info = AppCon.WorldCons[0].GLInfo;
            AboutDialog.lblOpenGLVersion.Text = info.Number;
            AboutDialog.lblGLSLVersion.Text = info.Shader;
            AboutDialog.lblVendorName.Text = info.Vendor;
            AboutDialog.lblRendererName.Text = info.Renderer;
        }

        private AboutDialog _aboutDialog;

        public AboutDialog AboutDialog => _aboutDialog ?? (_aboutDialog = new AboutDialog());

        public void ShowDialog(IWin32Window owner)
        {
            AboutDialog.btnOK.Visible = true;
            AboutDialog.ShowDialog(owner);
        }
    }
}
