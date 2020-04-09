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
        /// <param name="s">The source, contributing the items to be copied.</param>
        /// <param name="t">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStrip s, ToolStrip t) =>
            s?.Items.CloneTo(t?.Items);

        /// <summary>
        /// Copy the Items from one ToolStripDropDownItem to another.
        /// </summary>
        /// <param name="s">The source, contributing the items to be copied.</param>
        /// <param name="t">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStripDropDownItem s, ToolStripDropDownItem t) =>
            s?.DropDownItems.CloneTo(t?.DropDownItems);

        /// <summary>
        /// Copy the Items from a ToolStrip to a ToolStripDropDownItem.
        /// </summary>
        /// <param name="s">The source, contributing the items to be copied.</param>
        /// <param name="t">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStrip s, ToolStripDropDownItem t) =>
            s?.Items.CloneTo(t?.DropDownItems);

        /// <summary>
        /// Copy the DropDownItems from a ToolStripDropDownItem to a ToolStrip.
        /// </summary>
        /// <param name="s">The source, contributing the items to be copied.</param>
        /// <param name="t">The target, receiving the copies.</param>
        public static void CloneTo(this ToolStripDropDownItem s, ToolStrip t) =>
            s?.DropDownItems.CloneTo(t?.Items);

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

        private static ToolStripItem Clone(this ToolStripItem s)
        {
            switch (s)
            {
                case ToolStripSeparator p:
                    return new ToolStripSeparator();
                case ToolStripMenuItem m:
                    var t = new ToolStripMenuItem(m.Text, m.Image,
                        (object sender, EventArgs e) => m.PerformClick(),
                        m.ShortcutKeys)
                    {
                        Checked = m.Checked,
                        Enabled = m.Enabled,
                        Font = m.Font,
                        ShortcutKeyDisplayString = m.ShortcutKeyDisplayString,
                        Tag = m.Tag,
                        ToolTipText = m.ToolTipText
                    };
                    if (m.HasDropDownItems)
                        m.DropDownItems.CloneTo(t.DropDownItems);
                    return t;
            }
            return null;
        }

        private static void CloneTo(this ToolStripItemCollection s, ToolStripItemCollection t)
        {
            t.Clear();
            foreach (ToolStripItem i in s)
                t.Add(i.Clone());
        }
    }
}
