namespace TabbyCat.MvcModels
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    public class GLModeTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            value is string s ? GLMode.Parse(s) : base.ConvertFrom(context, culture, value);

        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(GLMode), attributes).Sort(new[]
            {
                "Index",
                "ColourFormat",
                "AccumColourFormat",
                "Buffers",
                "Depth",
                "Samples",
                "Stencil",
                "Stereo"
            });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
