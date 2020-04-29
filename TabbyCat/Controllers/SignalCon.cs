﻿namespace TabbyCat.Controllers
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
            InitSlider(AmplitudeSlider, AmpLeft, AmpRight, AmpSmall, AmpLarge, AmplitudeToGauge(signal.Amplitude));
            InitSlider(FrequencySlider, FreqLeft, FreqRight, FreqSmall, FreqLarge, FrequencyToGauge(signal.Frequency));
            WaveTypeButton.Tag = signal.WaveType;
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
            AmpLeft = -1024,
            AmpRight = +1024,
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

        private TrackBar AmplitudeSlider => SignalEdit.AmplitudeSlider;
        private ToolStripButton DeleteButton => SignalEdit.DeleteButton;
        private TrackBar FrequencySlider => SignalEdit.FrequencySlider;
        private TextBox NameEditor => SignalEdit.NameEditor;
        private ToolStrip Toolbar => SignalEdit.Toolbar;
        private ToolStripSplitButton WaveTypeButton => SignalEdit.WaveTypeButton;

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
            get => (WaveType)WaveTypeButton.Tag;
            set
            {
                if (SelectedWaveType != value)
                {
                    SetWaveType(value);
                    Run(new WaveTypeCommand(Index, value));
                }
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
            var signal = Scene.Signals[Index];
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case PropertyNames.Amplitude:
                        Amplitude = signal.Amplitude;
                        break;
                    case PropertyNames.Frequency:
                        Frequency = signal.Frequency;
                        break;
                    case PropertyNames.Name:
                        NameEditor.Text = signal.Name;
                        break;
                    case PropertyNames.WaveType:
                        SelectedWaveType = signal.WaveType;
                        break;
                }
            Updating = false;
        }

        // Private methods

        private void AmplitudeSlider_ValueChanged(object sender, System.EventArgs e)
        {
            Run(new AmplitudeCommand(Index, Amplitude));
            LocalizeFmt(Resources.SignalsForm_Amplitude, Amplitude, AmplitudeSlider);
        }

        private void DeleteButton_Click(object sender, EventArgs e) => Run(new SignalDeleteCommand(Index));

        private void FrequencySlider_ValueChanged(object sender, System.EventArgs e)
        {
            Run(new FrequencyCommand(Index, Frequency));
            LocalizeFmt(Resources.SignalsForm_Frequency, Frequency, FrequencySlider);
        }

        private void NameEditor_TextChanged(object sender, EventArgs e) => Run(new NameCommand(Index, NameEditor.Text));

        private void Signal_Enter(object sender, System.EventArgs e) => UpdateUI();

        private void UpdateUI()
        {
            //var showFrequency = SelectedWaveType != WaveType.Constant;
            //SignalsCon.BeginUpdate();
            //SignalsForm.FrequencyHeader.Enabled = FrequencySlider.Visible = showFrequency;
            //SignalsPanel.SetColumnSpan(AmplitudeSlider, showFrequency ? 1 : 2);
            //SignalsCon.EndUpdate();
        }

        private void WaveTypeButton_ButtonClick(object sender, System.EventArgs e) => SelectedWaveType = (WaveType)(((int)SelectedWaveType + 1) % 8);

        private void WaveTypeButton_DropDownOpening(object sender, System.EventArgs e)
        {
            foreach (var item in WaveTypeItems)
                item.Checked = (WaveType)item.Tag == SelectedWaveType;
            UpdateUI();
        }

        private void WaveTypeItem_Click(object sender, System.EventArgs e) => SelectedWaveType = (WaveType)((ToolStripItem)sender).Tag;

        private void WorldCon_PropertyChanged(object sender, PropertyChangedEventArgs e) => UpdateProperties(e.PropertyName);

        // Private static methods

        private static float AmplitudeFromGauge(int gauge) => ValueFromGauge(gauge, left: AmpLeft, min: AmpMin, ratio: AmpRatio);

        private static int AmplitudeToGauge(float amplitude) => ValueToGauge(value: amplitude, min: AmpMin, left: AmpLeft, ratio: AmpRatio);

        private static float FrequencyFromGauge(int gauge) => ValueFromGauge(gauge, left: FreqLeft, min: FreqMin, ratio: FreqRatio);

        private static int FrequencyToGauge(float frequency) => ValueToGauge(value: frequency, min: FreqMin, left: FreqLeft, ratio: FreqRatio);

        private static void InitSlider(TrackBar slider, int left, int right, int small, int large, int gauge)
        {
            slider.Minimum = left;
            slider.Maximum = right;
            slider.SmallChange = small;
            slider.LargeChange = large;
            slider.Value = gauge;
        }

        private static float ValueFromGauge(int gauge, int left, float min, float ratio) => min + (gauge - left) * ratio;

        private static int ValueToGauge(float value, float min, int left, float ratio) => (int)Math.Round(left + (value - min) / ratio);
    }
}
