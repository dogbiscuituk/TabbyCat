namespace TabbyCat.Controllers
{
    using Commands;
    using Models;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Types;
    using UserControls;
    using Utils;

    public class SignalCon : LocalizationCon
    {
        // Constructors

        public SignalCon(WorldCon worldCon, Signal signal) : base(worldCon)
        {
            SignalEdit = new SignalEdit();
            Index = Scene.Signals.IndexOf(signal);
            NameEditor.AutoSize = true;
            NameEditor.Text = signal?.Name;
            InitRanges(signal);
            InitSlider(AmplitudeSlider, AmpGaugeMin, AmpGaugeMax, AmpGaugeSmall, AmpGaugeLarge, AmplitudeToGauge(signal.Amplitude));
            InitSlider(FrequencySlider, FreqGaugeMin, FreqGaugeMax, FreqGaugeSmall, FreqGaugeLarge, FrequencyToGauge(signal.Frequency));
            SignalsForm.AddButton.CloneTo(SignalEdit.WaveTypeButton, ToolStripUtils.CloneOptions.None);
            AppCon.InitControlTheme(Toolbar);
            UpdateAllProperties();
        }

        // Public fields

        /// <summary>
        /// The index of this control's Signal in the Scene.Signals collection.
        /// </summary>
        public int Index { get; set; }

        public SignalEdit SignalEdit { get; set; }

        // Protected properties

        protected override IEnumerable<Property> AllProperties => new[]
        {
            Property.SignalAmplitude,
            Property.SignalAmplitudeMaximum,
            Property.SignalAmplitudeMinimum,
            Property.SignalFrequency,
            Property.SignalFrequencyMaximum,
            Property.SignalFrequencyMinimum,
            Property.SignalName,
            Property.SignalWaveType,
        };

        // Private constants

        private const int
            AmpGaugeMin = 0,
            AmpGaugeMax = 1000,
            AmpGaugeSmall = 1,
            AmpGaugeLarge = 10,
            AmpGaugeRange = AmpGaugeMax - AmpGaugeMin,
            FreqGaugeMin = 0,
            FreqGaugeMax = 500,
            FreqGaugeSmall = 1,
            FreqGaugeLarge = 10,
            FreqGaugeRange = FreqGaugeMax - FreqGaugeMin;

        // Private fields

        private float
            AmpMin,
            AmpRatio,
            LogFreqMin,
            LogFreqRatio;

        // Private properties

        private TrackBar AmplitudeSlider => SignalEdit.AmplitudeSlider;
        private ToolStripButton DeleteButton => SignalEdit.DeleteButton;
        private TrackBar FrequencySlider => SignalEdit.FrequencySlider;
        private TextBox NameEditor => SignalEdit.NameEditor;
        private ToolStrip Toolbar => SignalEdit.Toolbar;
        private ToolStripSplitButton WaveTypeButton => SignalEdit.WaveTypeButton;
        private Signal Signal => Scene.Signals[Index];
        private ToolStripMenuItem SignalProperties => SignalEdit.SignalProperties;

        private float Amplitude
        {
            get => AmplitudeFromGauge(AmplitudeSlider.Value);
            set => AmplitudeSlider.Value = AmplitudeToGauge(value);
        }

        private float Frequency
        {
            get => FrequencyFromGauge(FrequencySlider.Value);
            set => FrequencySlider.Value = FrequencyToGauge(value);
        }

        private WaveType SelectedWaveType
        {
            get
            {
                var tag = WaveTypeButton.Tag;
                return tag == null ? WaveType.Constant : (WaveType)tag;
            }
            set => SetWaveType(value);
        }

        private IEnumerable<ToolStripMenuItem> WaveTypeItems => WaveTypeButton.DropDownItems.OfType<ToolStripMenuItem>().Where(p => p.Tag != null);

        // Public methods

        public void InitRanges(Signal signal)
        {
            if (signal == null)
                return;
            AmpMin = signal.AmplitudeMinimum;
            AmpRatio = (signal.AmplitudeMaximum - AmpMin) / AmpGaugeRange;
            LogFreqMin = (float)Math.Log(signal.FrequencyMinimum);
            LogFreqRatio = (float)(Math.Log(signal.FrequencyMaximum) - LogFreqMin) / FreqGaugeRange;
        }

        public void SetWaveType(WaveType waveType)
        {
            var item = WaveTypeItems.FirstOrDefault(p => (WaveType)p.Tag == waveType);
            if (item == null)
                item = WaveTypeItems.First();
            WaveTypeButton.Image = item.Image;
            WaveTypeButton.ImageTransparentColor = item.ImageTransparentColor;
            WaveTypeButton.Tag = item.Tag;
            UpdateUI();
        }

        // Protected public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                AmplitudeSlider.ValueChanged += AmplitudeSlider_ValueChanged;
                AmplitudeSlider.Enter += Signal_Enter;
                DeleteButton.Click += DeleteButton_Click;
                FrequencySlider.Enter += Signal_Enter;
                FrequencySlider.ValueChanged += FrequencySlider_ValueChanged;
                NameEditor.Enter += Signal_Enter;
                NameEditor.TextChanged += NameEditor_TextChanged;
                SignalProperties.Click += SignalProperties_Click;
                WaveTypeButton.ButtonClick += WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening += WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click += WaveTypeItem_Click;
                WorldCon.PropertyEdit += WorldCon_PropertyEdit;
            }
            else
            {
                AmplitudeSlider.Enter -= Signal_Enter;
                AmplitudeSlider.ValueChanged -= AmplitudeSlider_ValueChanged;
                DeleteButton.Click -= DeleteButton_Click;
                FrequencySlider.Enter -= Signal_Enter;
                FrequencySlider.ValueChanged -= FrequencySlider_ValueChanged;
                NameEditor.Enter -= Signal_Enter;
                NameEditor.TextChanged -= NameEditor_TextChanged;
                SignalProperties.Click -= SignalProperties_Click;
                WaveTypeButton.ButtonClick -= WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening -= WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click -= WaveTypeItem_Click;
                WorldCon.PropertyEdit -= WorldCon_PropertyEdit;
            }
        }

        // Protected methods

        protected override void Localize()
        {
            Localize(Resources.SignalsForm_WaveType, SignalEdit.WaveTypeButton);
            Localize(Resources.SignalsForm_DeleteButton, SignalEdit.DeleteButton);
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
                    case Property.SignalAmplitude:
                        Amplitude = Signal.Amplitude;
                        break;
                    case Property.SignalFrequency:
                        Frequency = Signal.Frequency;
                        break;
                    case Property.SignalAmplitudeMaximum:
                    case Property.SignalAmplitudeMinimum:
                    case Property.SignalFrequencyMaximum:
                    case Property.SignalFrequencyMinimum:
                        InitRanges(Signal);
                        break;
                    case Property.SignalName:
                        NameEditor.Text = Signal.Name;
                        break;
                    case Property.SignalWaveType:
                        SelectedWaveType = Signal.WaveType;
                        break;
                }
            Updating = false;
        }

        // Private methods

        private float AmplitudeFromGauge(int gauge) => ValueFromGauge(gauge, left: AmpGaugeMin, min: AmpMin, ratio: AmpRatio);

        private void AmplitudeSlider_ValueChanged(object sender, EventArgs e)
        {
            Run(new AmplitudeCommand(Index, Amplitude));
            LocalizeFmt(Resources.SignalsForm_Amplitude, Amplitude, AmplitudeSlider);
        }

        private int AmplitudeToGauge(float amplitude) => ValueToGauge(value: amplitude, min: AmpMin, left: AmpGaugeMin, ratio: AmpRatio);

        private void DeleteButton_Click(object sender, EventArgs e) => Run(new SignalDeleteCommand(Index));

        private float FrequencyFromGauge(int gauge) => ValueFromGaugeLog(gauge, left: FreqGaugeMin, min: LogFreqMin, ratio: LogFreqRatio);

        private void FrequencySlider_ValueChanged(object sender, EventArgs e)
        {
            Run(new FrequencyCommand(Index, Frequency));
            LocalizeFmt(Resources.SignalsForm_Frequency, Frequency, FrequencySlider);
        }

        private int FrequencyToGauge(float frequency) => ValueToGaugeLog(value: frequency, min: LogFreqMin, left: FreqGaugeMin, ratio: LogFreqRatio);

        private void NameEditor_TextChanged(object sender, EventArgs e) => Run(new SignalNameCommand(Index, NameEditor.Text));

        private void Signal_Enter(object sender, EventArgs e) => UpdateUI();

        private void SignalProperties_Click(object sender, EventArgs e)
        {
            var signal = Signal;
            using (var signalPropertiesCon = new SignalPropertiesCon(WorldCon))
                if (!signalPropertiesCon.Execute(ref signal))
                    return;
            Run(new SignalNameCommand(Index, signal.Name));
            Run(new WaveTypeCommand(Index, signal.WaveType));
            Run(new AmplitudeCommand(Index, signal.Amplitude));
            Run(new AmplitudeMinimumCommand(Index, signal.AmplitudeMinimum));
            Run(new AmplitudeMaximumCommand(Index, signal.AmplitudeMaximum));
            Run(new FrequencyCommand(Index, signal.Frequency));
            Run(new FrequencyMinimumCommand(Index, signal.FrequencyMinimum));
            Run(new FrequencyMaximumCommand(Index, signal.FrequencyMaximum));
        }

        private void UpdateUI() => FrequencySlider.Enabled = SelectedWaveType != WaveType.Constant;

        private void WaveTypeButton_ButtonClick(object sender, EventArgs e) => SelectedWaveType = (WaveType)(((int)SelectedWaveType + 1) % 8);

        private void WaveTypeButton_DropDownOpening(object sender, EventArgs e)
        {
            foreach (var item in WaveTypeItems)
                item.Checked = (WaveType)item.Tag == SelectedWaveType;
            UpdateUI();
        }

        private void WaveTypeItem_Click(object sender, EventArgs e) => Run(new WaveTypeCommand(Index, (WaveType)((ToolStripItem)sender).Tag));

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e) => UpdateProperty(e.Property);

        // Private static methods

        private static void InitSlider(TrackBar slider, int left, int right, int small, int large, int gauge)
        {
            slider.Minimum = left;
            slider.Maximum = right;
            slider.SmallChange = small;
            slider.LargeChange = large;
            slider.Value = gauge;
        }

        private static float ValueFromGauge(int gauge, int left, float min, float ratio) => min + (gauge - left) * ratio;

        private static float ValueFromGaugeLog(int gauge, int left, float min, float ratio) => (float)Math.Exp(min + (gauge - left) * ratio);

        private static int ValueToGauge(float value, float min, int left, float ratio) => (int)Math.Round(left + (value - min) / ratio);

        private static int ValueToGaugeLog(float value, float min, int left, float ratio) => (int)Math.Round(left + (Math.Log(value) - min) / ratio);
    }
}
