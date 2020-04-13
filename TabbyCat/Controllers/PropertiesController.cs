namespace TabbyCat.Controllers
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controls;
    using TabbyCat.Properties;
    using TabbyCat.Views;

    internal class PropertiesController : HostController
    {
        internal PropertiesController(WorldController worldController) : base(worldController, Resources.Text_Properties) { }

        internal ToolTip ToolTip => WorldController.ToolTip;

        protected override Control Editor => PropertiesEdit;

        protected override Control EditorParent => WorldForm.SplitContainer1.Panel2;

        protected internal override void UpdateAllProperties()
        {
            SceneController.UpdateAllProperties();
            TraceController.UpdateAllProperties();
            ShaderController.UpdateAllProperties();
        }

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            SceneController.Connect(connect);
            ShaderController.Connect(connect);
            TraceController.Connect(connect);
            if (connect)
            {
                WorldController.PropertyChanged += WorldController_PropertyChanged;
                WorldForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
                WorldForm.ViewProperties.Click += ToggleEditor;
                WorldForm.PopupPropertiesMenu.Opening += PopupPropertiesMenu_Opening;
                WorldForm.PopupPropertiesHide.Click += PopupPropertiesHide_Click;
                WorldForm.PopupPropertiesUndock.Click += PopupPropertiesUndock_Click;
            }
            else
            {
                WorldController.PropertyChanged -= WorldController_PropertyChanged;
                WorldForm.ViewMenu.DropDownOpening -= ViewMenu_DropDownOpening;
                WorldForm.ViewProperties.Click -= ToggleEditor;
                WorldForm.PopupPropertiesMenu.Opening -= PopupPropertiesMenu_Opening;
                WorldForm.PopupPropertiesHide.Click -= PopupPropertiesHide_Click;
                WorldForm.PopupPropertiesUndock.Click -= PopupPropertiesUndock_Click;
            }
        }

        internal void InitViewProperties() => WorldForm.ViewProperties.Checked = EditorVisible;

        protected override void Collapse(bool collapse) => WorldForm.SplitContainer1.Panel2Collapsed = collapse;

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            TraceController?.Dispose();
        }

        private void PopupPropertiesHide_Click(object sender, EventArgs e) => EditorVisible = false;

        private void PopupPropertiesMenu_Opening(object sender, CancelEventArgs e) => Localize(
            EditorDocked ? Resources.Menu_Host_Undock : Resources.Menu_Host_Dock,
            WorldForm.PopupPropertiesUndock);

        private void PopupPropertiesUndock_Click(object sender, EventArgs e) => EditorDocked = !EditorDocked;

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) => InitViewProperties();

        private void WorldController_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case PropertyNames.GraphicsMode:
                    PropertiesEdit.GpuEdit.lblGpuMode.Text = WorldController.GraphicsMode.ToString();
                    break;
                case PropertyNames.GPUStatus:
                    PropertiesEdit.GpuEdit.lblGpuStatus.Text = Scene.GPUStatus.ToString();
                    break;
                case PropertyNames.GPULog:
                    PropertiesEdit.GpuEdit.lblGpuLog.Text = Scene.GPULog;
                    break;
            }
        }
    }
}
