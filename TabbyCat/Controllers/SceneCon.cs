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
        // Constructors

        internal SceneCon(WorldCon worldCon) : base(worldCon) { }

        // Private fields

        private SceneForm _SceneForm;

        // Protected internal properties

        protected internal override DockContent Form => SceneForm;

        // Protected properties

        protected override SceneForm SceneForm => _SceneForm ?? (_SceneForm = new SceneForm());

        // Internal methods

        internal void BackColorChanged() => SceneControl.Parent.BackColor = Scene.BackgroundColour;

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

        internal void RecreateSceneControl() => RecreateSceneControl(GraphicsMode);

        // Protected internal methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                SceneForm.HandleCreated += SceneForm_HandleCreated;
                SceneForm.HandleDestroyed += SceneForm_HandleDestroyed;
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
                SceneForm.HandleCreated -= SceneForm_HandleCreated;
                SceneForm.HandleDestroyed -= SceneForm_HandleDestroyed;
                SceneControl.BackColorChanged -= SceneControl_BackColorChanged;
                SceneControl.ClientSizeChanged -= SceneControl_ClientSizeChanged;
                SceneControl.Load -= SceneControl_Load;
                SceneControl.Paint -= SceneControl_Paint;
                SceneControl.Resize -= SceneControl_Resize;
            }
        }

        // Protected methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewScene, WorldForm.ViewScene);
        }

        // Private methods

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

        private void ViewScene_Click(object sender, EventArgs e) => ToggleVisibility();

        private void SceneForm_HandleCreated(object sender, EventArgs e)
        {
            RenderCon.SceneControlSuspended = false;
            RecreateSceneControl();
        }

        private void SceneForm_HandleDestroyed(object sender, EventArgs e)
        {
            RenderCon.Invalidate();
            RenderCon.SceneControlSuspended = true;
        }

        private void WorldCon_PropertyChanged(object sender, PropertyChangedEventArgs e) => OnPropertyChanged(e.PropertyName);
    }
}
