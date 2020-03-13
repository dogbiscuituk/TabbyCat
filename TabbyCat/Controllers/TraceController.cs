namespace TabbyCat.Controllers
{
    using OpenTK;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Models;
    using TabbyCat.Properties;
    using TabbyCatControls;

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

        #endregion

        #region Protected Internal Methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                UpdateAllProperties();
                Editor.edDescription.TextChanged += Description_TextChanged;
                Editor.seLocationX.ValueChanged += Location_ValueChanged;
                Editor.seLocationY.ValueChanged += Location_ValueChanged;
                Editor.seLocationZ.ValueChanged += Location_ValueChanged;
                Editor.seOrientationX.ValueChanged += Orientation_ValueChanged;
                Editor.seOrientationY.ValueChanged += Orientation_ValueChanged;
                Editor.seOrientationZ.ValueChanged += Orientation_ValueChanged;
                Editor.seScaleX.ValueChanged += Scale_ValueChanged;
                Editor.seScaleY.ValueChanged += Scale_ValueChanged;
                Editor.seScaleZ.ValueChanged += Scale_ValueChanged;
                Editor.cbPattern.SelectedValueChanged += Pattern_SelectedValueChanged;
                Editor.seMinimumX.ValueChanged += Minimum_ValueChanged;
                Editor.seMinimumY.ValueChanged += Minimum_ValueChanged;
                Editor.seMinimumZ.ValueChanged += Minimum_ValueChanged;
                Editor.seMaximumX.ValueChanged += Maximum_ValueChanged;
                Editor.seMaximumY.ValueChanged += Maximum_ValueChanged;
                Editor.seMaximumZ.ValueChanged += Maximum_ValueChanged;
                Editor.seStripCountX.ValueChanged += StripCount_ValueChanged;
                Editor.seStripCountY.ValueChanged += StripCount_ValueChanged;
                Editor.seStripCountZ.ValueChanged += StripCount_ValueChanged;
                Editor.cbVisible.CheckedChanged += Visible_CheckedChanged;
            }
            else
            {
                Editor.edDescription.TextChanged -= Description_TextChanged;
                Editor.seLocationX.ValueChanged -= Location_ValueChanged;
                Editor.seLocationY.ValueChanged -= Location_ValueChanged;
                Editor.seLocationZ.ValueChanged -= Location_ValueChanged;
                Editor.seOrientationX.ValueChanged -= Orientation_ValueChanged;
                Editor.seOrientationY.ValueChanged -= Orientation_ValueChanged;
                Editor.seOrientationZ.ValueChanged -= Orientation_ValueChanged;
                Editor.seScaleX.ValueChanged -= Scale_ValueChanged;
                Editor.seScaleY.ValueChanged -= Scale_ValueChanged;
                Editor.seScaleZ.ValueChanged -= Scale_ValueChanged;
                Editor.cbPattern.SelectedValueChanged -= Pattern_SelectedValueChanged;
                Editor.seMinimumX.ValueChanged -= Minimum_ValueChanged;
                Editor.seMinimumY.ValueChanged -= Minimum_ValueChanged;
                Editor.seMinimumZ.ValueChanged -= Minimum_ValueChanged;
                Editor.seMaximumX.ValueChanged -= Maximum_ValueChanged;
                Editor.seMaximumY.ValueChanged -= Maximum_ValueChanged;
                Editor.seMaximumZ.ValueChanged -= Maximum_ValueChanged;
                Editor.seStripCountX.ValueChanged -= StripCount_ValueChanged;
                Editor.seStripCountY.ValueChanged -= StripCount_ValueChanged;
                Editor.seStripCountZ.ValueChanged -= StripCount_ValueChanged;
            }
        }

        #endregion

        #region Protected Methods

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
                    case PropertyNames.Visible:
                        Editor.cbVisible.CheckState = GetCheckState(Selection.Visible);
                        break;
                }
            Updating = false;
        }

        #endregion

        #region Private Event Handlers

        private void Description_TextChanged(object sender, System.EventArgs e) =>
            Run(p => new DescriptionCommand(p, Editor.edDescription.Text));

        private void Location_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new LocationCommand(p, new Vector3(
                (float)Editor.seLocationX.Value,
                (float)Editor.seLocationY.Value,
                (float)Editor.seLocationZ.Value)));

        private void Maximum_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MaximumCommand(p, new Vector3(
                (float)Editor.seMaximumX.Value,
                (float)Editor.seMaximumY.Value,
                (float)Editor.seMaximumZ.Value)));

        private void Minimum_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MinimumCommand(p, new Vector3(
                (float)Editor.seMinimumX.Value,
                (float)Editor.seMinimumY.Value,
                (float)Editor.seMinimumZ.Value)));

        private void Orientation_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p, new Vector3(
                (float)Editor.seOrientationX.Value,
                (float)Editor.seOrientationY.Value,
                (float)Editor.seOrientationZ.Value)));

        private void Pattern_SelectedValueChanged(object sender, System.EventArgs e) =>
            Run(p => new PatternCommand(p, (Pattern)Editor.cbPattern.SelectedItem));

        private void Scale_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new ScaleCommand(p, new Vector3(
                (float)Editor.seScaleX.Value,
                (float)Editor.seScaleY.Value,
                (float)Editor.seScaleZ.Value)));

        private void StripCount_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new StripCountCommand(p, new Vector3(
                (float)Editor.seStripCountX.Value,
                (float)Editor.seStripCountY.Value,
                (float)Editor.seStripCountZ.Value)));

        private void Visible_CheckedChanged(object sender, EventArgs e) =>
            Run(p => new VisibleCommand(p, Editor.cbVisible.Checked));

        #endregion

        #region Private Methods

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
            foreach (Pattern pattern in Enum.GetValues(typeof(Pattern)))
                Editor.cbPattern.Items.Add(pattern);
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

        private void Run(Func<int, ICommand> makeCommand)
        {
            if (Updating || Selection.IsEmpty)
                return;
            Updating = true;
            Selection.ForEach(p => CommandProcessor.Run(makeCommand(p.Index)));
            Updating = false;
        }

        #endregion
    }
}
