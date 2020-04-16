namespace TabbyCat.Controllers
{
    using TabbyCat.Properties;
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class GpuCon : DockingCon
    {
        internal GpuCon(WorldCon worldCon) : base(worldCon) { }

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
