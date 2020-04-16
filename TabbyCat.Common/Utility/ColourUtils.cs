﻿namespace TabbyCat.Common.Utility
{
    using Jmk.Common;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Linq;
    using System.Reflection;
    using TabbyCat.Common.Types;

    public static class ColourUtils
    {
        private static readonly Dictionary<string, Func<Color, float>> ColourOrders =
            new Dictionary<string, Func<Color, float>>
            {
                { "Alpha", c => c.A },
                { "Red", c => c.R },
                { "Green", c=> c.G },
                { "Blue", c => c.B },
                { "Hue", c => c.GetHue() },
                { "Saturation", c => c.GetSaturation() },
                { "Brightness", c => c.GetBrightness() }
            };

        public static Color Contrast(this Color colour) => colour.IsBright() ? Color.Black : Color.White;

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

        public static IEnumerable<Color> GetColours() =>
                    Enum.GetValues(typeof(KnownColor))
                    .Cast<KnownColor>()
                    .Select(Color.FromKnownColor)
                    .Where(c => !c.IsSystemColor);

        public static IEnumerable<string> GetNonSystemColourNames(string orderByColourProperties)
        {
            var colours = GetColours();
            if (orderByColourProperties != null)
                colours = colours.OrderByColourProperties(orderByColourProperties);
            return colours.Select(c => c.Name);
        }

        public static bool IsBright(this Color colour) => colour.Luma() > 0.5;
        public static bool IsDark(this Color colour) => colour.Luma() <= 0.5;
        public static bool IsVeryBright(this Color colour) => colour.Luma() > 0.75;
        public static bool IsVeryDark(this Color colour) => colour.Luma() <= 0.25;

        /// <summary>
        /// Luma can be used to determine whether or not a Color is "bright", "dark", etc.
        /// https://en.wikipedia.org/wiki/Luma_%28video%29
        /// </summary>
        /// <param name="colour">The sample colour.</param>
        /// <returns>The sample colour's Luma value.</returns>
        public static double Luma(this Color colour) =>
            (0.2126 * colour.R + 0.7152 * colour.G + 0.0722 * colour.B) / 255;

        private static IEnumerable<Color> OrderByColourProperties(
            this IEnumerable<Color> colours, string colourProperties)
        {
            IOrderedEnumerable<Color> result = null;
            var first = true;
            foreach (var colourProperty in colourProperties.Split(',')
                .Select(p => p.Trim().ToTitleCase()))
            {
                var colourOrder = ColourOrders[colourProperty];
                result =
                    first
                    ? colours.OrderBy(colourOrder)
                    : result.ThenBy(colourOrder);
                first = false;
            }
            return result;
        }

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

        public static Brush ToBrush(this Color colour)
        {
            var flags = BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Static;
            var prop = typeof(Brushes).GetProperty(colour.Name, flags);
            return prop != null ? (Brush)prop.GetValue(null) : new SolidBrush(colour);
        }
    }
}