namespace TabbyCat.Controllers
{
    using Common.Types;
    using Common.Utils;
    using Controls;
    using Models;
    using TabbyCat.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;

    internal class SignalCon : LocalizationCon
    {
        // Constructors

        internal SignalCon(WorldCon worldCon, Signal signal) : base(worldCon)
        {
            SignalEdit = new SignalEdit();
            Index = Scene.Signals.IndexOf(signal);
            NameEditor.AutoSize = true;
            NameEditor.Text = signal.Name;
            InitSlider(AmplitudeSlider, AmpGaugeMin, AmpGaugeMax, AmpGaugeSmall, AmpGaugeLarge, AmplitudeToGauge(signal.Amplitude));
            InitSlider(FrequencySlider, FreqGaugeMin, FreqGaugeMax, FreqGaugeSmall, FreqGaugeLarge, FrequencyToGauge(signal.Frequency));
            SignalsForm.AddButton.CloneTo(SignalEdit.WaveTypeButton, onClick: false);
            AppCon.InitControlTheme(Toolbar);
            UpdateAllProperties();
        }

        // Internal fields

        internal int Index;
        internal SignalEdit SignalEdit;

        // Protected properties

        protected override string[] AllProperties => new[]
        {
            PropertyNames.Name,
            PropertyNames.WaveType,
            PropertyNames.Amplitude,
            PropertyNames.Frequency
        };

        // Private constants

        private const int
            AmpGaugeMin = -1024,
            AmpGaugeMax = +1024,
            AmpGaugeSmall = 1,
            AmpGaugeLarge = 10,
            AmpGaugeRange = AmpGaugeMax - AmpGaugeMin,
            FreqGaugeMin = 0,
            FreqGaugeMax = 1000,
            FreqGaugeSmall = 1,
            FreqGaugeLarge = 10,
            FreqGaugeRange = FreqGaugeMax - FreqGaugeMin;

        private const double
            AmpMin = -1,
            AmpMax = +1,
            FreqMin = 0.1,
            FreqMax = 100,
            AmpRange = AmpMax - AmpMin,
            AmpRatio = AmpRange / AmpGaugeRange;

        // Private fields

        private static readonly double
            LogFreqMin = Math.Log(FreqMin),
            LogFreqMax = Math.Log(FreqMax),
            LogFreqRange = LogFreqMax - LogFreqMin,
            LogFreqRatio = LogFreqRange / FreqGaugeRange;

        // Private properties

        private TrackBar AmplitudeSlider => SignalEdit.AmplitudeSlider;
        private ToolStripButton DeleteButton => SignalEdit.DeleteButton;
        private TrackBar FrequencySlider => SignalEdit.FrequencySlider;
        private TextBox NameEditor => SignalEdit.NameEditor;
        private ToolStrip Toolbar => SignalEdit.Toolbar;
        private ToolStripSplitButton WaveTypeButton => SignalEdit.WaveTypeButton;

        private double Amplitude
        {
            get => AmplitudeFromGauge(AmplitudeSlider.Value);
            set => AmplitudeSlider.Value = AmplitudeToGauge(value);
        }

        private double Frequency
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
            set
            {
                SetWaveType(value);
                if (SelectedWaveType != value)
                    Run(new WaveTypeCommand(Index, value));
            }
        }

        private IEnumerable<ToolStripMenuItem> WaveTypeItems => WaveTypeButton.DropDownItems.OfType<ToolStripMenuItem>();

        // Internal methods

        internal void SetWaveType(WaveType waveType)
        {
            var item = WaveTypeItems.FirstOrDefault(p => (WaveType)p.Tag == waveType);
            if (item == null)
                item = WaveTypeItems.First();
            WaveTypeButton.Image = item.Image;
            WaveTypeButton.ImageTransparentColor = item.ImageTransparentColor;
            WaveTypeButton.Tag = item.Tag;
            UpdateUI();
        }

