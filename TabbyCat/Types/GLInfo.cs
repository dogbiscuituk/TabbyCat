namespace TabbyCat.Types
{
    using OpenTK.Graphics.OpenGL;

    public class GLInfo
    {
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

        public string Number { get; }
        public int Major { get; }
        public int Minor { get; }
        public string Shader { get; }
        public string Vendor { get; }
        public string Renderer { get; }

        public override string ToString() => $"{Number}, {Major}, {Minor}, {Shader}, {Vendor}, {Renderer}";
    }
}
