namespace TabbyCat.Common.Types
{
    using OpenTK;
    using OpenTK.Graphics;
    using System;

    public class GLMode
    {
        #region Constructors

        public GLMode(GLControl control) : this(control?.GraphicsMode) { }

        public GLMode(GLMode mode)
        {
            if (mode != null) Init(
                mode.Index,
                mode.ColourFormat,
                mode.AccumColourFormat,
                mode.Buffers,
                mode.Depth,
                mode.Samples,
                mode.Stencil,
                mode.Stereo);
        }

        public GLMode(IntPtr? index, ColorFormat colourFormat, ColorFormat accumColourFormat,
            int buffers, int depth, int samples, int stencil, bool stereo) =>
            Init(index, colourFormat, accumColourFormat, buffers, depth, samples, stencil, stereo);

        #endregion

        #region Public Properties

        public IntPtr? Index { get; set; }
        public ColorFormat ColourFormat { get; set; }
        public ColorFormat AccumColourFormat { get; set; }
        public int Buffers { get; set; }
        public int Depth { get; set; }
        public int Samples { get; set; }
        public int Stencil { get; set; }
        public bool Stereo { get; set; }

        #endregion

        #region Public Operators

        public static implicit operator GLMode(GraphicsMode p) =>
            p == null ? null : new GLMode(
                index: p.Index,
                colourFormat: p.ColorFormat,
                accumColourFormat: p.AccumulatorFormat,
                buffers: p.Buffers,
                depth: p.Depth,
                samples: p.Samples,
                stencil: p.Stencil,
                stereo: p.Stereo);

        public static implicit operator GraphicsMode(GLMode p) =>
            p == null ? null : new GraphicsMode(
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

        public static string AsString(ColorFormat source) =>
            $"{source.Red}, {source.Green}, {source.Blue}, {source.Alpha}";

        private void Init(IntPtr? index, ColorFormat colourFormat, ColorFormat accumColourFormat,
            int buffers, int depth, int samples, int stencil, bool stereo)
        {
            Index = index;
            ColourFormat = colourFormat;
            AccumColourFormat = accumColourFormat;
            Buffers = buffers;
            Depth = depth;
            Samples = samples;
            Stencil = stencil;
            Stereo = stereo;
        }

        #endregion
    }
}
