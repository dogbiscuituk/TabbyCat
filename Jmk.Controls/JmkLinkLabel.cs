namespace Jmk.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class JmkLinkLabel : LinkLabel
    {
        public Link ActiveLink { get; private set; }

        public override string Text
        {
            get => base.Text;
            set => SetText(value);
        }

        public event EventHandler ActiveLinkChanged;

        protected virtual void OnActiveLinkChanged() => ActiveLinkChanged?.Invoke(this, EventArgs.Empty);

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var link = PointInLink(e.X, e.Y);
            if (link == ActiveLink)
                return;
            ActiveLink = link;
            OnActiveLinkChanged();
        }

        protected override void WndProc(ref Message m)
        {
            this.FirstFocus(ref m);
            base.WndProc(ref m);
        }

        private void SetText(string text)
        {
            ActiveLink = null;
            var s = new StringBuilder(text);
            var links = new List<Link>();
            while (true)
            {
                var match = Regex.Match(s.ToString(), @"\[([^\]]+)\]\(([^\)]+)");
                if (!match.Success)
                    break;
                var groups = match.Groups;
                int
                    start = groups[1].Index,
                    length = groups[1].Length;
                s.Remove(start + length, groups[2].Length + 3);
                start--;
                s.Remove(start, 1);
                var url = groups[2].Value;
                links.Add(new Link(start, length, url) { Description = url });
            }
            base.Text = s.ToString();
            Links.Clear();
            links.ForEach(p => Links.Add(p));
        }
    }
}
