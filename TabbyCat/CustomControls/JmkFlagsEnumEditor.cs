namespace TabbyCat.CustomControls
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Globalization;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    public sealed partial class JmkFlagsEnumEditor : UITypeEditor
    {
        // Constructors

        public JmkFlagsEnumEditor() => _listBox = new JmkFlagsCheckedListBox { BorderStyle = BorderStyle.None };

        // Private fields

        private readonly JmkFlagsCheckedListBox _listBox;

        // Public methods

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context?.Instance == null || provider == null)
                return null;
            var service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (service == null)
                return null;
            if (context.PropertyDescriptor != null)
                _listBox.EnumValue = (Enum)Convert.ChangeType(value, context.PropertyDescriptor.PropertyType,
                    CultureInfo.InvariantCulture);
            service.DropDownControl(_listBox);
            return _listBox.EnumValue;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.DropDown;
    }

    public partial class JmkFlagsEnumEditor : IDisposable
    {
        private bool _disposed;

        public void Dispose() => Dispose(true);

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _listBox?.Dispose();
            _disposed = true;
        }
    }
}
