namespace TabbyCat.Common.Utils
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;

    public static class ToolStripUtils
    {
        [Flags]
        public enum CloneOptions
        {
            [Description("None of the possible options are present.")]
            None = 0x00,

            [Description("Whether or not the destination items are cleared before the copy operation.")]
            ClearTarget = 0x01,

            [Description("Whether or not the OnClick event handlers are copied across.")]
            CopyClickHandler = 0x02,

            [Description("All of the possible options are present.")]
            All = ClearTarget | CopyClickHandler,
        }

        // Public methods

        /// <summary>
        /// Copy the Items from one ToolStrip to another.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStrip source, ToolStrip target, CloneOptions options) => source?.Items.CloneTo(target?.Items, options);

        /// <summary>
        /// Copy the Items from one ToolStripDropDownItem to another.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStripDropDownItem source, ToolStripDropDownItem target, CloneOptions options) => source?.DropDownItems.CloneTo(target?.DropDownItems, options);

        /// <summary>
        /// Copy the Items from a ToolStrip to a ToolStripDropDownItem.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="onClick">Whether or not the OnClick event handlers are copied across.</param>
        public static void CloneTo(this ToolStrip source, ToolStripDropDownItem target, CloneOptions options) => source?.Items.CloneTo(target?.DropDownItems, options);

        /// <summary>
        /// Copy the DropDownItems from a ToolStripDropDownItem to a ToolStrip.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="onClick">Whether or not the OnClick event handlers are copied across.</param>
        public static void CloneTo(this ToolStripDropDownItem source, ToolStrip target, CloneOptions options) => source?.DropDownItems.CloneTo(target?.Items, options);

        public static void EnableButtons(bool enabled, IEnumerable<ToolStripItem> items)
        {
            if (items != null)
                foreach (var item in items)
                    item.Enabled = enabled;
        }

        public static void EnableControls(bool enabled, IEnumerable<Control> controls)
        {
            if (controls != null)
                foreach (var control in controls)
                    control.Enabled = enabled;
        }

        // Private methods

        private static ToolStripItem CloneItem(this ToolStripItem source, CloneOptions options)
        {
            switch (source)
            {
                case ToolStripSeparator _:
                case ToolStripMenuItem separator when separator.Text == "-":
                    return new ToolStripSeparator();
                case ToolStripMenuItem menuItem:
                    var copyClickHandler = (options & CloneOptions.CopyClickHandler) != 0;
                    var target = new ToolStripMenuItem(
                        menuItem.Text,
                        menuItem.Image,
                        copyClickHandler ? (sender, e) => menuItem.PerformClick() : (EventHandler)null,
                        menuItem.ShortcutKeys)
                    {
                        Checked = menuItem.Checked,
                        Enabled = menuItem.Enabled,
                        Font = menuItem.Font,
                        ShortcutKeyDisplayString = menuItem.ShortcutKeyDisplayString,
                        Tag = menuItem.Tag,
                        ToolTipText = menuItem.ToolTipText
                    };
                    if (menuItem.HasDropDownItems)
                        menuItem.DropDownItems.CloneTo(target.DropDownItems, options);
                    return target;
            }
            return null;
        }

        private static void CloneTo(this ToolStripItemCollection source, ToolStripItemCollection target, CloneOptions options)
        {
            if ((options & CloneOptions.ClearTarget) != 0)
                target.Clear();
            foreach (ToolStripItem item in source)
                target.Add(item.CloneItem(options));
        }
    }
}
