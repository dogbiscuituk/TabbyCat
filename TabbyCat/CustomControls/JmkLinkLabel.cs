﻿namespace TabbyCat.CustomControls
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Types;

    /// <summary>
    /// A LinkLabel with a couple of additional features:
    /// 
    /// MULTIPLE LINKS can be embedded in the Text using a restricted Markdown syntax.
    /// 
    /// For example:
    /// - Click here for the [Microsoft](www.microsoft.com) website.
    /// will be replaced at runtime, when the value is assigned to the JmkLinkLabel's Text property, by:
    /// - Click here for the Microsoft website.
    /// The word "Microsoft" appears in link style, and when hovered over, generates an ActiveLinkChanged event.
    /// In the event handler, use the ActiveLink property to obtain the Description or LinkData of the hovered link.
    /// One good use of this feature would be to set the ToolTip associated with this link in the JmkLinkLabel.
    /// Of course, any of these links will generate the usual LinkClicked event when clicked.
    /// 
    /// CONFIGURABLE PARAMETERS can be embedded in the Text surrounded by % signs.
    /// 
    /// For example:
    ///  The base URL is set to %URL%.
    /// might be replaced at runtime, when the value is assigned to the JmkLinkLabel's Text property, by:
    ///  The base URL is set to https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.60.html.
    /// if that's what your LookupParameterValue event handler returns for the variable name URL.
    /// Note that such values are substituted on each assignment to the JmkLinkLabel's Text property.
    /// </summary>
    public sealed class JmkLinkLabel : LinkLabel
    {
        // Constructors

        public Link ActiveLink { get; private set; }

        // Private fields

        private int _offset;

        // Public properties

        public override string Text
        {
            get => base.Text;
            set => SetText(value);
        }

        // Public events

        public event EventHandler ActiveLinkChanged;
        public event EventHandler<LookupParameterEventArgs> LookupParameterValue;

        // Protected methods

        private void OnActiveLinkChanged() => ActiveLinkChanged?.Invoke(this, EventArgs.Empty);

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "e is never null")]
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

        // Private methods

        private string EvaluateLink(Match match)
        {
            var groups = match.Groups;
            Group
                group1 = groups[1],
                group2 = groups[2];
            int
                start = group1.Index,
                length = group1.Length;
            var url = group2.Value;
            Links.Add(new Link(start - 1 + _offset, length, url) { Description = url });
            var result = groups[1].Value;
            _offset += result.Length - match.Value.Length;
            return result;
        }

        private string EvaluateParameter(Match match)
        {
            var parameter = match.Groups[1].Value;
            var e = new LookupParameterEventArgs
            {
                Name = parameter,
                Value = string.Empty
            };
            LookupParameterValue?.Invoke(this, e);
            var result = e.Value;
            _offset += result.Length - match.Value.Length;
            return result;
        }

        private string ReplaceAll(string text, string pattern, MatchEvaluator evaluator)
        {
            _offset = 0;
            return Regex.Replace(text, pattern, evaluator);
        }

        private void SetText(string text)
        {
            const string
                linkPattern = @"\[([^\]]+)\]\(([^\)]+)\)",
                parameterPattern = @"\%([^\%]*)\%";
            ActiveLink = null;
            Links.Clear();
            base.Text = ReplaceAll(
                ReplaceAll(
                    text,
                    parameterPattern,
                    EvaluateParameter),
                linkPattern,
                EvaluateLink);
        }
    }
}
