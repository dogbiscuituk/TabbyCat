namespace Jmk.Controls
{
    using System.Windows.Forms;

    public partial class JmkNumericUpDownDegrees : NumericUpDown
    {
        public JmkNumericUpDownDegrees()
        {
            InitializeComponent();
        }

        protected override void UpdateEditText()
        {
            Text = $"{Value}°";
        }
    }
}
