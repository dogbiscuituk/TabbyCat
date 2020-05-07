namespace TabbyCat.Utils
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringUtils
    {
        /// <summary>
        /// Convert a string, potentially containing ampersands, for use in an
        /// accelerator-enabled UI context (label text, menu item caption, etc).
        /// </summary>
        /// <param name="s">The input string</param>
        /// <returns>The input string with all ampersands escaped (doubled up).</returns>
        public static string AmpersandEscape(this string s) => s?.Replace("&", "&&");

        /// <summary>
        /// Convert a string, obtained from an accelerator-enabled UI context
        /// (label text, menu item caption, etc) and potentially containing double
        /// ampersands, for use in other contexts.
        /// </summary>
        /// <param name="s">The string obtained from the UI context.</param>
        /// <returns>The input string with all escaped (doubled) ampersands unescaped.</returns>
        public static string AmpersandUnescape(this string s) => s?.Replace("&&", "&");

        /// <summary>
        /// Find which line of a multiline text string contains the first occurrence of a given token.
        /// </summary>
        /// <param name="s">The given multiline text string.</param>
        /// <param name="t">The token to search for.</param>
        /// <returns>The zero-based index of the line containing the first occurrence of the given token.</returns>
        public static int FindFirstTokenLine(this string s, string t) => s == null ? -1 : s.Substring(0, s.IndexOf(t, StringComparison.InvariantCulture)).GetLineCount() - 1;

        /// <summary>
        /// Get the number of occurrences of a given character in a string.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <param name="c">The character to count.</param>
        /// <returns>The number of occurrences of the given character in the string.</returns>
        public static int GetCharCount(this string s, char c) => string.IsNullOrEmpty(s) ? 0 : s.Count(p => p == c);

        /// <summary>
        /// Find the position of the nth occurrence of a character in a string.
        /// </summary>
        /// <param name="s">The source text string.</param>
        /// <param name="c">The character to search for.</param>
        /// <param name="index">The occurrence to seek (zero = first occurrence).</param>
        /// <returns>An integer indicating the position of the found occurrence of the given character,
        /// or -1 if the string contains fewer than (index + 1) occurrences of that character.</returns>
        public static int GetCharPos(this string s, char c, int index)
        {
            if (string.IsNullOrEmpty(s) || index < 0)
                return -1;
            int p;
            for (p = -1; (p = s.IndexOf(c, p + 1)) >= 0 && --index >= 0;) ;
            return p;
        }

        /// <summary>
        /// Get the number of lines in a multiline text string.
        /// </summary>
        /// <param name="s">The multiline text string.</param>
        /// <returns>The number of lines in the multiline text string.
        /// Empty lines are included in the count, but the empty string itself returns zero.</returns>
        public static int GetLineCount(this string s) => string.IsNullOrEmpty(s) ? 0 : s.GetCharCount('\n') + 1;

        /// <summary>
        /// Find the position within a multiline text string where a particular line begins.
        /// </summary>
        /// <param name="s">The multiline text string.</param>
        /// <param name="line">The zero-based index of the required line.</param>
        /// <returns>The position within the multiline text string where the specified line begins.</returns>
        public static int GetLinePos(this string s, int line)
        {
            if (line < 0)
                return -1;
            var index = $"\n{s}".GetCharPos('\n', line);
            return index >= 0 ? index : -1;
        }

        /// <summary>
        /// Return the minimum substring of a given multiline text string containing a given range of lines.
        /// </summary>
        /// <param name="s">The multiline text string.</param>
        /// <param name="first">The zero-based index of the first required line.</param>
        /// <param name="count">The number of lines required.</param>
        /// <returns>The minimum substring of a given multiline text string containing the given range of lines.
        /// Note that leading and trailing whitespace, including blank lines, will be trimmed from the result.</returns>
        public static string GetLines(this string s, int first, int count)
        {
            if (s == null)
                return null;
            var start = s.GetLinePos(first);
            if (start < 0)
                return string.Empty;
            var end = s.GetLinePos(first + count);
            if (end < start)
                end = s.Length;
            return s.Substring(start, end - start).Trim();
        }

        public static string Indent(this string s, string indent) => $"\n{s}"?.Replace("\n", $"\n{indent}").Substring(1);

        public static string Outdent(this string s, string indent) => $"\n{s}"?.Replace($"\n{indent}", "\n").Substring(1);

        /// <summary>
        /// Make a legal file name from a given string which may contain prohibited
        /// characters or substrings.
        /// 
        /// https://docs.microsoft.com/en-us/windows/desktop/fileio/naming-a-file
        /// 
        /// Do not assume case sensitivity. Use any character in the current code page
        /// for a name, including Unicode characters and characters in the extended
        /// character set (128–255), except for the following: <>:"/\|?*
        /// 
        /// Do not use the following reserved names for the name of a file:
        /// CON PRN AUX CLOCK$ NUL COM# LPT# (where # is a digit, 0..9).
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToFilename(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;
            var t = new StringBuilder(s.Trim());
            t.Replace('.', ',');
            foreach (var c in Path.GetInvalidFileNameChars())
                t.Replace(c, '_');
            s = t.ToString();
            return Regex.IsMatch(s, @"(^CON$|^PRN$|^AUX$|^CLOCK\$$|^NUL$|^COM[0-9]$|^LPT[0-9]$)",
                RegexOptions.IgnoreCase) ? s + "_" : s;
        }

        /// <summary>
        /// Capitalize the first character of a string.
        /// </summary>
        /// <param name="s">The input string.</param>
        /// <returns>A copy of the input string with the first character capitalized.</returns>
        public static string ToTitleCase(this string s) => string.IsNullOrWhiteSpace(s)
            ? string.Empty
            : $"{char.ToUpper(s[0], CultureInfo.CurrentCulture)}{s.ToLower(CultureInfo.CurrentCulture).Substring(1)}";
    }
}
