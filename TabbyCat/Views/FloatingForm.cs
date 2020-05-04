namespace TabbyCat.Views
{
    using System.Drawing;
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class FloatingForm : FloatWindow
    {
        public FloatingForm(DockPanel panel, DockPane pane) : base(panel, pane)
        {
            Init();
        }

        public FloatingForm(DockPanel panel, DockPane pane, Rectangle r) : base(panel, pane, r)
        {
            Init();
        }

        private void Init()
        {
            DoubleClickTitleBarToDock = true;
            FormBorderStyle = FormBorderStyle.Sizable;
            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
        }
    }
}
