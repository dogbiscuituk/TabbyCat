namespace TabbyCat.Common.Types
{
    using OpenTK.Graphics.OpenGL;
    using System.ComponentModel;

    [TypeConverter(typeof(GLInfoTypeConverter))]
    public class GLInfo
    {
        #region Constructors

        public GLInfo() : this(
            number: GL.GetString(StringName.Version),
            major: GL.GetInteger(GetPName.MajorVersion),
            minor: GL.GetInteger(GetPName.MinorVersion),
            shader: GL.GetString(StringName.ShadingLanguageVersion),
            vendor: GL.GetString(StringName.Vendor),
            renderer: GL.GetString(StringName.Renderer))
        { }

        public GLInfo(string number, int major, int minor, string vendor, string renderer, string shader)
        {
            Number = number;
            Major = major;
            Minor = minor;
            Shader = shader;
            Vendor = vendor;
            Renderer = renderer;
        }

        #endregion

        #region Public Properties

        public string Number { get; }
        public int Major { get; }
        public int Minor { get; }
        public string Shader { get; }
        public string Vendor { get; }
        public string Renderer { get; }

        #endregion

        #region Public Methods

        public override string ToString() =>
            $"{Number}, {Major}, {Minor}, {Shader}, {Vendor}, {Renderer}";

        #endregion
    }
}
