﻿namespace TabbyCat.CustomControls
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Forms;

    public partial class JmkFlagsCheckedListBox : CheckedListBox
    {
        public JmkFlagsCheckedListBox() => InitializeComponent();

        private Type _EnumType;
        private Enum _EnumValue;
        private bool Updating;

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public Enum EnumValue
        {
            get => (Enum)Enum.ToObject(_EnumType, GetCurrentValue());
            set
            {
                Items.Clear();
                _EnumValue = value;
                _EnumType = value?.GetType();
                Populate();
                Apply();
            }
        }

        public JmkFlagsCheckedListBoxItem Add(string text, int value) => Add(new JmkFlagsCheckedListBoxItem(text, value));

        public JmkFlagsCheckedListBoxItem Add(JmkFlagsCheckedListBoxItem item)
        {
            Items.Add(item);
            return item;
        }

        public int GetCurrentValue()
        {
            var result = 0;
            for (var index = 0; index < Items.Count; index++)
                if (GetItemChecked(index))
                    result |= ((JmkFlagsCheckedListBoxItem)Items[index]).Value;
            return result;
        }

        protected override void OnItemCheck(ItemCheckEventArgs e)
        {
            base.OnItemCheck(e);
            if (!Updating && e != null)
                UpdateItems((JmkFlagsCheckedListBoxItem)Items[e.Index], e.NewValue);
        }

        protected void UpdateItems(JmkFlagsCheckedListBoxItem item, CheckState state)
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

        protected void UpdateItems(int value)
        {
            Updating = true;
            for (var index = 0; index < Items.Count; index++)
            {
                var item = (JmkFlagsCheckedListBoxItem)Items[index];
                SetItemChecked(index, item.Value == 0
                    ? value == 0
                    : (item.Value & value) == item.Value && item.Value != 0);
            }
            Updating = false;
        }

        private void Apply() => UpdateItems(ChangeType(_EnumValue));

        private void Populate()
        {
            foreach (var name in Enum.GetNames(_EnumType))
                Add(name, ChangeType(Enum.Parse(_EnumType, name)));
        }

        private static int ChangeType(object value) => (int)Convert.ChangeType(value, typeof(int), CultureInfo.InvariantCulture);
    }
}