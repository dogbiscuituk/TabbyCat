namespace TabbyCat.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Windows.Forms;
    using Utils;

    public class ColourCon
    {
        public ColourCon() { }

        public List<ComboBox> Controls { get; } = new List<ComboBox>();

        public void AddControls(params ComboBox[] controls)
        {
            Controls.AddRange(controls);
            foreach (var control in controls)
            {
                control.Items.AddRange(NonSystemColourNames);
                control.DrawItem += Control_DrawItem;
            }
        }

        public void Clear()
        {
            foreach (var control in Controls)
                control.DrawItem -= Control_DrawItem;
            Controls.Clear();
        }

        public static Color GetColour(ComboBox comboBox)
        {
            if (comboBox == null)
                return Color.Transparent;
            var item = comboBox.SelectedItem;
            return item != null
                ? Color.FromName(item.ToString())
                : comboBox.Tag is Color
                ? (Color)comboBox.Tag
                : Color.Transparent;
        }

        public static void SetColour(ComboBox comboBox, Color colour)
        {
            if (comboBox == null)
                return;
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
            var text = "Transparent";
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
