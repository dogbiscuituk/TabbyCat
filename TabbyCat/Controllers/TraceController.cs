namespace TabbyCat.Controllers
{
    using Jmk.Common;
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

    internal class TraceController : ShaderSetController, IDisposable
    {
        internal TraceController(WorldController worldController)
            : base(worldController)
        {
            SelectionController = new SelectionController(worldController);
            InitCommonControls(Editor.TableLayoutPanel);
            InitLocalControls();
        }

        private readonly SelectionController SelectionController;

        private bool SelectionUpdating;

        internal ToolStrip SelectionToolbar => Editor.SelectionToolbar;

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

        private TraceEdit Editor => TraceEdit;

        private TraceSelection Selection => WorldController.Selection;

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
                Editor.sePitch.ValueChanged += OrientationX_ValueChanged;
                Editor.seYaw.ValueChanged += OrientationY_ValueChanged;
                Editor.seRoll.ValueChanged += OrientationZ_ValueChanged;
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
                SelectionController.SelectionChanged += Selection_Changed;
            }
            else
            {
                Editor.edDescription.TextChanged -= Description_TextChanged;
                Editor.seLocationX.ValueChanged -= LocationX_ValueChanged;
                Editor.seLocationY.ValueChanged -= LocationY_ValueChanged;
                Editor.seLocationZ.ValueChanged -= LocationZ_ValueChanged;
                Editor.sePitch.ValueChanged -= OrientationX_ValueChanged;
                Editor.seYaw.ValueChanged -= OrientationY_ValueChanged;
                Editor.seRoll.ValueChanged -= OrientationZ_ValueChanged;
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
                SelectionController.SelectionChanged -= Selection_Changed;
            }
            SelectionController.Connect(connect);
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.Control_Trace_Description, Editor.lblDescription, Editor.edDescription);
            Localize(Resources.Control_Trace_Location, Editor.lblLocation);
            Localize(Resources.Control_Trace_LocationX, Editor.seLocationX);
            Localize(Resources.Control_Trace_LocationY, Editor.seLocationY);
            Localize(Resources.Control_Trace_LocationZ, Editor.seLocationZ);
            Localize(Resources.Control_Trace_Orientation, Editor.lblOrientation);
            Localize(Resources.Control_Trace_Pitch, Editor.sePitch);
            Localize(Resources.Control_Trace_Yaw, Editor.seYaw);
            Localize(Resources.Control_Trace_Roll, Editor.seRoll);
            Localize(Resources.Control_Trace_Scale, Editor.lblScale);
            Localize(Resources.Control_Trace_ScaleX, Editor.seScaleX);
            Localize(Resources.Control_Trace_ScaleY, Editor.seScaleY);
            Localize(Resources.Control_Trace_ScaleZ, Editor.seScaleZ);
            Localize(Resources.Control_Trace_Minimum, Editor.lblMinimum);
            Localize(Resources.Control_Trace_MinimumX, Editor.seMinimumX);
            Localize(Resources.Control_Trace_MinimumY, Editor.seMinimumY);
            Localize(Resources.Control_Trace_MinimumZ, Editor.seMinimumZ);
            Localize(Resources.Control_Trace_Maximum, Editor.lblMaximum);
            Localize(Resources.Control_Trace_MaximumX, Editor.seMaximumX);
            Localize(Resources.Control_Trace_MaximumY, Editor.seMaximumY);
            Localize(Resources.Control_Trace_MaximumZ, Editor.seMaximumZ);
            Localize(Resources.Control_Trace_Strips, Editor.lblStrips);
            Localize(Resources.Control_Trace_StripsX, Editor.seStripCountX);
            Localize(Resources.Control_Trace_StripsY, Editor.seStripCountY);
            Localize(Resources.Control_Trace_StripsZ, Editor.seStripCountZ);
            Localize(Resources.Control_Trace_Pattern, Editor.lblPattern, Editor.cbPattern);
            Localize(Resources.Control_Trace_Visible, Editor.cbVisible);
            Localize(Resources.Control_Trace_Selection, Editor.lblSelectedTraces);
            Localize(Resources.Menu_Trace_All, Editor.lblAll);
        }

        protected override void OnSelectionChanged()
        {
            $"Selection = {{{Selection}}}".Spit();
            base.OnSelectionChanged();
            UpdateAllProperties();
            CopySelectionToControl();
        }

        protected override void UpdateAllProperties()
        {
            base.UpdateAllProperties();
            UIController.EnableControls(!Selection.IsEmpty,
                Editor.TableLayoutPanel.Controls.Cast<Control>()
                .Except(new Control[]
                {
                    Editor.lblSelectedTraces,
                    Editor.SelectionToolbar
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
                        Editor.sePitch.Value = (decimal)Selection.Orientation.X;
                        Editor.seYaw.Value = (decimal)Selection.Orientation.Y;
                        Editor.seRoll.Value = (decimal)Selection.Orientation.Z;
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
                        OnSelectionChanged();
                        break;
                    case PropertyNames.Visible:
                        Editor.cbVisible.CheckState = GetCheckState(Selection.Visible);
                        break;
                }
            Updating = false;
        }

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
                (float)Editor.sePitch.Value,
                p.Orientation.Y,
                p.Orientation.Z)));

        private void OrientationY_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p.Index, new Vector3(
                p.Orientation.X,
                (float)Editor.seYaw.Value,
                p.Orientation.Z)));

        private void OrientationZ_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p.Index, new Vector3(
                p.Orientation.X,
                p.Orientation.Y,
                (float)Editor.seRoll.Value)));

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

        private void Selection_Changed(object sender, EventArgs e) => CopySelectionFromControl();

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

        private void Visible_CheckedChanged(object sender, EventArgs e) =>
            Run(p => new VisibleCommand(p.Index, Editor.cbVisible.Checked));

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
            Editor.seStripCountX.Minimum =
            Editor.seStripCountY.Minimum =
            Editor.seStripCountZ.Minimum = 0;
            Editor.cbPattern.Items.AddRange(Enum.GetValues(typeof(Pattern)).Cast<object>().ToArray());
        }

        private void Run(Func<Trace, ICommand> command)
        {
            if (Updating || Selection.IsEmpty)
                return;
            Updating = true;
            Selection.ForEach(p => CommandProcessor.Run(command(p)));
            Updating = false;
        }

        #region IDisposable

        private bool Disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    SelectionController?.Dispose();
                }
                Disposed = true;
            }
        }

        #endregion
    }
}
