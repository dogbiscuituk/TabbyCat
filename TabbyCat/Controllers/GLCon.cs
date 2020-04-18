namespace TabbyCat.Controllers
{
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class GLCon : DockingCon
    {
        internal GLCon(WorldCon worldCon) : base(worldCon) { }

        private GLControlForm _GLControlForm;

        protected internal override DockContent Form => GLControlForm;

        protected override GLControlForm GLControlForm => _GLControlForm ?? (_GLControlForm = new GLControlForm());
    }
}
