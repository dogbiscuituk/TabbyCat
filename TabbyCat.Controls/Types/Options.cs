namespace TabbyCat.Controls.Types
{
    public class Options
    {
        public Theme Theme { get; set; }
        public bool OpenInNewWindow { get; set; }
        public string FilesFolderPath { get; set; }
        public string TemplatesFolderPath { get; set; }
        public string GLSLPath { get; set; }
        public TextStyleInfos SyntaxHighlightStyles { get; set; }
    }
}
