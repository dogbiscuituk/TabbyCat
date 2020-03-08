namespace TabbyCat.Common.Types
{
    using System.ComponentModel;

    public enum Optimization
    {
        [Description("Default")]
        Default,
        [Description("High Quailty")]
        HighQuality,
        [Description("High Speed")]
        HighSpeed
    }
}
