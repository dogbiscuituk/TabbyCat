﻿namespace TabbyCat.Types
{
    using System.Drawing;

    public interface IScene : IShaders
    {
        Color BackgroundColour { get; set; }
        Camera Camera { get; set; }
        string GLTargetVersion { get; set; }
        string GPULog { get; set; }
        GPUStatus GPUStatus { get; set; }
        Projection Projection { get; set; }
        int Samples { get; set; }
        float TargetFPS { get; set; }
        string Title { get; set; }
        bool VSync { get; set; }
    }
}
