namespace TabbyCat.Controllers
{
    using System.ComponentModel;
    using TabbyCat.Commands;
    using TabbyCat.Controls;
    using TabbyCat.Models;

    internal abstract class CodeEditController
    {
        internal CodeEditController(PropertyController propertyController)
        {
            PropertyController = propertyController;
        }

        private CommandProcessor CommandProcessor => SceneController.CommandProcessor;
        private readonly PropertyController PropertyController;
        protected TabbedEdit PropertyEditor => PropertyController.Editor;
        protected Scene Scene => SceneController.Scene;
        protected SceneController SceneController => PropertyController.SceneController;
        protected bool Updating;

        protected void Run(ICommand command)
        {
            if (Updating)
                return;
            Updating = true;
            CommandProcessor.Run(command);
            Updating = false;
        }

        protected abstract void Connect();
        protected abstract void Disconnect();

        internal void Connect(bool connect)
        {
            if (connect)
                Connect();
            else
                Disconnect();
        }
    }
}
