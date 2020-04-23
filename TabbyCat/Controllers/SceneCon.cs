namespace TabbyCat.Controllers
{
    using Properties;
    using System;
    using System.Windows.Forms;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class SceneCon : DockingCon
    {
        internal SceneCon(WorldCon worldCon) : base(worldCon) { }

        private int CurrencyCount;

        private SceneForm _SceneForm;

        protected internal override DockContent Form => SceneForm;

        protected override SceneForm SceneForm => _SceneForm ?? (_SceneForm = new SceneForm());

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.ViewScene.Click += ViewScene_Click;
                SceneControl.BackColorChanged += SceneControl_BackColorChanged;
                SceneControl.ClientSizeChanged += SceneControl_ClientSizeChanged;
                SceneControl.Load += SceneControl_Load;
                SceneControl.Paint += SceneControl_Paint;
                SceneControl.Resize += SceneControl_Resize;
            }
            else
            {
                WorldForm.ViewScene.Click -= ViewScene_Click;
                SceneControl.BackColorChanged -= SceneControl_BackColorChanged;
                SceneControl.ClientSizeChanged -= SceneControl_ClientSizeChanged;
                SceneControl.Load -= SceneControl_Load;
                SceneControl.Paint -= SceneControl_Paint;
                SceneControl.Resize -= SceneControl_Resize;
            }
        }

        internal void BackColorChanged() => SceneControl.Parent.BackColor = Scene.BackgroundColour;

        internal void Do(Action action)
        {
            if (SceneControl?.IsHandleCreated == true &&
                SceneControl?.HasValidContext == true &&
                SceneControl?.Visible == true)
            {
                if (++CurrencyCount == 1)
                    SceneControl.MakeCurrent();
                try
                {
                    action();
                }
                finally
                {
                    if (--CurrencyCount == 0)
                        SceneControl.Context.MakeCurrent(null);
                }
            }
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.Menu_View_Scene, WorldForm.ViewScene);
        }

        private void Resize() => RenderCon.InvalidateProjection();

        private void SceneControl_BackColorChanged(object sender, EventArgs e) => BackColorChanged();
        private void SceneControl_ClientSizeChanged(object sender, EventArgs e) => Resize();
        private void SceneControl_Load(object sender, EventArgs e) { }
        private void SceneControl_Paint(object sender, PaintEventArgs e) => RenderCon.Render();
        private void SceneControl_Resize(object sender, EventArgs e) { }
        private void ViewScene_Click(object sender, EventArgs e) => ToggleVisibility();
    }
}
