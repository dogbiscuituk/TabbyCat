namespace TabbyCat.Views
{
    using System.Drawing;
    using WeifenLuo.WinFormsUI.Docking;
    using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

    public class FloatingFormFactory : IFloatWindowFactory
    {
        public FloatWindow CreateFloatWindow(DockPanel panel, DockPane pane)
        {
            return new FloatingForm(panel, pane);
        }

        public FloatWindow CreateFloatWindow(DockPanel panel, DockPane pane, Rectangle r)
        {
            return new FloatingForm(panel, pane, r);
        }
    }
}
