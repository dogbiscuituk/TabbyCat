namespace TabbyCat.Controllers
{
    using Common.Types;
    using System;
    using System.Linq;
    using System.Windows.Forms;

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

        protected void InitCommonControls(Control control)
        {
            foreach (var spinEdit in control.Controls.OfType<NumericUpDown>())
            {
                spinEdit.Minimum = decimal.MinValue;
                spinEdit.Maximum = decimal.MaxValue;
            }
        }

        protected virtual void OnSelectionEdit() { }

        protected void SetToolTip(Control control, string toolTip)
        {
            if (ToolTip.GetToolTip(control) != toolTip)
                ToolTip.SetToolTip(control, toolTip);
        }

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e) => UpdateProperties(e.PropertyName);

        private void WorldCon_SelectionEdit(object sender, EventArgs e) => OnSelectionEdit();
    }
}
