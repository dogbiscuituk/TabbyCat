namespace TabbyCat.Controllers
{
    using Common.Types;
    using Controls;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Properties;
    using Jmk.Controls;
    using System.Globalization;

    internal class SignalCon : LocalizationCon
    {
        internal SignalCon(WorldCon worldCon) : base(worldCon)
        {
            Connect(true);
        }

        /*private WaveType SelectedWaveType
        {
            get => (WaveType)WaveTypeButton.Tag;
            set
            {
                if (SelectedWaveType != value)
                    SetWaveType(value);
            }
        }*/

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            /*if (connect)
            {
                WaveTypeButton.ButtonClick += WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening += WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click += WaveTypeItem_Click;
                AmplitudeTrackBar.ValueChanged += AmplitudeTrackBar_ValueChanged;
                FrequencyTrackBar.ValueChanged += FrequencyTrackBar_ValueChanged;
            }
            else
            {
                WaveTypeButton.ButtonClick -= WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening -= WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click -= WaveTypeItem_Click;
                AmplitudeTrackBar.ValueChanged -= AmplitudeTrackBar_ValueChanged;
                FrequencyTrackBar.ValueChanged -= FrequencyTrackBar_ValueChanged;
            }
            */
        }

        //private void FrequencyTrackBar_ValueChanged(object sender, System.EventArgs e) => InitToolTip(FrequencyToolStripTrackBar, Resources.Text_Frequency);

        //private void AmplitudeTrackBar_ValueChanged(object sender, System.EventArgs e) => InitToolTip(AmplitudeToolStripTrackBar, Resources.Text_Amplitude);

        /*private void InitToolTip(object sender, string format)
        {
            var trackBar = sender as JmkToolStripTrackBar;
            trackBar.ToolTipText = string.Empty;
            trackBar.ToolTipText = string.Format(CultureInfo.CurrentCulture, format, trackBar.Value);
        }*/

        /*protected override void Localize()
        {
            base.Localize();
            foreach (var item in WaveTypeItems)
                Localize(GetLocalization((WaveType)item.Tag), item);
        }*/

        private static string GetLocalization(WaveType waveType)
        {
            switch (waveType)
            {
                case WaveType.FixedValue:
                    return Resources.Menu_WaveType_FixedValue;
                case WaveType.SineWave:
                    return Resources.Menu_WaveType_SineWave;
                case WaveType.TriangleWave:
                    return Resources.Menu_WaveType_TriangleWave;
                case WaveType.ForwardSawtooth:
                    return Resources.Menu_WaveType_ForwardSawtooth;
                case WaveType.BackwardSawtooth:
                    return Resources.Menu_WaveType_BackwardSawtooth;
                case WaveType.SquareWave:
                    return Resources.Menu_WaveType_SquareWave;
                case WaveType.RandomLevels:
                    return Resources.Menu_WaveType_RandomLevels;
                case WaveType.CustomWave:
                    return Resources.Menu_WaveType_CustomWave;
                default:
                    goto case WaveType.FixedValue;
            }
        }

        /*
        private void SetWaveType(WaveType waveType)
        {
            var item = WaveTypeItems.FirstOrDefault(p => (WaveType)p.Tag == waveType);
            if (item == null)
                item = WaveTypeItems.First();
            WaveTypeButton.Image = item.Image;
            WaveTypeButton.ImageTransparentColor = item.ImageTransparentColor;
            WaveTypeButton.Tag = item.Tag;
            WaveTypeButton.ToolTipText = GetLocalization(waveType);
            FrequencyTrackBar.Enabled = waveType != WaveType.FixedValue;
        }

        private void WaveTypeButton_ButtonClick(object sender, System.EventArgs e) => SelectedWaveType = (WaveType)(((int)SelectedWaveType + 1) % 8);

        private void WaveTypeButton_DropDownOpening(object sender, System.EventArgs e)
        {
            foreach (var item in WaveTypeItems)
                item.Checked = (WaveType)item.Tag == SelectedWaveType;
        }

        private void WaveTypeItem_Click(object sender, System.EventArgs e) => SelectedWaveType = (WaveType)((ToolStripItem)sender).Tag;*/
    }
}
