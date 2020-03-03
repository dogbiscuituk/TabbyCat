namespace TabbyCat.Common.TypeConverters
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using TabbyCat.Common.Types;

    public class ColourFormatTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            value is string s ? ColourFormat.Parse(s) : base.ConvertFrom(context, culture, value);

        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(ColourFormat), attributes)
                .Sort(new string[] { "Red", "Green", "Blue", "Alpha" });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
