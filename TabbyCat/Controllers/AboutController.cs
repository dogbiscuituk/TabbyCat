namespace TabbyCat.Controllers
{
    using System.Reflection;
    using System.Windows.Forms;
    using TabbyCat.Views;

    internal class AboutController : LocalizationController
    {
        internal AboutController(WorldController worldController)
            : base(worldController)
        {
            View = new AboutDialog();
            var asm = Assembly.GetExecutingAssembly();
            View.Text = $"About {Application.ProductName}";
            View.lblProductName.Text = Application.ProductName;
            View.lblDescription.Text = asm.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            View.lblVersion.Text = Application.ProductVersion;
            View.lblAuthor.Text = Application.CompanyName;
            View.lblCopyright.Text = asm.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            var info = AppController.WorldControllers[0].GLInfo;
            View.lblOpenGLVersion.Text = info.Number;
            View.lblGLSLVersion.Text = info.Shader;
            View.lblVendorName.Text = info.Vendor;
            View.lblRendererName.Text = info.Renderer;
        }

        internal void Show(IWin32Window owner)
        {
            Init(false);
            View.Show(owner);
        }

        internal void ShowDialog(IWin32Window owner)
        {
            Init(true);
            View.ShowDialog(owner);
        }

        internal AboutDialog View { get; set; }

        private void Init(bool showOK) => View.btnOK.Visible = showOK;
    }
}
