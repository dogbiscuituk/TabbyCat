namespace Jmk.Controls
{
    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public class JmkToolStripTrackBar : ToolStripControlHost
    {
        public JmkToolStripTrackBar() : base(new TrackBar(), "TrackBar") { }

        public TrackBar TrackBarControl => Control as TrackBar;

        public int LargeChange
        {
            get => TrackBarControl.LargeChange;
            set => TrackBarControl.LargeChange = value;
        }

        public int Maximum
        {
            get => TrackBarControl.Maximum;
            set => TrackBarControl.Maximum = value;
        }

        public int Minimum
        {
            get => TrackBarControl.Minimum;
            set => TrackBarControl.Minimum = value;
        }

        public Orientation Orientation
        {
            get => TrackBarControl.Orientation;
            set => TrackBarControl.Orientation = value;
        }

        public int SmallChange
        {
            get => TrackBarControl.SmallChange;
            set => TrackBarControl.SmallChange = value;
        }

        public int TickFrequency
        {
            get => TrackBarControl.TickFrequency;
            set => TrackBarControl.TickFrequency = value;
        }

        public TickStyle TickStyle
        {
            get => TrackBarControl.TickStyle;
            set => TrackBarControl.TickStyle = value;
        }

        public int Value
        {
            get => TrackBarControl.Value;
            set => TrackBarControl.Value = value;
        }

        public event EventHandler ValueChanged;

        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
            if (control is TrackBar trackBar)
                trackBar.ValueChanged += OnValueChanged;
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            if (control is TrackBar trackBar)
                trackBar.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged(object sender, EventArgs e) => ValueChanged?.Invoke(this, e);
    }
}
