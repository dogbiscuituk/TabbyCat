namespace TabbyCat.Controllers
{
    using OpenTK;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Models;
    using TabbyCatControls;

    internal class TraceEditController : CodeEditController
    {
        #region Constructors

        internal TraceEditController(PropertiesController propertiesController)
            : base(propertiesController) => InitControls(Editor.TableLayoutPanel);

        #endregion

        #region Fields & Properties

        private TraceEdit Editor => PropertiesEditor.TraceEdit;
        private Selection Selection => SceneController.Selection;

        #endregion

        #region Protected Methods

        protected override void Connect()
        {
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
            Editor.cbPattern.SelectedIndexChanged += Pattern_SelectedIndexChanged;
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
            SceneController.PropertyChanged += SceneController_PropertyChanged;
            SceneController.SelectionChanged += SceneController_SelectionChanged;
        }

        protected override void Disconnect()
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
            Editor.cbPattern.SelectedIndexChanged -= Pattern_SelectedIndexChanged;
            Editor.seMinimumX.ValueChanged -= Minimum_ValueChanged;
            Editor.seMinimumY.ValueChanged -= Minimum_ValueChanged;
            Editor.seMinimumZ.ValueChanged -= Minimum_ValueChanged;
            Editor.seMaximumX.ValueChanged -= Maximum_ValueChanged;
            Editor.seMaximumY.ValueChanged -= Maximum_ValueChanged;
            Editor.seMaximumZ.ValueChanged -= Maximum_ValueChanged;
            Editor.seStripCountX.ValueChanged -= StripCount_ValueChanged;
            Editor.seStripCountY.ValueChanged -= StripCount_ValueChanged;
            Editor.seStripCountZ.ValueChanged -= StripCount_ValueChanged;
            SceneController.PropertyChanged -= SceneController_PropertyChanged;
            SceneController.SelectionChanged -= SceneController_SelectionChanged;
        }

        #endregion

        #region Private Event Handlers

        private void Description_TextChanged(object sender, System.EventArgs e) =>
            Run(p => new DescriptionCommand(p, Editor.edDescription.Text));

        private void Location_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new LocationCommand(p, new Vector3d(
                (double)Editor.seLocationX.Value,
                (double)Editor.seLocationY.Value,
                (double)Editor.seLocationZ.Value)));

        private void Maximum_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MaximumCommand(p, new Vector3d(
                (double)Editor.seMaximumX.Value,
                (double)Editor.seMaximumY.Value,
                (double)Editor.seMaximumZ.Value)));

        private void Minimum_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new MinimumCommand(p, new Vector3d(
                (double)Editor.seMinimumX.Value,
                (double)Editor.seMinimumY.Value,
                (double)Editor.seMinimumZ.Value)));

        private void Orientation_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new OrientationCommand(p, new Vector3d(
                (double)Editor.seOrientationX.Value,
                (double)Editor.seOrientationY.Value,
                (double)Editor.seOrientationZ.Value)));

        private void Pattern_SelectedIndexChanged(object sender, System.EventArgs e) =>
            Run(p => new PatternCommand(p, (Pattern)Editor.cbPattern.SelectedIndex));

        private void Scale_ValueChanged(object sender, System.EventArgs e) =>
            Run(p => new ScaleCommand(p, new Vector3d(
                (double)Editor.seScaleX.Value,
                (double)Editor.seScaleY.Value,
                (double)Editor.seScaleZ.Value)));

        private void SceneController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            UpdateProperties(e.PropertyName);

        private void SceneController_SelectionChanged(object sender, System.EventArgs e) =>
            UpdateAllProperties();

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

        private void Run(Func<int, ICommand> makeCommand)
        {
            if (Updating || !Selection.Traces.Any())
                return;
            Updating = true;
            foreach (var trace in Selection.Traces)
                CommandProcessor.Run(makeCommand(trace.Index));
            Updating = false;
        }

        private void UpdateAllProperties() => UpdateProperties(new[]
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
        });

        private void UpdateProperties(params string[] propertyNames)
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
                        Editor.cbPattern.SelectedIndex = (int)Selection.Pattern;
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
    }
}
