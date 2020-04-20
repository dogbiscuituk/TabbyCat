namespace TabbyCat.Controllers
{
    using System;
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class SceneCon : DockingCon
    {
        internal SceneCon(WorldCon worldCon) : base(worldCon) { }

        private int CurrencyCount;

        private SceneForm _SceneForm;

        protected internal override DockContent Form => SceneForm;

        protected override SceneForm SceneForm => _SceneForm ?? (_SceneForm = new SceneForm());

        internal void Do(Action action)
        {
            if (SceneControl?.IsHandleCreated == true &&
                SceneControl?.HasValidContext == true &&
                SceneControl?.Visible == true)
            {
                if (++CurrencyCount == 1)
                    SceneControl.MakeCurrent();
                try
                {
                    action();
                }
                finally
                {
                    if (--CurrencyCount == 0)
                        SceneControl.Context.MakeCurrent(null);
                }
            }
        }
    }
}
