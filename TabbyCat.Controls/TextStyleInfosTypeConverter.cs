namespace TabbyCat.Controls
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    public class TextStyleInfosTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            value is string s ? TextStyleInfos.Parse(s) : base.ConvertFrom(context, culture, value);

        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(TextStyleInfos), attributes).Sort(new[]
            {
                "Comments",
                "Directives",
                "Functions",
                "Keywords",
                "Numbers",
                "ReservedWords",
                "Strings",
            });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
