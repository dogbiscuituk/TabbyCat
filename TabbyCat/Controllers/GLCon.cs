namespace TabbyCat.Controllers
{
    using TabbyCat.Views;

    internal class GLCon : LocalizationCon
    {
        internal GLCon(WorldCon worldCon) : base(worldCon) { }

        private GLControlForm _GLControlForm;

        protected override GLControlForm GLControlForm => _GLControlForm ?? (_GLControlForm = new GLControlForm());
    }
}
