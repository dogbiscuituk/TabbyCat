namespace TabbyCat.Common.Types
{
    using System.Drawing;

    public interface IScene : ICode
    {
        Color BackgroundColour { get; set; }
        SimpleCamera Camera { get; set; }
        float FPS { get; set; }
        string GLTargetVersion { get; set; }
        string GPULog { get; set; }
        GPUStatus GPUStatus { get; set; }
        Projection Projection { get; set; }
        int Samples { get; set; }
        string Title { get; set; }
        // public List<Trace> Traces = new List<Trace>();
        bool VSync { get; set; }
    }
}
