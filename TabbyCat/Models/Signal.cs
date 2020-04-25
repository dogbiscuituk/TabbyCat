using TabbyCat.Common.Types;

namespace TabbyCat.Models
{
    public class Signal
    {
        public Signal() { }

        public string Name { get; set; } = "A";
        public WaveType WaveType { get; set; } = WaveType.Constant;
        public float Amplitude { get; set; } = 1;
        public float Frequency { get; set; } = 1;
    }
}
