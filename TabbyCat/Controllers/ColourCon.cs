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
        // Private fields

        private List<ComboBox> Controls { get; } = new List<ComboBox>();

        private static readonly IEnumerable<string> ColourNames = ColourUtils.GetNonSystemColourNames(Properties.Settings.Default.KnownColorSortOrder);

        // Public methods

        public void AddControls(params ComboBox[] controls)
        {
            Controls.AddRange(controls);
            foreach (var control in controls)
            {
                control.Items.AddRange(ColourNames.Cast<object>().ToArray());
                control.DrawItem += Control_DrawItem;
            }
        }

        // Private methods

        private static void Control_DrawItem(object sender, DrawItemEventArgs e)
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
            else if (comboBox.Tag is Color colour)
            {
                background = colour;
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
