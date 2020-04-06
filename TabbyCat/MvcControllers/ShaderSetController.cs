namespace TabbyCat.MvcControllers
{
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Controls;
    using TabbyCat.MvcModels;

    internal abstract class ShaderSetController : LocalizationController
    {
        #region Constructors

        internal ShaderSetController(WorldController worldController)
            : base(worldController) { }

        #endregion

        #region Fields & Properties

        protected abstract string[] AllProperties { get; }
        protected CommandProcessor CommandProcessor => WorldCon.CommandProcessor;
        protected Scene Scene => WorldCon.Scene;
        internal ToolTip ToolTip => PropertiesController.ToolTip;
        protected bool Updating;
        protected PropertiesEdit WorldEdit => PropertiesController.PropertiesEdit;

        #endregion

        #region Protected Internal Methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                UpdateAllProperties();
                WorldCon.PropertyChanged += WorldController_PropertyChanged;
                WorldCon.SelectionChanged += WorldController_SelectionChanged;
            }
            else
            {
                WorldCon.PropertyChanged -= WorldController_PropertyChanged;
                WorldCon.SelectionChanged -= WorldController_SelectionChanged;
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
