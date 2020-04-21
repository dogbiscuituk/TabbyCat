namespace TabbyCat.Controllers
{
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    internal abstract class CodeBasePropertiesCon : DockingCon
    {
        internal CodeBasePropertiesCon(WorldCon worldCon) : base(worldCon) { }

        protected bool Updating;

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                UpdateAllProperties();
                WorldCon.PropertyChanged += WorldCon_PropertyChanged;
                WorldCon.SelectionChanged += WorldCon_SelectionChanged;
            }
            else
            {
                WorldCon.PropertyChanged -= WorldCon_PropertyChanged;
                WorldCon.SelectionChanged -= WorldCon_SelectionChanged;
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

        protected virtual void OnSelectionChanged() { }

        protected void SetToolTip(Control control, string toolTip)
        {
            if (ToolTip.GetToolTip(control) != toolTip)
                ToolTip.SetToolTip(control, toolTip);
        }

        private void WorldCon_PropertyChanged(object sender, PropertyChangedEventArgs e) => UpdateProperties(e.PropertyName);

        private void WorldCon_SelectionChanged(object sender, System.EventArgs e) => OnSelectionChanged();
    }
}
