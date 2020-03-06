namespace TabbyCat.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    public class FlagsEnumEditor : UITypeEditor
    {
        #region Constructors

        public FlagsEnumEditor()
        {
            FlagsCheckedListBox = new FlagsCheckedListBox
            {
                BorderStyle = BorderStyle.None
            };
        }

        #endregion

        #region Public Methods

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                var service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (service != null)
                {
                    FlagsCheckedListBox.EnumValue = (Enum)Convert.ChangeType(value, context.PropertyDescriptor.PropertyType);
                    service.DropDownControl(FlagsCheckedListBox);
                    return FlagsCheckedListBox.EnumValue;
                }
            }
            return null;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.DropDown;

        #endregion

        #region Private Properties

        private readonly FlagsCheckedListBox FlagsCheckedListBox;

        #endregion
    }
}
