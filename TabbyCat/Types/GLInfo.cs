namespace TabbyCat.Types
{
    using OpenTK.Graphics.OpenGL;

    public class GLInfo
    {
        // Constructors

        public GLInfo() : this(
            number: GL.GetString(StringName.Version),
            major: GL.GetInteger(GetPName.MajorVersion),
            minor: GL.GetInteger(GetPName.MinorVersion),
            shader: GL.GetString(StringName.ShadingLanguageVersion),
            vendor: GL.GetString(StringName.Vendor),
            renderer: GL.GetString(StringName.Renderer))
        { }

        private GLInfo(string number, int major, int minor, string shader, string vendor, string renderer)
        {
            Number = number;
            Major = major;
            Minor = minor;
            Shader = shader;
            Vendor = vendor;
            Renderer = renderer;
        }

        // Public properties

        public string Number { get; }
        public string Shader { get; }
        public string Vendor { get; }
        public string Renderer { get; }

        // Private properties

        private int Major { get; }
        private int Minor { get; }

        // Public methods

        public override string ToString() => $"{Number}, {Major}, {Minor}, {Shader}, {Vendor}, {Renderer}";
    }
}
