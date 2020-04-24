namespace TabbyCat.Controllers
{
    using Common.Types;
    using Controls;
    using Properties;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    internal class SignalCon : LocalizationCon
    {
        internal SignalCon(WorldCon worldCon, string name) : base(worldCon)
        {
            var rowIndex = TableLayoutPanel.RowCount - 1;
            Controls.Add(NameTextBox = NewNameTextBox(name), 0, rowIndex);
            Controls.Add(AmplitudeSlider = NewSlider(), 1, rowIndex);
            Controls.Add(FrequencySlider = NewSlider(), 2, rowIndex);
            Controls.Add(SignalToolbar = NewSignalToolbar(), 3, rowIndex);
            InitSignalToolbar();
            TableLayoutPanel.RowCount++;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
            Connect(true);
        }

        private readonly TextBox NameTextBox;

        private readonly TrackBar
            AmplitudeSlider,
            FrequencySlider;

        private readonly SignalToolbar SignalToolbar;

        private TableLayoutControlCollection Controls => TableLayoutPanel.Controls;

        private ToolStripButton DeleteButton => SignalToolbar.DeleteButton;

        private TableLayoutPanel TableLayoutPanel => ParametersForm.TableLayoutPanel;

        private ToolStripSplitButton WaveTypeButton => SignalToolbar.WaveTypeButton;

        private IEnumerable<ToolStripMenuItem> WaveTypeItems => WaveTypeButton.DropDownItems.OfType<ToolStripMenuItem>();

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WaveTypeButton.ButtonClick += WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening += WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click += WaveTypeItem_Click;
                AmplitudeSlider.Enter += Signal_Enter;
                AmplitudeSlider.ValueChanged += AmplitudeSlider_ValueChanged;
                FrequencySlider.Enter += Signal_Enter;
                FrequencySlider.ValueChanged += FrequencySlider_ValueChanged;
            }
            else
            {
                WaveTypeButton.ButtonClick -= WaveTypeButton_ButtonClick;
                WaveTypeButton.DropDownOpening -= WaveTypeButton_DropDownOpening;
                foreach (var item in WaveTypeItems)
                    item.Click -= WaveTypeItem_Click;
                AmplitudeSlider.Enter -= Signal_Enter;
                AmplitudeSlider.ValueChanged -= AmplitudeSlider_ValueChanged;
                FrequencySlider.Enter -= Signal_Enter;
                FrequencySlider.ValueChanged -= FrequencySlider_ValueChanged;
            }
        }

        protected override void Localize()
        {
            base.Localize();
            foreach (var item in WaveTypeItems)
                Localize(GetLocalization((WaveType)item.Tag), item);
        }

        private void AmplitudeSlider_ValueChanged(object sender, System.EventArgs e) => InitToolTip(AmplitudeSlider, Resources.Text_Amplitude);

        private void FrequencySlider_ValueChanged(object sender, System.EventArgs e) => InitToolTip(FrequencySlider, Resources.Text_Frequency);

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

        private void InitSignalToolbar()
        {
            WaveTypeButton.Tag = WaveType.FixedValue;
            SignalToolbar.FixedValue.Tag = WaveType.FixedValue;
            SignalToolbar.SineWave.Tag = WaveType.SineWave;
            SignalToolbar.TriangleWave.Tag = WaveType.TriangleWave;
            SignalToolbar.ForwardSawtooth.Tag = WaveType.ForwardSawtooth;
            SignalToolbar.BackwardSawtooth.Tag = WaveType.BackwardSawtooth;
            SignalToolbar.SquareWave.Tag = WaveType.SquareWave;
            SignalToolbar.RandomLevels.Tag = WaveType.RandomLevels;
            SignalToolbar.CustomWave.Tag = WaveType.CustomWave;
            SetWaveType(WaveType.FixedValue);
        }

        private void InitToolTip(TrackBar slider, string format) => ToolTip.SetToolTip(slider, string.Format(CultureInfo.CurrentCulture, format, slider.Value));

        private static TextBox NewNameTextBox(string name) => new TextBox
        {
            AutoSize = true,
            BorderStyle = BorderStyle.None,
            Dock = DockStyle.Fill,
            Margin = new Padding(3, 0, 3, 0),
            Padding = new Padding(0),
            Size = new Size(30, 25),
            Text = name
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

        private WaveType SelectedWaveType
        {
            get => (WaveType)WaveTypeButton.Tag;
            set
            {
                if (SelectedWaveType != value)
                    SetWaveType(value);
            }
        }

        private void SetWaveType(WaveType waveType)
        {
            var item = WaveTypeItems.FirstOrDefault(p => (WaveType)p.Tag == waveType);
            if (item == null)
                item = WaveTypeItems.First();
            WaveTypeButton.Image = item.Image;
            WaveTypeButton.ImageTransparentColor = item.ImageTransparentColor;
            WaveTypeButton.Tag = item.Tag;
            WaveTypeButton.ToolTipText = GetLocalization(waveType);
            if (waveType == WaveType.FixedValue)
            {
                FrequencySlider.Visible = false;
                TableLayoutPanel.SetColumnSpan(AmplitudeSlider, 2);
            }
            else
            {
                TableLayoutPanel.SetColumnSpan(AmplitudeSlider, 1);
                FrequencySlider.Visible = true;
            }
        }

        private void Signal_Enter(object sender, System.EventArgs e) => UpdateHeadings();

        private void UpdateHeadings()
        {
            if (SelectedWaveType == WaveType.FixedValue)
            {
                ParametersForm.FrequencyHeader.Enabled = false;
            }
            else
            {
                ParametersForm.FrequencyHeader.Enabled = true;
            }
        }

        private void WaveTypeButton_ButtonClick(object sender, System.EventArgs e) => SelectedWaveType = (WaveType)(((int)SelectedWaveType + 1) % 8);

        private void WaveTypeButton_DropDownOpening(object sender, System.EventArgs e)
        {
            foreach (var item in WaveTypeItems)
                item.Checked = (WaveType)item.Tag == SelectedWaveType;
        }

        private void WaveTypeItem_Click(object sender, System.EventArgs e) => SelectedWaveType = (WaveType)((ToolStripItem)sender).Tag;
    }
}
