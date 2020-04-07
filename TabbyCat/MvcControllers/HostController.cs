namespace TabbyCat.MvcControllers
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using TabbyCat.MvcViews;

    internal abstract class HostController : LocalizationController
    {
        #region Constructor

        protected HostController(WorldController worldController, string caption)
            : base(worldController) => _Caption = caption;

        #endregion

        #region Protected Internal Properties

        protected internal bool EditorVisible
        {
            get => _EditorVisible;
            set
            {
                if (EditorVisible == value)
                    return;
                _EditorVisible = value;
                UpdateConfiguration();
                Refresh();
            }
        }

        protected internal abstract void Refresh();

        #endregion

        #region Protected Properties

        protected abstract Control Editor { get; }

        protected bool EditorDocked
        {
            get => _EditorDocked;
            set
            {
                if (EditorDocked == value)
                    return;
                _EditorDocked = value;
                UpdateConfiguration();
                FormVisible = EditorVisible && !EditorDocked;
            }
        }

        protected abstract Control EditorParent { get; }

        #endregion

        #region Protected Event Handlers

        protected void PopupEditorFloat_Click(object sender, EventArgs e) =>
            EditorDocked = !EditorDocked;

        protected void PopupEditorHide_Click(object sender, EventArgs e) =>
            EditorVisible = false;

        protected void ToggleEditor(object sender, EventArgs e) =>
            EditorVisible = !EditorVisible;

        #endregion

        #region Protected Methods

        protected abstract void Collapse(bool collapse);

        #endregion

        #region Private Fields

        private readonly string _Caption;
        private bool _EditorDocked = true;
        private bool _EditorVisible = true;
        private HostForm _HostForm;

        #endregion

        #region Private Properties

        private bool FormVisible
        {
            get => HostForm.Visible;
            set
            {
                if (FormVisible == value)
                    return;
                Control
                    From = value ? EditorParent : HostForm,
                    To = value ? HostForm : EditorParent;
                From.Controls.Remove(Editor);
                To.Controls.Add(Editor);
                Editor.BringToFront();
                if (value)
                    HostForm.Show(WorldForm);
                else
                    HostForm.Hide();
            }
        }

        private HostForm HostForm => _HostForm ?? (_HostForm = CreateHostForm());

        #endregion

        #region Private Event Handlers

        private void HostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    EditorVisible = false;
                    HostForm.Hide();
                    goto case CloseReason.FormOwnerClosing;
                case CloseReason.FormOwnerClosing:
                    e.Cancel = true;
                    break;
                case CloseReason.ApplicationExitCall:
                default:
                    HostForm.FormClosing -= HostForm_FormClosing;
                    break;
            }
        }

        #endregion

        #region Private Methods

        private HostForm CreateHostForm()
        {
            var hostForm = new HostForm
            {
                ClientSize = Editor.Size,
                Location = Editor.PointToScreen(new Point()),
                Text = _Caption
            };
            hostForm.FormClosing += HostForm_FormClosing;
            return hostForm;
        }

        private void UpdateConfiguration()
        {
            Collapse(!(EditorDocked && EditorVisible));
            FormVisible = EditorVisible && !EditorDocked;
        }

        #endregion
    }
}
