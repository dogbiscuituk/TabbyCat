namespace Jmk.Controls
{
    public class JmkFlagsCheckedListBoxItem
    {
        #region Constructors

        public JmkFlagsCheckedListBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        #endregion

        #region Public Properties

        public string Text { get; set; }
        public int Value { get; set; }

        #endregion

        #region Public Methods

        public override string ToString() => Text;

        #endregion

        /// <summary>
        /// Is this a single bit flag?
        /// </summary>
        public bool IsFlag => (Value & (Value - 1)) == 0;

        /// <summary>
        /// Is this part of a flag set?
        /// </summary>
        /// <param name="flags">The flag set.</param>
        /// <returns>True if part of the flag set, otherwise false.</returns>
        public bool IsMemberFlag(JmkFlagsCheckedListBoxItem flags) =>
            IsFlag && (Value & flags?.Value) == Value;
    }
}
