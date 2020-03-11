﻿namespace TabbyCat.Models
{
    using TabbyCat.Controls.Types;

    public class Options
    {
        public string FilesFolderPath { get; set; }
        public string TemplatesFolderPath { get; set; }
        public bool OpenInNewWindow { get; set; }
        public TextStyleInfos SyntaxHighlightStyles { get; set; }
        public string GLSLUrl { get; set; }
    }
}
