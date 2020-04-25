namespace TabbyCat.Controllers
{
    using Common.Types;
    using Controls;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    internal class SignalCon : LocalizationCon
    {
        internal SignalCon(WorldCon worldCon) : base(worldCon) { }

        internal TextBox NameEditor;

        internal TrackBar
            AmplitudeSlider,
            FrequencySlider;

        internal SignalToolbar SignalToolbar;

        private ToolStripButton DeleteButton => SignalToolbar.DeleteButton;

        private ToolStripSplitButton WaveTypeButton => SignalToolbar.WaveTypeButton;

        private IEnumerable<ToolStripMenuItem> WaveTypeItems => WaveTypeButton.DropDownItems.OfType<ToolStripMenuItem>();

        internal void DisposeControls() => DisposeControls(NameEditor, AmplitudeSlider, FrequencySlider, SignalToolbar);

        internal void DisposeControls(params Control[] controls) => Array.ForEach(controls, control =>
        {
            SignalsLayoutControls.Remove(control);
            control.Dispose();
        });

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

        protected override void Localize()
        {
            base.Localize();
            foreach (var item in WaveTypeItems)
                Localize((WaveType)item.Tag, item);
        }

        private void Localize(WaveType waveType, ToolStripItem item) => Localize(GetLocalization(waveType), item);

        private void AmplitudeSlider_ValueChanged(object sender, System.EventArgs e) => InitToolTip(AmplitudeSlider, Resources.Text_Amplitude);

        private void FrequencySlider_ValueChanged(object sender, System.EventArgs e) => InitToolTip(FrequencySlider, Resources.Text_Frequency);

        private void InitToolTip(TrackBar slider, string format) => ToolTip.SetToolTip(slider, string.Format(CultureInfo.CurrentCulture, format, slider.Value));

        private WaveType SelectedWaveType
        {
            get => (WaveType)WaveTypeButton.Tag;
            set
            {
                if (SelectedWaveType != value)
                    SetWaveType(value);
            }
        }

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

        private static float GetValue(TrackBar t, float min, float max) => min + (max - min) * (t.Value - t.Minimum) / (t.Maximum - t.Minimum);

        private static void SetValue(TrackBar t, float min, float max, float value) => t.Value = (int)Math.Min(Math.Max(
            t.Minimum, Math.Round(t.Minimum + (t.Maximum - t.Minimum) * (value - min) / (max - min))), t.Maximum);

        /*
        private float Amplitude
        {
            get => GetValue(AmplitudeSlider, AmpMin, AmpMax);
            set => SetValue(AmplitudeSlider, AmpMin, AmpMax, value);
        }
        */

        /*
        private float Frequency
        {
            get => GetValue(FrequencySlider, FreqMin, FreqMax);
            set => SetValue(FrequencySlider, FreqMin, FreqMax, value);
        }
        */
    }
}
