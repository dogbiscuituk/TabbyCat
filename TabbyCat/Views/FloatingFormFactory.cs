namespace TabbyCat.Views
{
    using System.Drawing;
    using WeifenLuo.WinFormsUI.Docking;

    public class FloatingFormFactory : DockPanelExtender.IFloatWindowFactory
    {
        public FloatWindow CreateFloatWindow(DockPanel panel, DockPane pane) => new FloatingForm(panel, pane);

        public FloatWindow CreateFloatWindow(DockPanel panel, DockPane pane, Rectangle r) => new FloatingForm(panel, pane, r);
    }
}
