namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;

    internal abstract class DockingController : LocalizationController
    {
        internal DockingController(WorldController worldController) : base(worldController) { }

        protected internal abstract DockContent Form { get; }

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
