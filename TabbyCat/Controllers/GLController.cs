namespace TabbyCat.Controllers
{
    using TabbyCat.Views;

    internal class GLController : LocalizationController
    {
        internal GLController(WorldController worldController) : base(worldController) { }

        private GLControlForm _GLControlForm;

        protected override GLControlForm GLControlForm => _GLControlForm ?? (_GLControlForm = new GLControlForm());
    }
}
