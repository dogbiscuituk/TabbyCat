namespace TabbyCat.Controllers
{
    using System;
    using System.Windows.Forms;
    using Types;

    public abstract class PropertiesCon : DockingCon
    {
        public PropertiesCon(WorldCon worldCon) : base(worldCon) { }

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

        protected virtual void OnSelectionEdit() { }

        protected void SetToolTip(Control control, string toolTip)
        {
            if (ToolTip.GetToolTip(control) != toolTip)
                ToolTip.SetToolTip(control, toolTip);
        }

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e) => UpdateProperties(e.Property);

        private void WorldCon_SelectionEdit(object sender, EventArgs e) => OnSelectionEdit();
    }
}
