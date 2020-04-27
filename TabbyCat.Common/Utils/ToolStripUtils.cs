namespace TabbyCat.Common.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public static class ToolStripUtils
    {
        // Public methods

        /// <summary>
        /// Copy the Items from one ToolStrip to another.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="onClick">Whether or not the OnClick event handlers are copied across.</param>
        public static void CloneTo(this ToolStrip source, ToolStrip target, bool onClick = true) =>
            source?.Items.CloneTo(target?.Items, onClick);

        /// <summary>
        /// Copy the Items from one ToolStripDropDownItem to another.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="onClick">Whether or not the OnClick event handlers are copied across.</param>
        public static void CloneTo(this ToolStripDropDownItem source, ToolStripDropDownItem target, bool onClick = true) =>
            source?.DropDownItems.CloneTo(target?.DropDownItems, onClick);

        /// <summary>
        /// Copy the Items from a ToolStrip to a ToolStripDropDownItem.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="onClick">Whether or not the OnClick event handlers are copied across.</param>
        public static void CloneTo(this ToolStrip source, ToolStripDropDownItem target, bool onClick = true) =>
            source?.Items.CloneTo(target?.DropDownItems, onClick);

        /// <summary>
        /// Copy the DropDownItems from a ToolStripDropDownItem to a ToolStrip.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        /// <param name="onClick">Whether or not the OnClick event handlers are copied across.</param>
        public static void CloneTo(this ToolStripDropDownItem source, ToolStrip target, bool onClick = true) =>
            source?.DropDownItems.CloneTo(target?.Items, onClick);

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

        private static ToolStripItem CloneItem(this ToolStripItem source, bool onClick)
        {
            switch (source)
            {
                case ToolStripSeparator _:
                case ToolStripMenuItem separator when separator.Text == "-":
                    return new ToolStripSeparator();
                case ToolStripMenuItem menuItem:
                    var target = new ToolStripMenuItem(
                        menuItem.Text,
                        menuItem.Image,
                        onClick ? (sender, e) => menuItem.PerformClick() : (EventHandler)null,
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
                        menuItem.DropDownItems.CloneTo(target.DropDownItems, onClick);
                    return target;
            }
            return null;
        }

        private static void CloneTo(this ToolStripItemCollection source, ToolStripItemCollection target, bool onClick)
        {
            target.Clear();
            foreach (ToolStripItem item in source)
                target.Add(item.CloneItem(onClick));
        }
    }
}
