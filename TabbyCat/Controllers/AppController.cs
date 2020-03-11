namespace TabbyCat.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using TabbyCat.Controls.Types;
    using TabbyCat.Models;
    using TabbyCat.Properties;
    using TabbyCat.Views;

    internal static class AppController
    {
        #region Static Constructor

        static AppController()
        {
            Timer = new Timer { Interval = 5000, Enabled = true };
            Timer.Tick += Timer_Tick;
            ApplyOptions();
            AddNewWorldController();
        }

        #endregion

        #region Internal Properties

        internal static AboutDialog AboutDialog
        {
            get
            {
                if (_AboutDialog == null)
                    _AboutDialog = new AboutController().View;
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
                    GLSLUrl = Settings.GLSLUrl
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
                Settings.GLSLUrl = value.GLSLUrl;
                Settings.Save();
                ApplyOptions();
            }
        }

        internal static List<WorldController> WorldControllers = new List<WorldController>();

        #endregion

        #region Internal Methods

        internal static WorldController AddNewWorldController()
        {
            var worldController = new WorldController();
            WorldControllers.Add(worldController);
            worldController.Show();
            return worldController;
        }

        internal static void Close()
        {
            Application.Exit();
        }

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

        #endregion

        #region Private Properties

        private static AboutDialog _AboutDialog;

        private static readonly string DefaultFilesFolderPath =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{Application.ProductName}";

        private static Settings Settings => Settings.Default;

        private static Timer Timer;

        #endregion

        #region Private Event Handlers

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            Timer.Dispose();
            Timer = null;
            AboutDialog.Hide();
        }

        #endregion

        #region Private Methods

        private static void ApplyOptions()
        {
            if (!Directory.Exists(Options.FilesFolderPath))
                Directory.CreateDirectory(Options.FilesFolderPath);
            if (!Directory.Exists(Options.TemplatesFolderPath))
                Directory.CreateDirectory(Options.TemplatesFolderPath);
            GLPageController.ApplyStyles(Options.SyntaxHighlightStyles);
        }

        #endregion
    }
}
