namespace TabbyCat.Controllers
{
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
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal partial class TraceController : ShaderSetController
    {
        internal TraceController(WorldController worldController) : base(worldController)
        {
            SelectionController = new SelectionController(worldController);
            InitCommonControls(TraceEdit.TableLayoutPanel);
            InitLocalControls();
        }

        private TraceForm _TraceForm;

        private readonly SelectionController SelectionController;
        private bool SelectionUpdating;

        protected internal override DockContent Form => TraceForm;

        protected override TraceForm TraceForm => _TraceForm ?? (_TraceForm = new TraceForm
        {
            TabText = Resources.TraceForm_TabText,
            Text = Resources.TraceForm_Text,
            ToolTipText = Resources.TraceForm_Text
        });

        internal ToolStrip SelectionToolbar => TraceEdit.SelectionToolbar;

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

        private TraceSelection Selection => WorldController.Selection;

        private TraceEdit TraceEdit => TraceForm.TraceEdit;

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                UpdateAllProperties();
                TraceEdit.edDescription.TextChanged += Description_TextChanged;
                TraceEdit.seLocationX.ValueChanged += LocationX_ValueChanged;
                TraceEdit.seLocationY.ValueChanged += LocationY_ValueChanged;
                TraceEdit.seLocationZ.ValueChanged += LocationZ_ValueChanged;
                TraceEdit.sePitch.ValueChanged += OrientationX_ValueChanged;
                TraceEdit.seYaw.ValueChanged += OrientationY_ValueChanged;
                TraceEdit.seRoll.ValueChanged += OrientationZ_ValueChanged;
                TraceEdit.seScaleX.ValueChanged += ScaleX_ValueChanged;
                TraceEdit.seScaleY.ValueChanged += ScaleY_ValueChanged;
                TraceEdit.seScaleZ.ValueChanged += ScaleZ_ValueChanged;
                TraceEdit.cbPattern.SelectedValueChanged += Pattern_SelectedValueChanged;
                TraceEdit.seMinimumX.ValueChanged += MinimumX_ValueChanged;
                TraceEdit.seMinimumY.ValueChanged += MinimumY_ValueChanged;
                TraceEdit.seMinimumZ.ValueChanged += MinimumZ_ValueChanged;
                TraceEdit.seMaximumX.ValueChanged += MaximumX_ValueChanged;
                TraceEdit.seMaximumY.ValueChanged += MaximumY_ValueChanged;
                TraceEdit.seMaximumZ.ValueChanged += MaximumZ_ValueChanged;
                TraceEdit.seStripCountX.ValueChanged += StripCountX_ValueChanged;
                TraceEdit.seStripCountY.ValueChanged += StripCountY_ValueChanged;
                TraceEdit.seStripCountZ.ValueChanged += StripCountZ_ValueChanged;
                TraceEdit.cbVisible.CheckedChanged += Visible_CheckedChanged;
                SelectionController.SelectionChanged += Selection_Changed;
            }
            else
            {
                TraceEdit.edDescription.TextChanged -= Description_TextChanged;
                TraceEdit.seLocationX.ValueChanged -= LocationX_ValueChanged;
                TraceEdit.seLocationY.ValueChanged -= LocationY_ValueChanged;
                TraceEdit.seLocationZ.ValueChanged -= LocationZ_ValueChanged;
                TraceEdit.sePitch.ValueChanged -= OrientationX_ValueChanged;
                TraceEdit.seYaw.ValueChanged -= OrientationY_ValueChanged;
                TraceEdit.seRoll.ValueChanged -= OrientationZ_ValueChanged;
                TraceEdit.seScaleX.ValueChanged -= ScaleX_ValueChanged;
                TraceEdit.seScaleY.ValueChanged -= ScaleY_ValueChanged;
                TraceEdit.seScaleZ.ValueChanged -= ScaleZ_ValueChanged;
                TraceEdit.cbPattern.SelectedValueChanged -= Pattern_SelectedValueChanged;
                TraceEdit.seMinimumX.ValueChanged -= MinimumX_ValueChanged;
                TraceEdit.seMinimumY.ValueChanged -= MinimumY_ValueChanged;
                TraceEdit.seMinimumZ.ValueChanged -= MinimumZ_ValueChanged;
                TraceEdit.seMaximumX.ValueChanged -= MaximumX_ValueChanged;
                TraceEdit.seMaximumY.ValueChanged -= MaximumY_ValueChanged;
                TraceEdit.seMaximumZ.ValueChanged -= MaximumZ_ValueChanged;
                TraceEdit.seStripCountX.ValueChanged -= StripCountX_ValueChanged;
                TraceEdit.seStripCountY.ValueChanged -= StripCountY_ValueChanged;
                TraceEdit.seStripCountZ.ValueChanged -= StripCountZ_ValueChanged;
                TraceEdit.cbVisible.CheckedChanged -= Visible_CheckedChanged;
                SelectionController.SelectionChanged -= Selection_Changed;
            }
            SelectionController.Connect(connect);
        }

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            SelectionController?.Dispose();
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.Control_Trace_Description, TraceEdit.lblDescription, TraceEdit.edDescription);
            Localize(Resources.Control_Trace_Location, TraceEdit.lblLocation);
            Localize(Resources.Control_Trace_LocationX, TraceEdit.seLocationX);
            Localize(Resources.Control_Trace_LocationY, TraceEdit.seLocationY);
            Localize(Resources.Control_Trace_LocationZ, TraceEdit.seLocationZ);
            Localize(Resources.Control_Trace_Orientation, TraceEdit.lblOrientation);
            Localize(Resources.Control_Trace_Pitch, TraceEdit.sePitch);
            Localize(Resources.Control_Trace_Yaw, TraceEdit.seYaw);
            Localize(Resources.Control_Trace_Roll, TraceEdit.seRoll);
            Localize(Resources.Control_Trace_Scale, TraceEdit.lblScale);
            Localize(Resources.Control_Trace_ScaleX, TraceEdit.seScaleX);
            Localize(Resources.Control_Trace_ScaleY, TraceEdit.seScaleY);
            Localize(Resources.Control_Trace_ScaleZ, TraceEdit.seScaleZ);
            Localize(Resources.Control_Trace_Minimum, TraceEdit.lblMinimum);
            Localize(Resources.Control_Trace_MinimumX, TraceEdit.seMinimumX);
            Localize(Resources.Control_Trace_MinimumY, TraceEdit.seMinimumY);
            Localize(Resources.Control_Trace_MinimumZ, TraceEdit.seMinimumZ);
            Localize(Resources.Control_Trace_Maximum, TraceEdit.lblMaximum);
            Localize(Resources.Control_Trace_MaximumX, TraceEdit.seMaximumX);
            Localize(Resources.Control_Trace_MaximumY, TraceEdit.seMaximumY);
            Localize(Resources.Control_Trace_MaximumZ, TraceEdit.seMaximumZ);
            Localize(Resources.Control_Trace_Strips, TraceEdit.lblStrips);
            Localize(Resources.Control_Trace_StripsX, TraceEdit.seStripCountX);
            Localize(Resources.Control_Trace_StripsY, TraceEdit.seStripCountY);
            Localize(Resources.Control_Trace_StripsZ, TraceEdit.seStripCountZ);
            Localize(Resources.Control_Trace_Pattern, TraceEdit.lblPattern, TraceEdit.cbPattern);
            Localize(Resources.Control_Trace_Visible, TraceEdit.cbVisible);
            Localize(Resources.Control_Trace_Selection, TraceEdit.lblSelectedTraces);
            Localize(Resources.Menu_Trace_All, TraceEdit.lblAll);
        }

        protected override void OnSelectionChanged()
        {
            base.OnSelectionChanged();
            UpdateAllProperties();
        }

        protected internal override void UpdateAllProperties()
        {
            base.UpdateAllProperties();
            CopySelectionToControl();
            UIController.EnableControls(!Selection.IsEmpty,
                TraceEdit.TableLayoutPanel.Controls.Cast<Control>()
                .Except(new Control[]
                {
                    TraceEdit.lblSelectedTraces,
                    TraceEdit.SelectionToolbar
                }));
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
                        TraceEdit.edDescription.Text = Selection.Description;
                        break;
                    case PropertyNames.Location:
                        TraceEdit.seLocationX.Value = (decimal)Selection.Location.X;
                        TraceEdit.seLocationY.Value = (decimal)Selection.Location.Y;
                        TraceEdit.seLocationZ.Value = (decimal)Selection.Location.Z;
                        break;
                    case PropertyNames.Maximum:
                        TraceEdit.seMaximumX.Value = (decimal)Selection.Maximum.X;
                        TraceEdit.seMaximumY.Value = (decimal)Selection.Maximum.Y;
                        TraceEdit.seMaximumZ.Value = (decimal)Selection.Maximum.Z;
                        break;
                    case PropertyNames.Minimum:
                        TraceEdit.seMinimumX.Value = (decimal)Selection.Minimum.X;
                        TraceEdit.seMinimumY.Value = (decimal)Selection.Minimum.Y;
                        TraceEdit.seMinimumZ.Value = (decimal)Selection.Minimum.Z;
                        break;
                    case PropertyNames.Orientation:
                        TraceEdit.sePitch.Value = (decimal)Selection.Orientation.X;
                        TraceEdit.seYaw.Value = (decimal)Selection.Orientation.Y;
                        TraceEdit.seRoll.Value = (decimal)Selection.Orientation.Z;
                        break;
                    case PropertyNames.Pattern:
                        TraceEdit.cbPattern.SelectedItem = Selection.Pattern;
                        break;
                    case PropertyNames.Scale:
                        TraceEdit.seScaleX.Value = (decimal)Selection.Scale.X;
                        TraceEdit.seScaleY.Value = (decimal)Selection.Scale.Y;
                        TraceEdit.seScaleZ.Value = (decimal)Selection.Scale.Z;
                        break;
                    case PropertyNames.StripCount:
                        TraceEdit.seStripCountX.Value = (decimal)Selection.StripCount.X;
                        TraceEdit.seStripCountY.Value = (decimal)Selection.StripCount.Y;
                        TraceEdit.seStripCountZ.Value = (decimal)Selection.StripCount.Z;
                        break;
                    case PropertyNames.Traces:
                        OnSelectionChanged();
                        break;
                    case PropertyNames.Visible:
                        TraceEdit.cbVisible.CheckState = GetCheckState(Selection.Visible);
                        break;
                }
            Updating = false;
        }

        private void CopySelectionFromControl()
        {
            if (SelectionUpdating)
                return;
            SelectionUpdating = true;
            Selection.Set(SelectionController.Selection.Select(p => Scene.Traces[p]));
            SelectionUpdating = false;
        }

        private void CopySelectionToControl()
        {
            if (SelectionUpdating)
                return;
            SelectionUpdating = true;
            SelectionController.TraceCount = Scene.Traces.Count;
            SelectionController.Selection = Selection.GetTraceIndices().ToList();
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
            TraceEdit.seStripCountX.Minimum =
            TraceEdit.seStripCountY.Minimum =
            TraceEdit.seStripCountZ.Minimum = 0;
            TraceEdit.cbPattern.Items.AddRange(Enum.GetValues(typeof(Pattern)).Cast<object>().ToArray());
        }

        private void Run(Func<Trace, ICommand> command)
        {
            if (Updating || Selection.IsEmpty)
                return;
            Updating = true;
            Selection.ForEach(p => CommandProcessor.Run(command(p)));
            Updating = false;
        }

        private void Selection_Changed(object sender, EventArgs e) => CopySelectionFromControl();
    }

    /// <summary>
    /// Command runners.
    /// </summary>
    partial class TraceController
    {
        private void Description_TextChanged(object sender, System.EventArgs e) =>
            Run(p => new DescriptionCommand(p.Index, TraceEdit.edDescription.Text));

        private void LocationX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new LocationCommand(p.Index, new Vector3(
                (float)TraceEdit.seLocationX.Value,
                p.Location.Y,
                p.Location.Z)));

        private void LocationY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new LocationCommand(p.Index, new Vector3(
                p.Location.X,
                (float)TraceEdit.seLocationY.Value,
                p.Location.Z)));

        private void LocationZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new LocationCommand(p.Index, new Vector3(
                p.Location.X,
                p.Location.Y,
                (float)TraceEdit.seLocationZ.Value)));

        private void MaximumX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MaximumCommand(p.Index, new Vector3(
                (float)TraceEdit.seMaximumX.Value,
                p.Maximum.Y,
                p.Maximum.Z)));

        private void MaximumY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MaximumCommand(p.Index, new Vector3(
                p.Maximum.X,
                (float)TraceEdit.seMaximumY.Value,
                p.Maximum.Z)));

        private void MaximumZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MaximumCommand(p.Index, new Vector3(
                p.Maximum.X,
                p.Maximum.Y,
                (float)TraceEdit.seMaximumZ.Value)));

        private void MinimumX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MinimumCommand(p.Index, new Vector3(
                (float)TraceEdit.seMinimumX.Value,
                p.Minimum.Y,
                p.Minimum.Z)));

        private void MinimumY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MinimumCommand(p.Index, new Vector3(
                p.Minimum.X,
                (float)TraceEdit.seMinimumY.Value,
                p.Minimum.Z)));

        private void MinimumZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MinimumCommand(p.Index, new Vector3(
                p.Minimum.X,
                p.Minimum.Y,
                (float)TraceEdit.seMinimumZ.Value)));

        private void OrientationX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p.Index, new Vector3(
                (float)TraceEdit.sePitch.Value,
                p.Orientation.Y,
                p.Orientation.Z)));

        private void OrientationY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p.Index, new Vector3(
                p.Orientation.X,
                (float)TraceEdit.seYaw.Value,
                p.Orientation.Z)));

        private void OrientationZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p.Index, new Vector3(
                p.Orientation.X,
                p.Orientation.Y,
                (float)TraceEdit.seRoll.Value)));

        private void Pattern_SelectedValueChanged(object sender, System.EventArgs e) =>
            Run(p => new PatternCommand(p.Index, (Pattern)TraceEdit.cbPattern.SelectedItem));

        private void ScaleX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new ScaleCommand(p.Index, new Vector3(
                (float)TraceEdit.seScaleX.Value,
                p.Scale.Y,
                p.Scale.Z)));

        private void ScaleY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new ScaleCommand(p.Index, new Vector3(
                p.Scale.X,
                (float)TraceEdit.seScaleY.Value,
                p.Scale.Z)));

        private void ScaleZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new ScaleCommand(p.Index, new Vector3(
                p.Scale.X,
                p.Scale.Y,
                (float)TraceEdit.seScaleZ.Value)));

        private void StripCountX_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new StripCountCommand(p.Index, new Vector3(
                (float)TraceEdit.seStripCountX.Value,
                p.StripCount.Y,
                p.StripCount.Z)));

        private void StripCountY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new StripCountCommand(p.Index, new Vector3(
                p.StripCount.X,
                (float)TraceEdit.seStripCountY.Value,
                p.StripCount.Z)));

        private void StripCountZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new StripCountCommand(p.Index, new Vector3(
                p.StripCount.X,
                p.StripCount.Y,
                (float)TraceEdit.seStripCountZ.Value)));

        private void Visible_CheckedChanged(object sender, EventArgs e) =>
            Run(p => new VisibleCommand(p.Index, TraceEdit.cbVisible.Checked));

    }
}
