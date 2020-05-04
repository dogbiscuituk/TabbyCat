namespace TabbyCat.Utils
{
    using Jmk.Common;
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

        public static Color Contrast(this Color colour)
        {
            return colour.IsBright() ? Color.Black : Color.White;
        }

        public static void DrawText(DrawItemEventArgs e, Color foreground, Color background, string text)
        {
            if (e == null)
            {
                return;
            }

            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            g.SetOptimization(Optimization.HighQuality);
            background.WithBrush(brush => g.FillRectangle(brush, r));
            foreground.WithBrush(brush => g.DrawString(text, e.Font, brush, r.X + 1, r.Y - 2));
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

        public static IEnumerable<Color> GetColours()
        {
            return Enum.GetValues(typeof(KnownColor))
.Cast<KnownColor>()
.Select(Color.FromKnownColor)
.Where(c => !c.IsSystemColor);
        }

        public static IEnumerable<string> GetNonSystemColourNames(string orderByColourProperties)
        {
            IEnumerable<Color> colours = GetColours();
            if (orderByColourProperties != null)
            {
                colours = colours.OrderByColourProperties(orderByColourProperties);
            }

            return colours.Select(c => c.Name);
        }

        public static bool IsBright(this Color colour)
        {
            return colour.Luma() > 0.5;
        }

        public static bool IsDark(this Color colour)
        {
            return colour.Luma() <= 0.5;
        }

        public static bool IsVeryBright(this Color colour)
        {
            return colour.Luma() > 0.75;
        }

        public static bool IsVeryDark(this Color colour)
        {
            return colour.Luma() <= 0.25;
        }

        /// <summary>
        /// Luma can be used to determine whether or not a Color is "bright", "dark", etc.
        /// https://en.wikipedia.org/wiki/Luma_%28video%29
        /// </summary>
        /// <param name="colour">The sample colour.</param>
        /// <returns>The sample colour's Luma value.</returns>
        public static float Luma(this Color colour)
        {
            return (0.2126f * colour.R + 0.7152f * colour.G + 0.0722f * colour.B) / 255;
        }

        public static void SetOptimization(this Graphics g, Optimization optimization)
        {
            if (g == null)
            {
                return;
            }

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

        public static Brush ToBrush(this Color colour, out bool stock)
        {
            PropertyInfo prop = GetProp(colour);
            stock = prop != null;
            return stock ? (Brush)prop.GetValue(null) : new SolidBrush(colour);
        }

        public static void WithBrush(this Color colour, Action<Brush> action)
        {
            if (action == null)
            {
                return;
            }

            PropertyInfo prop = GetProp(colour);
            if (prop != null)
            {
                action((Brush)prop.GetValue(null));
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(colour))
                {
                    action(brush);
                }
            }
        }

        // Private methods

        private static PropertyInfo GetProp(Color colour)
        {
            return typeof(Brushes).GetProperty(colour.Name, BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Static);
        }

        private static IEnumerable<Color> OrderByColourProperties(this IEnumerable<Color> colours, string colourProperties)
        {
            IOrderedEnumerable<Color> result = null;
            bool first = true;
            foreach (string colourProperty in colourProperties.Split(',')
                .Select(p => p.Trim().ToTitleCase()))
            {
                Func<Color, float> colourOrder = ColourOrders[colourProperty];
                result =
                    first
                    ? colours.OrderBy(colourOrder)
                    : result.ThenBy(colourOrder);
                first = false;
            }
            return result;
        }
    }
}
