namespace TabbyCat.Common.Types
{
    using OpenTK.Graphics;
    using System.ComponentModel;
    using System.Globalization;
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
        public ColourFormat(ColourFormat colourFormat)
        {
            if (colourFormat == null)
                return;
            Red = colourFormat.Red;
            Green = colourFormat.Green;
            Blue = colourFormat.Blue;
            Alpha = colourFormat.Alpha;
        }

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
                case "Red": Red = value; break;
                case "Green": Green = value; break;
                case "Blue": Blue = value; break;
                case "Alpha": Alpha = value; break;
            }
        }

        #endregion

        #region Public Properties

        [DefaultValue(0)]
        [Description(Descriptions.Red)]
        public int Red { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Green)]
        public int Green { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Blue)]
        public int Blue { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Alpha)]
        public int Alpha { get; set; }

        #endregion

        #region Public Operators

        public static bool operator ==(ColourFormat p, ColourFormat q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(ColourFormat p, ColourFormat q) => !(p == q);

        public static implicit operator ColorFormat(ColourFormat p) => p != null
            ? new ColorFormat(p.Red, p.Green, p.Blue, p.Alpha)
            : ColorFormat.Empty;

        public static implicit operator ColourFormat(ColorFormat p) => p != null
            ? new ColourFormat(p.Red, p.Green, p.Blue, p.Alpha)
            : null;

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is ColourFormat f &&
            f.Red == Red && f.Green == Green && f.Blue == Blue && f.Alpha == Alpha;

        public override int GetHashCode() => Red ^ Green ^ Blue ^ Alpha;

        public static ColourFormat Parse(string s)
        {
            if (s == null)
                return null;
            var t = s.Split(',');
            return new ColourFormat(
                int.Parse(t[0], CultureInfo.InvariantCulture),
                int.Parse(t[1], CultureInfo.InvariantCulture),
                int.Parse(t[2], CultureInfo.InvariantCulture),
                int.Parse(t[3], CultureInfo.InvariantCulture));
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

        #endregion
    }
}