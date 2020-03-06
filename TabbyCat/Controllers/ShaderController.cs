namespace TabbyCat.Controllers
{
    using TabbyCat.Controls;

    internal class ShaderController
    {
        #region Constructors

        internal ShaderController(PropertyController propertyController)
        {
            PropertyController = propertyController;
            Editor.btnExportHTML.Click += BtnExportHTML_Click;
        }

        private void BtnExportHTML_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Fields & Properties

        private ShaderEdit Editor => PropertyEditor.ShaderEdit;
        private readonly PropertyController PropertyController;
        private TabbedEdit PropertyEditor => PropertyController.Editor;

        #endregion

        #region Private Methods

        internal void Connect(bool connect)
        {
            if (connect)
            {

            }
            else
            {

            }
        }

        #endregion
    }
}
