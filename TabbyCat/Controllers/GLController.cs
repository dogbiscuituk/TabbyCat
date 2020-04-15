using TabbyCat.Views;

namespace TabbyCat.Controllers
{
    internal class GLController : LocalizationController
    {
        internal GLController(WorldController worldController) : base(worldController)
        {
            GLControlForm = new GLControlForm();
        }

        protected override GLControlForm GLControlForm { get; }
    }
}
