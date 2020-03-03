namespace TabbyCat.Controllers
{
    using TabbyCatControls;

    internal class TracePropertyController : CodeSourcePropertyController
    {
        internal TracePropertyController(PropertyController propertyController)
            : base(propertyController)
        { }

        private TracePropertiesControl Editor => PropertyEditor.TracePropertiesControl;

        protected override void Connect()
        {
        }

        protected override void Disconnect()
        {
        }
    }
}
