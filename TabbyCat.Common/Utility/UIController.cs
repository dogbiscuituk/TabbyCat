namespace TabbyCat.Common.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public static class UIController
    {
        /// <summary>
        /// Copy the Items from one ToolStrip to another.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStrip source, ToolStrip target) =>
            source?.Items.CloneTo(target?.Items);

        /// <summary>
        /// Copy the Items from one ToolStripDropDownItem to another.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStripDropDownItem source, ToolStripDropDownItem target) =>
            source?.DropDownItems.CloneTo(target?.DropDownItems);

        /// <summary>
        /// Copy the Items from a ToolStrip to a ToolStripDropDownItem.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStrip source, ToolStripDropDownItem target) =>
            source?.Items.CloneTo(target?.DropDownItems);

        /// <summary>
        /// Copy the DropDownItems from a ToolStripDropDownItem to a ToolStrip.
        /// </summary>
        /// <param name="source">The source, contributing the items to be copied.</param>
        /// <param name="target">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStripDropDownItem source, ToolStrip target) =>
            source?.DropDownItems.CloneTo(target?.Items);

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

        private static ToolStripItem Clone(this ToolStripItem source)
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
                        (object sender, EventArgs e) => menuItem.PerformClick(),
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
                        menuItem.DropDownItems.CloneTo(target.DropDownItems);
                    return target;
            }
            return null;
        }

        private static void CloneTo(this ToolStripItemCollection source, ToolStripItemCollection target)
        {
            target.Clear();
            foreach (ToolStripItem item in source)
                target.Add(item.Clone());
        }
    }
}
