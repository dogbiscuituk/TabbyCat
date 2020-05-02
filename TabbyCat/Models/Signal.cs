namespace TabbyCat.Models
{
    using Common.Types;
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Globalization;

    public class Signal
    {
        // Constructors

        public Signal() { }

        // Public properties

        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;

        [DefaultValue(0)]
        public WaveType WaveType { get; set; } = WaveType.Constant;

        [DefaultValue(0)]
        public float Amplitude { get; set; } = 0;

        [DefaultValue(1)]
        public float AmplitudeMaximum { get; set; } = 1;

        [DefaultValue(-1)]
        public float AmplitudeMinimum { get; set; } = -1;

        [DefaultValue(0)]
        public float Frequency { get; set; } = 1;

        [DefaultValue(100)]
        public float FrequencyMaximum { get; set; } = 100;

        [DefaultValue(0.1f)]
        public float FrequencyMinimum { get; set; } = 0.1f;

        // Public methods

        public float GetValueAt(float time) => Amplitude * GetScaleAt(time);

        public override string ToString() => string.Format(CultureInfo.CurrentCulture, Resources.Text_SignalName, Name);

        private float GetScaleAt(float time)
        {
            if (WaveType == WaveType.Constant)
                return 1;
            time *= Frequency;
            time -= (float)Math.Floor(time);
            float t;
            switch (WaveType)
            {
                case WaveType.Sine:
                    return (float)Math.Sin(2 * Math.PI * time);
                case WaveType.Square:
                    return time < 0.5 ? +1 : -1;
                case WaveType.Triangle:
                    t = 4 * time;
                    return t < 1 ? t : t < 3 ? 2 - t : t - 4;
                case WaveType.RampUp:
                    t = 2 * time;
                    return t < 1 ? t : t - 2;
                case WaveType.RampDown:
                    t = 2 * time;
                    return t < 1 ? -t : 2 - t;
                default:
                    return 0;
            }
        }
    }
}
