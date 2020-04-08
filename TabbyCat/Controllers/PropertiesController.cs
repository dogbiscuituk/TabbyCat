namespace TabbyCat.Controllers
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controls;
    using TabbyCat.Views;
    using TabbyCat.Properties;

    internal class PropertiesController : HostController, IDisposable
    {
        #region Constructors

        internal PropertiesController(WorldController worldController)
            : base(worldController, Resources.Text_Properties)
        { }

        #endregion

        #region Fields & Properties

        internal ToolTip ToolTip => WorldController.ToolTip;

        protected override Control Editor => PropertiesEdit;
        protected override Control EditorParent => WorldForm.SplitContainer1.Panel2;

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

        private void PopupPropertiesHide_Click(object sender, EventArgs e) =>
            EditorVisible = false;

        private void PopupPropertiesMenu_Opening(object sender, CancelEventArgs e) =>
            Localize(EditorDocked ? Resources.Menu_Host_Undock : Resources.Menu_Host_Dock,
                WorldForm.PopupPropertiesUndock);

        private void PopupPropertiesUndock_Click(object sender, EventArgs e) =>
            EditorDocked = !EditorDocked;

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) =>
            WorldForm.ViewProperties.Checked = EditorVisible;

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

        #endregion

        #region Private Methods

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

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    TraceController?.Dispose();
                }
                disposed = true;
            }
        }

        private bool disposed;

        #endregion
    }
}
