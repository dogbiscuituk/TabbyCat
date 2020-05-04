namespace Jmk.Controls
{
    using Jmk.Common;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public static class JmkControl
    {
        public static string CompactMenuText(this string text)
        {
            return Path.ChangeExtension(text, string.Empty).CompactText().AmpersandEscape();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://stackoverflow.com/questions/1764204/how-to-display-abbreviated-path-names-in-net
        /// "Important: Passing in a formatting option of TextFormatFlags.ModifyString actually causes
        /// the MeasureText method to alter the string argument[...] to be a compacted string. This
        /// seems very weird since no explicit ref or out method parameter keyword is specified and
        /// strings are immutable.However, its definitely the case. I assume the string's pointer was
        /// updated via unsafe code to the new compacted string." -- Sam.
        /// </remarks>
        public static string CompactText(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            string result = text.TrimEnd('.');
            TextRenderer.MeasureText(
                result, SystemFonts.MenuFont, new Size(320, 0),
                TextFormatFlags.PathEllipsis | TextFormatFlags.ModifyString);
            int length = result.IndexOf((char)0);
            if (length >= 0)
            {
                result = result.Substring(0, length);
            }

            return result;
        }

        public static void FirstFocus(this Control control, ref Message m)
        {
            const int WM_MOUSEACTIVATE = 0x21;
            if (m.Msg == WM_MOUSEACTIVATE && control != null && control.CanFocus && !control.Focused)
            {
                control.Focus();
            }
        }
    }
}
