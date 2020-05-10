namespace TabbyCat.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Types;

    public static class ColourUtils
    {
        // Private fields

        // TODO: When finalized, dispose any SolidBrush in this dictionary whose Stock property is false.
        // The Stock flag indicates whether the associated SolidBrush is retrieved from the standard colour Brushes.
        // If not, then it was created here, and we are ultimately responsible for its disposal.
        private static readonly Dictionary<Color, (SolidBrush SolidBrush, bool Stock)> SolidBrushInfos = new Dictionary<Color, (SolidBrush, bool)>();

        private static readonly Dictionary<string, Func<Color, float>> ColourOrders = new Dictionary<string, Func<Color, float>>
        {
            { "Alpha", c => c.A },
            { "Red", c => c.R },
            { "Green", c=> c.G },
            { "Blue", c => c.B },
            { "Hue", c => c.GetHue() },
            { "Saturation", c => c.GetSaturation() },
            { "Brightness", c => c.GetBrightness() }
        };

        // Public methods

        public static Color Contrast(this Color colour) => colour.IsBright() ? Color.Black : Color.White;

        public static void DrawText(DrawItemEventArgs e, Color foreground, Color background, string text)
        {
            if (e == null)
                return;
            var g = e.Graphics;
            var r = e.Bounds;
            g.SetOptimization(Optimization.HighQuality);
            background.WithSolidBrush(brush => g.FillRectangle(brush, r));
            foreground.WithSolidBrush(brush => g.DrawString(text, e.Font, brush, r.X + 1, r.Y - 2));
        }

        public static Color GetColour(this GPUStatus status)
        {
            switch (status)
            {
                case GPUStatus.OK:
                    return Color.Green;
                case GPUStatus.Warning:
                    return Color.Orange;
                case GPUStatus.Error:
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }

        public static IEnumerable<string> GetNonSystemColourNames(string orderByColourProperties)
        {
            var colours = GetColours();
            if (orderByColourProperties != null)
                colours = colours.OrderByColourProperties(orderByColourProperties);
            return colours.Select(c => c.Name);
        }

        public static bool IsDark(this Color colour) => colour.Luma() <= 0.5;

        public static bool IsVeryBright(this Color colour) => colour.Luma() > 0.75;

        public static bool IsVeryDark(this Color colour) => colour.Luma() <= 0.25;

        /// <summary>
        /// Luma can be used to determine whether or not a Color is "bright", "dark", etc.
        /// https://en.wikipedia.org/wiki/Luma_%28video%29
        /// </summary>
        /// <param name="colour">The sample colour.</param>
        /// <returns>The sample colour's Luma value.</returns>
        public static float Luma(this Color colour) => (0.2126f * colour.R + 0.7152f * colour.G + 0.0722f * colour.B) / 255;

        public static void SetOptimization(this Graphics g, Optimization optimization)
        {
            if (g == null)
                return;
            switch (optimization)
            {
                case Optimization.HighSpeed:
                    g.InterpolationMode = InterpolationMode.Low;
                    g.CompositingQuality = CompositingQuality.HighSpeed;
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                    g.TextRenderingHint = TextRenderingHint.SystemDefault;
                    g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    break;
                case Optimization.HighQuality:
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    break;
                default:
                    g.InterpolationMode = InterpolationMode.Bilinear;
                    g.CompositingQuality = CompositingQuality.Default;
                    g.SmoothingMode = SmoothingMode.None;
                    g.TextRenderingHint = TextRenderingHint.SystemDefault;
                    g.PixelOffsetMode = PixelOffsetMode.Default;
                    break;
            }
        }

        /// <summary>
        /// Converts a given colour to a SolidBrush of that colour. Results are cached in the static SolidBrushes Dictionary.
        /// The dictionary is indexed by colour, and each SolidBrush value is accompanied by a boolean "stock" flag.
        /// If true, this flag indicates that the corresponding SolidBrush was obtained from the standard Brushes list.
        /// </summary>
        /// <param name="colour">The colour of the required SolidBrush.</param>
        /// <returns>The required SolidBrush.</returns>
        public static SolidBrush ToSolidBrush(this Color colour)
        {
            if (!SolidBrushInfos.TryGetValue(colour, out var info))
            {
                var prop = GetProp(colour);
                info = prop != null
                    ? (SolidBrush: (SolidBrush)prop.GetValue(null), Stock: true)
                    : (SolidBrush: new SolidBrush(colour), Stock: false);
                SolidBrushInfos.Add(colour, info);
            }
            return info.SolidBrush;
        }

        public static void WithSolidBrush(this Color colour, Action<Brush> action) => action?.Invoke(colour.ToSolidBrush());

        // Private methods

        private static IEnumerable<Color> GetColours() =>
            Enum.GetValues(typeof(KnownColor))
                .Cast<KnownColor>()
                .Select(Color.FromKnownColor)
                .Where(c => !c.IsSystemColor);

        private static PropertyInfo GetProp(Color colour) => typeof(Brushes).GetProperty(colour.Name, BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Static);

        private static bool IsBright(this Color colour) => colour.Luma() > 0.5;

        private static IEnumerable<Color> OrderByColourProperties(this IEnumerable<Color> colours, string colourProperties)
        {
            IOrderedEnumerable<Color> result = null;
            var first = true;
            foreach (var colourProperty in colourProperties.Split(',').Select(p => p.Trim().ToTitleCase()))
            {
                var colourOrder = ColourOrders[colourProperty];
                result = first ? colours.OrderBy(colourOrder) : result.ThenBy(colourOrder);
                first = false;
            }
            return result;
        }
    }
}
