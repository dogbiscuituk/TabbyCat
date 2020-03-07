﻿namespace TabbyCat.Models
{
    using TabbyCat.Controls;

    public class Options
    {
        public string FilesFolderPath { get; set; }
        public string TemplatesFolderPath { get; set; }
        public bool OpenInNewWindow { get; set; }
        public TextStyleInfos SyntaxHighlightStyles { get; set; }
    }
}
