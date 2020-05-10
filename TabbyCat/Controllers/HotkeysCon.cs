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

        private HotkeysForm _hotkeysForm;

        // Protected properties

        protected override DockContent Form => HotkeysForm;

        protected override HotkeysForm HotkeysForm => _hotkeysForm ?? (_hotkeysForm = new HotkeysForm());

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
                WorldForm.HelpCodeHotkeys.Click += HelpCodeEditorKeys_Click;
            else
                WorldForm.HelpCodeHotkeys.Click -= HelpCodeEditorKeys_Click;
        }

        // Private Methods

        private void HelpCodeEditorKeys_Click(object sender, EventArgs e) => ToggleVisibility();
    }
}
