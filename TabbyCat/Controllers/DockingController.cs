namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;

    internal abstract class DockingController : LocalizationController
    {
        internal DockingController(WorldController worldController) : base(worldController)
        {
        }

        protected abstract DockContent Form { get; }

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                Form.FormClosing += Form_FormClosing;
            }
            else
            {
                Form.FormClosing -= Form_FormClosing;
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Form.Hide();
            }
        }
    }
}
