namespace TabbyCat.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    internal class SelectionController
    {
        #region Constructor

        internal SelectionController(TraceController traceController) => TraceController = traceController;

        #endregion

        #region Internal Fields

        internal readonly List<int> Selection = new List<int>();

        #endregion

        #region Internal Properties

        internal int Count
        {
            get => Labels.Count;
            set
            {
                var delta = value - Count;
                for (; delta > 0; delta--) AddLabel();
                for (; delta < 0; delta++) RemoveLabel();
            }
        }

        internal ToolStripItemCollection Labels => Toolbar.Items;

        #endregion

        #region Internal Events

        internal event EventHandler SelectionChanged;

        #endregion

        #region Private Fields

        private readonly TraceController TraceController;

        #endregion

        #region Private Properties

        private ToolStrip Toolbar => TraceController.SelectionToolbar;

        #endregion

        #region Private Event Handlers

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            var label = sender as ToolStripLabel;
            Selection.Clear();
            Selection.Add(Labels.IndexOf(label));
            OnSelectionChanged();
        }

        private void Label_Paint(object sender, PaintEventArgs e)
        {
            var label = sender as ToolStripLabel;
            if (Selection.Contains(Labels.IndexOf(label)))
                e.Graphics.DrawRectangle(Pens.Black, 0, 0, label.Width - 2, label.Height - 1);
        }

        #endregion

        #region Private Methods

        private void AddLabel()
        {
            var label = new ToolStripLabel($"{Count}");
            Labels.Add(label);
            label.MouseDown += Label_MouseDown;
            label.Paint += Label_Paint;
        }

        private void OnSelectionChanged()
        {
            Toolbar.Invalidate();
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void RemoveLabel()
        {
            var label = Labels[Count - 1];
            Labels.Remove(label);
            label.MouseDown -= Label_MouseDown;
            label.Paint -= Label_Paint;
        }

        #endregion
    }
}
