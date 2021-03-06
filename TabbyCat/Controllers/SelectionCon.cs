﻿namespace TabbyCat.Controllers
{
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Utils;

    public class SelectionCon : LocalCon
    {
        // Constructors

        public SelectionCon(WorldCon worldCon) : base(worldCon) { }

        // Private fields

        private int _lastIndex = -1;

        private ToolStripLabel _prevLabel;

        private readonly Brush
            _highlight = Color.FromKnownColor(KnownColor.Highlight).ToSolidBrush(),
            _highlightText = Color.FromKnownColor(KnownColor.HighlightText).ToSolidBrush();

        private Font _highlightFont;

        // Public properties

        public List<int> Selection { get; private set; } = new List<int>();

        public int ShapeCount
        {
            get => Labels.Count - 1;
            set
            {
                var delta = value - ShapeCount;
                for (; delta > 0; delta--)
                    AddLabel();
                for (; delta < 0; delta++)
                    RemoveLabel();
                _lastIndex = -1;
            }
        }

        // Private properties

        private bool AllSelected => Selection.Count == ShapeCount;

        private ToolStripItemCollection Labels => Toolbar.Items;

        private Font HighlightFont => _highlightFont ?? (_highlightFont = new Font(Toolbar.Font, FontStyle.Bold));

        private ToolStrip Toolbar => ShapePropertiesCon.SelectionToolbar;

        // Public events

        public event EventHandler SelectionChanged;

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                Init();
                Toolbar.MouseMove += Toolbar_MouseMove;
            }
            else
                Toolbar.MouseMove -= Toolbar_MouseMove;
        }

        public void SetSelection(List<int> selection)
        {
            if (ToString(Selection) == ToString(selection))
                return;
            Selection = selection;
            OnSelectionChanged();
        }

        // Protected methods

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            _highlight?.Dispose();
            _highlightText?.Dispose();
            _highlightFont?.Dispose();
        }

        // Private methods

        private void AddLabel()
        {
            var label = new ToolStripLabel($"{ShapeCount + 1}");
            Labels.Add(label);
            label.MouseDown += Label_MouseDown;
            label.MouseMove += Label_MouseMove;
            label.Paint += Label_Paint;
        }

        private void ClearSelection() => Selection.Clear();

        private void Exclude(int shapeIndex)
        {
            if (Selection.Contains(shapeIndex))
                Selection.Remove(shapeIndex);
        }

        private void Include(int shapeIndex)
        {
            if (!Selection.Contains(shapeIndex))
                Selection.Add(shapeIndex);
        }

        private void IncludeRange(int low, int high)
        {
            if (low > high)
                IncludeRange(high, low);
            else
                do
                    Include(low++);
                while (low <= high);
        }

        private void Init()
        {
            Labels.Clear();
            var label = new ToolStripLabel(string.Empty);
            Localize(Resources.WorldForm_Shape_All, label);
            Labels.Add(label);
            label.MouseDown += LabelAll_MouseDown;
            label.MouseMove += Label_MouseMove;
            label.Paint += LabelAll_Paint;
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            var shapeIndex = Labels.IndexOf((ToolStripItem)sender) - 1;
            bool
                shift = (Control.ModifierKeys & Keys.Shift) != 0,
                ctrl = (Control.ModifierKeys & Keys.Control) != 0;
            if (!ctrl)
                ClearSelection();
            if (shift && _lastIndex >= 0)
                IncludeRange(_lastIndex, shapeIndex);
            else
            {
                if (ctrl)
                    Toggle(shapeIndex);
                else
                    Include(shapeIndex);
                _lastIndex = shapeIndex;
            }
            OnSelectionChanged();
        }

        private void Label_MouseMove(object sender, MouseEventArgs e) => MouseMove(sender);

        private void Label_Paint(object sender, PaintEventArgs e)
        {
            if (Selection.Contains(Labels.IndexOf((ToolStripItem)sender) - 1))
                Paint_Highlight(sender, e);
        }

        private void LabelAll_MouseDown(object sender, MouseEventArgs e)
        {
            if (AllSelected)
                ClearSelection();
            else
                SelectAll();
            OnSelectionChanged();
        }

        private void LabelAll_Paint(object sender, PaintEventArgs e)
        {
            if (ShapeCount > 0 && AllSelected)
                Paint_Highlight(sender, e);
        }

        private void MouseMove(object sender)
        {
            var label = (ToolStripLabel)sender;
            if (label == _prevLabel)
                return;
            _prevLabel = label;
            var index = Labels.IndexOf(label);
            var tooltip = index < 0
                ? string.Empty
                : index == 0
                ? Resources.Text_SelectDeselectAllShapes
                : ShapePropertiesCon.Scene.Shapes[index - 1].ToString();
            ToolTip.SetToolTip(Toolbar, tooltip);
        }

        private void OnSelectionChanged()
        {
            Toolbar.Invalidate();
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Paint_Highlight(object sender, PaintEventArgs e)
        {
            var item = (ToolStripItem)sender;
            var g = e.Graphics;
            g.FillRectangle(_highlight, 1, 1, item.Width - 2, item.Height - 1);
            g.DrawString(item.Text, HighlightFont, _highlightText, 1, 0);
        }

        private void RemoveLabel()
        {
            var label = Labels[ShapeCount];
            Labels.Remove(label);
            label.MouseDown -= Label_MouseDown;
            label.Paint -= Label_Paint;
        }

        private void SelectAll() => IncludeRange(0, ShapeCount - 1);

        private void Toggle(int shapeIndex)
        {
            if (Selection.Contains(shapeIndex))
                Exclude(shapeIndex);
            else
                Include(shapeIndex);
        }

        private void Toolbar_MouseMove(object sender, MouseEventArgs e) => MouseMove(Toolbar.GetItemAt(e.X, e.Y));

        // Private static methods

        private static string ToString(IEnumerable<int> items)
        {
            var ints = items as int[] ?? items.ToArray();
            return ints.Any()
                ? string.Concat(ints.OrderBy(p => p).Select(p => $"{p} "))
                : string.Empty;
        }
    }
}
