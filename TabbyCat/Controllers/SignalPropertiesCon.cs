namespace TabbyCat.Controllers
{
    using Models;
    using System;
    using System.Windows.Forms;
    using Types;
    using Views;

    internal class SignalPropertiesCon : LocalizationCon
    {
        internal SignalPropertiesCon(WorldCon worldCon) : base(worldCon) { }

        internal Signal ShowDialog(Signal signal)
        {
            using (SignalPropertiesDialog dialog = new SignalPropertiesDialog())
            {
                InitCommonControls(dialog.TableLayoutPanel);
                dialog.edName.Text = signal.Name;
                dialog.seWaveType.Items.AddRange(Enum.GetNames(typeof(WaveType)));
                dialog.seWaveType.SelectedIndex = (int)signal.WaveType;
                dialog.seAmplitudeMinimum.Value = (decimal)signal.AmplitudeMinimum;
                dialog.seAmplitudeValue.Value = (decimal)signal.Amplitude;
                dialog.seAmplitudeMaximum.Value = (decimal)signal.AmplitudeMaximum;
                dialog.seFrequencyMinimum.Value = (decimal)signal.FrequencyMinimum;
                dialog.seFrequencyValue.Value = (decimal)signal.Frequency;
                dialog.seFrequencyMaximum.Value = (decimal)signal.FrequencyMaximum;
                if (dialog.ShowDialog(SignalsForm) == DialogResult.OK)
                {
                    signal = new Signal
                    {
                        Name = dialog.edName.Text,
                        WaveType = (WaveType)dialog.seWaveType.SelectedIndex,
                        AmplitudeMinimum = (float)dialog.seAmplitudeMinimum.Value,
                        Amplitude = (float)dialog.seAmplitudeValue.Value,
                        AmplitudeMaximum = (float)dialog.seAmplitudeMaximum.Value,
                        FrequencyMinimum = (float)dialog.seFrequencyMinimum.Value,
                        Frequency = (float)dialog.seFrequencyValue.Value,
                        FrequencyMaximum = (float)dialog.seFrequencyMaximum.Value,
                    };
                }

                return signal;
            }
        }
    }
}
