﻿namespace TabbyCat.Types
{
    using OpenTK;

    public interface IShape : IShaders
    {
        string Description { get; set; }
        Pattern Pattern { get; set; }
        bool Visible { get; set; }

        Vector3 Location { get; set; }
        Vector3 Maximum { get; set; }
        Vector3 Minimum { get; set; }
        Vector3 Orientation { get; set; }
        Vector3 Scale { get; set; }
        Vector3i StripeCount { get; set; }
    }
}
