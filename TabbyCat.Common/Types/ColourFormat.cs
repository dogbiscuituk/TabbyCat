namespace TabbyCat.Common.Types
{
    using OpenTK.Graphics;
    using System.ComponentModel;
    using TabbyCat.Common.TypeConverters;

    [TypeConverter(typeof(ColourFormatTypeConverter))]
    public class ColourFormat
    {
        #region Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public ColourFormat() : this(0) { }

        /// <summary>
        /// Uniform Constructor.
        /// </summary>
        /// <param name="bpp"></param>
        public ColourFormat(int bpp) : this(bpp, bpp, bpp, bpp) { }

        /// <summary>
        /// General Constructor
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        public ColourFormat(int red, int green, int blue, int alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        /// <summary>
        /// Copy Constructor.
        /// </summary>
        /// <param name="colourFormat"></param>
        public ColourFormat(ColourFormat colourFormat) :
            this(colourFormat.Red, colourFormat.Green, colourFormat.Blue, colourFormat.Alpha)
        { }

        /// <summary>
        /// Copy & Modify Constructor.
        /// </summary>
        /// <param name="colourFormat"></param>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        public ColourFormat(ColourFormat colourFormat, string fieldName, int value) :
            this(colourFormat)
        {
            switch (fieldName)
            {
                case DisplayNames.Red: Red = value; break;
                case DisplayNames.Green: Green = value; break;
                case DisplayNames.Blue: Blue = value; break;
                case DisplayNames.Alpha: Alpha = value; break;
            }
        }

        #endregion

        #region Public Properties

        [DefaultValue(0)]
        [Description(Descriptions.Red)]
        [DisplayName(DisplayNames.Red)]
        public int Red { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Green)]
        [DisplayName(DisplayNames.Green)]
        public int Green { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Blue)]
        [DisplayName(DisplayNames.Blue)]
        public int Blue { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Alpha)]
        [DisplayName(DisplayNames.Alpha)]
        public int Alpha { get; set; }

        #endregion

        #region Public Operators

        public static bool operator ==(ColourFormat p, ColourFormat q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(ColourFormat p, ColourFormat q) => !(p == q);

        public static implicit operator ColorFormat(ColourFormat p) => new ColorFormat(p.Red, p.Green, p.Blue, p.Alpha);
        public static implicit operator ColourFormat(ColorFormat p) => new ColourFormat(p.Red, p.Green, p.Blue, p.Alpha);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is ColourFormat f &&
            f.Red == Red && f.Green == Green && f.Blue == Blue && f.Alpha == Alpha;

        public override int GetHashCode() => Red ^ Green ^ Blue ^ Alpha;

        public static ColourFormat Parse(string s)
        {
            var t = s.Split(',');
            return new ColourFormat(int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]), int.Parse(t[3]));
        }

        public override string ToString() => $"{Red}, {Green}, {Blue}, {Alpha}";

        #endregion

        #region Nested Classes

        private static class Descriptions
        {
            internal const string
                Red = "The Red component of the colour format.",
                Green = "The Green component of the colour format.",
                Blue = "The Blue component of the colour format.",
                Alpha = "The Alpha component of the colour format.";
        }

        public static class DisplayNames
        {
            public const string
                Red = "Red",
                Green = "Green",
                Blue = "Blue",
                Alpha = "Alpha";
        }

        #endregion
    }
}