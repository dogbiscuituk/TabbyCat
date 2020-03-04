namespace TabbyCat.Controllers
{
    using TabbyCat.Commands;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class CodeSourcePropertyController
    {
        internal CodeSourcePropertyController(PropertyController propertyController)
        {
            PropertyController = propertyController;
        }

        private CommandProcessor CommandProcessor => SceneController.CommandProcessor;
        private readonly PropertyController PropertyController;
        protected PropertyEditor PropertyEditor => PropertyController.Editor;
        protected Scene Scene => SceneController.Scene;
        protected SceneController SceneController => PropertyController.SceneController;
        protected bool Updating;

        protected void Run(ICommand command) => CommandProcessor.Run(command);

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
