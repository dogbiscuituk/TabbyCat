namespace Jmk.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Globalization;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    public partial class JmkFlagsEnumEditor : UITypeEditor
    {
        public JmkFlagsEnumEditor()
        {
            FlagsCheckedListBox = new JmkFlagsCheckedListBox
            {
                BorderStyle = BorderStyle.None
            };
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                var service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (service != null)
                {
                    FlagsCheckedListBox.EnumValue = (Enum)Convert.ChangeType(
                        value, context.PropertyDescriptor.PropertyType, CultureInfo.InvariantCulture);
                    service.DropDownControl(FlagsCheckedListBox);
                    return FlagsCheckedListBox.EnumValue;
                }
            }
            return null;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.DropDown;

        private readonly JmkFlagsCheckedListBox FlagsCheckedListBox;
    }

    partial class JmkFlagsEnumEditor : IDisposable
    {
        private bool Disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    FlagsCheckedListBox?.Dispose();
                }
                Disposed = true;
            }
        }
    }
}
