namespace TabbyCat.Models
{
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using Types;

    public class Signal
    {
        // Public properties

        [DefaultValue(0f)]
        public float Amplitude { get; set; } = 0;

        [DefaultValue(1f)]
        public float AmplitudeMaximum { get; set; } = 1;

        [DefaultValue(0f)]
        public float AmplitudeMinimum { get; set; } = 0;

        [DefaultValue(0f)]
        public float Frequency { get; set; } = 1;

        [DefaultValue(10f)]
        public float FrequencyMaximum { get; set; } = 10;

        [DefaultValue(0.1f)]
        public float FrequencyMinimum { get; set; } = 0.1f;

        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;

        [DefaultValue(0)]
        public WaveType WaveType { get; set; } = WaveType.Constant;

        // Public methods

        public float GetValueAt(float time) => Amplitude * GetScaleAt(time);

        public override string ToString() => string.Format(CultureInfo.CurrentCulture, Resources.Text_SignalName, Name);

        // Private methods

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
