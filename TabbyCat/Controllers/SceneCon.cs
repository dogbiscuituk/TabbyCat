namespace TabbyCat.Controllers
{
    using OpenTK;
    using Properties;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Types;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    public class SceneCon : DockingCon
    {
        // Constructors

        public SceneCon(WorldCon worldCon) : base(worldCon) { }

        // Private fields

        private bool _sceneControlHandleDestroyed;
        private SceneForm _sceneForm;

        // Public properties

        public override GLControl SceneControl
        {
            get
            {
                if (_sceneControlHandleDestroyed)
                {
                    _sceneControlHandleDestroyed  = false;
                    RecreateSceneControl();
                }
                return GetSceneControl();
            }
        }

        // Protected properties

        protected override DockContent Form => SceneForm;

        protected override SceneForm SceneForm => _sceneForm ?? (_sceneForm = new SceneForm());

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                SceneControl.ClientSizeChanged += SceneControl_ClientSizeChanged;
                SceneControl.Load += SceneControl_Load;
                SceneControl.Paint += SceneControl_Paint;
                SceneControl.Resize += SceneControl_Resize;
                SceneControl.HandleDestroyed += SceneControl_HandleDestroyed;
                WorldCon.PropertyEdit += WorldCon_PropertyEdit;
                WorldForm.ViewScene.Click += ViewScene_Click;
            }
            else
            {
                SceneControl.ClientSizeChanged -= SceneControl_ClientSizeChanged;
                SceneControl.Load -= SceneControl_Load;
                SceneControl.Paint -= SceneControl_Paint;
                SceneControl.Resize -= SceneControl_Resize;
                SceneControl.HandleDestroyed -= SceneControl_HandleDestroyed;
                WorldCon.PropertyEdit -= WorldCon_PropertyEdit;
                WorldForm.ViewScene.Click -= ViewScene_Click;
            }
        }

        public GLControl GetSceneControl() => SceneForm?.Controls.OfType<GLControl>().FirstOrDefault();

        public void RecreateSceneControl()
        {
            GLControl
                oldControl = GetSceneControl(),
                newControl = new GLControl();
            var parent = oldControl.Parent;
            newControl.BackColor = Scene.BackgroundColour;
            newControl.Dock = DockStyle.Fill;
            newControl.Location = new System.Drawing.Point(0, 0);
            newControl.Name = "SceneControl";
            newControl.Size = new System.Drawing.Size(100, 100);
            newControl.TabIndex = 1;
            newControl.VSync = Scene.VSync;
            parent.SuspendLayout();
            SceneCon.Connect(false);
            parent.Controls.Remove(oldControl);
            parent.Controls.Add(newControl);
            SceneCon.Connect(true);
            RenderCon.Refresh();
            parent.ResumeLayout();
            oldControl.Dispose();
        }

        // Protected methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewScene, WorldForm.ViewScene);
        }

        // Private methods

        private void OnPropertyEdit(Property property)
        {
            /*
        switch (property)
        {
            case Property.GraphicsMode:
                RecreateSceneControl();
                break;
            case Property.Samples:
                RecreateSceneControl("Samples", Scene.Samples);
                break;
            case Property.Stereo:
                RecreateSceneControl("Stereo", Scene.Stereo);
                break;
        }
            */
            SceneControl.Invalidate();
        }

        private void Resize() => RenderCon.InvalidateProjection();

        private void SceneControl_ClientSizeChanged(object sender, EventArgs e) => Resize();

        private void SceneControl_HandleDestroyed(object sender, EventArgs e) => _sceneControlHandleDestroyed = true;

        private void SceneControl_Load(object sender, EventArgs e) { }

        private void SceneControl_Paint(object sender, PaintEventArgs e) => RenderCon.Render();

        private void ViewScene_Click(object sender, EventArgs e) => ToggleVisibility();

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e) => OnPropertyEdit(e.Property);

        // Private static methods

        private static void SceneControl_Resize(object sender, EventArgs e) { }
    }
}
