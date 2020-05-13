namespace TabbyCat.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Types;

    public static class ToolStripUtils
    {
        // Public methods

        /// <summary>
        /// Copy the Items from one ToolStrip to another.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="options">Flags determining details of the cloning performed, such as
        /// whether the destination items will be cleared before the copy operation, or
        /// whether an existing OnClick event handler will be copied across."</param>
        public static void CloneTo(this ToolStrip source, ToolStrip target, ToolStripCloneOptions options) => source?.Items.CloneTo(target?.Items, options);

        /// <summary>
        /// Copy the Items from one ToolStripDropDownItem to another.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="options">Flags determining details of the cloning performed, such as
        /// whether the destination items will be cleared before the copy operation, or
        /// whether an existing OnClick event handler will be copied across."</param>
        public static void CloneTo(this ToolStripDropDownItem source, ToolStripDropDownItem target, ToolStripCloneOptions options) => source?.DropDownItems.CloneTo(target?.DropDownItems, options);

        /// <summary>
        /// Copy the Items from a ToolStrip to a ToolStripDropDownItem.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="options">Flags determining details of the cloning performed, such as
        /// whether the destination items will be cleared before the copy operation, or
        /// whether an existing OnClick event handler will be copied across."</param>
        public static void CloneTo(this ToolStrip source, ToolStripDropDownItem target, ToolStripCloneOptions options) => source?.Items.CloneTo(target?.DropDownItems, options);

        /// <summary>
        /// Copy the DropDownItems from a ToolStripDropDownItem to a ToolStrip.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="options">Flags determining details of the cloning performed, such as
        /// whether the destination items will be cleared before the copy operation, or
        /// whether an existing OnClick event handler will be copied across."</param>
        public static void CloneTo(this ToolStripDropDownItem source, ToolStrip target, ToolStripCloneOptions options) => source?.DropDownItems.CloneTo(target?.Items, options);

        public static void EnableButtons(bool enabled, IEnumerable<ToolStripItem> items)
        {
            if (items == null)
                return;
            foreach (var item in items)
                item.Enabled = enabled;
        }

        public static void EnableControls(bool enabled, IEnumerable<Control> controls)
        {
            if (controls == null)
                return;
            foreach (var control in controls)
                control.Enabled = enabled;
        }

        // Private methods

        private static ToolStripItem CloneItem(this ToolStripItem source, ToolStripCloneOptions options)
        {
            switch (source)
            {
                case ToolStripSeparator _:
                case ToolStripMenuItem separator when separator.Text == @"-":
                    return new ToolStripSeparator();
                case ToolStripMenuItem menuItem:
                    var copyClickHandler = (options & ToolStripCloneOptions.CopyClickHandler) != 0;
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

        private static void CloneTo(this ToolStripItemCollection source, ToolStripItemCollection target, ToolStripCloneOptions options)
        {
            if ((options & ToolStripCloneOptions.ClearTarget) != 0)
                target.Clear();
            foreach (ToolStripItem item in source)
                target.Add(item.CloneItem(options));
        }
    }
}
