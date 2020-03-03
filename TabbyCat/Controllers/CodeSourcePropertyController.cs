namespace TabbyCat.Controllers
{
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class CodeSourcePropertyController
    {
        internal CodeSourcePropertyController(PropertyController propertyController)
        {
            PropertyController = propertyController;
        }

        private readonly PropertyController PropertyController;
        protected PropertyEditor PropertyEditor => PropertyController.Editor;
        protected Scene Scene => SceneController.Scene;
        private SceneController SceneController => PropertyController.SceneController;
        protected bool Updating;

        protected virtual void Connect()
        {

        }

        protected virtual void Disconnect()
        {

        }

        internal void Connect(bool connect)
        {
            if (connect)
                Connect();
            else
                Disconnect();
        }
    }
}
