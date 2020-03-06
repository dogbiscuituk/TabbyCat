namespace TabbyCat.Controllers
{
    using TabbyCatControls;

    internal class TraceEditController : CodeEditController
    {
        internal TraceEditController(PropertyController propertyController)
            : base(propertyController) => InitControls(Editor.TableLayoutPanel);

        private TraceEdit Editor => PropertyEditor.TraceEdit;

        protected override void Connect()
        {
        }

        protected override void Disconnect()
        {
        }
    }
}
