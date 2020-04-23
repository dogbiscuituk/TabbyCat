namespace TabbyCat.Controllers
{
    using Common.Utils;
    using OpenTK;
    using OpenTK.Graphics;
    using Properties;
    using System;
    using System.ComponentModel;
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

        internal void RecreateSceneControl() => RecreateSceneControl(GraphicsMode);

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

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldCon.PropertyChanged += WorldCon_PropertyChanged;
                WorldForm.ViewScene.Click += ViewScene_Click;
                SceneControl.BackColorChanged += SceneControl_BackColorChanged;
                SceneControl.ClientSizeChanged += SceneControl_ClientSizeChanged;
                SceneControl.Load += SceneControl_Load;
                SceneControl.Paint += SceneControl_Paint;
                SceneControl.Resize += SceneControl_Resize;
            }
            else
            {
                WorldCon.PropertyChanged -= WorldCon_PropertyChanged;
                WorldForm.ViewScene.Click -= ViewScene_Click;
                SceneControl.BackColorChanged -= SceneControl_BackColorChanged;
                SceneControl.ClientSizeChanged -= SceneControl_ClientSizeChanged;
                SceneControl.Load -= SceneControl_Load;
                SceneControl.Paint -= SceneControl_Paint;
                SceneControl.Resize -= SceneControl_Resize;
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

        private void RecreateSceneControl(string propertyName, object value) => RecreateSceneControl(GraphicsMode.Change(propertyName, value));

        private void RecreateSceneControl(GraphicsMode mode)
        {
            var parent = SceneControl.Parent;
            GLControl
                oldControl = SceneControl,
                newControl = mode == null ? new GLControl() : new GLControl(mode);
            newControl.BackColor = Scene.BackgroundColour;
            newControl.Dock = DockStyle.Fill;
            newControl.Location = new System.Drawing.Point(0, 0);
            newControl.Name = "SceneControl";
            newControl.Size = new System.Drawing.Size(100, 100);
            newControl.TabIndex = 1;
            newControl.VSync = Scene.VSync;
            SceneCon.BackColorChanged();
            parent.SuspendLayout();
            SceneCon.Connect(false);
            parent.Controls.Remove(oldControl);
            parent.Controls.Add(newControl);
            SceneCon.Connect(true);
            RenderCon.Refresh();
            parent.ResumeLayout();
            oldControl.Dispose();
        }

        internal void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case PropertyNames.GraphicsMode:
                    RecreateSceneControl();
                    break;
                case PropertyNames.Samples:
                    RecreateSceneControl("Samples", Scene.Samples);
                    break;
                case PropertyNames.Stereo:
                    RecreateSceneControl("Stereo", Scene.Stereo);
                    break;
            }
            SceneControl.Invalidate();
        }

        private void ViewScene_Click(object sender, EventArgs e) => ToggleVisibility();

        private void WorldCon_PropertyChanged(object sender, PropertyChangedEventArgs e) => OnPropertyChanged(e.PropertyName);
    }
}
