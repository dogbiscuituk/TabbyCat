namespace TabbyCat.Controllers
{
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Properties;
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class GpuCon : DockingCon
    {
        internal GpuCon(WorldCon worldCon) : base(worldCon) { }

        private GraphicsStateForm _GpuForm;

        protected internal override DockContent Form => GpuForm;

        protected override GraphicsStateForm GpuForm => _GpuForm ?? (_GpuForm = new GraphicsStateForm
        {
            TabText = Resources.GpuForm_TabText,
            Text = Resources.GpuForm_Text,
            ToolTipText = Resources.GpuForm_Text
        });

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldCon.PropertyChanged += WorldCon_PropertyChanged;
            }
            else
            {
                WorldCon.PropertyChanged -= WorldCon_PropertyChanged;
            }
        }

        private void WorldCon_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case PropertyNames.GraphicsMode:
                    GpuEdit.lblGpuMode.Text = Scene.GraphicsMode.ToString();
                    break;
                case PropertyNames.GPUStatus:
                    GpuEdit.lblGpuStatus.Text = Scene.GPUStatus.ToString();
                    break;
                case PropertyNames.GPULog:
                    GpuEdit.lblGpuLog.Text = Scene.GPULog;
                    break;
            }
        }
    }
}
