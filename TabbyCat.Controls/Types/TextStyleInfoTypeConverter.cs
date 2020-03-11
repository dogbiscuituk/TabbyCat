namespace TabbyCat.Controls.Types
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    public class TextStyleInfoTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            value is string s ? TextStyleInfo.Parse(s) : base.ConvertFrom(context, culture, value);

        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(TextStyleInfo), attributes).Sort(new[]
            {
                "Foreground",
                "Background",
                "TextFormat",
            });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
