namespace TabbyCat.Commands
{
    using Types;

    public class AmplitudeCommand : SignalPropertyCommand<float>
    {
        public AmplitudeCommand(int index, float value) : base(
            index,
            Property.SignalAmplitude,
            value,
            t => t.Amplitude,
            (t, v) => t.Amplitude = v)
        { }
    }

    public class AmplitudeMaximumCommand : SignalPropertyCommand<float>
    {
        public AmplitudeMaximumCommand(int index, float value) : base(
            index,
            Property.SignalAmplitudeMaximum,
            value,
            t => t.AmplitudeMaximum,
            (t, v) => t.AmplitudeMaximum = v)
        { }
    }

    public class AmplitudeMinimumCommand : SignalPropertyCommand<float>
    {
        public AmplitudeMinimumCommand(int index, float value) : base(
            index,
            Property.SignalAmplitudeMinimum,
            value,
            t => t.AmplitudeMinimum,
            (t, v) => t.AmplitudeMinimum = v)
        { }
    }

    public class FrequencyCommand : SignalPropertyCommand<float>
    {
        public FrequencyCommand(int index, float value) : base(
            index,
            Property.SignalFrequency,
            value,
            t => t.Frequency,
            (t, v) => t.Frequency = v)
        { }
    }

    public class FrequencyMaximumCommand : SignalPropertyCommand<float>
    {
        public FrequencyMaximumCommand(int index, float value) : base(
            index,
            Property.SignalFrequencyMaximum,
            value,
            t => t.FrequencyMaximum,
            (t, v) => t.FrequencyMaximum = v)
        { }
    }

    public class FrequencyMinimumCommand : SignalPropertyCommand<float>
    {
        public FrequencyMinimumCommand(int index, float value) : base(
            index,
            Property.SignalFrequencyMinimum,
            value,
            t => t.FrequencyMinimum,
            (t, v) => t.FrequencyMinimum = v)
        { }
    }

    public class SignalNameCommand : SignalPropertyCommand<string>
    {
        public SignalNameCommand(int index, string value) : base(
            index,
            Property.SignalName,
            value,
            t => t.Name,
            (t, v) => t.Name = v)
        { }
    }

    public class WaveTypeCommand : SignalPropertyCommand<WaveType>
    {
        public WaveTypeCommand(int index, WaveType value) : base(
            index,
            Property.SignalWaveType,
            value,
            t => t.WaveType,
            (t, v) => t.WaveType = v)
        { }
    }
}
