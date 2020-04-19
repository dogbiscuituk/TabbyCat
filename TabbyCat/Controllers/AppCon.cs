namespace TabbyCat.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using TabbyCat.Common.Types;
    using TabbyCat.Controls.Types;
    using TabbyCat.Properties;
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;
    using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;
    using static WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender;

    internal static partial class AppCon
    {
        static AppCon()
        {
            Pulse.Tick += Pulse_Tick;
            ApplyOptions();
            AddNewWorldCon();
        }

        internal static bool CanPaste;

        internal static string DataFormat = "TabbyCatDataFormat";

        internal static List<WorldCon> WorldCons = new List<WorldCon>();

        private static AboutDialog _AboutDialog;

        private static readonly string DefaultFilesFolderPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Application.ProductName}";

        private readonly static Timer Pulse = new Timer { Interval = 200, Enabled = true };

        private static int PulseCount;

        internal static AboutDialog AboutDialog
        {
            get
            {
                if (_AboutDialog == null)
                    using (AboutCon aboutCon = new AboutCon(null))
                        _AboutDialog = aboutCon.AboutDialog;
                return _AboutDialog;
            }
        }

        internal static Options Options
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
                Settings.Options_Theme = value.Theme;
                Settings.Options_OpenInNewWindow = value.OpenInNewWindow;
                Settings.FilesFolderPath = value.FilesFolderPath;
                Settings.TemplatesFolderPath = value.TemplatesFolderPath;
                Settings.GLSLUrl = value.GLSLPath;
                Settings.Save();
                ApplyOptions();
            }
        }

        private static Settings Settings => Settings.Default;

        internal static WorldCon AddNewWorldCon()
        {
            var worldCon = new WorldCon();
            WorldCons.Add(worldCon);
            worldCon.Show();
            worldCon.RefreshGraphicsMode();
            return worldCon;
        }

        internal static void Close() => Application.Exit();

        internal static string GetDefaultFolder(FilterIndex filterIndex)
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

        internal static void Remove(WorldCon worldCon)
        {
            WorldCons.Remove(worldCon);
            if (WorldCons.Count == 0)
                Close();
        }

        private static void ApplyOptions()
        {
            InitTheme();
            if (!Directory.Exists(Options.FilesFolderPath))
                Directory.CreateDirectory(Options.FilesFolderPath);
            if (!Directory.Exists(Options.TemplatesFolderPath))
                Directory.CreateDirectory(Options.TemplatesFolderPath);
            GLPageCon.ApplyStyles(Options.SyntaxHighlightStyles);
        }

        private static void Pulse_Tick(object sender, EventArgs e)
        {
            CanPaste = Clipboard.ContainsData(DataFormat);
            foreach (var worldCon in WorldCons)
                worldCon.OnPulse();
            if (PulseCount < 10)
                PulseCount++;
            else
                AboutDialog.Hide();
        }
    }

    /// <summary>
    /// Visual Studio Themes.
    /// </summary>
    partial class AppCon
    {
        internal static void InitControlTheme(params Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control is DockPanel dockPanel)
                    dockPanel.Theme = VsTheme;
                else if (control is ToolStrip toolStrip)
                    ToolStripExtender.SetStyle(toolStrip, VsVersion, VsTheme);
            }
        }

        private static readonly IFloatWindowFactory FloatingFormFactory = new FloatingFormFactory();

        private static readonly VisualStudioToolStripExtender ToolStripExtender = new VisualStudioToolStripExtender()
        {
            DefaultRenderer = new ToolStripProfessionalRenderer()
        };

        private static ThemeBase VsTheme;

        private static VsVersion VsVersion;

        private static ThemeBase GetVsTheme()
        {
            switch (Options.Theme)
            {
                case Theme.VS2003:
                    return new VS2003Theme();
                case Theme.VS2005:
                    return new VS2005Theme();
                case Theme.VS2012Blue:
                    return new VS2012BlueTheme();
                case Theme.VS2012Dark:
                    return new VS2012DarkTheme();
                case Theme.VS2012Light:
                    return new VS2012LightTheme();
                case Theme.VS2013Blue:
                    return new VS2013BlueTheme();
                case Theme.VS2013Dark:
                    return new VS2013DarkTheme();
                case Theme.VS2013Light:
                    return new VS2013LightTheme();
                case Theme.VS2015Blue:
                    return new VS2015BlueTheme();
                case Theme.VS2015Dark:
                    return new VS2015DarkTheme();
                case Theme.VS2015Light:
                    return new VS2015LightTheme();
                default:
                    return new VS2015BlueTheme();
            }
        }

        private static VsVersion GetVsVersion()
        {
            switch (Options.Theme)
            {
                case Theme.VS2003:
                    return VsVersion.Vs2003;
                case Theme.VS2005:
                    return VsVersion.Vs2005;
                case Theme.VS2012Blue:
                case Theme.VS2012Dark:
                case Theme.VS2012Light:
                    return VsVersion.Vs2012;
                case Theme.VS2013Blue:
                case Theme.VS2013Dark:
                case Theme.VS2013Light:
                    return VsVersion.Vs2013;
                case Theme.VS2015Blue:
                case Theme.VS2015Dark:
                case Theme.VS2015Light:
                    return VsVersion.Vs2015;
                default:
                    return VsVersion.Vs2015;
            }
        }

        private static void InitTheme()
        {
            VsTheme = GetVsTheme();
            VsVersion = GetVsVersion();
            VsTheme.Extender.FloatWindowFactory = FloatingFormFactory;
        }
    }
}