        // Protected internal methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                AmplitudeSlider.Enter += Signal_Enter;
                AmplitudeSlider.ValueChanged += AmplitudeSlider_ValueChanged;
                DeleteButton.Click += DeleteButton_Click;
                FrequencySlider.Enter += Signal_Enter;
                FrequencySlider.ValueChanged += FrequencySlider_ValueChanged;
                NameEditor.Enter += Signal_Enter;
                NameEditor.TextChanged += NameEditor_TextChanged;
                WaveTypeButton.ButtonClick += WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening += WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click += WaveTypeItem_Click;
                WorldCon.PropertyChanged += WorldCon_PropertyChanged;
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
                WaveTypeButton.ButtonClick -= WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening -= WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click -= WaveTypeItem_Click;
                WorldCon.PropertyChanged -= WorldCon_PropertyChanged;
            }
        }

        // Protected methods

        protected override void UpdateProperties(params string[] propertyNames)
        {
            if (Updating)
                return;
            Updating = true;
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case PropertyNames.Amplitude:
                        Amplitude = Scene.Signals[Index].Amplitude;
                        break;
                    case PropertyNames.Frequency:
                        Frequency = Scene.Signals[Index].Frequency;
                        break;
                    case PropertyNames.Name:
                        NameEditor.Text = Scene.Signals[Index].Name;
                        break;
                    case PropertyNames.WaveType:
                        SelectedWaveType = Scene.Signals[Index].WaveType;
                        break;
                }
            Updating = false;
        }

        // Private methods

        private void AmplitudeSlider_ValueChanged(object sender, EventArgs e)
        {
            Run(new AmplitudeCommand(Index, (float)Amplitude));
            LocalizeFmt(Resources.SignalsForm_Amplitude, Amplitude, AmplitudeSlider);
        }

        private void DeleteButton_Click(object sender, EventArgs e) => Run(new SignalDeleteCommand(Index));

        private void FrequencySlider_ValueChanged(object sender, EventArgs e)
        {
            Run(new FrequencyCommand(Index, (float)Frequency));
            LocalizeFmt(Resources.SignalsForm_Frequency, Frequency, FrequencySlider);
        }

        private void NameEditor_TextChanged(object sender, EventArgs e) => Run(new NameCommand(Index, NameEditor.Text));

        private void Signal_Enter(object sender, EventArgs e) => UpdateUI();

        private void UpdateUI() => FrequencySlider.Enabled = SelectedWaveType != WaveType.Constant;

        private void WaveTypeButton_ButtonClick(object sender, EventArgs e) => SelectedWaveType = (WaveType)(((int)SelectedWaveType + 1) % 8);

        private void WaveTypeButton_DropDownOpening(object sender, EventArgs e)
        {
            foreach (var item in WaveTypeItems)
                item.Checked = (WaveType)item.Tag == SelectedWaveType;
            UpdateUI();
        }

        private void WaveTypeItem_Click(object sender, EventArgs e) => SelectedWaveType = (WaveType)((ToolStripItem)sender).Tag;

        private void WorldCon_PropertyChanged(object sender, PropertyChangedEventArgs e) => UpdateProperties(e.PropertyName);

        // Private static methods

        private static double AmplitudeFromGauge(int gauge) => ValueFromGauge(gauge, left: AmpGaugeMin, min: AmpMin, ratio: AmpRatio);

        private static int AmplitudeToGauge(double amplitude) => ValueToGauge(value: amplitude, min: AmpMin, left: AmpGaugeMin, ratio: AmpRatio);

        private static double FrequencyFromGauge(int gauge) => ValueFromGaugeLog(gauge, left: FreqGaugeMin, min: LogFreqMin, ratio: LogFreqRatio);

        private static int FrequencyToGauge(double frequency) => ValueToGaugeLog(value: frequency, min: LogFreqMin, left: FreqGaugeMin, ratio: LogFreqRatio);

        private static void InitSlider(TrackBar slider, int left, int right, int small, int large, int gauge)
        {
            slider.Minimum = left;
            slider.Maximum = right;
            slider.SmallChange = small;
            slider.LargeChange = large;
            slider.Value = gauge;
        }

        private static double ValueFromGauge(int gauge, int left, double min, double ratio) => min + (gauge - left) * ratio;

        private static double ValueFromGaugeLog(int gauge, int left, double min, double ratio) => Math.Exp(min + (gauge - left) * ratio);

        private static int ValueToGauge(double value, double min, int left, double ratio) => (int)Math.Round(left + (value - min) / ratio);

        private static int ValueToGaugeLog(double value, double min, int left, double ratio) => (int)Math.Round(left + (Math.Log(value) - min) / ratio);
    }
}
