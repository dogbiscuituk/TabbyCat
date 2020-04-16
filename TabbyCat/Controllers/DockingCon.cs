namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;

    internal abstract class DockingCon : LocalizationCon
    {
        internal DockingCon(WorldCon worldCon) : base(worldCon) { }

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
