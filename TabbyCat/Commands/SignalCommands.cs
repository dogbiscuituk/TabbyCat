namespace TabbyCat.Commands
{
    using Common.Types;
    using Utils;

    internal class AmplitudeCommand : SignalPropertyCommand<float>
    {
        internal AmplitudeCommand(int index, float value) : base(
            index,
            PropertyNames.Amplitude,
            value,
            t => t.Amplitude,
            (t, v) => t.Amplitude = v)
        { }
    }

    internal class AmplitudeMaximumCommand : SignalPropertyCommand<float>
    {
        internal AmplitudeMaximumCommand(int index, float value) : base(
        index,
        PropertyNames.AmplitudeMaximum,
        value,
        t => t.AmplitudeMaximum,
        (t, v) => t.AmplitudeMaximum = v)
        { }
    }

    internal class AmplitudeMinimumCommand : SignalPropertyCommand<float>
    {
        internal AmplitudeMinimumCommand(int index, float value) : base(
        index,
        PropertyNames.AmplitudeMinimum,
        value,
        t => t.AmplitudeMinimum,
        (t, v) => t.AmplitudeMinimum = v)
        { }
    }

    internal class FrequencyCommand : SignalPropertyCommand<float>
    {
        internal FrequencyCommand(int index, float value) : base(
            index,
            PropertyNames.Frequency,
            value,
            t => t.Frequency,
            (t, v) => t.Frequency = v)
        { }
    }

    internal class FrequencyMaximumCommand : SignalPropertyCommand<float>
    {
        internal FrequencyMaximumCommand(int index, float value) : base(
            index,
            PropertyNames.FrequencyMaximum,
            value,
            t => t.FrequencyMaximum,
            (t, v) => t.FrequencyMaximum = v)
        { }
    }

    internal class FrequencyMinimumCommand : SignalPropertyCommand<float>
    {
        internal FrequencyMinimumCommand(int index, float value) : base(
            index,
            PropertyNames.FrequencyMinimum,
            value,
            t => t.FrequencyMinimum,
            (t, v) => t.FrequencyMinimum = v)
        { }
    }

    internal class SignalNameCommand : SignalPropertyCommand<string>
    {
        internal SignalNameCommand(int index, string value) : base(
            index,
            PropertyNames.Name,
            value,
            t => t.Name,
            (t, v) => t.Name = v)
        { }
    }

    internal class WaveTypeCommand : SignalPropertyCommand<WaveType>
    {
        internal WaveTypeCommand(int index, WaveType value) : base(
            index,
            PropertyNames.WaveType,
            value,
            t => t.WaveType,
            (t, v) => t.WaveType = v)
        { }
    }
}
