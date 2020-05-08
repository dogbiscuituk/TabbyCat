namespace TabbyCat.Controllers
{
    using System;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    public class HotkeysCon : DockingCon
    {
        // Constructors

        public HotkeysCon(WorldCon worldCon) : base(worldCon) { }

        // Private fields

        private HotkeysForm _HotkeysForm;

        // Public properties

        public override DockContent Form => HotkeysForm;

        // Protected properties

        protected override HotkeysForm HotkeysForm => _HotkeysForm ?? (_HotkeysForm = new HotkeysForm());

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.HelpCodeEditorKeys.Click += HelpCodeEditorKeys_Click;
            }
            else
            {
                WorldForm.HelpCodeEditorKeys.Click -= HelpCodeEditorKeys_Click;
            }
        }

        private void HelpCodeEditorKeys_Click(object sender, EventArgs e) => ToggleVisibility();
    }
}
