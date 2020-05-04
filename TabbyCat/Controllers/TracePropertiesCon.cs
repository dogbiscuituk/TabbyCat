namespace TabbyCat.Controllers
{
    using Commands;
    using Controls;
    using Models;
    using OpenTK;
    using Properties;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Types;
    using Utils;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal partial class TracePropertiesCon : PropertiesCon
    {
        internal TracePropertiesCon(WorldCon worldCon) : base(worldCon)
        {
            AppCon.InitControlTheme(TracePropertiesEdit.SelectionToolbar);
            SelectionCon = new SelectionCon(worldCon);
            InitCommonControls(TracePropertiesEdit.TableLayoutPanel);
            InitLocalControls();
        }

        private TracePropertiesForm _TracePropertiesForm;

        private readonly SelectionCon SelectionCon;
        private bool SelectionUpdating;

        protected internal override DockContent Form => TracePropertiesForm;

        protected override TracePropertiesForm TracePropertiesForm => _TracePropertiesForm ?? (_TracePropertiesForm = new TracePropertiesForm
        {
            TabText = Resources.TracePropertiesForm_TabText,
            Text = Resources.TracePropertiesForm_Text,
            ToolTipText = Resources.TracePropertiesForm_Text
        });

        internal ToolStrip SelectionToolbar => TracePropertiesEdit.SelectionToolbar;

        protected override string[] AllProperties => new[]
        {
            PropertyNames.Description,
            PropertyNames.Location,
            PropertyNames.Maximum,
            PropertyNames.Minimum,
            PropertyNames.Orientation,
            PropertyNames.Pattern,
            PropertyNames.Scale,
            PropertyNames.StripeCount,
            PropertyNames.Visible
        };

        private TraceSelection Selection => WorldCon.TraceSelection;

        private TracePropertiesEdit TracePropertiesEdit => TracePropertiesForm.TracePropertiesEdit;

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                SelectionCon.SelectionChanged += Selection_Changed;
                TracePropertiesEdit.edDescription.TextChanged += Description_TextChanged;
                TracePropertiesEdit.seLocationX.ValueChanged += LocationX_ValueChanged;
                TracePropertiesEdit.seLocationY.ValueChanged += LocationY_ValueChanged;
                TracePropertiesEdit.seLocationZ.ValueChanged += LocationZ_ValueChanged;
                TracePropertiesEdit.sePitch.ValueChanged += OrientationX_ValueChanged;
                TracePropertiesEdit.seYaw.ValueChanged += OrientationY_ValueChanged;
                TracePropertiesEdit.seRoll.ValueChanged += OrientationZ_ValueChanged;
                TracePropertiesEdit.seScaleX.ValueChanged += ScaleX_ValueChanged;
                TracePropertiesEdit.seScaleY.ValueChanged += ScaleY_ValueChanged;
                TracePropertiesEdit.seScaleZ.ValueChanged += ScaleZ_ValueChanged;
                TracePropertiesEdit.cbPattern.DrawItem += Pattern_DrawItem;
                TracePropertiesEdit.cbPattern.SelectedValueChanged += Pattern_SelectedValueChanged;
                TracePropertiesEdit.seMinimumX.ValueChanged += MinimumX_ValueChanged;
                TracePropertiesEdit.seMinimumY.ValueChanged += MinimumY_ValueChanged;
                TracePropertiesEdit.seMinimumZ.ValueChanged += MinimumZ_ValueChanged;
                TracePropertiesEdit.seMaximumX.ValueChanged += MaximumX_ValueChanged;
                TracePropertiesEdit.seMaximumY.ValueChanged += MaximumY_ValueChanged;
                TracePropertiesEdit.seMaximumZ.ValueChanged += MaximumZ_ValueChanged;
                TracePropertiesEdit.seStripeCountX.ValueChanged += StripeCountX_ValueChanged;
                TracePropertiesEdit.seStripeCountY.ValueChanged += StripeCountY_ValueChanged;
                TracePropertiesEdit.seStripeCountZ.ValueChanged += StripeCountZ_ValueChanged;
                TracePropertiesEdit.cbVisible.CheckedChanged += Visible_CheckedChanged;
                WorldForm.ViewTraceProperties.Click += ViewTraceProperties_Click;
            }
            else
            {
                SelectionCon.SelectionChanged -= Selection_Changed;
                TracePropertiesEdit.edDescription.TextChanged -= Description_TextChanged;
                TracePropertiesEdit.seLocationX.ValueChanged -= LocationX_ValueChanged;
                TracePropertiesEdit.seLocationY.ValueChanged -= LocationY_ValueChanged;
                TracePropertiesEdit.seLocationZ.ValueChanged -= LocationZ_ValueChanged;
                TracePropertiesEdit.sePitch.ValueChanged -= OrientationX_ValueChanged;
                TracePropertiesEdit.seYaw.ValueChanged -= OrientationY_ValueChanged;
                TracePropertiesEdit.seRoll.ValueChanged -= OrientationZ_ValueChanged;
                TracePropertiesEdit.seScaleX.ValueChanged -= ScaleX_ValueChanged;
                TracePropertiesEdit.seScaleY.ValueChanged -= ScaleY_ValueChanged;
                TracePropertiesEdit.seScaleZ.ValueChanged -= ScaleZ_ValueChanged;
                TracePropertiesEdit.cbPattern.DrawItem -= Pattern_DrawItem;
                TracePropertiesEdit.cbPattern.SelectedValueChanged -= Pattern_SelectedValueChanged;
                TracePropertiesEdit.seMinimumX.ValueChanged -= MinimumX_ValueChanged;
                TracePropertiesEdit.seMinimumY.ValueChanged -= MinimumY_ValueChanged;
                TracePropertiesEdit.seMinimumZ.ValueChanged -= MinimumZ_ValueChanged;
                TracePropertiesEdit.seMaximumX.ValueChanged -= MaximumX_ValueChanged;
                TracePropertiesEdit.seMaximumY.ValueChanged -= MaximumY_ValueChanged;
                TracePropertiesEdit.seMaximumZ.ValueChanged -= MaximumZ_ValueChanged;
                TracePropertiesEdit.seStripeCountX.ValueChanged -= StripeCountX_ValueChanged;
                TracePropertiesEdit.seStripeCountY.ValueChanged -= StripeCountY_ValueChanged;
                TracePropertiesEdit.seStripeCountZ.ValueChanged -= StripeCountZ_ValueChanged;
                TracePropertiesEdit.cbVisible.CheckedChanged -= Visible_CheckedChanged;
                WorldForm.ViewTraceProperties.Click -= ViewTraceProperties_Click;
            }
            SelectionCon.Connect(connect);
        }

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            SelectionCon?.Dispose();
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewTraceProperties, WorldForm.ViewTraceProperties);
            Localize(Resources.Control_Trace_Description, TracePropertiesEdit.lblDescription, TracePropertiesEdit.edDescription);
            Localize(Resources.Control_Trace_Location, TracePropertiesEdit.lblLocation);
            Localize(Resources.Control_Trace_LocationX, TracePropertiesEdit.seLocationX);
            Localize(Resources.Control_Trace_LocationY, TracePropertiesEdit.seLocationY);
            Localize(Resources.Control_Trace_LocationZ, TracePropertiesEdit.seLocationZ);
            Localize(Resources.Control_Trace_Orientation, TracePropertiesEdit.lblOrientation);
            Localize(Resources.Control_Trace_Pitch, TracePropertiesEdit.sePitch);
            Localize(Resources.Control_Trace_Yaw, TracePropertiesEdit.seYaw);
            Localize(Resources.Control_Trace_Roll, TracePropertiesEdit.seRoll);
            Localize(Resources.Control_Trace_Scale, TracePropertiesEdit.lblScale);
            Localize(Resources.Control_Trace_ScaleX, TracePropertiesEdit.seScaleX);
            Localize(Resources.Control_Trace_ScaleY, TracePropertiesEdit.seScaleY);
            Localize(Resources.Control_Trace_ScaleZ, TracePropertiesEdit.seScaleZ);
            Localize(Resources.Control_Trace_Minimum, TracePropertiesEdit.lblMinimum);
            Localize(Resources.Control_Trace_MinimumX, TracePropertiesEdit.seMinimumX);
            Localize(Resources.Control_Trace_MinimumY, TracePropertiesEdit.seMinimumY);
            Localize(Resources.Control_Trace_MinimumZ, TracePropertiesEdit.seMinimumZ);
            Localize(Resources.Control_Trace_Maximum, TracePropertiesEdit.lblMaximum);
            Localize(Resources.Control_Trace_MaximumX, TracePropertiesEdit.seMaximumX);
            Localize(Resources.Control_Trace_MaximumY, TracePropertiesEdit.seMaximumY);
            Localize(Resources.Control_Trace_MaximumZ, TracePropertiesEdit.seMaximumZ);
            Localize(Resources.Control_Trace_Stripes, TracePropertiesEdit.lblStripes);
            Localize(Resources.Control_Trace_StripesX, TracePropertiesEdit.seStripeCountX);
            Localize(Resources.Control_Trace_StripesY, TracePropertiesEdit.seStripeCountY);
            Localize(Resources.Control_Trace_StripesZ, TracePropertiesEdit.seStripeCountZ);
            Localize(Resources.Control_Trace_Pattern, TracePropertiesEdit.lblPattern, TracePropertiesEdit.cbPattern);
            Localize(Resources.Control_Trace_Visible, TracePropertiesEdit.cbVisible);
            Localize(Resources.Control_Trace_Selection, TracePropertiesEdit.lblSelectedTraces);
            Localize(Resources.WorldForm_Trace_All, TracePropertiesEdit.lblAll);
        }

        protected override void OnSelectionEdit()
        {
            base.OnSelectionEdit();
            UpdateAllProperties();
        }

        protected internal override void UpdateAllProperties()
        {
            base.UpdateAllProperties();
            CopySelectionToControl();
            ToolStripUtils.EnableControls(!Selection.IsEmpty,
                TracePropertiesEdit.TableLayoutPanel.Controls.Cast<Control>()
                .Except(new Control[]
                {
                    TracePropertiesEdit.lblSelectedTraces,
                    TracePropertiesEdit.SelectionToolbar
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
                        TracePropertiesEdit.edDescription.Text = Selection.Description;
                        break;
                    case PropertyNames.Location:
                        TracePropertiesEdit.seLocationX.Value = (decimal)Selection.Location.X;
                        TracePropertiesEdit.seLocationY.Value = (decimal)Selection.Location.Y;
                        TracePropertiesEdit.seLocationZ.Value = (decimal)Selection.Location.Z;
                        break;
                    case PropertyNames.Maximum:
                        TracePropertiesEdit.seMaximumX.Value = (decimal)Selection.Maximum.X;
                        TracePropertiesEdit.seMaximumY.Value = (decimal)Selection.Maximum.Y;
                        TracePropertiesEdit.seMaximumZ.Value = (decimal)Selection.Maximum.Z;
                        break;
                    case PropertyNames.Minimum:
                        TracePropertiesEdit.seMinimumX.Value = (decimal)Selection.Minimum.X;
                        TracePropertiesEdit.seMinimumY.Value = (decimal)Selection.Minimum.Y;
                        TracePropertiesEdit.seMinimumZ.Value = (decimal)Selection.Minimum.Z;
                        break;
                    case PropertyNames.Orientation:
                        TracePropertiesEdit.sePitch.Value = (decimal)Selection.Orientation.X;
                        TracePropertiesEdit.seYaw.Value = (decimal)Selection.Orientation.Y;
                        TracePropertiesEdit.seRoll.Value = (decimal)Selection.Orientation.Z;
                        break;
                    case PropertyNames.Pattern:
                        TracePropertiesEdit.cbPattern.SelectedItem = Selection.Pattern;
                        break;
                    case PropertyNames.Scale:
                        TracePropertiesEdit.seScaleX.Value = (decimal)Selection.Scale.X;
                        TracePropertiesEdit.seScaleY.Value = (decimal)Selection.Scale.Y;
                        TracePropertiesEdit.seScaleZ.Value = (decimal)Selection.Scale.Z;
                        break;
                    case PropertyNames.StripeCount:
                        TracePropertiesEdit.seStripeCountX.Value = (decimal)Selection.StripeCount.X;
                        TracePropertiesEdit.seStripeCountY.Value = (decimal)Selection.StripeCount.Y;
                        TracePropertiesEdit.seStripeCountZ.Value = (decimal)Selection.StripeCount.Z;
                        break;
                    case PropertyNames.Traces:
                        OnSelectionEdit();
                        break;
                    case PropertyNames.Visible:
                        TracePropertiesEdit.cbVisible.CheckState = GetCheckState(Selection.Visible);
                        break;
                }
            Updating = false;
        }

        private void CopySelectionFromControl()
        {
            if (SelectionUpdating)
                return;
            SelectionUpdating = true;
            Selection.Set(SelectionCon.Selection.Select(p => Scene.Traces[p]));
            SelectionUpdating = false;
        }

        private void CopySelectionToControl()
        {
            if (SelectionUpdating)
                return;
            SelectionUpdating = true;
            SelectionCon.TraceCount = Scene.Traces.Count;
            SelectionCon.Selection = Selection.GetTraceIndices().ToList();
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
            TracePropertiesEdit.seStripeCountX.Minimum =
            TracePropertiesEdit.seStripeCountY.Minimum =
            TracePropertiesEdit.seStripeCountZ.Minimum = 0;
            TracePropertiesEdit.cbPattern.Items.AddRange(Enum.GetValues(typeof(Pattern)).Cast<object>().ToArray());
        }

        private bool Run(Func<Trace, ICommand> command)
        {
            var result = false;
            if (!Selection.IsEmpty)
                Selection.ForEach(p => result |= Run(command(p)));
            return result;
        }

        private void Selection_Changed(object sender, EventArgs e) => CopySelectionFromControl();
    }

    /// <summary>
    /// Command runners.
    /// </summary>
    internal partial class TracePropertiesCon
    {
        private void Description_TextChanged(object sender, System.EventArgs e) => Run(p => new DescriptionCommand(p.Index, TracePropertiesEdit.edDescription.Text));

        private void LocationX_ValueChanged(object sender, System.EventArgs e) => Run(p => new LocationCommand(p.Index, new Vector3(
            (float)TracePropertiesEdit.seLocationX.Value,
            p.Location.Y,
            p.Location.Z)));

        private void LocationY_ValueChanged(object sender, System.EventArgs e) => Run(p => new LocationCommand(p.Index, new Vector3(
            p.Location.X,
            (float)TracePropertiesEdit.seLocationY.Value,
            p.Location.Z)));

        private void LocationZ_ValueChanged(object sender, System.EventArgs e) => Run(p => new LocationCommand(p.Index, new Vector3(
            p.Location.X,
            p.Location.Y,
            (float)TracePropertiesEdit.seLocationZ.Value)));

        private void MaximumX_ValueChanged(object sender, System.EventArgs e) => Run(p => new MaximumCommand(p.Index, new Vector3(
            (float)TracePropertiesEdit.seMaximumX.Value,
            p.Maximum.Y,
            p.Maximum.Z)));

        private void MaximumY_ValueChanged(object sender, System.EventArgs e) => Run(p => new MaximumCommand(p.Index, new Vector3(
            p.Maximum.X,
            (float)TracePropertiesEdit.seMaximumY.Value,
            p.Maximum.Z)));

        private void MaximumZ_ValueChanged(object sender, System.EventArgs e) => Run(p => new MaximumCommand(p.Index, new Vector3(
            p.Maximum.X,
            p.Maximum.Y,
            (float)TracePropertiesEdit.seMaximumZ.Value)));

        private void MinimumX_ValueChanged(object sender, System.EventArgs e) => Run(p => new MinimumCommand(p.Index, new Vector3(
            (float)TracePropertiesEdit.seMinimumX.Value,
            p.Minimum.Y,
            p.Minimum.Z)));

        private void MinimumY_ValueChanged(object sender, System.EventArgs e) => Run(p => new MinimumCommand(p.Index, new Vector3(
            p.Minimum.X,
            (float)TracePropertiesEdit.seMinimumY.Value,
            p.Minimum.Z)));

        private void MinimumZ_ValueChanged(object sender, System.EventArgs e) => Run(p => new MinimumCommand(p.Index, new Vector3(
            p.Minimum.X,
            p.Minimum.Y,
            (float)TracePropertiesEdit.seMinimumZ.Value)));

        private void OrientationX_ValueChanged(object sender, System.EventArgs e) => Run(p => new OrientationCommand(p.Index, new Vector3(
            (float)TracePropertiesEdit.sePitch.Value,
            p.Orientation.Y,
            p.Orientation.Z)));

        private void OrientationY_ValueChanged(object sender, System.EventArgs e) => Run(p => new OrientationCommand(p.Index, new Vector3(
            p.Orientation.X,
            (float)TracePropertiesEdit.seYaw.Value,
            p.Orientation.Z)));

        private void OrientationZ_ValueChanged(object sender, System.EventArgs e) => Run(p => new OrientationCommand(p.Index, new Vector3(
            p.Orientation.X,
            p.Orientation.Y,
            (float)TracePropertiesEdit.seRoll.Value)));

        private void Pattern_DrawItem(object sender, DrawItemEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selected = (e.State & DrawItemState.Selected) != 0;
            ColourUtils.DrawText(
                e,
                foreground: selected ? Color.FromKnownColor(KnownColor.HighlightText) : comboBox.ForeColor,
                background: selected ? Color.FromKnownColor(KnownColor.Highlight) : comboBox.BackColor,
                text: comboBox.Items[e.Index].ToString());
        }

        private void Pattern_SelectedValueChanged(object sender, System.EventArgs e) => Run(p => new PatternCommand(p.Index, (Pattern)TracePropertiesEdit.cbPattern.SelectedItem));

        private void ScaleX_ValueChanged(object sender, System.EventArgs e) => Run(p => new ScaleCommand(p.Index, new Vector3(
            (float)TracePropertiesEdit.seScaleX.Value,
            p.Scale.Y,
            p.Scale.Z)));

        private void ScaleY_ValueChanged(object sender, System.EventArgs e) => Run(p => new ScaleCommand(p.Index, new Vector3(
            p.Scale.X,
            (float)TracePropertiesEdit.seScaleY.Value,
            p.Scale.Z)));

        private void ScaleZ_ValueChanged(object sender, System.EventArgs e) => Run(p => new ScaleCommand(p.Index, new Vector3(
            p.Scale.X,
            p.Scale.Y,
            (float)TracePropertiesEdit.seScaleZ.Value)));

        private void StripeCountX_ValueChanged(object sender, System.EventArgs e) => Run(p => new StripeCountCommand(p.Index, new Vector3(
            (float)TracePropertiesEdit.seStripeCountX.Value,
            p.StripeCount.Y,
            p.StripeCount.Z)));

        private void StripeCountY_ValueChanged(object sender, System.EventArgs e) => Run(p => new StripeCountCommand(p.Index, new Vector3(
            p.StripeCount.X,
            (float)TracePropertiesEdit.seStripeCountY.Value,
            p.StripeCount.Z)));

        private void StripeCountZ_ValueChanged(object sender, System.EventArgs e) => Run(p => new StripeCountCommand(p.Index, new Vector3(
            p.StripeCount.X,
            p.StripeCount.Y,
            (float)TracePropertiesEdit.seStripeCountZ.Value)));

        private void ViewTraceProperties_Click(object sender, EventArgs e) => ToggleVisibility();

        private void Visible_CheckedChanged(object sender, EventArgs e) => Run(p => new VisibleCommand(p.Index, TracePropertiesEdit.cbVisible.Checked));
    }
}
