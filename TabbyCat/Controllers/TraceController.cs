namespace TabbyCat.Controllers
{
    using Jmk.Common;
    using Jmk.Controls;
    using OpenTK;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controls;
    using TabbyCat.Models;
    using TabbyCat.Properties;

    internal class TraceController : ShaderSetController
    {
        #region Constructors

        internal TraceController(PropertiesController propertiesController)
            : base(propertiesController)
        {
            InitCommonControls(Editor.TableLayoutPanel);
            InitLocalControls();
        }

        #endregion

        #region Fields & Properties

        protected override string[] AllProperties => new[]
        {
            PropertyNames.Description,
            PropertyNames.Location,
            PropertyNames.Maximum,
            PropertyNames.Minimum,
            PropertyNames.Orientation,
            PropertyNames.Pattern,
            PropertyNames.Scale,
            PropertyNames.StripCount,
            PropertyNames.Visible
        };

        private TraceEdit Editor => WorldEdit.TraceEdit;
        private Selection Selection => WorldController.Selection;
        private bool SelectionUpdating;
        private JmkCheckedListBox TraceSelector => Editor.clbTraceSelector;

        #endregion

        #region Protected Internal Methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                UpdateAllProperties();
                Editor.edDescription.TextChanged += Description_TextChanged;
                Editor.seLocationX.ValueChanged += LocationX_ValueChanged;
                Editor.seLocationY.ValueChanged += LocationY_ValueChanged;
                Editor.seLocationZ.ValueChanged += LocationZ_ValueChanged;
                Editor.seOrientationX.ValueChanged += OrientationX_ValueChanged;
                Editor.seOrientationY.ValueChanged += OrientationY_ValueChanged;
                Editor.seOrientationZ.ValueChanged += OrientationZ_ValueChanged;
                Editor.seScaleX.ValueChanged += ScaleX_ValueChanged;
                Editor.seScaleY.ValueChanged += ScaleY_ValueChanged;
                Editor.seScaleZ.ValueChanged += ScaleZ_ValueChanged;
                Editor.cbPattern.SelectedValueChanged += Pattern_SelectedValueChanged;
                Editor.seMinimumX.ValueChanged += MinimumX_ValueChanged;
                Editor.seMinimumY.ValueChanged += MinimumY_ValueChanged;
                Editor.seMinimumZ.ValueChanged += MinimumZ_ValueChanged;
                Editor.seMaximumX.ValueChanged += MaximumX_ValueChanged;
                Editor.seMaximumY.ValueChanged += MaximumY_ValueChanged;
                Editor.seMaximumZ.ValueChanged += MaximumZ_ValueChanged;
                Editor.seStripCountX.ValueChanged += StripCountX_ValueChanged;
                Editor.seStripCountY.ValueChanged += StripCountY_ValueChanged;
                Editor.seStripCountZ.ValueChanged += StripCountZ_ValueChanged;
                Editor.cbVisible.CheckedChanged += Visible_CheckedChanged;
                TraceSelector.MouseInItem += TraceSelector_MouseInItem;
                TraceSelector.SelectionChanged += TraceSelector_SelectionChanged;
            }
            else
            {
                Editor.edDescription.TextChanged -= Description_TextChanged;
                Editor.seLocationX.ValueChanged -= LocationX_ValueChanged;
                Editor.seLocationY.ValueChanged -= LocationY_ValueChanged;
                Editor.seLocationZ.ValueChanged -= LocationZ_ValueChanged;
                Editor.seOrientationX.ValueChanged -= OrientationX_ValueChanged;
                Editor.seOrientationY.ValueChanged -= OrientationY_ValueChanged;
                Editor.seOrientationZ.ValueChanged -= OrientationZ_ValueChanged;
                Editor.seScaleX.ValueChanged -= ScaleX_ValueChanged;
                Editor.seScaleY.ValueChanged -= ScaleY_ValueChanged;
                Editor.seScaleZ.ValueChanged -= ScaleZ_ValueChanged;
                Editor.cbPattern.SelectedValueChanged -= Pattern_SelectedValueChanged;
                Editor.seMinimumX.ValueChanged -= MinimumX_ValueChanged;
                Editor.seMinimumY.ValueChanged -= MinimumY_ValueChanged;
                Editor.seMinimumZ.ValueChanged -= MinimumZ_ValueChanged;
                Editor.seMaximumX.ValueChanged -= MaximumX_ValueChanged;
                Editor.seMaximumY.ValueChanged -= MaximumY_ValueChanged;
                Editor.seMaximumZ.ValueChanged -= MaximumZ_ValueChanged;
                Editor.seStripCountX.ValueChanged -= StripCountX_ValueChanged;
                Editor.seStripCountY.ValueChanged -= StripCountY_ValueChanged;
                Editor.seStripCountZ.ValueChanged -= StripCountZ_ValueChanged;
                Editor.cbVisible.CheckedChanged -= Visible_CheckedChanged;
                TraceSelector.MouseInItem -= TraceSelector_MouseInItem;
                TraceSelector.SelectionChanged -= TraceSelector_SelectionChanged;
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectionChanged()
        {
            $"Selection = {{{Selection}}}".Spit();
            base.OnSelectionChanged();
            UpdateAllProperties();
            CopySelectionToControl();
        }

        protected override void UpdateProperties(params string[] propertyNames)
        {
            if (Updating)
                return;
            Updating = true;
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case PropertyNames.Description:
                        Editor.edDescription.Text = Selection.Description;
                        break;
                    case PropertyNames.Location:
                        Editor.seLocationX.Value = (decimal)Selection.Location.X;
                        Editor.seLocationY.Value = (decimal)Selection.Location.Y;
                        Editor.seLocationZ.Value = (decimal)Selection.Location.Z;
                        break;
                    case PropertyNames.Maximum:
                        Editor.seMaximumX.Value = (decimal)Selection.Maximum.X;
                        Editor.seMaximumY.Value = (decimal)Selection.Maximum.Y;
                        Editor.seMaximumZ.Value = (decimal)Selection.Maximum.Z;
                        break;
                    case PropertyNames.Minimum:
                        Editor.seMinimumX.Value = (decimal)Selection.Minimum.X;
                        Editor.seMinimumY.Value = (decimal)Selection.Minimum.Y;
                        Editor.seMinimumZ.Value = (decimal)Selection.Minimum.Z;
                        break;
                    case PropertyNames.Orientation:
                        Editor.seOrientationX.Value = (decimal)Selection.Orientation.X;
                        Editor.seOrientationY.Value = (decimal)Selection.Orientation.Y;
                        Editor.seOrientationZ.Value = (decimal)Selection.Orientation.Z;
                        break;
                    case PropertyNames.Pattern:
                        Editor.cbPattern.SelectedItem = Selection.Pattern;
                        break;
                    case PropertyNames.Scale:
                        Editor.seScaleX.Value = (decimal)Selection.Scale.X;
                        Editor.seScaleY.Value = (decimal)Selection.Scale.Y;
                        Editor.seScaleZ.Value = (decimal)Selection.Scale.Z;
                        break;
                    case PropertyNames.StripCount:
                        Editor.seStripCountX.Value = (decimal)Selection.StripCount.X;
                        Editor.seStripCountY.Value = (decimal)Selection.StripCount.Y;
                        Editor.seStripCountZ.Value = (decimal)Selection.StripCount.Z;
                        break;
                    case PropertyNames.Traces:
                        InitSelector();
                        break;
                    case PropertyNames.Visible:
                        Editor.cbVisible.CheckState = GetCheckState(Selection.Visible);
                        break;
                }
            Updating = false;
        }

        #endregion

        #region Private Event Handlers

        private void Description_TextChanged(object sender, System.EventArgs e) =>
            Run(p => new DescriptionCommand(p.Index, Editor.edDescription.Text));

        private void LocationX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new LocationCommand(p.Index, new Vector3(
                (float)Editor.seLocationX.Value,
                p.Location.Y,
                p.Location.Z)));

        private void LocationY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new LocationCommand(p.Index, new Vector3(
                p.Location.X,
                (float)Editor.seLocationY.Value,
                p.Location.Z)));

        private void LocationZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new LocationCommand(p.Index, new Vector3(
                p.Location.X,
                p.Location.Y,
                (float)Editor.seLocationZ.Value)));

        private void MaximumX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MaximumCommand(p.Index, new Vector3(
                (float)Editor.seMaximumX.Value,
                p.Maximum.Y,
                p.Maximum.Z)));

        private void MaximumY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MaximumCommand(p.Index, new Vector3(
                p.Maximum.X,
                (float)Editor.seMaximumY.Value,
                p.Maximum.Z)));

        private void MaximumZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MaximumCommand(p.Index, new Vector3(
                p.Maximum.X,
                p.Maximum.Y,
                (float)Editor.seMaximumZ.Value)));

        private void MinimumX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MinimumCommand(p.Index, new Vector3(
                (float)Editor.seMinimumX.Value,
                p.Minimum.Y,
                p.Minimum.Z)));

        private void MinimumY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MinimumCommand(p.Index, new Vector3(
                p.Minimum.X,
                (float)Editor.seMinimumY.Value,
                p.Minimum.Z)));

        private void MinimumZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MinimumCommand(p.Index, new Vector3(
                p.Minimum.X,
                p.Minimum.Y,
                (float)Editor.seMinimumZ.Value)));

        private void OrientationX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p.Index, new Vector3(
                (float)Editor.seOrientationX.Value,
                p.Orientation.Y,
                p.Orientation.Z)));

        private void OrientationY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p.Index, new Vector3(
                p.Orientation.X,
                (float)Editor.seOrientationY.Value,
                p.Orientation.Z)));

        private void OrientationZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p.Index, new Vector3(
                p.Orientation.X,
                p.Orientation.Y,
                (float)Editor.seOrientationZ.Value)));

        private void Pattern_SelectedValueChanged(object sender, System.EventArgs e) =>
            Run(p => new PatternCommand(p.Index, (Pattern)Editor.cbPattern.SelectedItem));

        private void ScaleX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new ScaleCommand(p.Index, new Vector3(
                (float)Editor.seScaleX.Value,
                p.Scale.Y,
                p.Scale.Z)));

        private void ScaleY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new ScaleCommand(p.Index, new Vector3(
                p.Scale.X,
                (float)Editor.seScaleY.Value,
                p.Scale.Z)));

        private void ScaleZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new ScaleCommand(p.Index, new Vector3(
                p.Scale.X,
                p.Scale.Y,
                (float)Editor.seScaleZ.Value)));

        private void StripCountX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new StripCountCommand(p.Index, new Vector3(
                (float)Editor.seStripCountX.Value,
                p.StripCount.Y,
                p.StripCount.Z)));

        private void StripCountY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new StripCountCommand(p.Index, new Vector3(
                p.StripCount.X,
                (float)Editor.seStripCountY.Value,
                p.StripCount.Z)));

        private void StripCountZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new StripCountCommand(p.Index, new Vector3(
                p.StripCount.X,
                p.StripCount.Y,
                (float)Editor.seStripCountZ.Value)));

        private void TraceSelector_MouseInItem(object sender, ItemCheckEventArgs e) =>
            SetToolTip(TraceSelector, e.Index < 0 ? string.Empty : Scene.Traces[e.Index].ToString());

        private void TraceSelector_SelectionChanged(object sender, EventArgs e) =>
            CopySelectionFromControl();

        private void Visible_CheckedChanged(object sender, EventArgs e) =>
            Run(p => new VisibleCommand(p.Index, Editor.cbVisible.Checked));

        #endregion

        #region Private Methods

        private void CopySelectionFromControl()
        {
            if (SelectionUpdating)
                return;
            SelectionUpdating = true;
            Selection.Set(TraceSelector.CheckedIndices.Cast<int>().Select(p => Scene.Traces[p]));
            SelectionUpdating = false;
        }

        private void CopySelectionToControl()
        {
            if (SelectionUpdating)
                return;
            SelectionUpdating = true;
            TraceSelector.SetCheckedIndices(Selection.Select(p => p.Index).ToList());
            SelectionUpdating = false;
        }

        private static CheckState GetCheckState(bool? input)
        {
            switch (input)
            {
                case true:
                    return CheckState.Checked;
                case false:
                    return CheckState.Unchecked;
                default:
                    return CheckState.Indeterminate;
            }
        }

        private void InitLocalControls()
        {
            InitToolTips();
            Editor.seStripCountX.Minimum =
            Editor.seStripCountY.Minimum =
            Editor.seStripCountZ.Minimum = 0;
            Editor.cbPattern.Items.AddRange(Enum.GetValues(typeof(Pattern)).Cast<object>().ToArray());
        }

        private void InitSelector()
        {
            TraceSelector.BeginUpdate();
            var items = TraceSelector.Items;
            var traces = Scene.Traces;
            while (items.Count > traces.Count)
                items.RemoveAt(traces.Count);
            while (items.Count < traces.Count)
                items.Add(string.Empty);
            TraceSelector.EndUpdate();
        }

        private void InitToolTips()
        {
            SetToolTip(Editor.edDescription, Resources.Trace_Description);
            SetToolTip(Editor.seLocationX, Resources.Trace_LocationX);
            SetToolTip(Editor.seLocationY, Resources.Trace_LocationY);
            SetToolTip(Editor.seLocationZ, Resources.Trace_LocationZ);
            SetToolTip(Editor.seMaximumX, Resources.Trace_MaximumX);
            SetToolTip(Editor.seMaximumY, Resources.Trace_MaximumY);
            SetToolTip(Editor.seMaximumZ, Resources.Trace_MaximumZ);
            SetToolTip(Editor.seMinimumX, Resources.Trace_MinimumX);
            SetToolTip(Editor.seMinimumY, Resources.Trace_MinimumY);
            SetToolTip(Editor.seMinimumZ, Resources.Trace_MinimumZ);
            SetToolTip(Editor.seOrientationX, Resources.Trace_OrientationX);
            SetToolTip(Editor.seOrientationY, Resources.Trace_OrientationY);
            SetToolTip(Editor.seOrientationZ, Resources.Trace_OrientationZ);
            SetToolTip(Editor.cbPattern, Resources.Trace_Pattern);
            SetToolTip(Editor.seScaleX, Resources.Trace_ScaleX);
            SetToolTip(Editor.seScaleY, Resources.Trace_ScaleY);
            SetToolTip(Editor.seScaleZ, Resources.Trace_ScaleZ);
            SetToolTip(Editor.seStripCountX, Resources.Trace_StripCountX);
            SetToolTip(Editor.seStripCountY, Resources.Trace_StripCountY);
            SetToolTip(Editor.seStripCountZ, Resources.Trace_StripCountZ);
            SetToolTip(Editor.cbVisible, Resources.Trace_Visible);
        }

        private void Run(Func<Trace, ICommand> command)
        {
            if (Updating || !Selection.Any())
                return;
            Updating = true;
            Selection.ForEach(p => CommandProcessor.Run(command(p)));
            Updating = false;
        }

        #endregion
    }
}
