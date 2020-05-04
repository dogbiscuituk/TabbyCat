namespace TabbyCat.Controllers
{
    using System;
    using System.Windows.Forms;
    using Types;

    internal abstract class PropertiesCon : DockingCon
    {
        internal PropertiesCon(WorldCon worldCon) : base(worldCon) { }

        protected internal override void Connect(bool connect)
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
            {
                ToolTip.SetToolTip(control, toolTip);
            }
        }

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e) => UpdateProperties(e.PropertyName);

        private void WorldCon_SelectionEdit(object sender, EventArgs e) => OnSelectionEdit();
    }
}
