namespace TabbyCat.Controllers
{
    using TabbyCat.Properties;
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class GpuController : DockingController
    {
        internal GpuController(WorldController worldController) : base(worldController) { }

        private GpuForm _GpuForm;

        protected internal override DockContent Form => GpuForm;

        protected override GpuForm GpuForm => _GpuForm ?? (_GpuForm = new GpuForm
        {
            TabText = Resources.GpuForm_TabText,
            Text = Resources.GpuForm_Text,
            ToolTipText = Resources.GpuForm_Text
        });
    }
}
