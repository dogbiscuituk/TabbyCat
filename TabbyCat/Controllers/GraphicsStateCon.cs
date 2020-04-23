namespace TabbyCat.Controllers
{
    using Common.Utils;
    using Properties;
    using System;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class GraphicsStateCon : DockingCon
    {
        internal GraphicsStateCon(WorldCon worldCon) : base(worldCon) { }

        private GraphicsStateForm _GraphicsStateForm;

        protected internal override DockContent Form => GraphicsStateForm;

        protected override GraphicsStateForm GraphicsStateForm => _GraphicsStateForm ?? (_GraphicsStateForm = new GraphicsStateForm
        {
            TabText = Resources.GraphicsStateForm_TabText,
            Text = Resources.GraphicsStateForm_Text,
            ToolTipText = Resources.GraphicsStateForm_Text
        });

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldCon.PropertyChanged += WorldCon_PropertyChanged;
                WorldForm.ViewGraphicsState.Click += ViewGraphicsState_Click;
            }
            else
            {
                WorldCon.PropertyChanged -= WorldCon_PropertyChanged;
                WorldForm.ViewGraphicsState.Click -= ViewGraphicsState_Click;
            }
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.Menu_View_GraphicsState, WorldForm.ViewGraphicsState);
        }

        private void ViewGraphicsState_Click(object sender, EventArgs e) => ToggleVisibility();

        private void WorldCon_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case PropertyNames.GraphicsMode:
                    GraphicsStateView.lblGpuMode.Text = Scene.GraphicsMode.ToString();
                    break;
                case PropertyNames.GPUStatus:
                    GraphicsStateView.lblGpuStatus.Text = Scene.GPUStatus.ToString();
                    break;
                case PropertyNames.GPULog:
                    GraphicsStateView.lblGpuLog.Text = Scene.GPULog;
                    break;
            }
        }
    }
}
