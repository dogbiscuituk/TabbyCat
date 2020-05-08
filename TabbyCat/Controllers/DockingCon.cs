namespace TabbyCat.Controllers
{
    using WeifenLuo.WinFormsUI.Docking;

    public abstract class DockingCon : LocalizationCon
    {
        public DockingCon(WorldCon worldCon) : base(worldCon) { }

        public abstract DockContent Form { get; }

        public void SetVisibility(bool visible)
        {
            if (visible)
                Form.Activate();
            else
                Form.Hide();
        }

        protected void ToggleVisibility() => SetVisibility(!Form.Visible);
    }
}
