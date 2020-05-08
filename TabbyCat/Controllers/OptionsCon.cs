namespace TabbyCat.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Types;
    using Utils;
    using Views;

    public class OptionsCon : LocalizationCon
    {
        public OptionsCon(WorldCon worldCon) : base(worldCon)
        {
            OptionsDialog = new OptionsDialog { Text = $"{Application.ProductName} Options" };
            OptionsDialog.cbTheme.Items.AddRange(typeof(Theme).GetDescriptions().Reverse().ToArray());
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

        private static IList<string> ThemeDescriptions => typeof(Theme).GetDescriptions().ToList();

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            OptionsDialog?.Dispose();
        }

        public DialogResult ShowModal()
        {
            Options = AppCon.Options;
            var result = OptionsDialog.ShowDialog(WorldForm);
            if (result == DialogResult.OK)
                AppCon.Options = Options;
            return result;
        }

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

        private void BtnFilesFolder_Click(object sender, EventArgs e) => BrowseFolder("files", OptionsDialog.edFilesFolder);

        private void BtnTemplatesFolder_Click(object sender, EventArgs e) => BrowseFolder("templates", OptionsDialog.edTemplatesFolder);

        private Options GetOptions() => new Options
        {
            Theme = (Theme)ThemeDescriptions.IndexOf(OptionsDialog.cbTheme.Text),
            OpenInNewWindow = OptionsDialog.rbWindowNew.Checked,
            FilesFolderPath = OptionsDialog.edFilesFolder.Text,
            TemplatesFolderPath = OptionsDialog.edTemplatesFolder.Text,
            SyntaxHighlightStyles = (TextStyleInfos)StylesGrid.SelectedObject,
            GLSLPath = OptionsDialog.edGLSLUrl.Text
        };

        private void SetOptions(Options options)
        {
            OptionsDialog.cbTheme.Text = ThemeDescriptions[(int)options.Theme];
            OptionsDialog.rbWindowNew.Checked = options.OpenInNewWindow;
            OptionsDialog.rbWindowReuse.Checked = !options.OpenInNewWindow;
            OptionsDialog.edFilesFolder.Text = options.FilesFolderPath;
            OptionsDialog.edTemplatesFolder.Text = options.TemplatesFolderPath;
            StylesGrid.SelectedObject = options.SyntaxHighlightStyles;
            OptionsDialog.edGLSLUrl.Text = options.GLSLPath;
        }
    }
}
