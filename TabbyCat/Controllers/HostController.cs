namespace TabbyCat.Controllers
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using TabbyCat.Views;

    internal abstract class HostController : LocalizationController
    {
        protected HostController(WorldController worldController, string caption)
            : base(worldController) => _Caption = caption;

        private readonly string _Caption;

        private bool
            _EditorDocked = true,
            _EditorVisible = true;

        private HostForm _HostForm;

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

        protected internal bool EditorVisible
        {
            get => _EditorVisible;
            set
            {
                if (EditorVisible == value)
                    return;
                _EditorVisible = value;
                UpdateConfiguration();
            }
        }

        protected abstract Control EditorParent { get; }

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

        protected void PopupEditorFloat_Click(object sender, EventArgs e) =>
            EditorDocked = !EditorDocked;

        protected void PopupEditorHide_Click(object sender, EventArgs e) =>
            EditorVisible = false;

        protected void ToggleEditor(object sender, EventArgs e) =>
            EditorVisible = !EditorVisible;

        protected abstract void Collapse(bool collapse);

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

        private HostForm CreateHostForm()
        {
            var hostForm = new HostForm
            {
                ClientSize = Editor.Size,
                Location = Editor.PointToScreen(Point.Empty),
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
    }
}
