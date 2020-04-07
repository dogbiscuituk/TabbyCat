namespace TabbyCat.Common.Types
{
    using OpenTK;
    using OpenTK.Graphics;
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using TabbyCat.Common.Utility;

    [TypeConverter(typeof(GLModeTypeConverter))]
    public class GLMode
    {
        #region Constructors

        public GLMode(GLControl control) : this(control.GraphicsMode) { }

        public GLMode(GLMode mode) =>
            Init(mode.Index, mode.ColourFormat, mode.AccumColourFormat,
            mode.Buffers, mode.Depth, mode.Samples, mode.Stencil, mode.Stereo);

        public GLMode(IntPtr? index, ColourFormat colourFormat, ColourFormat accumColourFormat,
            int buffers, int depth, int samples, int stencil, bool stereo) =>
            Init(index, colourFormat, accumColourFormat, buffers, depth, samples, stencil, stereo);

        public GLMode(GLMode mode, string field, object value) : this(mode)
        {
            switch (field)
            {
                case "GLMode_Index":
                    Index = (IntPtr?)value;
                    return;
                case "GLMode_ColourFormat":
                    ColourFormat = new ColourFormat((ColourFormat)value);
                    return;
                case "GLMode_AccumColourFormat":
                    AccumColourFormat = new ColourFormat((ColourFormat)value);
                    return;
                case "GLMode_Buffers":
                    Buffers = (int)value;
                    return;
                case "GLMode_Depth":
                    Depth = (int)value;
                    return;
                case PropertyNames.Samples:
                    Samples = (int)value;
                    return;
                case "GLMode_Stencil":
                    Stencil = (int)value;
                    return;
                case "GLMode_Stereo":
                    Stereo = (bool)value;
                    return;
            }
            var v = (int)value;
            var fields = field.Split('.');
            var p = fields[0] == "GLMode_AccumColourFormat" ? AccumColourFormat : ColourFormat;
            switch (fields[1])
            {
                case "Red": p.Red = v; break;
                case "Green": p.Green = v; break;
                case "Blue": p.Blue = v; break;
                case "Alpha": p.Alpha = v; break;
            }
            switch (fields[0])
            {
                case "GLMode_AccumColourFormat":
                    AccumColourFormat = p;
                    break;
                case "GLMode_ColourFormat":
                    ColourFormat = p;
                    break;
            }
        }

        #endregion

        #region Public Properties

        public IntPtr? Index { get; set; }
        public ColourFormat ColourFormat { get; set; }
        public ColourFormat AccumColourFormat { get; set; }
        public int Buffers { get; set; }
        public int Depth { get; set; }
        public int Samples { get; set; }
        public int Stencil { get; set; }
        public bool Stereo { get; set; }

        #endregion

        #region Public Operators

        public static implicit operator GLMode(GraphicsMode p) => new GLMode(
            index: p.Index,
            colourFormat: new ColourFormat(p.ColorFormat),
            accumColourFormat: new ColourFormat(p.AccumulatorFormat),
            buffers: p.Buffers,
            depth: p.Depth,
            samples: p.Samples,
            stencil: p.Stencil,
            stereo: p.Stereo);

        public static implicit operator GraphicsMode(GLMode p) => new GraphicsMode(
            color: p.ColourFormat,
            accum: p.AccumColourFormat,
            buffers: p.Buffers,
            depth: p.Depth,
            samples: p.Samples,
            stencil: p.Stencil,
            stereo: p.Stereo);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is GLMode p
            && p.ColourFormat == ColourFormat
            && p.AccumColourFormat == AccumColourFormat
            && p.Buffers == Buffers
            && p.Depth == Depth
            && p.Samples == Samples
            && p.Stencil == Stencil
            && p.Stereo == Stereo;

        public override int GetHashCode() =>
            ColourFormat.GetHashCode() ^ AccumColourFormat.GetHashCode() ^
            Buffers ^ Depth ^ Samples ^ Stencil ^ (Stereo ? 1 : 0);

        public static GLMode Parse(string s)
        {
            var t = s.Split(',');
            return new GLMode((IntPtr?)0,
                new ColourFormat(
                    int.Parse(t[0], CultureInfo.CurrentCulture),
                    int.Parse(t[1]),
                    int.Parse(t[2]),
                    int.Parse(t[3])),
                new ColourFormat(
                    int.Parse(t[4]),
                    int.Parse(t[5]),
                    int.Parse(t[6]),
                    int.Parse(t[7])),
                int.Parse(t[8]),
                int.Parse(t[9]),
                int.Parse(t[10]),
                int.Parse(t[11]),
                bool.Parse(t[12]));
        }

        public override string ToString() =>
            $@"Colour format: {ColourFormat}
Accumulator colour format: {AccumColourFormat}
Buffers: {Buffers}
Depth bits: {Depth}
Samples: {Samples}
Stencil bits: {Stencil}
Stereo: {Stereo}";

        #endregion

        #region Private Methods

        public string GetColourFormat(ColorFormat source) =>
            $"{source.Red}, {source.Green}, {source.Blue}, {source.Alpha}";

        private void Init(IntPtr? index, ColourFormat colourFormat, ColourFormat accumColourFormat,
            int buffers, int depth, int samples, int stencil, bool stereo)
        {
            Index = index;
            ColourFormat = new ColourFormat(colourFormat);
            AccumColourFormat = new ColourFormat(accumColourFormat);
            Buffers = buffers;
            Depth = depth;
            Samples = samples;
            Stencil = stencil;
            Stereo = stereo;
        }

        #endregion
    }
}
