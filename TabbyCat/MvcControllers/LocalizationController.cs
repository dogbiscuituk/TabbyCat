namespace TabbyCat.MvcControllers
{
    using System;
    using System.Windows.Forms;

    internal class LocalizationController
    {
        #region Constructors

        internal LocalizationController(WorldController worldController)
        {
            WorldController = worldController;
        }

        #endregion

        #region Protected Internal Methods

        protected internal virtual void Connect(bool connect)
        {
            if (connect)
            {
                InitTexts();
                InitTooltips();
            }
            else
            {

            }
        }

        #endregion

        #region Protected Methods

        protected virtual void InitMenuItems(string text, params ToolStripItem[] items) =>
            Array.ForEach(items, p => p.Text = text);

        protected virtual void InitTexts() { }

        protected void InitTooltip(string text, params Control[] controls) =>
            Array.ForEach(controls, p => ToolTip.SetToolTip(p, text));

        protected virtual void InitTooltips() { }

        #endregion

        #region Private Fields

        protected WorldController WorldController;

        #endregion

        #region Private Properties

        private ToolTip ToolTip => WorldController.WorldForm.ToolTip;

        #endregion
    }
}
