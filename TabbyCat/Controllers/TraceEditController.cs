namespace TabbyCat.Controllers
{
    using TabbyCatControls;

    internal class TraceEditController : CodeEditController
    {
        internal TraceEditController(PropertyController propertyController)
            : base(propertyController) => InitControls(Editor.TableLayoutPanel);

        private TracePropertiesControl Editor => PropertyEditor.TracePropertiesControl;

        protected override void Connect()
        {
        }

        protected override void Disconnect()
        {
        }
    }
}
