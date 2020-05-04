namespace TabbyCat.Views
{
    using System.Drawing;
    using WeifenLuo.WinFormsUI.Docking;
    using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

    public class FloatingFormFactory : IFloatWindowFactory
    {
        public FloatWindow CreateFloatWindow(DockPanel panel, DockPane pane) => new FloatingForm(panel, pane);

        public FloatWindow CreateFloatWindow(DockPanel panel, DockPane pane, Rectangle r) => new FloatingForm(panel, pane, r);
    }
}
