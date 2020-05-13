namespace TabbyCat.Controllers
{
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using Types;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;
    using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;
    using static WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender;

    public static partial class AppCon
    {
        // Constructors

        static AppCon()
        {
            Pulse.Tick += Pulse_Tick;
            ApplyOptions();
            AddNewWorldCon();
        }

        // Public fields

        public static bool CanPaste { get; private set; }

        public static string DataFormat { get; } = "TabbyCatDataFormat";

        public static List<WorldCon> WorldCons { get; } = new List<WorldCon>();

        // Private fields

        private static AboutDialog _aboutDialog;

        private static readonly string DefaultFilesFolderPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Application.ProductName}";

        private static readonly Timer Pulse = new Timer { Interval = 200, Enabled = true };

        private static int _pulseCount;

        // Public properties

        public static AboutDialog AboutDialog
        {
            get
            {
                if (_aboutDialog == null)
                    using (var aboutCon = new AboutCon(null))
                        _aboutDialog = aboutCon.AboutDialog;
                return _aboutDialog;
            }
        }

        public static Options Options
        {
            get
            {
                var options = new Options
                {
                    Theme = Settings.Options_Theme,
                    OpenInNewWindow = Settings.Options_OpenInNewWindow,
                    FilesFolderPath = Settings.FilesFolderPath,
                    TemplatesFolderPath = Settings.TemplatesFolderPath,
                    SyntaxHighlightStyles = Settings.SyntaxHighlightStyles ?? new TextStyleInfos(),
                    GLSLPath = Settings.GLSLUrl
                };
                if (string.IsNullOrWhiteSpace(options.FilesFolderPath))
                    options.FilesFolderPath = DefaultFilesFolderPath;
                if (string.IsNullOrWhiteSpace(options.TemplatesFolderPath))
                    options.TemplatesFolderPath = $"{DefaultFilesFolderPath}\\Templates";
                return options;
            }
            set
            {
                if (value == null)
                    return;
                Settings.Options_Theme = value.Theme;
                Settings.Options_OpenInNewWindow = value.OpenInNewWindow;
                Settings.FilesFolderPath = value.FilesFolderPath;
                Settings.TemplatesFolderPath = value.TemplatesFolderPath;
                Settings.GLSLUrl = value.GLSLPath;
                Settings.Save();
                ApplyOptions();
            }
        }

        // Private properties

        private static Settings Settings => Settings.Default;

        // Public methods

        public static WorldCon AddNewWorldCon()
        {
            var worldCon = new WorldCon();
            WorldCons.Add(worldCon);
            worldCon.Show();
            worldCon.RefreshGraphicsMode();
            return worldCon;
        }

        public static void Close() => Application.Exit();

        public static string GetDefaultFolder(FilterIndex filterIndex)
        {
            switch (filterIndex)
            {
                case FilterIndex.File:
                    return Options.FilesFolderPath;
                case FilterIndex.Template:
                    return Options.TemplatesFolderPath;
                default:
                    return string.Empty;
            }
        }

        public static void Remove(WorldCon worldCon)
        {
            WorldCons.Remove(worldCon);
            if (WorldCons.Count == 0)
                Close();
        }

        // Private methods

        private static void ApplyOptions()
        {
            InitTheme();
            if (!Directory.Exists(Options.FilesFolderPath))
                Directory.CreateDirectory(Options.FilesFolderPath);
            if (!Directory.Exists(Options.TemplatesFolderPath))
                Directory.CreateDirectory(Options.TemplatesFolderPath);
            CodePageCon.ApplyStyles(Options.SyntaxHighlightStyles);
        }

        private static void Pulse_Tick(object sender, EventArgs e)
        {
            CanPaste = Clipboard.ContainsData(DataFormat);
            foreach (var worldCon in WorldCons)
                worldCon.OnPulse();
            if (_pulseCount < 10)
                _pulseCount++;
            else
                AboutDialog.Hide();
        }
    }

    /// <summary>
    /// Visual Studio Themes.
    /// </summary>
    public partial class AppCon
    {
        public static void InitControlTheme(params Control[] controls)
        {
            var theme = _vsTheme;
            var version = _vsVersion;
            foreach (var control in controls)
                switch (control)
                {
                    case DockPanel dockPanel:
                        dockPanel.Theme = theme;
                        break;
                    case ToolStrip toolStrip:
                        ToolStripExtender.SetStyle(toolStrip, version, theme);
                        break;
                }
        }

        private static readonly IFloatWindowFactory FloatingFormFactory = new FloatingFormFactory();

        private static readonly VisualStudioToolStripExtender ToolStripExtender = new VisualStudioToolStripExtender()
        {
            DefaultRenderer = new ToolStripProfessionalRenderer()
        };

        private static ThemeBase _vsTheme;

        private static VsVersion _vsVersion;

        private static ThemeBase GetVsTheme()
        {
            switch (Options.Theme)
            {
                case Theme.None:
                    return null;
                case Theme.Vs2003:
                    return new VS2003Theme();
                case Theme.Vs2005:
                    return new VS2005Theme();
                case Theme.Vs2012Blue:
                    return new VS2012BlueTheme();
                case Theme.Vs2012Dark:
                    return new VS2012DarkTheme();
                case Theme.Vs2012Light:
                    return new VS2012LightTheme();
                case Theme.Vs2013Blue:
                    return new VS2013BlueTheme();
                case Theme.Vs2013Dark:
                    return new VS2013DarkTheme();
                case Theme.Vs2013Light:
                    return new VS2013LightTheme();
                case Theme.Vs2015Blue:
                    return new VS2015BlueTheme();
                case Theme.Vs2015Dark:
                    return new VS2015DarkTheme();
                case Theme.Vs2015Light:
                    return new VS2015LightTheme();
                default:
                    return new VS2015BlueTheme();
            }
        }

        private static VsVersion GetVsVersion()
        {
            switch (Options.Theme)
            {
                case Theme.None:
                    return VsVersion.Unknown;
                case Theme.Vs2003:
                    return VsVersion.Vs2003;
                case Theme.Vs2005:
                    return VsVersion.Vs2005;
                case Theme.Vs2012Blue:
                case Theme.Vs2012Dark:
                case Theme.Vs2012Light:
                    return VsVersion.Vs2012;
                case Theme.Vs2013Blue:
                case Theme.Vs2013Dark:
                case Theme.Vs2013Light:
                    return VsVersion.Vs2013;
                case Theme.Vs2015Blue:
                case Theme.Vs2015Dark:
                case Theme.Vs2015Light:
                    return VsVersion.Vs2015;
                default:
                    return VsVersion.Vs2015;
            }
        }

        private static void InitTheme()
        {
            _vsTheme = GetVsTheme();
            _vsVersion = GetVsVersion();
            if (_vsTheme != null)
                _vsTheme.Extender.FloatWindowFactory = FloatingFormFactory;
        }
    }
}
