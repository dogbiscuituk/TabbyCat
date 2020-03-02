namespace TabbyCat.Models
{
    using System.Drawing;

    public class Scene
    {
        public Color BackgroundColour { get; set; }
        public Camera Camera = new Camera();
        public int FPS { get; set; }
        public string GLSLTargetVersion { get; set; }
        public Projection Projection = new Projection();
        public int SampleCount { get; set; }
        public string Title { get; set; }
        public bool VSync { get; set; }
    }
}
