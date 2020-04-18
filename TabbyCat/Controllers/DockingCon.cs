namespace TabbyCat.Controllers
{
    using WeifenLuo.WinFormsUI.Docking;

    internal abstract class DockingCon : LocalizationCon
    {
        internal DockingCon(WorldCon worldCon) : base(worldCon) { }

        protected internal abstract DockContent Form { get; }
    }
}
