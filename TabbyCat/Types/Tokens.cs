namespace TabbyCat.Types
{
    public static class Tokens
    {
        public const string
            BeginFormula = "// Begin Formula",
            BeginScene = "// Begin Scene",
            EndFormula = "// End Formula",
            EndScene = "// End Scene";

        public static string BeginTrace(int index) => $"// Begin Trace #{index + 1}";

        public static string EndTrace(int index) => $"// End Trace #{index + 1}";
    }
}
