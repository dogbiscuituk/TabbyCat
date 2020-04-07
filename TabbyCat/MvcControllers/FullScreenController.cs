namespace TabbyCat.MvcControllers
{
    using System;
    using System.Windows.Forms;
    using TabbyCat.MvcViews;

    internal class FullScreenController : LocalizationController
    {
        #region Constructor

        internal FullScreenController(WorldController worldController)
            : base(worldController)
        { }

        #endregion

        #region Protected Internal Methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.ViewFullScreen.Click += ZoomFullScreen_Click;
            }
            else
            {
                WorldForm.ViewFullScreen.Click -= ZoomFullScreen_Click;
            }
        }

        #endregion

        #region Private Types

        [Flags]
        internal enum FormElements
        {
            None = 0x00,
            MainMenu = 0x01,
            Toolbar = 0x02,
            StatusBar = 0x04,
            Properties = 0x08
        }

        private struct FormState
        {
            internal FormBorderStyle BorderStyle;
            internal FormElements Elements;
            internal FormWindowState WindowState;
        }

        #endregion

        #region Private Properties

        private PropertiesController PropertiesController => WorldController.PropertiesController;

        private FormState SavedFormState;

        private bool FullScreen
        {
            get => WorldForm.ViewFullScreen.Checked;
            set
            {
                WorldForm.ViewFullScreen.Checked = value;
                AdjustFullScreen();
            }
        }

        private FormState State
        {
            get => new FormState
            {
                BorderStyle = WorldForm.FormBorderStyle,
                Elements = FormElements.None
                | (WorldForm.MainMenuStrip.Visible ? FormElements.MainMenu : 0)
                | (WorldForm.Toolbar.Visible ? FormElements.Toolbar : 0)
                | (WorldForm.StatusBar.Visible ? FormElements.StatusBar : 0)
                | (PropertiesController.EditorVisible ? FormElements.Properties : 0),
                WindowState = WorldForm.WindowState
            };
            set
            {
                WorldForm.FormBorderStyle = value.BorderStyle;
                var elements = value.Elements;
                WorldForm.MainMenuStrip.Visible = (elements & FormElements.MainMenu) != 0;
                WorldForm.Toolbar.Visible = (elements & FormElements.Toolbar) != 0;
                WorldForm.StatusBar.Visible = (elements & FormElements.StatusBar) != 0;
                PropertiesController.EditorVisible = (elements & FormElements.Properties) != 0;
                WorldForm.WindowState = value.WindowState;
            }
        }

        private static readonly FormState FullScreenState = new FormState
        {
            BorderStyle = FormBorderStyle.None,
            Elements = FormElements.None,
            WindowState = FormWindowState.Maximized
        };

        #endregion

        #region Private Event Handlers

        private void ZoomFullScreen_Click(object sender, EventArgs e) => ToggleFullScreen();

        #endregion

        #region Private Methods

        private void AdjustFullScreen()
        {
            if (FullScreen)
            {
                SavedFormState = State;
                State = FullScreenState;
            }
            else
                State = SavedFormState;
        }

        private void ToggleFullScreen() => FullScreen = !FullScreen;

        #endregion
    }
}
