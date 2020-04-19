namespace TabbyCat.Controllers
{
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class SceneCon : DockingCon
    {
        internal SceneCon(WorldCon worldCon) : base(worldCon) { }

        private SceneForm _SceneForm;

        protected internal override DockContent Form => SceneForm;

        protected override SceneForm SceneForm => _SceneForm ?? (_SceneForm = new SceneForm());
    }
}
