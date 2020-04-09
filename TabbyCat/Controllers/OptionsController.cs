namespace TabbyCat.Controllers
{
    using System;
    using System.Windows.Forms;
    using TabbyCat.Controls.Types;
    using TabbyCat.Views;

    internal class OptionsController : LocalizationController, IDisposable
    {
        internal OptionsController(WorldController worldController)
            :base(worldController)
        {
            OptionsDialog = new OptionsDialog { Text = $"{Application.ProductName} Options" };
            OptionsDialog.btnFilesFolder.Click += BtnFilesFolder_Click;
            OptionsDialog.btnTemplatesFolder.Click += BtnTemplatesFolder_Click;
        }

        private readonly OptionsDialog OptionsDialog;

        private Options Options
        {
            get => GetOptions();
            set => SetOptions(value);
        }

        private PropertyGrid StylesGrid => OptionsDialog.GLSLStylesPropertyGrid;

        internal DialogResult ShowModal()
        {
            Options = AppController.Options;
            var result = OptionsDialog.ShowDialog(WorldForm);
            if (result == DialogResult.OK)
                AppController.Options = Options;
            return result;
        }

        private void BtnFilesFolder_Click(object sender, EventArgs e) =>
            BrowseFolder("files", OptionsDialog.edFilesFolder);

        private void BtnTemplatesFolder_Click(object sender, EventArgs e) =>
            BrowseFolder("templates", OptionsDialog.edTemplatesFolder);

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
            GLSLPath = OptionsDialog.edGLSLUrl.Text
        };

        private void SetOptions(Options options)
        {
            OptionsDialog.rbWindowNew.Checked = options.OpenInNewWindow;
            OptionsDialog.rbWindowReuse.Checked = !options.OpenInNewWindow;
            OptionsDialog.edFilesFolder.Text = options.FilesFolderPath;
            OptionsDialog.edTemplatesFolder.Text = options.TemplatesFolderPath;
            StylesGrid.SelectedObject = options.SyntaxHighlightStyles;
            OptionsDialog.edGLSLUrl.Text = options.GLSLPath;
        }

        #region IDisposable

        private bool Disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    OptionsDialog?.Dispose();
                }
                Disposed = true;
            }
        }

        #endregion
    }
}
