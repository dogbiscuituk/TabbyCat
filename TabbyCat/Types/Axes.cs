namespace TabbyCat.Types
{
    using System;

    [Flags]
    public enum Axes
    {
        None = 0,
        X = 1,
        Y = 2,
        Z = 4,
        XY = X | Y,
        YZ = Y | Z,
        ZX = Z | X,
        XYZ = X | Y | Z,
        All = XYZ,
    }
}
