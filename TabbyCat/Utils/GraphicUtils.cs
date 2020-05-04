namespace TabbyCat.Utils
{
    using OpenTK.Graphics;
    using Properties;
    using System.Globalization;

    public static class GraphicUtils
    {
        public static GraphicsMode Change(this GraphicsMode mode, string propertyName, object value)
        {
            if (mode == null)
            {
                mode = new GraphicsMode();
            }

            ColorFormat
                accum = mode.AccumulatorFormat,
                color = mode.ColorFormat;
            int
                buffers = mode.Buffers,
                depth = mode.Depth,
                samples = mode.Samples,
                stencil = mode.Stencil;
            bool
                stereo = mode.Stereo;
            switch (propertyName)
            {
                case "Samples":
                    samples = (int)value;
                    break;
                case "Stereo":
                    stereo = (bool)value;
                    break;
            }
            return new GraphicsMode(
                color: color,
                depth: depth,
                stencil: stencil,
                samples: samples,
                accum: accum,
                buffers: buffers,
                stereo: stereo);
        }

        public static string AsString(this GraphicsMode mode)
        {
            return mode == null ? string.Empty : string.Format(
CultureInfo.CurrentCulture,
Resources.GraphicsModeFormat,
mode.Index,
mode.ColorFormat,
mode.AccumulatorFormat,
mode.Buffers,
mode.Depth,
mode.Samples,
mode.Stencil,
mode.Stereo);
        }
    }
}
