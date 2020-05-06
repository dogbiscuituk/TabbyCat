namespace TabbyCat.Commands
{
    using Types;

    internal class AmplitudeCommand : SignalPropertyCommand<float>
    {
        internal AmplitudeCommand(int index, float value) : base(
            index,
            Property.SignalAmplitude,
            value,
            t => t.Amplitude,
            (t, v) => t.Amplitude = v)
        { }
    }

    internal class AmplitudeMaximumCommand : SignalPropertyCommand<float>
    {
        internal AmplitudeMaximumCommand(int index, float value) : base(
            index,
            Property.SignalAmplitudeMaximum,
            value,
            t => t.AmplitudeMaximum,
            (t, v) => t.AmplitudeMaximum = v)
        { }
    }

    internal class AmplitudeMinimumCommand : SignalPropertyCommand<float>
    {
        internal AmplitudeMinimumCommand(int index, float value) : base(
            index,
            Property.SignalAmplitudeMinimum,
            value,
            t => t.AmplitudeMinimum,
            (t, v) => t.AmplitudeMinimum = v)
        { }
    }

    internal class FrequencyCommand : SignalPropertyCommand<float>
    {
        internal FrequencyCommand(int index, float value) : base(
            index,
            Property.SignalFrequency,
            value,
            t => t.Frequency,
            (t, v) => t.Frequency = v)
        { }
    }

    internal class FrequencyMaximumCommand : SignalPropertyCommand<float>
    {
        internal FrequencyMaximumCommand(int index, float value) : base(
            index,
            Property.SignalFrequencyMaximum,
            value,
            t => t.FrequencyMaximum,
            (t, v) => t.FrequencyMaximum = v)
        { }
    }

    internal class FrequencyMinimumCommand : SignalPropertyCommand<float>
    {
        internal FrequencyMinimumCommand(int index, float value) : base(
            index,
            Property.SignalFrequencyMinimum,
            value,
            t => t.FrequencyMinimum,
            (t, v) => t.FrequencyMinimum = v)
        { }
    }

    internal class SignalNameCommand : SignalPropertyCommand<string>
    {
        internal SignalNameCommand(int index, string value) : base(
            index,
            Property.SignalName,
            value,
            t => t.Name,
            (t, v) => t.Name = v)
        { }
    }

    internal class WaveTypeCommand : SignalPropertyCommand<WaveType>
    {
        internal WaveTypeCommand(int index, WaveType value) : base(
            index,
            Property.SignalWaveType,
            value,
            t => t.WaveType,
            (t, v) => t.WaveType = v)
        { }
    }
}
