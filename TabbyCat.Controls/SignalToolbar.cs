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
        }
    }
}
