﻿namespace TabbyCat.Controllers
{
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    internal abstract class ShaderSetController : LocalizationController
    {
        internal ShaderSetController(WorldController worldController)
            : base(worldController)
        { }

        protected bool Updating;

        protected abstract string[] AllProperties { get; }

        internal ToolTip ToolTip => WorldController.ToolTip;

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                UpdateAllProperties();
                WorldController.PropertyChanged += WorldController_PropertyChanged;
                WorldController.SelectionChanged += WorldController_SelectionChanged;
            }
            else
            {
                WorldController.PropertyChanged -= WorldController_PropertyChanged;
                WorldController.SelectionChanged -= WorldController_SelectionChanged;
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

        protected virtual void UpdateAllProperties() => UpdateProperties(AllProperties);

        protected abstract void UpdateProperties(params string[] propertyNames);

        private void WorldController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            UpdateProperties(e.PropertyName);

        private void WorldController_SelectionChanged(object sender, System.EventArgs e) =>
            OnSelectionChanged();
    }
}
