namespace TabbyCat.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using TabbyCat.Models;
    using TabbyCat.Properties;

    internal static class AppController
    {
        internal static void Close()
        {
            Application.Exit();
        }

        #region Internal Properties

        internal static Options Options
        {
            get
            {
                var options = new Options
                {
                    OpenInNewWindow = Settings.Options_OpenInNewWindow,
                    FilesFolderPath = Settings.FilesFolderPath,
                    TemplatesFolderPath = Settings.TemplatesFolderPath,
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
                Settings.Save();
                ApplyOptions();
            }
        }

        internal static List<SceneController> SceneControllers = new List<SceneController>();

        #endregion

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

        internal static SceneController AddNewSceneController()
        {
            var sceneController = new SceneController();
            SceneControllers.Add(sceneController);
            sceneController.Show();
            return sceneController;
        }

        #region Private Properties

        private static readonly string DefaultFilesFolderPath =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{Application.ProductName}";
        private static Settings Settings => Settings.Default;

        #endregion

        #region Private Methods

        private static void ApplyOptions()
        {
            if (!Directory.Exists(Options.FilesFolderPath))
                Directory.CreateDirectory(Options.FilesFolderPath);
            if (!Directory.Exists(Options.TemplatesFolderPath))
                Directory.CreateDirectory(Options.TemplatesFolderPath);
        }

        #endregion
    }
}
