namespace TabbyCat.Controllers
{
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Controls;
    using TabbyCat.Models;

    internal abstract class CodeEditController
    {
        #region Constructors

        internal CodeEditController(PropertiesController propertiesController) =>
            PropertiesController = propertiesController;

        #endregion

        #region Fields & Properties

        protected CommandProcessor CommandProcessor => SceneController.CommandProcessor;
        private readonly PropertiesController PropertiesController;
        protected TabbedEdit PropertiesEditor => PropertiesController.TabbedEdit;
        protected Scene Scene => SceneController.Scene;
        protected SceneController SceneController => PropertiesController.SceneController;
        protected bool Updating;

        #endregion

        #region Internal Methods

        internal void Connect(bool connect)
        {
            if (connect)
                Connect();
            else
                Disconnect();
        }

        #endregion

        #region Protected Methods

        protected abstract void Connect();
        protected abstract void Disconnect();

        protected void InitControls(TableLayoutPanel tableLayoutPanel)
        {
            foreach (var spinEdit in tableLayoutPanel.Controls.OfType<NumericUpDown>())
            {
                spinEdit.Minimum = decimal.MinValue;
                spinEdit.Maximum = decimal.MaxValue;
            }
        }

        #endregion
    }
}
