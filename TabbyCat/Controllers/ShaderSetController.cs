namespace TabbyCat.Controllers
{
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Controls;
    using TabbyCat.Models;

    internal abstract class ShaderSetController
    {
        #region Constructors

        internal ShaderSetController(PropertiesController propertiesController) =>
            PropertiesController = propertiesController;

        #endregion

        #region Fields & Properties

        protected abstract string[] AllProperties { get; }
        protected CommandProcessor CommandProcessor => WorldController.CommandProcessor;
        private readonly PropertiesController PropertiesController;
        protected Scene Scene => WorldController.Scene;
        internal ToolTip ToolTip => PropertiesController.ToolTip;
        protected bool Updating;
        protected WorldController WorldController => PropertiesController.WorldController;
        protected PropertiesEdit WorldEdit => PropertiesController.PropertiesEdit;

        #endregion

        #region Protected Internal Methods

        protected internal virtual void Connect(bool connect)
        {
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

        #endregion

        #region Protected Methods

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

        #endregion

        #region Private Event Handlers

        private void WorldController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            UpdateProperties(e.PropertyName);

        private void WorldController_SelectionChanged(object sender, System.EventArgs e) =>
            OnSelectionChanged();

        #endregion
    }
}
