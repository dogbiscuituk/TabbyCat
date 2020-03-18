namespace Jmk.Controls
{
    using System.Windows.Forms;

    public class JmkMenuStrip : MenuStrip
    {
        protected override void WndProc(ref Message m)
        {
            this.FirstFocus(ref m);
            base.WndProc(ref m);
        }
    }
}
