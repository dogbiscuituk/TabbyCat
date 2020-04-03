namespace Jmk.Controls
{
    using System.Windows.Forms;

    public static class HotkeysController
    {
        public static void Show(IWin32Window owner)
        {
            if (HotkeysForm.Visible)
                HotkeysForm.BringToFront();
            else
                HotkeysForm.Show(owner);
        }

        private static HotkeysForm _HotkeysForm;
        private static HotkeysForm HotkeysForm
        {
            get
            {
                if (_HotkeysForm == null)
                {
                    _HotkeysForm = new HotkeysForm();
                    _HotkeysForm.FormClosing += Form_FormClosing;
                }
                return _HotkeysForm;
            }
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                HotkeysForm.Hide();
                e.Cancel = true;
            }
        }
    }
}
