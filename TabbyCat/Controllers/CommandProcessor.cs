namespace TabbyCat.Controllers
{
    internal class CommandProcessor
    {
        private SceneController _SceneController;

        internal CommandProcessor(SceneController sceneController)
        {
            _SceneController = sceneController;
        }

        internal void Clear() { }
    }
}
