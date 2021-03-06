﻿namespace TabbyCat.Controllers
{
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Types;
    using Utils;
    using Views;

    public class OptionsCon : LocalCon
    {
        // Constructors

        public OptionsCon(WorldCon worldCon) : base(worldCon)
        {
            _optionsDialog = new OptionsDialog { Text = Resources.OptionsDialog.Format(Application.ProductName) };
            _optionsDialog.cbTheme.Items.AddRange(typeof(Theme).GetDescriptions().Reverse().Cast<object>().ToArray());
            _optionsDialog.btnFilesFolder.Click += BtnFilesFolder_Click;
            _optionsDialog.btnTemplatesFolder.Click += BtnTemplatesFolder_Click;
        }

        // Private fields

        private readonly OptionsDialog _optionsDialog;

        // Private properties

        private Options Options
        {
            get => GetOptions();
            set => SetOptions(value);
        }

        private PropertyGrid StylesGrid => _optionsDialog.GLSLStylesPropertyGrid;

        private static IList<string> ThemeDescriptions => typeof(Theme).GetDescriptions().ToList();

        // Public methods

        public void ShowModal()
        {
            Options = AppCon.Options;
            var result = _optionsDialog.ShowDialog(WorldForm);
            if (result == DialogResult.OK)
                AppCon.Options = Options;
        }

        // Protected methods

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            _optionsDialog?.Dispose();
        }

        // Private methods

        private void BtnFilesFolder_Click(object sender, EventArgs e) => BrowseFolder("files", _optionsDialog.edFilesFolder);

        private void BtnTemplatesFolder_Click(object sender, EventArgs e) => BrowseFolder("templates", _optionsDialog.edTemplatesFolder);

        private Options GetOptions() => new Options
        {
            Theme = (Theme)ThemeDescriptions.IndexOf(_optionsDialog.cbTheme.Text),
            OpenInNewWindow = _optionsDialog.rbWindowNew.Checked,
            FilesFolderPath = _optionsDialog.edFilesFolder.Text,
            TemplatesFolderPath = _optionsDialog.edTemplatesFolder.Text,
            SyntaxHighlightStyles = (TextStyleInfos)StylesGrid.SelectedObject,
            GLSLPath = _optionsDialog.edGLSLUrl.Text
        };

        private void SetOptions(Options options)
        {
            _optionsDialog.cbTheme.Text = ThemeDescriptions[(int)options.Theme];
            _optionsDialog.rbWindowNew.Checked = options.OpenInNewWindow;
            _optionsDialog.rbWindowReuse.Checked = !options.OpenInNewWindow;
            _optionsDialog.edFilesFolder.Text = options.FilesFolderPath;
            _optionsDialog.edTemplatesFolder.Text = options.TemplatesFolderPath;
            StylesGrid.SelectedObject = options.SyntaxHighlightStyles;
            _optionsDialog.edGLSLUrl.Text = options.GLSLPath;
        }

        // Private static methods

        private static void BrowseFolder(string detail, TextBox textBox)
        {
            using (var dialog = new FolderBrowserDialog
            {
                Description = Resources.OptionsDialog_DefaultFolder.Format(detail),
                SelectedPath = textBox.Text,
                ShowNewFolderButton = true
            })
                if (dialog.ShowDialog() == DialogResult.OK)
                    textBox.Text = dialog.SelectedPath;
        }
    }
}
