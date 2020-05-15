namespace TabbyCat.Controllers
{
    using Commands;
    using Models;
    using OpenTK;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Types;
    using UserControls;
    using Utils;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class ShapePropertiesCon : PropertiesCon
    {
        // Constructors

        public ShapePropertiesCon(WorldCon worldCon) : base(worldCon)
        {
            AppCon.InitControlTheme(ShapePropertiesEdit.SelectionToolbar);
            _selectionCon = new SelectionCon(worldCon);
            InitCommonControls(ShapePropertiesEdit.TableLayoutPanel);
            InitLocalControls();
        }

        // Private fields

        private readonly SelectionCon _selectionCon;

        private bool _selectionUpdating;

        private ShapePropertiesForm _shapePropertiesForm;

        // Public properties

        public ToolStrip SelectionToolbar => ShapePropertiesEdit.SelectionToolbar;

        // Protected properties

        protected override IEnumerable<Property> AllProperties => new List<Property>
        {
            Property.ShapeDescription,
            Property.ShapeLocation,
            Property.ShapeMaximum,
            Property.ShapeMinimum,
            Property.ShapeOrientation,
            Property.ShapePattern,
            Property.ShapeScale,
            Property.ShapeStripeCount,
            Property.ShapeVisible
        };

        protected override DockContent Form => ShapePropertiesForm;

        protected override ShapePropertiesForm ShapePropertiesForm => _shapePropertiesForm ?? (_shapePropertiesForm = new ShapePropertiesForm
        {
            TabText = Resources.ShapePropertiesForm_TabText,
            Text = Resources.ShapePropertiesForm_Text,
            ToolTipText = Resources.ShapePropertiesForm_Text
        });

        // Private properties

        private ShapeSelection Selection => WorldCon.ShapeSelection;

        private ShapePropertiesEdit ShapePropertiesEdit => ShapePropertiesForm.ShapePropertiesEdit;

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                _selectionCon.SelectionChanged += Selection_Changed;
                ShapePropertiesEdit.edDescription.TextChanged += Description_TextChanged;
                ShapePropertiesEdit.seLocationX.ValueChanged += LocationX_ValueChanged;
                ShapePropertiesEdit.seLocationY.ValueChanged += LocationY_ValueChanged;
                ShapePropertiesEdit.seLocationZ.ValueChanged += LocationZ_ValueChanged;
                ShapePropertiesEdit.sePitch.ValueChanged += OrientationX_ValueChanged;
                ShapePropertiesEdit.seYaw.ValueChanged += OrientationY_ValueChanged;
                ShapePropertiesEdit.seRoll.ValueChanged += OrientationZ_ValueChanged;
                ShapePropertiesEdit.seScaleX.ValueChanged += ScaleX_ValueChanged;
                ShapePropertiesEdit.seScaleY.ValueChanged += ScaleY_ValueChanged;
                ShapePropertiesEdit.seScaleZ.ValueChanged += ScaleZ_ValueChanged;
                ShapePropertiesEdit.cbPattern.DrawItem += Pattern_DrawItem;
                ShapePropertiesEdit.cbPattern.SelectedValueChanged += Pattern_SelectedValueChanged;
                ShapePropertiesEdit.seMinimumX.ValueChanged += MinimumX_ValueChanged;
                ShapePropertiesEdit.seMinimumY.ValueChanged += MinimumY_ValueChanged;
                ShapePropertiesEdit.seMinimumZ.ValueChanged += MinimumZ_ValueChanged;
                ShapePropertiesEdit.seMaximumX.ValueChanged += MaximumX_ValueChanged;
                ShapePropertiesEdit.seMaximumY.ValueChanged += MaximumY_ValueChanged;
                ShapePropertiesEdit.seMaximumZ.ValueChanged += MaximumZ_ValueChanged;
                ShapePropertiesEdit.seStripeCountX.ValueChanged += StripeCountX_ValueChanged;
                ShapePropertiesEdit.seStripeCountY.ValueChanged += StripeCountY_ValueChanged;
                ShapePropertiesEdit.seStripeCountZ.ValueChanged += StripeCountZ_ValueChanged;
                ShapePropertiesEdit.cbVisible.CheckedChanged += Visible_CheckedChanged;
                WorldForm.ViewShapeProperties.Click += ViewShapeProperties_Click;
            }
            else
            {
                _selectionCon.SelectionChanged -= Selection_Changed;
                ShapePropertiesEdit.edDescription.TextChanged -= Description_TextChanged;
                ShapePropertiesEdit.seLocationX.ValueChanged -= LocationX_ValueChanged;
                ShapePropertiesEdit.seLocationY.ValueChanged -= LocationY_ValueChanged;
                ShapePropertiesEdit.seLocationZ.ValueChanged -= LocationZ_ValueChanged;
                ShapePropertiesEdit.sePitch.ValueChanged -= OrientationX_ValueChanged;
                ShapePropertiesEdit.seYaw.ValueChanged -= OrientationY_ValueChanged;
                ShapePropertiesEdit.seRoll.ValueChanged -= OrientationZ_ValueChanged;
                ShapePropertiesEdit.seScaleX.ValueChanged -= ScaleX_ValueChanged;
                ShapePropertiesEdit.seScaleY.ValueChanged -= ScaleY_ValueChanged;
                ShapePropertiesEdit.seScaleZ.ValueChanged -= ScaleZ_ValueChanged;
                ShapePropertiesEdit.cbPattern.DrawItem -= Pattern_DrawItem;
                ShapePropertiesEdit.cbPattern.SelectedValueChanged -= Pattern_SelectedValueChanged;
                ShapePropertiesEdit.seMinimumX.ValueChanged -= MinimumX_ValueChanged;
                ShapePropertiesEdit.seMinimumY.ValueChanged -= MinimumY_ValueChanged;
                ShapePropertiesEdit.seMinimumZ.ValueChanged -= MinimumZ_ValueChanged;
                ShapePropertiesEdit.seMaximumX.ValueChanged -= MaximumX_ValueChanged;
                ShapePropertiesEdit.seMaximumY.ValueChanged -= MaximumY_ValueChanged;
                ShapePropertiesEdit.seMaximumZ.ValueChanged -= MaximumZ_ValueChanged;
                ShapePropertiesEdit.seStripeCountX.ValueChanged -= StripeCountX_ValueChanged;
                ShapePropertiesEdit.seStripeCountY.ValueChanged -= StripeCountY_ValueChanged;
                ShapePropertiesEdit.seStripeCountZ.ValueChanged -= StripeCountZ_ValueChanged;
                ShapePropertiesEdit.cbVisible.CheckedChanged -= Visible_CheckedChanged;
                WorldForm.ViewShapeProperties.Click -= ViewShapeProperties_Click;
            }
            _selectionCon.Connect(connect);
        }

        public override void UpdateAllProperties()
        {
            base.UpdateAllProperties();
            CopySelectionToControl();
            ToolStripUtils.EnableControls(!Selection.IsEmpty,
                ShapePropertiesEdit.TableLayoutPanel.Controls.Cast<Control>()
                    .Except(new Control[]
                    {
                        ShapePropertiesEdit.lblSelectedShapes,
                        ShapePropertiesEdit.SelectionToolbar
                    }));
        }

        // Protected methods

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            _selectionCon?.Dispose();
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewShapeProperties, WorldForm.ViewShapeProperties);
            Localize(Resources.Control_Shape_Description, ShapePropertiesEdit.lblDescription, ShapePropertiesEdit.edDescription);
            Localize(Resources.Control_Shape_Location, ShapePropertiesEdit.lblLocation);
            Localize(Resources.Control_Shape_LocationX, ShapePropertiesEdit.seLocationX);
            Localize(Resources.Control_Shape_LocationY, ShapePropertiesEdit.seLocationY);
            Localize(Resources.Control_Shape_LocationZ, ShapePropertiesEdit.seLocationZ);
            Localize(Resources.Control_Shape_Orientation, ShapePropertiesEdit.lblOrientation);
            Localize(Resources.Control_Shape_Pitch, ShapePropertiesEdit.sePitch);
            Localize(Resources.Control_Shape_Yaw, ShapePropertiesEdit.seYaw);
            Localize(Resources.Control_Shape_Roll, ShapePropertiesEdit.seRoll);
            Localize(Resources.Control_Shape_Scale, ShapePropertiesEdit.cbScale);
            Localize(Resources.Control_Shape_ScaleX, ShapePropertiesEdit.seScaleX);
            Localize(Resources.Control_Shape_ScaleY, ShapePropertiesEdit.seScaleY);
            Localize(Resources.Control_Shape_ScaleZ, ShapePropertiesEdit.seScaleZ);
            Localize(Resources.Control_Shape_Minimum, ShapePropertiesEdit.cbMinimum);
            Localize(Resources.Control_Shape_MinimumX, ShapePropertiesEdit.seMinimumX);
            Localize(Resources.Control_Shape_MinimumY, ShapePropertiesEdit.seMinimumY);
            Localize(Resources.Control_Shape_MinimumZ, ShapePropertiesEdit.seMinimumZ);
            Localize(Resources.Control_Shape_Maximum, ShapePropertiesEdit.cbMaximum);
            Localize(Resources.Control_Shape_MaximumX, ShapePropertiesEdit.seMaximumX);
            Localize(Resources.Control_Shape_MaximumY, ShapePropertiesEdit.seMaximumY);
            Localize(Resources.Control_Shape_MaximumZ, ShapePropertiesEdit.seMaximumZ);
            Localize(Resources.Control_Shape_Stripes, ShapePropertiesEdit.cbStripes);
            Localize(Resources.Control_Shape_StripesX, ShapePropertiesEdit.seStripeCountX);
            Localize(Resources.Control_Shape_StripesY, ShapePropertiesEdit.seStripeCountY);
            Localize(Resources.Control_Shape_StripesZ, ShapePropertiesEdit.seStripeCountZ);
            Localize(Resources.Control_Shape_Pattern, ShapePropertiesEdit.lblPattern, ShapePropertiesEdit.cbPattern);
            Localize(Resources.Control_Shape_Visible, ShapePropertiesEdit.cbVisible);
            Localize(Resources.Control_Shape_Selection, ShapePropertiesEdit.lblSelectedShapes);
            Localize(Resources.WorldForm_Shape_All, ShapePropertiesEdit.lblAll);
        }

        protected override void OnSelectionEdit()
        {
            base.OnSelectionEdit();
            UpdateAllProperties();
        }

        protected override void UpdateProperties(IEnumerable<Property> properties)
        {
            if (properties == null)
                return;
            if (Updating)
                return;
            Updating = true;
            foreach (var property in properties)
                switch (property)
                {
                    case Property.ShapeDescription:
                        ShapePropertiesEdit.edDescription.Text = Selection.Description;
                        break;
                    case Property.ShapeLocation:
                        ShapePropertiesEdit.seLocationX.Value = (decimal)Selection.Location.X;
                        ShapePropertiesEdit.seLocationY.Value = (decimal)Selection.Location.Y;
                        ShapePropertiesEdit.seLocationZ.Value = (decimal)Selection.Location.Z;
                        break;
                    case Property.ShapeMaximum:
                        ShapePropertiesEdit.seMaximumX.Value = (decimal)Selection.Maximum.X;
                        ShapePropertiesEdit.seMaximumY.Value = (decimal)Selection.Maximum.Y;
                        ShapePropertiesEdit.seMaximumZ.Value = (decimal)Selection.Maximum.Z;
                        break;
                    case Property.ShapeMinimum:
                        ShapePropertiesEdit.seMinimumX.Value = (decimal)Selection.Minimum.X;
                        ShapePropertiesEdit.seMinimumY.Value = (decimal)Selection.Minimum.Y;
                        ShapePropertiesEdit.seMinimumZ.Value = (decimal)Selection.Minimum.Z;
                        break;
                    case Property.ShapeOrientation:
                        ShapePropertiesEdit.sePitch.Value = (decimal)Selection.Orientation.X;
                        ShapePropertiesEdit.seYaw.Value = (decimal)Selection.Orientation.Y;
                        ShapePropertiesEdit.seRoll.Value = (decimal)Selection.Orientation.Z;
                        break;
                    case Property.ShapePattern:
                        ShapePropertiesEdit.cbPattern.SelectedItem = Selection.Pattern;
                        break;
                    case Property.ShapeScale:
                        ShapePropertiesEdit.seScaleX.Value = (decimal)Selection.Scale.X;
                        ShapePropertiesEdit.seScaleY.Value = (decimal)Selection.Scale.Y;
                        ShapePropertiesEdit.seScaleZ.Value = (decimal)Selection.Scale.Z;
                        break;
                    case Property.ShapeStripeCount:
                        ShapePropertiesEdit.seStripeCountX.Value = (decimal)Selection.StripeCount.X;
                        ShapePropertiesEdit.seStripeCountY.Value = (decimal)Selection.StripeCount.Y;
                        ShapePropertiesEdit.seStripeCountZ.Value = (decimal)Selection.StripeCount.Z;
                        break;
                    case Property.Shapes:
                        OnSelectionEdit();
                        break;
                    case Property.ShapeVisible:
                        ShapePropertiesEdit.cbVisible.CheckState = GetCheckState(Selection.Visible);
                        break;
                }
            Updating = false;
        }

        // Private methods

        private void CopySelectionFromControl()
        {
            if (_selectionUpdating)
                return;
            _selectionUpdating = true;
            Selection.Set(_selectionCon.Selection.Select(p => Scene.Shapes[p]));
            _selectionUpdating = false;
        }

        private void CopySelectionToControl()
        {
            if (_selectionUpdating)
                return;
            _selectionUpdating = true;
            _selectionCon.ShapeCount = Scene.Shapes.Count;
            _selectionCon.SetSelection(Selection.GetShapeIndices().ToList());
            _selectionUpdating = false;
        }

        private void InitLocalControls()
        {
            ShapePropertiesEdit.seStripeCountX.Minimum =
            ShapePropertiesEdit.seStripeCountY.Minimum =
            ShapePropertiesEdit.seStripeCountZ.Minimum = 0;
            ShapePropertiesEdit.cbPattern.Items.AddRange(Enum.GetValues(typeof(Pattern)).Cast<object>().ToArray());
        }

        private void Run(Func<Shape, ICommand> command)
        {
            if (!Selection.IsEmpty)
                Selection.ForEach(p => Run(command(p)));
        }

        private void Selection_Changed(object sender, EventArgs e) => CopySelectionFromControl();

        // Private static methods

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
    }

    /// <summary>
    /// Command runners.
    /// </summary>
    public partial class ShapePropertiesCon
    {
        private void Description_TextChanged(object sender, EventArgs e) => Run(p => new DescriptionCommand(p.Index, ShapePropertiesEdit.edDescription.Text));

        private void LocationX_ValueChanged(object sender, EventArgs e) => Run(p => new LocationCommand(p.Index, new Vector3(
            (float)ShapePropertiesEdit.seLocationX.Value,
            p.Location.Y,
            p.Location.Z)));

        private void LocationY_ValueChanged(object sender, EventArgs e) => Run(p => new LocationCommand(p.Index, new Vector3(
            p.Location.X,
            (float)ShapePropertiesEdit.seLocationY.Value,
            p.Location.Z)));

        private void LocationZ_ValueChanged(object sender, EventArgs e) => Run(p => new LocationCommand(p.Index, new Vector3(
            p.Location.X,
            p.Location.Y,
            (float)ShapePropertiesEdit.seLocationZ.Value)));

        private void MaximumX_ValueChanged(object sender, EventArgs e) => Run(p => new MaximumCommand(p.Index, new Vector3(
            (float)ShapePropertiesEdit.seMaximumX.Value,
            p.Maximum.Y,
            p.Maximum.Z)));

        private void MaximumY_ValueChanged(object sender, EventArgs e) => Run(p => new MaximumCommand(p.Index, new Vector3(
            p.Maximum.X,
            (float)ShapePropertiesEdit.seMaximumY.Value,
            p.Maximum.Z)));

        private void MaximumZ_ValueChanged(object sender, EventArgs e) => Run(p => new MaximumCommand(p.Index, new Vector3(
            p.Maximum.X,
            p.Maximum.Y,
            (float)ShapePropertiesEdit.seMaximumZ.Value)));

        private void MinimumX_ValueChanged(object sender, EventArgs e) => Run(p => new MinimumCommand(p.Index, new Vector3(
            (float)ShapePropertiesEdit.seMinimumX.Value,
            p.Minimum.Y,
            p.Minimum.Z)));

        private void MinimumY_ValueChanged(object sender, EventArgs e) => Run(p => new MinimumCommand(p.Index, new Vector3(
            p.Minimum.X,
            (float)ShapePropertiesEdit.seMinimumY.Value,
            p.Minimum.Z)));

        private void MinimumZ_ValueChanged(object sender, EventArgs e) => Run(p => new MinimumCommand(p.Index, new Vector3(
            p.Minimum.X,
            p.Minimum.Y,
            (float)ShapePropertiesEdit.seMinimumZ.Value)));

        private void OrientationX_ValueChanged(object sender, EventArgs e) => Run(p => new OrientationCommand(p.Index, new Vector3(
            (float)ShapePropertiesEdit.sePitch.Value,
            p.Orientation.Y,
            p.Orientation.Z)));

        private void OrientationY_ValueChanged(object sender, EventArgs e) => Run(p => new OrientationCommand(p.Index, new Vector3(
            p.Orientation.X,
            (float)ShapePropertiesEdit.seYaw.Value,
            p.Orientation.Z)));

        private void OrientationZ_ValueChanged(object sender, EventArgs e) => Run(p => new OrientationCommand(p.Index, new Vector3(
            p.Orientation.X,
            p.Orientation.Y,
            (float)ShapePropertiesEdit.seRoll.Value)));

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

        private void Pattern_SelectedValueChanged(object sender, EventArgs e) => Run(p => new PatternCommand(p.Index, (Pattern)ShapePropertiesEdit.cbPattern.SelectedItem));

        private void ScaleX_ValueChanged(object sender, EventArgs e) => Run(p => new ScaleCommand(p.Index, new Vector3(
            (float)ShapePropertiesEdit.seScaleX.Value,
            p.Scale.Y,
            p.Scale.Z)));

        private void ScaleY_ValueChanged(object sender, EventArgs e) => Run(p => new ScaleCommand(p.Index, new Vector3(
            p.Scale.X,
            (float)ShapePropertiesEdit.seScaleY.Value,
            p.Scale.Z)));

        private void ScaleZ_ValueChanged(object sender, EventArgs e) => Run(p => new ScaleCommand(p.Index, new Vector3(
            p.Scale.X,
            p.Scale.Y,
            (float)ShapePropertiesEdit.seScaleZ.Value)));

        private void StripeCountX_ValueChanged(object sender, EventArgs e) => Run(p => new StripeCountCommand(p.Index, new Vector3i(
            (int)ShapePropertiesEdit.seStripeCountX.Value,
            p.StripeCount.Y,
            p.StripeCount.Z)));

        private void StripeCountY_ValueChanged(object sender, EventArgs e) => Run(p => new StripeCountCommand(p.Index, new Vector3i(
            p.StripeCount.X,
            (int)ShapePropertiesEdit.seStripeCountY.Value,
            p.StripeCount.Z)));

        private void StripeCountZ_ValueChanged(object sender, EventArgs e) => Run(p => new StripeCountCommand(p.Index, new Vector3i(
            p.StripeCount.X,
            p.StripeCount.Y,
            (int)ShapePropertiesEdit.seStripeCountZ.Value)));

        private void ViewShapeProperties_Click(object sender, EventArgs e) => ToggleVisibility();

        private void Visible_CheckedChanged(object sender, EventArgs e) => Run(p => new VisibleCommand(p.Index, ShapePropertiesEdit.cbVisible.Checked));
    }
}
