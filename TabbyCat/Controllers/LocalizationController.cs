namespace TabbyCat.Controllers
{
    using OpenTK;
    using System;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Controls;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal partial class LocalizationController
    {
        internal LocalizationController(WorldController worldController) => WorldController = worldController;

        protected virtual string[] AllProperties => Array.Empty<string>();
        protected Camera Camera => Scene.Camera;
        protected virtual CameraController CameraController => WorldController.CameraController;
        protected virtual Clock Clock => ClockController.Clock;
        protected virtual ClockController ClockController => WorldController.ClockController;
        internal virtual CommandProcessor CommandProcessor => WorldController.CommandProcessor;
        protected internal GLControl GLControl => (GLControl)GLControlForm.Controls[0];
        protected virtual GLControlForm GLControlForm => GLController.GLControlForm;
        protected virtual GLController GLController => WorldController.GLController;
        protected virtual GpuController GpuController => WorldController.GpuController;
        protected virtual GpuForm GpuForm => GpuController.GpuForm;
        protected virtual ShaderController GpuShaderController => WorldController.GpuShaderController;
        protected ShaderForm GpuShaderForm => GpuShaderController.ShaderForm;
        protected virtual JsonController JsonController => WorldController.JsonController;
        protected virtual RenderController RenderController => WorldController.RenderController;
        protected internal virtual Scene Scene { get => WorldController.Scene; set { WorldController.Scene = value; } }
        protected virtual SceneController SceneController => WorldController.SceneController;
        protected SceneEdit SceneEdit => SceneForm.SceneEdit;
        protected virtual SceneForm SceneForm => SceneController.SceneForm;
        protected virtual ShaderController SceneShaderController => WorldController.SceneShaderController;
        protected ShaderForm SceneShaderForm => SceneShaderController.ShaderForm;
        protected ToolTip ToolTip => WorldForm.ToolTip;
        protected virtual TraceController TraceController => WorldController.TraceController;
        protected virtual TraceForm TraceForm => TraceController.TraceForm;
        protected virtual ShaderController TraceShaderController => WorldController.TraceShaderController;
        protected ShaderForm TraceShaderForm => TraceShaderController.ShaderForm;
        protected virtual WorldController WorldController { get; }
        protected internal virtual WorldForm WorldForm => WorldController.WorldForm;

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

        protected virtual void Localize() { }

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

        private static string Parse(string info, out string hint, out string keys, out Keys shortcut)
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

        protected virtual void UpdateProperties(params string[] propertyNames) { }

        protected internal virtual void UpdateAllProperties() => UpdateProperties(AllProperties);
    }

    partial class LocalizationController : IDisposable
    {
        private bool Disposed;

        public void Dispose()
        {
            if (!Disposed)
            {
                DisposeManagedState();
                Disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeManagedState() { }
    }
}
