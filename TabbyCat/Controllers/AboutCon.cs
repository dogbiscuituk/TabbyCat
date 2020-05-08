namespace TabbyCat.Controllers
{
    using System.Reflection;
    using System.Windows.Forms;
    using Views;

    public class AboutCon : LocalizationCon
    {
        public AboutCon(WorldCon worldCon) : base(worldCon)
        {
            var asm = Assembly.GetExecutingAssembly();
            AboutDialog.Text = $"About {Application.ProductName}";
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

        private AboutDialog _AboutDialog;

        public AboutDialog AboutDialog => _AboutDialog ?? (_AboutDialog = new AboutDialog());

        public void Show(IWin32Window owner)
        {
            Init(false);
            AboutDialog.Show(owner);
        }

        public void ShowDialog(IWin32Window owner)
        {
            Init(true);
            AboutDialog.ShowDialog(owner);
        }

        private void Init(bool showOK) => AboutDialog.btnOK.Visible = showOK;
    }
}
