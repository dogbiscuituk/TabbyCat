namespace TabbyCat.Controllers
{
    using Common.Types;
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
            foreach (var control in controls)
            {
                control.Items.AddRange(NonSystemColourNames);
                control.DrawItem += Control_DrawItem;
            }
        }

        internal void Clear()
        {
            foreach (var control in Controls)
                control.DrawItem -= Control_DrawItem;
            Controls.Clear();
        }

        internal Color GetColour(ComboBox comboBox)
        {
            var item = comboBox.SelectedItem;
            if (item != null)
                return Color.FromName(item.ToString());
            else if (comboBox.Tag is Color)
                return (Color)comboBox.Tag;
            else
                return Color.Transparent;
        }

        internal void SetColour(ComboBox comboBox, Color colour)
        {
            var argb = colour.ToArgb();
            comboBox.Tag = colour;
            var name = comboBox.Items.Cast<string>()
                .FirstOrDefault(s => Color.FromName(s).ToArgb() == argb);
            comboBox.SelectedIndex =
                string.IsNullOrWhiteSpace(name) ? -1 : comboBox.Items.IndexOf(name);
            comboBox.Invalidate();
        }

        private static readonly string[] NonSystemColourNames =
            ColourUtils.GetNonSystemColourNames(Properties.Settings.Default.KnownColorSortOrder).ToArray();

        private void Control_DrawItem(object sender, DrawItemEventArgs e)
        {
            var selected = (e.State & DrawItemState.Selected) != 0;
            string text = "Transparent";
            var background = Color.Transparent;
            var comboBox = (ComboBox)sender;
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
            var foreground = background.Contrast();
            ColourUtils.DrawText(e, foreground, background, text);
            if (selected)
            {
                var r = e.Bounds;
                using (var pen = new Pen(foreground) { DashStyle = DashStyle.Dash })
                    e.Graphics.DrawRectangle(pen, r.X + 1, r.Y + 1, r.Width - 2, r.Height - 2);
            }
        }
    }
}
