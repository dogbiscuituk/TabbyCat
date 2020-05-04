namespace TabbyCat.Controllers
{
    using System.Reflection;
    using System.Windows.Forms;
    using Views;

    internal class AboutCon : LocalizationCon
    {
        internal AboutCon(WorldCon worldCon) : base(worldCon)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            AboutDialog.Text = $"About {Application.ProductName}";
            AboutDialog.lblProductName.Text = Application.ProductName;
            AboutDialog.lblDescription.Text = asm.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            AboutDialog.lblVersion.Text = Application.ProductVersion;
            AboutDialog.lblAuthor.Text = Application.CompanyName;
            AboutDialog.lblCopyright.Text = asm.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            Types.GLInfo info = AppCon.WorldCons[0].GLInfo;
            AboutDialog.lblOpenGLVersion.Text = info.Number;
            AboutDialog.lblGLSLVersion.Text = info.Shader;
            AboutDialog.lblVendorName.Text = info.Vendor;
            AboutDialog.lblRendererName.Text = info.Renderer;
        }

        private AboutDialog _AboutDialog;

        internal AboutDialog AboutDialog => _AboutDialog ?? (_AboutDialog = new AboutDialog());

        internal void Show(IWin32Window owner)
        {
            Init(false);
            AboutDialog.Show(owner);
        }

        internal void ShowDialog(IWin32Window owner)
        {
            Init(true);
            AboutDialog.ShowDialog(owner);
        }

        private void Init(bool showOK)
        {
            AboutDialog.btnOK.Visible = showOK;
        }
    }
}
