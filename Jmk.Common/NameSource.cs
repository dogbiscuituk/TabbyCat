namespace Jmk.Common
{
    using System.Collections.Generic;

    public static class NameSource
    {
        public static IEnumerable<string> Names => GetNames();

        private static IEnumerable<string> GetNames()
        {
            for (var n = 0; ; n++)
                yield return ToBase26(n);
        }

        private static string ToBase26(int n) => n < 26 ? $"{(char)('A' + n)}" : $"{ToBase26(n / 26 - 1)}{(char)('A' + n % 26)}";
    }
}
