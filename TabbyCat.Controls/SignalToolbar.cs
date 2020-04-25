namespace TabbyCat.Controls
{
    using Common.Types;
    using System.Windows.Forms;

    public partial class SignalToolbar : UserControl
    {
        public SignalToolbar()
        {
            InitializeComponent();
            WaveTypeButton.Tag = WaveType.Constant;
            Constant.Tag = WaveType.Constant;
            Sine.Tag = WaveType.Sine;
            Square.Tag = WaveType.Square;
            Triangle.Tag = WaveType.Triangle;
            Sawtooth.Tag = WaveType.Sawtooth;
            BackwardSawtooth.Tag = WaveType.ReverseSawtooth;
            Custom.Tag = WaveType.Custom;
            Noise.Tag = WaveType.Noise;
        }
    }
}
