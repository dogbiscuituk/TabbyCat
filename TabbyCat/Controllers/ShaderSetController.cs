namespace TabbyCat.Controllers
{
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

        protected CommandProcessor CommandProcessor => WorldController.CommandProcessor;
        private readonly PropertiesController PropertiesController;
        protected Scene Scene => WorldController.Scene;
        internal ToolTip ToolTip => PropertiesController.ToolTip;
        protected bool Updating;
        protected WorldController WorldController => PropertiesController.WorldController;
        protected WorldEdit WorldEdit => PropertiesController.WorldEdit;

        #endregion

        #region Internal Methods

        protected internal abstract void Connect(bool connect);

        #endregion

        #region Protected Methods

        protected void SetToolTip(Control control, string toolTip) =>
            ToolTip.SetToolTip(control, toolTip);

        protected void InitCommonControls(Control control)
        {
            foreach (var spinEdit in control.Controls.OfType<NumericUpDown>())
            {
                spinEdit.Minimum = decimal.MinValue;
                spinEdit.Maximum = decimal.MaxValue;
            }
        }

        #endregion
    }
}
