namespace TabbyCat.Types
{
    using Converters;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(TextStyleInfosTypeConverter))]
    public class TextStyleInfos
    {
        [Description("The text style used to highlight comments in the GPU code.")]
        [DisplayName("Comments")]
        public TextStyleInfo Comments { get; set; } = new TextStyleInfo(Color.Green);

        [Description("The text style used to highlight preprocessor directives in the GPU code.")]
        [DisplayName("Preprocessor Directives")]
        public TextStyleInfo Directives { get; set; } = new TextStyleInfo(Color.Maroon);

        [Description("The text style used to highlight built-in functions in the GPU code.")]
        [DisplayName("Built-in Functions")]
        public TextStyleInfo Functions { get; set; } = new TextStyleInfo(Color.DarkTurquoise);

        [Description("The text style used to highlight GLSL keywords in the GPU code.")]
        [DisplayName("GLSL Keywords")]
        public TextStyleInfo Keywords { get; set; } = new TextStyleInfo(Color.Blue);

        [Description("The text style used to highlight numeric literals in the GPU code.")]
        [DisplayName("Numeric Literals")]
        public TextStyleInfo Numbers { get; set; } = new TextStyleInfo(Color.Magenta);

        [Description("The text style used to indicate sections of the GPU code which are not user-editable.")]
        [DisplayName("Read Only")]
        public TextStyleInfo ReadOnly { get; set; } = new TextStyleInfo(Color.Gray, FontStyle.Italic);

        [Description("The text style used to highlight words in the GPU code which are reserved for future expansion.")]
        [DisplayName("Reserved Words")]
        public TextStyleInfo ReservedWords { get; set; } = new TextStyleInfo(Color.Red);

        [Description("The text style used to highlight string literals in the GPU code.")]
        [DisplayName("String Literals")]
        public TextStyleInfo Strings { get; set; } = new TextStyleInfo(Color.Brown);

        public static TextStyleInfos Parse(string s)
        {
            if (s == null)
            {
                return new TextStyleInfos();
            }

            var t = s.Split(':');
            return new TextStyleInfos
            {
                Comments = TextStyleInfo.Parse(t[0]),
                Directives = TextStyleInfo.Parse(t[1]),
                Functions = TextStyleInfo.Parse(t[2]),
                Keywords = TextStyleInfo.Parse(t[3]),
                Numbers = TextStyleInfo.Parse(t[4]),
                ReadOnly = TextStyleInfo.Parse(t[5]),
                ReservedWords = TextStyleInfo.Parse(t[6]),
                Strings = TextStyleInfo.Parse(t[7])
            };
        }

        public override string ToString() => $"{Comments}:{Directives}:{Functions}:{Keywords}:{Numbers}:{ReadOnly}:{ReservedWords}:{Strings}";
    }
}
