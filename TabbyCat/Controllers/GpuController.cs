namespace TabbyCat.Controllers
{
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class GpuController : DockingController
    {
        internal GpuController(WorldController worldController) : base(worldController)
        {
            GpuForm = new GpuForm();
        }

        protected override DockContent Form => GpuForm;
        protected override GpuForm GpuForm { get; }
    }
}
