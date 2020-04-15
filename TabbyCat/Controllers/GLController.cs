using TabbyCat.Views;

namespace TabbyCat.Controllers
{
    internal class GLController : LocalizationController
    {
        internal GLController(WorldController worldController) : base(worldController)
        {
            GLControlForm = new GLControlForm();
        }

        protected internal override GLControlForm GLControlForm { get; }
    }
}
