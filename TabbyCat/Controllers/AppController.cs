﻿namespace TabbyCat.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using TabbyCat.Common.Types;
    using TabbyCat.Controls.Types;
    using TabbyCat.Properties;
    using TabbyCat.Views;

    internal static class AppController
    {
        internal static bool CanPaste;

        internal static string DataFormat = "TabbyCatDataFormat";

        internal static List<WorldController> WorldControllers = new List<WorldController>();

        private static AboutDialog _AboutDialog;

        private static readonly string DefaultFilesFolderPath =
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\{Application.ProductName}";

        private readonly static Timer Pulse = new Timer { Interval = 200, Enabled = true };

        private static int PulseCount;

        static AppController()
        {
            Pulse.Tick += Pulse_Tick;
            ApplyOptions();
            AddNewWorldController();
        }

        internal static AboutDialog AboutDialog
        {
            get
            {
                if (_AboutDialog == null)
                    using (AboutController aboutController = new AboutController(null))
                        _AboutDialog = aboutController.View;
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

        internal static WorldController AddNewWorldController()
        {
            var worldController = new WorldController();
            WorldControllers.Add(worldController);
            worldController.Show();
            worldController.RefreshGraphicsMode();
            return worldController;
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

        internal static void Remove(WorldController worldController)
        {
            WorldControllers.Remove(worldController);
            if (WorldControllers.Count == 0)
                Close();
        }

        private static void ApplyOptions()
        {
            if (!Directory.Exists(Options.FilesFolderPath))
                Directory.CreateDirectory(Options.FilesFolderPath);
            if (!Directory.Exists(Options.TemplatesFolderPath))
                Directory.CreateDirectory(Options.TemplatesFolderPath);
            GLPageController.ApplyStyles(Options.SyntaxHighlightStyles);
        }

        private static void Pulse_Tick(object sender, EventArgs e)
        {
            CanPaste = Clipboard.ContainsData(DataFormat);
            foreach (var worldController in WorldControllers)
                worldController.OnPulse();
            if (PulseCount < 10)
                PulseCount++;
            else
                AboutDialog.Hide();
        }
    }
}
