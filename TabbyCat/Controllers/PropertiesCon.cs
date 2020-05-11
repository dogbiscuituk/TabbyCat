namespace TabbyCat.Controllers
{
    using System;
    using Types;

    public abstract class PropertiesCon : DockingCon
    {
        // Constructors

        protected PropertiesCon(WorldCon worldCon) : base(worldCon) { }

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldCon.PropertyEdit += WorldCon_PropertyEdit;
                WorldCon.SelectionChanged += WorldCon_SelectionEdit;
            }
            else
            {
                WorldCon.PropertyEdit -= WorldCon_PropertyEdit;
                WorldCon.SelectionChanged -= WorldCon_SelectionEdit;
            }
        }

        // Protected methods

        protected virtual void OnSelectionEdit() { }

        // Private methods

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e) => UpdateProperty(e.Property);

        private void WorldCon_SelectionEdit(object sender, EventArgs e) => OnSelectionEdit();
    }
}
