namespace TabbyCat.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Windows.Forms;
    using Utils;

    internal class ColourCon
    {
        internal ColourCon() { }

        internal readonly List<ComboBox> Controls = new List<ComboBox>();

        internal void AddControls(params ComboBox[] controls)
        {
            Controls.AddRange(controls);
            foreach (ComboBox control in controls)
            {
                control.Items.AddRange(NonSystemColourNames);
                control.DrawItem += Control_DrawItem;
            }
        }

        internal void Clear()
        {
            foreach (ComboBox control in Controls)
            {
                control.DrawItem -= Control_DrawItem;
            }

            Controls.Clear();
        }

        internal Color GetColour(ComboBox comboBox)
        {
            object item = comboBox.SelectedItem;
            if (item != null)
            {
                return Color.FromName(item.ToString());
            }
            else if (comboBox.Tag is Color)
            {
                return (Color)comboBox.Tag;
            }
            else
            {
                return Color.Transparent;
            }
        }

        internal void SetColour(ComboBox comboBox, Color colour)
        {
            int argb = colour.ToArgb();
            comboBox.Tag = colour;
            string name = comboBox.Items.Cast<string>()
                .FirstOrDefault(s => Color.FromName(s).ToArgb() == argb);
            comboBox.SelectedIndex =
                string.IsNullOrWhiteSpace(name) ? -1 : comboBox.Items.IndexOf(name);
            comboBox.Invalidate();
        }

        private static readonly string[] NonSystemColourNames =
            ColourUtils.GetNonSystemColourNames(Properties.Settings.Default.KnownColorSortOrder).ToArray();

        private void Control_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool selected = (e.State & DrawItemState.Selected) != 0;
            string text = "Transparent";
            Color background = Color.Transparent;
            ComboBox comboBox = (ComboBox)sender;
            if (e.Index >= 0)
            {
                text = comboBox.Items[e.Index].ToString();
                background = Color.FromName(text);
            }
            else if (comboBox.Tag is Color)
            {
                background = (Color)comboBox.Tag;
                text = $"{background.ToArgb() & 0xffffff:X}";
            }
            Color foreground = background.Contrast();
            ColourUtils.DrawText(e, foreground, background, text);
            if (selected)
            {
                Rectangle r = e.Bounds;
                using (Pen pen = new Pen(foreground) { DashStyle = DashStyle.Dash })
                {
                    e.Graphics.DrawRectangle(pen, r.X + 1, r.Y + 1, r.Width - 2, r.Height - 2);
                }
            }
        }
    }
}
