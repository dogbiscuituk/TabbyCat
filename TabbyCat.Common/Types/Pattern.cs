namespace TabbyCat.Common.Types
{
    using OpenTK.Graphics.OpenGL;
    using System.ComponentModel;

    public enum Pattern
    {
        [Description("None")]
        None = FillType.None | PrimitiveType.Points,

        [Description("Fill")]
        Fill = FillType.Fill | PrimitiveType.TriangleStrip,

        [Description("Points")]
        Points = FillType.Points | PrimitiveType.Points,

        [Description("Rectangles")]
        Rectangles = FillType.Rectangles | PrimitiveType.Lines,

        [Description("Saltires")]
        Saltires = FillType.Saltires | PrimitiveType.Lines,

        [Description("Triangles")]
        Triangles = FillType.Triangles | PrimitiveType.Lines
    }
}
