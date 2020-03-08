namespace TabbyCat.Controllers
{
    using System.ComponentModel;
    using TabbyCat.Models;
    using TabbyCatControls;

    internal class TraceEditController : CodeEditController
    {
        #region Constructors

        internal TraceEditController(PropertyController propertyController)
            : base(propertyController) => InitControls(Editor.TableLayoutPanel);

        #endregion

        #region Fields & Properties

        private TraceEdit Editor => PropertyEditor.TraceEdit;
        private ITrace Selection => SceneController.Selection;

        #endregion

        #region Protected Methods

        protected override void Connect()
        {
            SceneController.PropertyChanged += SceneController_PropertyChanged;
            SceneController.SelectionChanged += SceneController_SelectionChanged;
        }

        protected override void Disconnect()
        {
            SceneController.PropertyChanged -= SceneController_PropertyChanged;
            SceneController.SelectionChanged -= SceneController_SelectionChanged;
        }

        #endregion

        #region Private Event Handlers

        private void SceneController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            UpdateProperties(e.PropertyName);

        private void SceneController_SelectionChanged(object sender, System.EventArgs e) =>
            UpdateSelection();

        #endregion

        #region Private Methods

        private void UpdateProperties(params string[] propertyNames)
        {
        }

        private void UpdateSelection()
        {
        }

        #endregion
    }
}
