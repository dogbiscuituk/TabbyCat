namespace TabbyCat.Types
{
    public static class Tokens
    {
        public const string
            BeginFormula = "// Begin Formula",
            BeginScene = "// Begin Scene",
            EndFormula = "// End Formula",
            EndScene = "// End Scene";

        public static string BeginShape(int index) => $"// Begin Shape #{index + 1}";

        public static string EndShape(int index) => $"// End Shape #{index + 1}";
    }
}
