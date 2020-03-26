namespace Jmk.Controls
{
    using System;
    using System.Windows.Forms;

    public partial class JmkCheckedListBox : CheckedListBox
    {
        #region Constructors

        public JmkCheckedListBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Fields, Properties, Events

        public event EventHandler SelectionChanged;

        private bool Control, Shift, Updating;
        private int PrevIndex = -1;

        #endregion

        #region Protected Methods

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            if (Updating)
                return;
            Updating = true;
            var thisIndex = ice.Index;
            if (!Control)
                for (var index = 0; index < Items.Count; index++)
                    if (index != thisIndex)
                        SetItemChecked(index, false);
            if (Shift && PrevIndex >= 0)
                for (var index = Math.Min(PrevIndex, thisIndex); index <= Math.Max(PrevIndex, thisIndex); index++)
                    SetItemChecked(index, true);
            else
            {
                SetItemChecked(thisIndex, true);
                PrevIndex = thisIndex;
            }
            OnSelectionChanged();
            Updating = false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            Control = e.Control;
            Shift = e.Shift;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            Control = Shift = false;
        }

        protected virtual void OnSelectionChanged() => SelectionChanged?.Invoke(this, EventArgs.Empty);

        protected override void WndProc(ref Message m)
        {
            this.FirstFocus(ref m);
            base.WndProc(ref m);
        }

        #endregion
    }
}
