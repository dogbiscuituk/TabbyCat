namespace TabbyCat.Controllers
{
    using Properties;
    using System;
    using System.Windows.Forms;

    public class FullScreenCon : LocalizationCon
    {
        public FullScreenCon(WorldCon worldCon) : base(worldCon) { }

        private bool FullScreen;

        private FormWindowState PriorWindowState;

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

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewFullScreen, WorldForm.ViewFullScreen, WorldForm.tbFullScreen);
        }

        private void ViewFullScreen_Click(object sender, System.EventArgs e)
        {
            FullScreen = !FullScreen;
            if (!FullScreen)
            {
                WorldForm.FormBorderStyle = FormBorderStyle.Sizable;
                WorldForm.WindowState = PriorWindowState;
            }
            Array.ForEach(new DockingCon[]
            {
                SignalsCon,
                SceneCodeCon,
                ScenePropertiesCon,
                ShaderCodeCon,
                TraceCodeCon,
                TracePropertiesCon
            },
                p => p.SetVisibility(!FullScreen));
            WorldForm.MainMenu.Visible =
                WorldForm.Toolbar.Visible =
                WorldForm.StatusBar.Visible = !FullScreen;
            if (FullScreen)
            {
                PriorWindowState = WorldForm.WindowState;
                WorldForm.WindowState = FormWindowState.Maximized;
                WorldForm.FormBorderStyle = FormBorderStyle.None;
            }
            WorldForm.ViewFullScreen.Checked = WorldForm.tbFullScreen.Checked = FullScreen;
        }
    }
}
