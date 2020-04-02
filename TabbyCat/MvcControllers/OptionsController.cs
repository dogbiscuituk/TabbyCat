﻿namespace TabbyCat.MvcControllers
{
    using System;
    using System.Windows.Forms;
    using TabbyCat.Controls.Types;
    using TabbyCat.MvcModels;
    using TabbyCat.MvcViews;

    internal class OptionsController : IDisposable
    {
        #region Internal Interface

        internal OptionsController()
        {
            OptionsDialog = new OptionsDialog { Text = $"{Application.ProductName} Options" };
            OptionsDialog.btnFilesFolder.Click += BtnFilesFolder_Click;
            OptionsDialog.btnTemplatesFolder.Click += BtnTemplatesFolder_Click;
        }

        internal DialogResult ShowModal(IWin32Window owner)
        {
            Options = AppController.Options;
            var result = OptionsDialog.ShowDialog(owner);
            if (result == DialogResult.OK)
                AppController.Options = Options;
            return result;
        }

        #endregion

        #region Private Properties

        private PropertyGrid StylesGrid => OptionsDialog.GLSLStylesPropertyGrid;
        private OptionsDialog OptionsDialog;
        private Options Options
        {
            get => GetOptions();
            set => SetOptions(value);
        }

        #endregion

        #region Private Event Handlers

        private void BtnFilesFolder_Click(object sender, EventArgs e) =>
            BrowseFolder("files", OptionsDialog.edFilesFolder);

        private void BtnTemplatesFolder_Click(object sender, EventArgs e) =>
            BrowseFolder("templates", OptionsDialog.edTemplatesFolder);

        #endregion

        #region Private Methods

        private void BrowseFolder(string detail, TextBox textBox)
        {
            using (var dialog = new FolderBrowserDialog
            {
                Description = $"Select the default folder for storing scene {detail}:",
                SelectedPath = textBox.Text,
                ShowNewFolderButton = true
            })
                if (dialog.ShowDialog() == DialogResult.OK)
                    textBox.Text = dialog.SelectedPath;
        }

        private Options GetOptions() => new Options
        {
            OpenInNewWindow = OptionsDialog.rbWindowNew.Checked,
            FilesFolderPath = OptionsDialog.edFilesFolder.Text,
            TemplatesFolderPath = OptionsDialog.edTemplatesFolder.Text,
            SyntaxHighlightStyles = (TextStyleInfos)StylesGrid.SelectedObject,
            GLSLUrl = OptionsDialog.edGLSLUrl.Text
        };

        private void SetOptions(Options options)
        {
            OptionsDialog.rbWindowNew.Checked = options.OpenInNewWindow;
            OptionsDialog.rbWindowReuse.Checked = !options.OpenInNewWindow;
            OptionsDialog.edFilesFolder.Text = options.FilesFolderPath;
            OptionsDialog.edTemplatesFolder.Text = options.TemplatesFolderPath;
            StylesGrid.SelectedObject = options.SyntaxHighlightStyles;
            OptionsDialog.edGLSLUrl.Text = options.GLSLUrl;
        }

        #endregion

        #region IDisposable

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                DisposeOptionsDialog();
        }

        private void DisposeOptionsDialog()
        {
            if (OptionsDialog != null)
            {
                OptionsDialog.Dispose();
                OptionsDialog = null;
            }
        }

        #endregion
    }
}