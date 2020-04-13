namespace TabbyCat.Controls.Types
{
    using Jmk.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;

    [TypeConverter(typeof(TextStyleInfoTypeConverter))]
    public class TextStyleInfo
    {
        public TextStyleInfo(Color foreground, FontStyle fontStyle = 0) : this(foreground, Color.Transparent, fontStyle) { }

        public TextStyleInfo(Color foreground, Color background, FontStyle fontStyle = 0)
        {
            Foreground = foreground;
            Background = background;
            FontStyle = fontStyle;
        }

        [Description("The foreground colour of the text style.")]
        [DisplayName("Foreground Colour")]
        public Color Foreground { get; set; }

        [DefaultValue(typeof(Color), "Transparent")]
        [Description("The background colour of the text style.")]
        [DisplayName("Background Colour")]
        public Color Background { get; set; }

        [DefaultValue(0)]
        [Description("The font attributes of the text style (bold, italic, etc).")]
        [DisplayName("Font Attributes")]
        [Editor(typeof(JmkFlagsEnumEditor), typeof(UITypeEditor))]
        public FontStyle FontStyle { get; set; }

        public static TextStyleInfo Parse(string s)
        {
            if (s == null)
                return null;
            var t = s.Split(';');
            return new TextStyleInfo(
                Color.FromName(t[0]),
                Color.FromName(t[1]),
                (FontStyle)Enum.Parse(typeof(FontStyle), t[2]));
        }

        public override string ToString() => $"{Foreground.Name}; {Background.Name}; {FontStyle}";
    }
}
