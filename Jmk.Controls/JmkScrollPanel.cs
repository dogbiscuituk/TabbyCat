namespace Jmk.Controls
{
    using System.Drawing;
    using System.Windows.Forms;

    public class JmkScrollPanel : Panel
    {
        /// <summary>
        /// Don't scroll to the top of a child control when selected.
        /// </summary>
        /// <param name="activeControl">The selected child control.</param>
        /// <returns>The current value of the panel's AutoScrollPosition.
        /// Returning this value essentially causes the scroll method to do nothing.</returns>
        protected override Point ScrollToControl(Control activeControl) => AutoScrollPosition;
    }
}
