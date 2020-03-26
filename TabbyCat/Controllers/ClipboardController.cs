namespace TabbyCat.Controllers
{
    internal class ClipboardController
    {
        #region Constructors

        internal ClipboardController(WorldController worldController) => WorldController = worldController;

        #endregion

        #region Fields, Properties, Events

        private readonly WorldController WorldController;

        #endregion

        #region Internal Methods

        internal void Copy()
        {
            var foo = WorldController.Selection;
        }

        #endregion
    }
}
