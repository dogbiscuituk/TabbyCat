namespace Jmk.Common
{
    using System.Collections.Generic;

    public static class NameSource
    {
        /// <summary>
        /// Return the full list of alphabetical names, starting with "A" to "Z", then "AA" to "ZZ", "AAA" to "ZZZ", etc.
        /// This is similar to the problem of representing all natural numbers in the form "0" to "9", "10" to "99", "100" to "999", etc,
        /// and can be implemented using almost the same algorithm, replacing 0, 1, 2, ... 9 with A, B, C, ... Z, with one exception.
        /// In the case of numbers, the only allowed representation having a leading zero is "0" itself.
        /// By contrast, these names can be prefixed with any number of leading "A", resulting in another new, unique name.
        /// The impact of this in the implementation is the surprise appearance of a "-1" in the body of the ToName() method.
        /// </summary>
        public static IEnumerable<string> Names => GetNames();

        private static IEnumerable<string> GetNames()
        {
            for (var n = 0; ; n++)
            {
                yield return ToName(n);
            }
        }

        private static string ToName(int n) => n < 26 ? $"{(char)('A' + n)}" : $"{ToName(n / 26 - 1)}{(char)('A' + n % 26)}";
    }
}
