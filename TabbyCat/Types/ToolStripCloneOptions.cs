namespace TabbyCat.Types
{
    using System;
    using System.ComponentModel;

    [Flags]
    public enum ToolStripCloneOptions
    {
        [Description("None of the available options are selected.")]
        None = 0x00,

        [Description("The destination items will be cleared before the copy operation.")]
        ClearTarget = 0x01,

        [Description("Existing OnClick event handlers will be copied across.")]
        CopyClickHandler = 0x02,

        [Description("All of the available options are selected.")]
        All = ClearTarget | CopyClickHandler,
    }
}
