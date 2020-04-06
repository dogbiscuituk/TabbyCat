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

        protected virtual void InitMenuItems(string info, params ToolStripItem[] items)
        {
            var infos = info.Split('|');
            string
                text = infos[0],
                hint = string.Empty,
                keys = string.Empty;
            Keys shortcut = Keys.None;
            if (infos.Length > 2)
            {
                keys = infos[2];
                if (!string.IsNullOrWhiteSpace(keys))
                    shortcut = (Keys)new KeysConverter().ConvertFrom(keys.Replace("^", "Control+"));
            }
            if (infos.Length > 1)
            {
                hint = infos[1];
                if (shortcut != Keys.None)
                    hint = $"{hint} ({keys})";
            }
            foreach (var item in items)
            {
                item.Text = text;
                item.ToolTipText = hint;
                if (shortcut != Keys.None && item is ToolStripMenuItem menuItem)
                {
                    menuItem.ShortcutKeys = shortcut;
                    menuItem.ShortcutKeyDisplayString = keys;
                }
            }
        }

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
