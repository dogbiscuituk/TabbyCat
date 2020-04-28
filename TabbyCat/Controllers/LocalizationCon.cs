namespace TabbyCat.Controllers
{
    using Commands;
    using Common.Types;
    using Controls;
    using Models;
    using OpenTK;
    using OpenTK.Graphics;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using Views;

    internal partial class LocalizationCon
    {
        // Constructors

        internal LocalizationCon(WorldCon worldCon) => WorldCon = worldCon;

        // Protected fields

        protected bool Updating;

        // Protected internal properties

        protected internal virtual void UpdateAllProperties() => UpdateProperties(AllProperties);

        // Protected properties

        protected virtual string[] AllProperties => Array.Empty<string>();

        // Protected internal methods

        protected internal virtual void Connect(bool connect)
        {
            if (connect)
            {
                Localize();
                UpdateAllProperties();
            }
            else
            {

            }
        }

        protected internal virtual bool Run(ICommand command)
        {
            if (Updating)
                return false;
            Updating = true;
            try
            {
                return CommandCon.Run(command);
            }
            finally
            {
                Updating = false;
            }
        }

        // Protected methods

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

        protected virtual void LocalizeFmt<T>(string format, T value, params Control[] controls) =>
            Localize(string.Format(CultureInfo.CurrentCulture, format, value), controls);

        protected virtual void LocalizeFmt<T>(string format, T value, params ToolStripItem[] controls) =>
            Localize(string.Format(CultureInfo.CurrentCulture, format, value), controls);

        protected virtual void UpdateProperties(params string[] propertyNames) { }

        // Private static methods

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
        // Internal properties

        internal virtual CommandCon CommandCon => WorldCon.CommandCon;

        // Protected internal properties

        protected internal virtual GraphicsMode GraphicsMode => RenderCon.GraphicsMode;
        protected internal virtual JsonCon JsonCon => WorldCon.JsonCon;
        protected internal virtual Scene Scene { get => WorldCon.Scene; set { WorldCon.Scene = value; } }
        protected internal GLControl SceneControl => SceneForm?.Controls?.OfType<GLControl>().FirstOrDefault();
        protected internal virtual WorldForm WorldForm => WorldCon.WorldForm;

        // Protected properties

        protected virtual CameraCon CameraCon => WorldCon.CameraCon;
        protected virtual ClockCon ClockCon => WorldCon.ClockCon;
        protected virtual FullScreenCon FullScreenCon => WorldCon.FullScreenCon;
        protected virtual RenderCon RenderCon => WorldCon.RenderCon;
        protected virtual SceneCodeCon SceneCodeCon => WorldCon.SceneCodeCon;
        protected virtual SceneCon SceneCon => WorldCon.SceneCon;
        protected virtual ScenePropertiesCon ScenePropertiesCon => WorldCon.ScenePropertiesCon;
        protected virtual ShaderCodeCon ShaderCodeCon => WorldCon.ShaderCodeCon;
        protected virtual SignalsCon SignalsCon => WorldCon.SignalsCon;
        protected virtual TraceCodeCon TraceCodeCon => WorldCon.TraceCodeCon;
        protected virtual TracePropertiesCon TracePropertiesCon => WorldCon.TracePropertiesCon;
        protected virtual WorldCon WorldCon { get; }

        protected virtual Clock Clock => ClockCon.Clock;
        protected virtual SceneForm SceneForm => SceneCon.SceneForm;
        protected virtual ScenePropertiesForm ScenePropertiesForm => ScenePropertiesCon.ScenePropertiesForm;
        protected virtual SignalsForm SignalsForm => SignalsCon.SignalsForm;
        protected virtual TracePropertiesForm TracePropertiesForm => TracePropertiesCon.TracePropertiesForm;

        protected CodeForm SceneCodeForm => SceneCodeCon.CodeForm;
        protected CodeForm ShaderCodeForm => ShaderCodeCon.CodeForm;
        protected CodeForm TraceCodeForm => TraceCodeCon.CodeForm;

        protected Camera Camera => Scene.Camera;
        protected ScenePropertiesEdit ScenePropertiesEdit => ScenePropertiesForm.ScenePropertiesEdit;
        protected TableLayoutControlCollection SignalsControls => SignalsPanel.Controls;
        protected TableLayoutPanel SignalsPanel => SignalsForm.TableLayoutPanel;
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
