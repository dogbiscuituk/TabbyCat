namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using TabbyCatControls;

    internal class ScenePropertyController : CodeSourcePropertyController
    {
        internal ScenePropertyController(PropertyController propertyController)
            : base(propertyController)
        { }

        private ScenePropertiesControl Editor => PropertyEditor.ScenePropertiesControl;

        #region Private Event Handlers

        private void EdTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (!Updating)
                Scene.Title = ((Control)sender).Text;
        }

        #endregion

        protected override void Connect()
        {
            Editor.edTitle.TextChanged += EdTitle_TextChanged;
        }

        protected override void Disconnect()
        {
            Editor.edTitle.TextChanged -= EdTitle_TextChanged;
        }
    }
}
