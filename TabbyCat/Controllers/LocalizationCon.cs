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

    internal partial class LocalizationCon
    {
        internal LocalizationCon(WorldCon worldCon) => WorldCon = worldCon;

        protected const string BeginSceneToken = "// Begin Scene";
        protected static string BeginTraceToken(int index) => $"// Begin Trace #{index + 1}";
        protected const string EndSceneToken = "// End Scene";
        protected static string EndTraceToken(int index) => $"// End Trace #{index + 1}";

        protected virtual string[] AllProperties => Array.Empty<string>();
        protected Camera Camera => Scene.Camera;
        protected virtual CameraCon CameraCon => WorldCon.CameraCon;
        protected virtual Clock Clock => ClockCon.Clock;
        protected virtual ClockCon ClockCon => WorldCon.ClockCon;
        internal virtual CommandProcessor CommandProcessor => WorldCon.CommandProcessor;
        protected internal GLControl GLControl => (GLControl)GLControlForm?.Controls?[0];
        protected virtual GLControlForm GLControlForm => GLCon.GLControlForm;
        protected virtual GLCon GLCon => WorldCon.GLCon;
        protected virtual GpuCon GpuCon => WorldCon.GpuCon;
        protected GPUEdit GpuEdit => GpuForm.GpuEdit;
        protected virtual GpuForm GpuForm => GpuCon.GpuForm;
        protected virtual ShaderCon GpuShaderCon => WorldCon.GpuShaderCon;
        protected ShaderForm GpuShaderForm => GpuShaderCon.ShaderForm;
        protected virtual JsonCon JsonCon => WorldCon.JsonCon;
        protected virtual RenderCon RenderCon => WorldCon.RenderCon;
        protected internal virtual Scene Scene { get => WorldCon.Scene; set { WorldCon.Scene = value; } }
        protected virtual SceneCon SceneCon => WorldCon.SceneCon;
        protected SceneEdit SceneEdit => SceneForm.SceneEdit;
        protected virtual SceneForm SceneForm => SceneCon.SceneForm;
        protected virtual ShaderCon SceneShaderCon => WorldCon.SceneShaderCon;
        protected ShaderForm SceneShaderForm => SceneShaderCon.ShaderForm;
        protected ToolTip ToolTip => WorldForm.ToolTip;
        protected virtual TraceCon TraceCon => WorldCon.TraceCon;
        protected virtual TraceForm TraceForm => TraceCon.TraceForm;
        protected virtual ShaderCon TraceShaderCon => WorldCon.TraceShaderCon;
        protected ShaderForm TraceShaderForm => TraceShaderCon.ShaderForm;
        protected virtual WorldCon WorldCon { get; }
        protected internal virtual WorldForm WorldForm => WorldCon.WorldForm;

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

    partial class LocalizationCon : IDisposable
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
