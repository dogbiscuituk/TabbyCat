namespace TabbyCat.Controllers
{
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    internal static class LinkLabelController
    {
        /// <summary>
        /// Copy markdown text into a LinkLabel, replacing each link in the text
        /// with an active link in the label.
        /// </summary>
        /// <param name="label">The target LinkLabel control.</param>
        /// <param name="text">The markdown text, containing zero or more links of the form
        /// [Microsoft Ltd](www.microsoft.com).
        /// Note: there must be no spaces between the central ]( characters.</param>
        internal static void SetText(LinkLabel label, string text)
        {
            var s = new StringBuilder(text);
            var links = new List<LinkLabel.Link>();
            while (true)
            {
                var match = Regex.Match(s.ToString(), @"\[([^\]]+)\]\(([^\)]+)\)");
                if (!match.Success)
                    break;
                var groups = match.Groups;
                int
                    start = groups[1].Index,
                    length = groups[1].Length;
                s.Remove(start + length, groups[2].Length + 3);
                start--;
                s.Remove(start, 1);
                links.Add(new LinkLabel.Link(start, length, groups[2].Value));
            }
            label.LinkArea = new LinkArea(0, 0);
            label.Text = s.ToString();
            links.ForEach(p => label.Links.Add(p));
        }
    }
}
