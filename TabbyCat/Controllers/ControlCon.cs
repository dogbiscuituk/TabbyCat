namespace TabbyCat.Controllers
{
    using Properties;
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class ControlCon : DockingCon
    {
        internal ControlCon(WorldCon worldCon) : base(worldCon) { }

        private ControlForm _ControlForm;

        protected internal override DockContent Form => ControlForm;

        protected override ControlForm ControlForm => _ControlForm ?? (_ControlForm = new ControlForm
        {
            TabText = Resources.ControlForm_TabText,
            Text = Resources.ControlForm_Text,
            ToolTipText = Resources.ControlForm_Text
        });

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
            }
            else
            {
            }
        }
    }
}
