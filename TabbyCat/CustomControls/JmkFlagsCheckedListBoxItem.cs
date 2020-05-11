namespace TabbyCat.CustomControls
{
    public class JmkFlagsCheckedListBoxItem
    {
        public JmkFlagsCheckedListBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public int Value { get; }

        private string Text { get; }

        public override string ToString() => Text;
    }
}
