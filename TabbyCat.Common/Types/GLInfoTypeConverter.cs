namespace TabbyCat.Common.Types
{
    using System;
    using System.ComponentModel;

    public class GLInfoTypeConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(GLInfo), attributes)
                .Sort(new string[] { "Number", "Major", "Minor", "Shader", "Vendor", "Renderer" });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
