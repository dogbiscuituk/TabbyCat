namespace Jmk.Controls
{
    public class JmkFlagsCheckedListBoxItem
    {
        public JmkFlagsCheckedListBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public int Value { get; set; }

        /// <summary>
        /// Is this a single bit flag?
        /// </summary>
        public bool IsFlag => (Value & (Value - 1)) == 0;

        /// <summary>
        /// Is this part of a flag set?
        /// </summary>
        /// <param name="flags">The flag set.</param>
        /// <returns>True if part of the flag set, otherwise false.</returns>
        public bool IsMemberFlag(JmkFlagsCheckedListBoxItem flags)
        {
            return IsFlag && (Value & flags?.Value) == Value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
