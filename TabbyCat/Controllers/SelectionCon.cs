﻿namespace TabbyCat.Controllers
{
    using Jmk.Common;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Properties;

    internal class SelectionCon : LocalizationCon
    {
        internal SelectionCon(WorldCon worldCon)
            : base(worldCon)
        { }

        private int LastIndex = -1;

        private ToolStripLabel PrevLabel;

        private List<int> _Selection = new List<int>();

        private readonly Brush
            Highlight = Color.FromKnownColor(KnownColor.Highlight).ToBrush(),
            HighlightText = Color.FromKnownColor(KnownColor.HighlightText).ToBrush();

        private Font _HighlightFont;

        internal List<int> Selection
        {
            get => _Selection;
            set
            {
                if (ToString(Selection) == ToString(value))
                    return;
                _Selection = value;
                OnSelectionChanged();
            }
        }

        internal ToolStripItemCollection Labels => Toolbar.Items;

        internal int TraceCount
        {
            get => Labels.Count - 1;
            set
            {
                var delta = value - TraceCount;
                for (; delta > 0; delta--) AddLabel();
                for (; delta < 0; delta++) RemoveLabel();
                LastIndex = -1;
            }
        }

        private bool AllSelected => Selection.Count == TraceCount;

        private Font HighlightFont => _HighlightFont ??
            (_HighlightFont = new Font(Toolbar.Font, FontStyle.Bold));

        private ToolStrip Toolbar => TraceCon.SelectionToolbar;

        internal event EventHandler SelectionChanged;

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                Init();
                Toolbar.MouseMove += Toolbar_MouseMove;
            }
            else
            {
                Toolbar.MouseMove -= Toolbar_MouseMove;
            }
        }

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            Highlight?.Dispose();
            HighlightText?.Dispose();
            _HighlightFont?.Dispose();
        }

        private void AddLabel()
        {
            var traceIndex = TraceCount;
            var label = new ToolStripLabel($"{TraceCount + 1}");
            Labels.Add(label);
            label.MouseDown += Label_MouseDown;
            label.MouseMove += Label_MouseMove;
            label.Paint += Label_Paint;
        }

        private void ClearSelection() => _Selection.Clear();

        private void Exclude(int traceIndex)
        {
            if (_Selection.Contains(traceIndex))
                _Selection.Remove(traceIndex);
        }

        private void Include(int traceIndex)
        {
            if (!_Selection.Contains(traceIndex))
                _Selection.Add(traceIndex);
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
            Localize(Resources.Menu_Trace_All, label);
            Labels.Add(label);
            label.MouseDown += LabelAll_MouseDown;
            label.MouseMove += Label_MouseMove;
            label.Paint += LabelAll_Paint;
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
            if (TraceCount > 0 && AllSelected)
                Paint_Highlight(sender, e);
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            var traceIndex = Labels.IndexOf(sender as ToolStripItem) - 1;
            bool
                shift = (Control.ModifierKeys & Keys.Shift) != 0,
                ctrl = (Control.ModifierKeys & Keys.Control) != 0;
            if (!ctrl)
                ClearSelection();
            if (shift && LastIndex >= 0)
                IncludeRange(LastIndex, traceIndex);
            else
            {
                if (ctrl)
                    Toggle(traceIndex);
                else
                    Include(traceIndex);
                LastIndex = traceIndex;
            }
            OnSelectionChanged();
        }

        private void Label_MouseMove(object sender, MouseEventArgs e) => MouseMove(sender);

        private void Label_Paint(object sender, PaintEventArgs e)
        {
            if (_Selection.Contains(Labels.IndexOf((ToolStripItem)sender) - 1))
                Paint_Highlight(sender, e);
        }

        private void MouseMove(object sender)
        {
            var label = sender as ToolStripLabel;
            if (label == PrevLabel)
                return;
            PrevLabel = label;
            var index = Labels.IndexOf(label);
            var
                tooltip = index < 0
                ? string.Empty
                : index == 0
                ? Resources.Text_SelectDeselectAllTraces
                : TraceCon.Scene.Traces[index - 1].ToString();
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
            g.FillRectangle(Highlight, 1, 1, item.Width - 2, item.Height - 1);
            g.DrawString(item.Text, HighlightFont, HighlightText, 1, 0);
        }

        private void RemoveLabel()
        {
            var label = Labels[TraceCount];
            Labels.Remove(label);
            label.MouseDown -= Label_MouseDown;
            label.Paint -= Label_Paint;
        }

        private void SelectAll() => IncludeRange(0, TraceCount - 1);

        private void Toolbar_MouseMove(object sender, MouseEventArgs e) => MouseMove(Toolbar.GetItemAt(e.X, e.Y));

        private void Toggle(int traceIndex)
        {
            if (_Selection.Contains(traceIndex))
                Exclude(traceIndex);
            else
                Include(traceIndex);
        }

        private static string ToString(IEnumerable<int> items) =>
            items == null || !items.Any()
            ? string.Empty
            : string.Concat(items.OrderBy(p => p).Select(p => $"{p} "));
    }
}