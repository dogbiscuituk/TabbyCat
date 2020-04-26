namespace TabbyCat.Controllers
{
    using Common.Types;
    using Controls;
    using Models;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    internal class SignalCon : LocalizationCon
    {
        // Constructors

        internal SignalCon(WorldCon worldCon, Signal signal) : base(worldCon)
        {
            NameEditor = NewNameEditor(signal.Name);
            AmplitudeSlider = NewSlider();
            FrequencySlider = NewSlider();
            SignalToolbar = NewSignalToolbar();
            InitSlider(AmplitudeSlider, AmpLeft, AmpRight, AmpSmall, AmpLarge, AmplitudeToGauge(signal.Amplitude));
            InitSlider(FrequencySlider, FreqLeft, FreqRight, FreqSmall, FreqLarge, FrequencyToGauge(signal.Frequency));
            AppCon.InitControlTheme(SignalToolbar.ToolStrip);
        }

        // Internal fields

        internal TextBox NameEditor;

        internal TrackBar
            AmplitudeSlider,
            FrequencySlider;

        internal SignalToolbar SignalToolbar;

        // Private constants

        private const int
            AmpLeft = -1000,
            AmpRight = +1000,
            AmpSmall = 1,
            AmpLarge = 10,
            FreqLeft = 0,
            FreqRight = 1000,
            FreqSmall = 1,
            FreqLarge = 10;

        private const float
            AmpMin = -1,
            AmpMax = +1,
            AmpRatio = (AmpMax - AmpMin) / (AmpRight - AmpLeft),
            FreqMin = 0,
            FreqMax = 100,
            FreqRatio = (FreqMax - FreqMin) / (FreqRight - FreqLeft);

        // Private properties

        private float Amplitude
        {
            get => AmplitudeFromGauge(AmplitudeSlider.Value);
            set => AmplitudeSlider.Value = AmplitudeToGauge(value);
        }

        private ToolStripButton DeleteButton => SignalToolbar.DeleteButton;

        private float Frequency
        {
            get => FrequencyFromGauge(FrequencySlider.Value);
            set => FrequencySlider.Value = FrequencyToGauge(value);
        }

        private WaveType SelectedWaveType
        {
            get => (WaveType)WaveTypeButton.Tag;
            set
            {
                if (SelectedWaveType != value)
                    SetWaveType(value);
            }
        }

        private ToolStripSplitButton WaveTypeButton => SignalToolbar.WaveTypeButton;

        private IEnumerable<ToolStripMenuItem> WaveTypeItems => WaveTypeButton.DropDownItems.OfType<ToolStripMenuItem>();

        // Internal methods

        internal void DisposeControls() => DisposeControls(NameEditor, AmplitudeSlider, FrequencySlider, SignalToolbar);

        internal void DisposeControls(params Control[] controls) => Array.ForEach(controls, control =>
        {
            SignalsLayoutControls.Remove(control);
            control.Dispose();
        });

        internal void SetWaveType(WaveType waveType)
        {
            var item = WaveTypeItems.FirstOrDefault(p => (WaveType)p.Tag == waveType);
            if (item == null)
                item = WaveTypeItems.First();
            WaveTypeButton.Image = item.Image;
            WaveTypeButton.ImageTransparentColor = item.ImageTransparentColor;
            WaveTypeButton.Tag = item.Tag;
            Localize(waveType, WaveTypeButton);
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
                FrequencySlider.Enter += Signal_Enter;
                FrequencySlider.ValueChanged += FrequencySlider_ValueChanged;
                NameEditor.Enter += Signal_Enter;
                WaveTypeButton.ButtonClick += WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening += WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click += WaveTypeItem_Click;
            }
            else
            {
                AmplitudeSlider.Enter -= Signal_Enter;
                AmplitudeSlider.ValueChanged -= AmplitudeSlider_ValueChanged;
                FrequencySlider.Enter -= Signal_Enter;
                FrequencySlider.ValueChanged -= FrequencySlider_ValueChanged;
                NameEditor.Enter -= Signal_Enter;
                WaveTypeButton.ButtonClick -= WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening -= WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click -= WaveTypeItem_Click;
            }
        }

        // Protected methods

        protected override void Localize()
        {
            base.Localize();
            foreach (var item in WaveTypeItems)
                Localize((WaveType)item.Tag, item);
        }

        // Private methods

        private void Localize(WaveType waveType, ToolStripItem item) => Localize(GetLocalization(waveType), item);

        private void AmplitudeSlider_ValueChanged(object sender, System.EventArgs e)
        {
            InitToolTip(AmplitudeSlider, Resources.Text_Amplitude, Amplitude);
        }

        private void FrequencySlider_ValueChanged(object sender, System.EventArgs e) => InitToolTip(FrequencySlider, Resources.Text_Frequency, Frequency);

        private void InitToolTip(TrackBar slider, string format, float value) => ToolTip.SetToolTip(slider, string.Format(CultureInfo.CurrentCulture, format, value));

        private void Signal_Enter(object sender, System.EventArgs e) => UpdateUI();

        private void UpdateUI()
        {
            var showFrequency = SelectedWaveType != WaveType.Constant;
            SignalsCon.BeginUpdate();
            SignalsForm.FrequencyHeader.Enabled = FrequencySlider.Visible = showFrequency;
            SignalsLayoutPanel.SetColumnSpan(AmplitudeSlider, showFrequency ? 1 : 2);
            SignalsCon.EndUpdate();
        }

        private void WaveTypeButton_ButtonClick(object sender, System.EventArgs e) => SelectedWaveType = (WaveType)(((int)SelectedWaveType + 1) % 8);

        private void WaveTypeButton_DropDownOpening(object sender, System.EventArgs e)
        {
            foreach (var item in WaveTypeItems)
                item.Checked = (WaveType)item.Tag == SelectedWaveType;
            UpdateUI();
        }

        private void WaveTypeItem_Click(object sender, System.EventArgs e) => SelectedWaveType = (WaveType)((ToolStripItem)sender).Tag;

        // Private static methods

        private static float AmplitudeFromGauge(int gauge) => ValueFromGauge(gauge, left: AmpLeft, min: AmpMin, ratio: AmpRatio);

        private static int AmplitudeToGauge(float amplitude) => ValueToGauge(value: amplitude, min: AmpMin, left: AmpLeft, ratio: AmpRatio);

        private static float FrequencyFromGauge(int gauge) => ValueFromGauge(gauge, left: FreqLeft, min: FreqMin, ratio: FreqRatio);

        private static int FrequencyToGauge(float frequency) => ValueToGauge(value: frequency, min: FreqMin, left: FreqLeft, ratio: FreqRatio);

        private static string GetLocalization(WaveType waveType)
        {
            switch (waveType)
            {
                case WaveType.Constant:
                    return Resources.Menu_WaveType_Constant;
                case WaveType.Sine:
                    return Resources.Menu_WaveType_Sine;
                case WaveType.Square:
                    return Resources.Menu_WaveType_Square;
                case WaveType.Triangle:
                    return Resources.Menu_WaveType_Triangle;
                case WaveType.Sawtooth:
                    return Resources.Menu_WaveType_Sawtooth;
                case WaveType.ReverseSawtooth:
                    return Resources.Menu_WaveType_ReverseSawtooth;
                case WaveType.Custom:
                    return Resources.Menu_WaveType_Custom;
                case WaveType.Noise:
                    return Resources.Menu_WaveType_Noise;
                default:
                    goto case WaveType.Constant;
            }
        }

        private static void InitSlider(TrackBar slider, int left, int right, int small, int large, int gauge)
        {
            slider.Minimum = left;
            slider.Maximum = right;
            slider.SmallChange = small;
            slider.LargeChange = large;
            slider.Value = gauge;
        }

        private static TextBox NewNameEditor(string name) => new TextBox
        {
            AutoSize = true,
            BorderStyle = BorderStyle.None,
            Dock = DockStyle.Fill,
            Margin = new Padding(3, 0, 3, 0),
            Padding = new Padding(0),
            Size = new Size(30, 25),
            Text = name,
            TextAlign = HorizontalAlignment.Center
        };

        private static SignalToolbar NewSignalToolbar() => new SignalToolbar
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0)
        };

        private static TrackBar NewSlider() => new TrackBar
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            TickStyle = TickStyle.None
        };

        private static float ValueFromGauge(int gauge, int left, float min, float ratio) => min + (gauge - left) * ratio;

        private static int ValueToGauge(float value, float min, int left, float ratio) => (int)Math.Round(left + (value - min) / ratio);
    }
}
