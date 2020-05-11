namespace TabbyCat.CustomControls
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    public partial class JmkFlagsCheckedListBox : CheckedListBox
    {
        // Constructors

        public JmkFlagsCheckedListBox() => InitializeComponent();

        // Private fields

        private Type _enumType;
        private Enum _enumValue;
        private bool _updating;

        // Public properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Enum EnumValue
        {
            get => (Enum)Enum.ToObject(_enumType, GetCurrentValue());
            set
            {
                Items.Clear();
                _enumValue = value;
                _enumType = value?.GetType();
                Populate();
                Apply();
            }
        }

        // Protected methods

        protected override void OnItemCheck(ItemCheckEventArgs e)
        {
            base.OnItemCheck(e);
            if (!_updating && e != null)
                UpdateItems((JmkFlagsCheckedListBoxItem)Items[e.Index], e.NewValue);
        }

        protected override void WndProc(ref Message m)
        {
            this.FirstFocus(ref m);
            base.WndProc(ref m);
        }

        // Private methods

        private void Add(string text, int value) => Add(new JmkFlagsCheckedListBoxItem(text, value));

        private void Add(JmkFlagsCheckedListBoxItem item) => Items.Add(item);

        private void Apply() => UpdateItems(ChangeType(_enumValue));

        private int GetCurrentValue() =>
            Items.Cast<object>().Where((t, index) =>
                GetItemChecked(index)).Aggregate(0, (current, t) =>
                current | ((JmkFlagsCheckedListBoxItem)t).Value);

        private void Populate()
        {
            foreach (var name in Enum.GetNames(_enumType))
                Add(name, ChangeType(Enum.Parse(_enumType, name)));
        }

        private void UpdateItems(JmkFlagsCheckedListBoxItem item, CheckState state)
        {
            if (item == null)
                return;
            if (item.Value == 0)
                UpdateItems(0);
            var result = 0;
            for (var index = 0; index < Items.Count; index++)
                if (GetItemChecked(index))
                    result |= ((JmkFlagsCheckedListBoxItem)Items[index]).Value;
            if (state == CheckState.Unchecked)
                result &= ~item.Value;
            else
                result |= item.Value;
            UpdateItems(result);
        }

        private void UpdateItems(int value)
        {
            _updating = true;
            for (var index = 0; index < Items.Count; index++)
            {
                var item = (JmkFlagsCheckedListBoxItem)Items[index];
                SetItemChecked(index, item.Value == 0
                    ? value == 0
                    : (item.Value & value) == item.Value && item.Value != 0);
            }
            _updating = false;
        }

        // Private static methods

        private static int ChangeType(object value) => (int)Convert.ChangeType(value, typeof(int), CultureInfo.InvariantCulture);
    }
}
