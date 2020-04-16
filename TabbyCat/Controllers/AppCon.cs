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

    internal static class AppCon
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

        private static readonly string DefaultFilesFolderPath =
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Application.ProductName}";

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
}
