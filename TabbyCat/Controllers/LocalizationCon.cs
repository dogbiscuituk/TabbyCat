namespace TabbyCat.Controllers
{
    using Commands;
    using Common.Types;
    using Controls;
    using Models;
    using OpenTK;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Views;

    internal partial class LocalizationCon
    {
        internal LocalizationCon(WorldCon worldCon) => WorldCon = worldCon;

        protected virtual string[] AllProperties => Array.Empty<string>();

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

        protected internal virtual void UpdateAllProperties() => UpdateProperties(AllProperties);

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

        protected virtual void UpdateProperties(params string[] propertyNames) { }

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
    }

    /// <summary>
    /// Derived controllers and their views.
    /// </summary>
    partial class LocalizationCon
    {
        protected internal GLControl SceneControl => (GLControl)SceneForm?.Controls?.OfType<Control>().FirstOrDefault();
        protected internal virtual Scene Scene { get => WorldCon.Scene; set { WorldCon.Scene = value; } }
        protected internal virtual WorldForm WorldForm => WorldCon.WorldForm;

        internal virtual CommandProcessor CommandProcessor => WorldCon.CommandProcessor;

        protected virtual CameraCon CameraCon => WorldCon.CameraCon;
        protected virtual ClockCon ClockCon => WorldCon.ClockCon;
        protected virtual GraphicsStateCon GraphicsStateCon => WorldCon.GraphicsStateCon;
        protected virtual JsonCon JsonCon => WorldCon.JsonCon;
        protected virtual ParametersCon ParametersCon => WorldCon.ParametersCon;
        protected virtual RenderCon RenderCon => WorldCon.RenderCon;
        protected virtual SceneCodeCon SceneCodeCon => WorldCon.SceneCodeCon;
        protected virtual SceneCon SceneCon => WorldCon.SceneCon;
        protected virtual ScenePropertiesCon ScenePropertiesCon => WorldCon.ScenePropertiesCon;
        protected virtual ShaderCodeCon ShaderCodeCon => WorldCon.ShaderCodeCon;
        protected virtual TraceCodeCon TraceCodeCon => WorldCon.TraceCodeCon;
        protected virtual TracePropertiesCon TracePropertiesCon => WorldCon.TracePropertiesCon;
        protected virtual WorldCon WorldCon { get; }

        protected virtual Clock Clock => ClockCon.Clock;
        protected virtual GraphicsStateForm GraphicsStateForm => GraphicsStateCon.GraphicsStateForm;
        protected virtual ParametersForm ParametersForm => ParametersCon.ParametersForm;
        protected virtual SceneForm SceneForm => SceneCon.SceneForm;
        protected virtual ScenePropertiesForm ScenePropertiesForm => ScenePropertiesCon.ScenePropertiesForm;
        protected virtual TracePropertiesForm TracePropertiesForm => TracePropertiesCon.TracePropertiesForm;

        protected CodeForm SceneCodeForm => SceneCodeCon.CodeForm;
        protected CodeForm ShaderCodeForm => ShaderCodeCon.CodeForm;
        protected CodeForm TraceCodeForm => TraceCodeCon.CodeForm;

        protected GraphicsStateView GraphicsStateView => GraphicsStateForm.GraphicsStateView;
        protected ScenePropertiesEdit ScenePropertiesEdit => ScenePropertiesForm.ScenePropertiesEdit;

        protected Camera Camera => Scene.Camera;
        protected ToolTip ToolTip => WorldForm.ToolTip;
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
