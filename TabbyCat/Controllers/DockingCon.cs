namespace TabbyCat.Controllers
{
    using WeifenLuo.WinFormsUI.Docking;

    public abstract class DockingCon : LocalizationCon
    {
        // Constructors

        protected DockingCon(WorldCon worldCon) : base(worldCon) { }

        // Protected properties

        protected abstract DockContent Form { get; }

        // Public methods

        public void SetVisibility(bool visible)
        {
            if (visible)
                Form.Activate();
            else
                Form.Hide();
        }

        // Protected methods

        protected void ToggleVisibility() => SetVisibility(!Form.Visible);
    }
}
