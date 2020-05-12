namespace TabbyCat.Controllers
{
    using Properties;
    using System;
    using System.Windows.Forms;

    public class FullScreenCon : LocalCon
    {
        // Constructors

        public FullScreenCon(WorldCon worldCon) : base(worldCon) { }

        // Private fields

        private bool _fullScreen;

        private FormWindowState _priorWindowState;

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.ViewFullScreen.Click += ViewFullScreen_Click;
                WorldForm.tbFullScreen.Click += ViewFullScreen_Click;
            }
            else
            {
                WorldForm.ViewFullScreen.Click -= ViewFullScreen_Click;
                WorldForm.tbFullScreen.Click -= ViewFullScreen_Click;
            }
        }

        // Protected methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewFullScreen, WorldForm.ViewFullScreen, WorldForm.tbFullScreen);
        }

        // Private methods

        private void ViewFullScreen_Click(object sender, EventArgs e)
        {
            _fullScreen = !_fullScreen;
            if (!_fullScreen)
            {
                WorldForm.FormBorderStyle = FormBorderStyle.Sizable;
                WorldForm.WindowState = _priorWindowState;
            }
            Array.ForEach(new DockingCon[]
            {
                HotkeysCon,
                SignalsCon,
                SceneCodeCon,
                ScenePropertiesCon,
                ShaderCodeCon,
                TraceCodeCon,
                TracePropertiesCon
            },
                p => p.SetVisibility(!_fullScreen));
            WorldForm.MainMenu.Visible =
                WorldForm.Toolbar.Visible =
                WorldForm.StatusBar.Visible = !_fullScreen;
            if (_fullScreen)
            {
                _priorWindowState = WorldForm.WindowState;
                WorldForm.WindowState = FormWindowState.Maximized;
                WorldForm.FormBorderStyle = FormBorderStyle.None;
            }
            WorldForm.ViewFullScreen.Checked = WorldForm.tbFullScreen.Checked = _fullScreen;
        }
    }
}
