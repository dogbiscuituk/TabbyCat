﻿namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using TabbyCat.Controls;
    using TabbyCat.Views;

    internal class PropertiesController : HostController
    {
        #region Constructors

        internal PropertiesController(WorldController worldController)
            : base(worldController, "Properties")
        {
            SceneController = new SceneController(this);
            ShaderController = new ShaderController(this);
            TraceController = new TraceController(this);
            Connect(true);
        }

        #endregion

        #region Fields & Properties

        internal TabbedEdit TabbedEdit => WorldForm.TabbedEdit;
        internal readonly ShaderController ShaderController;

        protected override Control Editor => TabbedEdit;
        protected override Control EditorParent => WorldForm.SplitContainer1.Panel2;

        private readonly SceneController SceneController;
        private readonly TraceController TraceController;

        #endregion

        #region Protected Internal Methods

        protected internal override void Refresh()
        {
            if (EditorVisible)
            {

            }
        }

        #endregion

        #region Protected Methods

        protected override void Collapse(bool collapse) => WorldForm.SplitContainer1.Panel2Collapsed = collapse;

        #endregion

        #region Private Event Handlers

        private void PopupPropertiesUndock_Click(object sender, System.EventArgs e) =>
            EditorDocked = !EditorDocked;

        private void PopupPropertiesHide_Click(object sender, System.EventArgs e) =>
            EditorVisible = false;

        private void PopupPropertiesMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) =>
            WorldForm.PopupPropertiesUndock.Text = EditorDocked ? "&Undock" : "&Dock";

        #endregion

        #region Private Methods

        private void Connect(bool connect)
        {
            if (connect)
            {
                WorldForm.ViewProperties.Click += ToggleEditor;
                WorldForm.PopupPropertiesMenu.Opening += PopupPropertiesMenu_Opening;
                WorldForm.PopupPropertiesHide.Click += PopupPropertiesHide_Click;
                WorldForm.PopupPropertiesUndock.Click += PopupPropertiesUndock_Click;
            }
            else
            {
                WorldForm.ViewProperties.Click -= ToggleEditor;
                WorldForm.PopupPropertiesMenu.Opening -= PopupPropertiesMenu_Opening;
                WorldForm.PopupPropertiesHide.Click -= PopupPropertiesHide_Click;
                WorldForm.PopupPropertiesUndock.Click -= PopupPropertiesUndock_Click;
            }
            SceneController.Connect(connect);
            TraceController.Connect(connect);
            ShaderController.Connect(connect);
        }

        #endregion
    }
}
