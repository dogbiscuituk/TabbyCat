namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using TabbyCat.Controls;
    using TabbyCat.Views;

    internal class PropertiesController : HostController
    {
        #region Constructors

        internal PropertiesController(SceneController sceneController)
            : base(sceneController, "Properties")
        {
            //SceneController = sceneController;
            SceneEditController = new SceneEditController(this);
            ShaderController = new ShaderController(this);
            TraceEditController = new TraceEditController(this);
            Connect(true);
        }

        #endregion

        #region Fields & Properties

        internal TabbedEdit TabbedEdit => SceneForm.TabbedEdit;
        internal readonly ShaderController ShaderController;

        protected override Control Editor => TabbedEdit;
        protected override Control EditorParent => SceneForm.SplitContainer1.Panel2;

        private readonly SceneEditController SceneEditController;
        private readonly TraceEditController TraceEditController;

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

        protected override void Collapse(bool collapse) => SceneForm.SplitContainer1.Panel2Collapsed = collapse;

        #endregion

        #region Private Event Handlers

        private void PopupPropertiesUndock_Click(object sender, System.EventArgs e) =>
            EditorDocked = !EditorDocked;

        private void PopupPropertiesHide_Click(object sender, System.EventArgs e) =>
            EditorVisible = false;

        private void PopupPropertiesMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) =>
            SceneForm.PopupPropertiesUndock.Text = EditorDocked ? "&Undock" : "&Dock";

        #endregion

        #region Private Methods

        private void Connect(bool connect)
        {
            if (connect)
            {
                SceneForm.ViewProperties.Click += ToggleEditor;
                SceneForm.PopupPropertiesMenu.Opening += PopupPropertiesMenu_Opening;
                SceneForm.PopupPropertiesHide.Click += PopupPropertiesHide_Click;
                SceneForm.PopupPropertiesUndock.Click += PopupPropertiesUndock_Click;
            }
            else
            {
                SceneForm.ViewProperties.Click -= ToggleEditor;
                SceneForm.PopupPropertiesMenu.Opening -= PopupPropertiesMenu_Opening;
                SceneForm.PopupPropertiesHide.Click -= PopupPropertiesHide_Click;
                SceneForm.PopupPropertiesUndock.Click -= PopupPropertiesUndock_Click;
            }
            SceneEditController.Connect(connect);
            TraceEditController.Connect(connect);
            ShaderController.Connect(connect);
        }

        #endregion
    }
}
