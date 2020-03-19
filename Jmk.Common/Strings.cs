﻿namespace Jmk.Common
{
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class Strings
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

        public static int GetCharCount(this string s, char c)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            var n = 0;
            for (int p = -1; (p = s.IndexOf(c, p + 1)) >= 0; n++) ;
            return n;
        }

        public static int GetCharCount(this StringBuilder builder, char c) => builder.ToString().GetCharCount(c);
        public static int GetLineCount(this string s) => string.IsNullOrEmpty(s) ? 0 : s.GetCharCount('\n') + 1;
        public static int GetLineCount(this StringBuilder builder) => builder.ToString().GetLineCount();

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
            foreach (var c in Path.GetInvalidFileNameChars()) t.Replace(c, '_');
            s = t.ToString();
            return Regex.IsMatch(s, @"(^CON$|^PRN$|^AUX$|^CLOCK\$$|^NUL$|^COM[0-9]$|^LPT[0-9]$)",
                RegexOptions.IgnoreCase) ? s + "_" : s;
        }

        public static string ToTitleCase(this string s) =>
            s == string.Empty
            ? string.Empty
            : $"{char.ToUpper(s[0])}{s.ToLower().Substring(1)}";
    }
}