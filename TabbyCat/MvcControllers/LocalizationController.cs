﻿namespace TabbyCat.MvcControllers
{
    using System;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Controls;
    using TabbyCat.MvcModels;
    using TabbyCat.MvcViews;

    internal class LocalizationController
    {
        #region Constructors

        internal LocalizationController(WorldController worldController) =>
            WorldController = worldController;

        #endregion

        #region Protected Fields

        protected WorldController WorldController;

        #endregion

        #region Protected Properties

        protected Camera Camera => Scene.Camera;

        protected internal virtual CommandProcessor CommandProcessor
        {
            get => WorldController.CommandProcessor;
            protected set { }
        }

        protected virtual ClockController ClockController
        {
            get => WorldController.ClockController;
            set { }
        }

        protected virtual Clock Clock
        {
            get => ClockController.Clock;
            set { }
        }

        protected internal virtual PropertiesController PropertiesController
        {
            get => WorldController.PropertiesController;
            set { }
        }

        protected internal PropertiesEdit PropertiesEdit => WorldForm.PropertiesEdit;

        protected internal virtual RenderController RenderController
        {
            get => WorldController.RenderController;
            set { }
        }

        protected internal virtual SceneEdit SceneEdit
        {
            get => PropertiesEdit.SceneEdit;
            set { }
        }

        protected internal virtual SceneController SceneController
        {
            get => WorldController.SceneController;
            set { }
        }

        protected internal virtual ShaderController ShaderController
        {
            get => WorldController.ShaderController;
            set { }
        }

        protected internal virtual TraceController TraceController
        {
            get => WorldController.TraceController;
            set { }
        }

        protected internal virtual TraceEdit TraceEdit
        {
            get => PropertiesEdit.TraceEdit;
            set { }
        }

        protected internal virtual Scene Scene
        {
            get => WorldController.Scene;
            set { }
        }

        protected internal virtual WorldForm WorldForm
        {
            get => WorldController.WorldForm;
            set { }
        }

        #endregion

        #region Protected Internal Methods

        protected internal virtual void Connect(bool connect)
        {
            if (connect)
            {
                Localize();
            }
            else
            {

            }
        }

        #endregion

        #region Protected Methods

        private string Parse(string info, out string hint, out string keys, out Keys shortcut)
        {
            var infos = info.Split('|');
            hint = string.Empty;
            keys = string.Empty;
            shortcut = Keys.None;
            if (infos.Length > 2)
            {
                keys = infos[2];
                if (!string.IsNullOrWhiteSpace(keys))
                    try
                    {
                        shortcut = (Keys)new KeysConverter().ConvertFrom(keys.Replace("^", "Control+"));
                    }
                    catch (ArgumentException ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"InitMenuItems(\"{info}\", ...): {ex.Message}");
                    }
            }
            if (infos.Length > 1)
            {
                hint = infos[1];
                if (shortcut != Keys.None)
                    hint = $"{hint} ({keys})";
            }
            return infos[0];
        }

        protected virtual void Localize(string info, params Control[] controls)
        {
            string hint, text = Parse(info, out hint, out _, out _);
            foreach (var control in controls)
            {
                if (!string.IsNullOrWhiteSpace(text))
                    control.Text = text;
                ToolTip.SetToolTip(control, hint);
            }
        }

        protected virtual void Localize(string info, params ToolStripItem[] items)
        {
            var text = Parse(info, out string hint, out string keys, out Keys shortcut);
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

        protected virtual void Localize() { }

        protected void InitTooltip(string text, params Control[] controls) =>
            Array.ForEach(controls, p => ToolTip.SetToolTip(p, text));

        #endregion

        #region Private Properties

        private ToolTip ToolTip => WorldController.WorldForm.ToolTip;

        #endregion
    }
}
