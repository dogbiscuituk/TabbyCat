namespace TabbyCat.Commands
{
    using Common.Types;
    using Common.Utils;

    internal class AmplitudeCommand : SignalPropertyCommand<float>
    {
        internal AmplitudeCommand(int index, float value) : base(
            index,
            PropertyNames.Amplitude,
            value,
            t => (float)t.Amplitude,
            (t, v) => t.Amplitude = v)
        { }
    }

    internal class FrequencyCommand : SignalPropertyCommand<float>
    {
        internal FrequencyCommand(int index, float value) : base(
            index,
            PropertyNames.Frequency,
            value,
            t => (float)t.Frequency,
            (t, v) => t.Frequency = v)
        { }
    }

    internal class NameCommand : SignalPropertyCommand<string>
    {
        internal NameCommand(int index, string value) : base(
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
