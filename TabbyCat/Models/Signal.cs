namespace TabbyCat.Models
{
    using Common.Types;
    using Properties;
    using System.ComponentModel;
    using System.Globalization;

    public class Signal
    {
        public Signal() { }

        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;

        [DefaultValue(0)]
        public WaveType WaveType { get; set; } = WaveType.Constant;

        [DefaultValue(1f)]
        public float Amplitude { get; set; } = 1;

        [DefaultValue(1f)]
        public float Frequency { get; set; } = 1;

        public override string ToString() => string.Format(CultureInfo.CurrentCulture, Resources.Text_SignalName, Name);
    }
}
