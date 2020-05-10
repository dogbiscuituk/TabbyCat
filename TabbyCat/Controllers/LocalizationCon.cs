namespace TabbyCat.Controllers
{
    using Commands;
    using Models;
    using OpenTK;
    using OpenTK.Graphics;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using Types;
    using UserControls;
    using Utils;
    using Views;

    public partial class LocalizationCon
    {
        // Constructors

        protected LocalizationCon(WorldCon worldCon) => WorldCon = worldCon;

        // Protected fields

        protected bool Updating { get; set; }

        // Protected public properties

        public virtual void UpdateAllProperties() => UpdateProperties(AllProperties);

        // Protected properties

        protected virtual IEnumerable<Property> AllProperties => Enumerable.Empty<Property>();

        // Public methods

        public virtual void Connect(bool connect)
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

        // Protected methods

        protected virtual void Localize() { }

        protected virtual void Localize(string info, params Control[] controls)
        {
            if (info == null)
                info = string.Empty;
            var text = Parse(info, out var hint, out _, out _);
            foreach (var control in controls)
            {
                if (!string.IsNullOrWhiteSpace(text))
                    control.Text = text;
                ToolTip.SetToolTip(control, hint);
            }
        }

        protected virtual void Localize(string info, params ToolStripItem[] items)
        {
            if (info == null)
                info = string.Empty;
            var text = Parse(info, out var hint, out var keys, out var shortcut);
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

        protected void LocalizeFmt<T>(string format, T value, params Control[] controls) => Localize(string.Format(CultureInfo.CurrentCulture, format, value), controls);

        protected void LocalizeFmt<T>(string format, T value, params ToolStripItem[] controls) => Localize(string.Format(CultureInfo.CurrentCulture, format, value), controls);

        protected virtual bool Run(ICommand command) => CommandCon.Run(command);

        protected virtual void UpdateProperties(IEnumerable<Property> properties) { }

        protected void UpdateProperty(Property property) => UpdateProperties(new List<Property> { property });

        // Protected static methods

        protected static void InitCommonControls(Control control)
        {
            foreach (var spinEdit in control?.Controls.OfType<NumericUpDown>())
            {
                spinEdit.Minimum = decimal.MinValue;
                spinEdit.Maximum = decimal.MaxValue;
            }
        }

        protected static void LaunchBrowser(string path)
        {
            if (MessageBox.Show(
                string.Format(CultureInfo.CurrentCulture, Resources.Text_LaunchMessage, path),
                Resources.Text_LaunchCaption,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information) == DialogResult.OK)
                path.Launch();
        }

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
    public partial class LocalizationCon
    {
        // Public properties

        public virtual CommandCon CommandCon => WorldCon.CommandCon;
        public virtual GraphicsMode GraphicsMode => RenderCon.GraphicsMode;
        public virtual JsonCon JsonCon => WorldCon.JsonCon;
        public virtual Scene Scene { get => WorldCon.Scene; set => WorldCon.Scene = value; }
        public GLControl SceneControl => SceneForm?.Controls.OfType<GLControl>().FirstOrDefault();
        public virtual WorldForm WorldForm => WorldCon.WorldForm;

        // Protected properties

        protected virtual CameraCon CameraCon => WorldCon.CameraCon;
        protected virtual ClockCon ClockCon => WorldCon.ClockCon;
        protected virtual FullScreenCon FullScreenCon => WorldCon.FullScreenCon;
        protected virtual HotkeysCon HotkeysCon => WorldCon.HotkeysCon;
        protected virtual RenderCon RenderCon => WorldCon.RenderCon;
        protected virtual SceneCodeCon SceneCodeCon => WorldCon.SceneCodeCon;
        protected virtual SceneCon SceneCon => WorldCon.SceneCon;
        protected virtual ScenePropertiesCon ScenePropertiesCon => WorldCon.ScenePropertiesCon;
        protected virtual ShaderCodeCon ShaderCodeCon => WorldCon.ShaderCodeCon;
        protected virtual SignalsCon SignalsCon => WorldCon.SignalsCon;
        protected virtual TraceCodeCon TraceCodeCon => WorldCon.TraceCodeCon;
        protected virtual TracePropertiesCon TracePropertiesCon => WorldCon.TracePropertiesCon;
        protected WorldCon WorldCon { get; }

        protected virtual Clock Clock => ClockCon.Clock;
        protected virtual HotkeysForm HotkeysForm => HotkeysCon.HotkeysForm;
        protected virtual SceneForm SceneForm => SceneCon.SceneForm;
        protected virtual ScenePropertiesForm ScenePropertiesForm => ScenePropertiesCon.ScenePropertiesForm;
        protected virtual SignalsForm SignalsForm => SignalsCon.SignalsForm;
        protected virtual TracePropertiesForm TracePropertiesForm => TracePropertiesCon.TracePropertiesForm;

        protected CodeForm SceneCodeForm => SceneCodeCon.CodeForm;
        protected CodeForm ShaderCodeForm => ShaderCodeCon.CodeForm;
        protected CodeForm TraceCodeForm => TraceCodeCon.CodeForm;

        protected Camera Camera => Scene.Camera;
        protected ScenePropertiesEdit ScenePropertiesEdit => ScenePropertiesForm.ScenePropertiesEdit;
        protected ToolTip ToolTip => WorldForm.ToolTip;
    }

    public partial class LocalizationCon : IDisposable
    {
        // Private fields

        private bool _disposed;

        // Public methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected methods

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    DisposeManagedState();
                DisposeUnmanagedState();
                _disposed = true;
            }
        }

        protected virtual void DisposeManagedState() { }

        protected virtual void DisposeUnmanagedState() { }
    }
}
