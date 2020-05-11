namespace TabbyCat.Controllers
{
    using CustomControls;
    using Properties;
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using Types;
    using Utils;

    /// <summary>
    /// "Single Document Interface" Controller.
    /// 
    /// Extend MruCon to provide file Open and Save dialogs.
    /// Keep track of the document/model's "Modified" state, prompting for "Save" as necessary
    /// (for example, prior to "File|New" or "File|Open", or application closing).
    /// </summary>
    public abstract class SdiCon : MruCon
    {
        // Constructors

        protected SdiCon(WorldCon worldCon, string filter, string subKeyName) : base(worldCon, subKeyName)
        {
            _openFileDialog = new OpenFileDialog { Filter = filter, Title = Resources.OpenFileDialog_Title };
            _saveFileDialog = new SaveFileDialog { Filter = filter, Title = Resources.SaveFileDialog_Title };
        }

        // Private fields

        private string _filePath = string.Empty;

        private readonly OpenFileDialog _openFileDialog;

        private readonly SaveFileDialog _saveFileDialog;

        // Protected properties

        protected string FilePath
        {
            get => _filePath;
            set
            {
                if (value == null)
                    return;
                var filePath = value.Trim();
                if (FilePath != filePath)
                {
                    _filePath = filePath;
                    OnFilePathChanged();
                }
            }
        }

        // Public events

        public event EventHandler<CancelEventArgs>
            FileLoading,
            FileSaving;

        public event EventHandler
            FileLoaded,
            FilePathChanged,
            FileSaved;

        public event EventHandler<FilePathEventArgs> FilePathRequest;

        // Public methods

        public bool LoadFromFile(string filePath)
        {
            if (!OnFileLoading())
                return false;
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                if (!LoadFromStream(stream))
                    return false;
            FilePath = filePath;
            AddItem(filePath);
            OnFileLoaded();
            return true;
        }

        public bool SaveIfModified()
        {
            if (!Scene.IsModified)
                return true;
            OnFilePathRequest();
            switch (MessageBox.Show(
                WorldForm,
                Resources.Message_FileModified_Text,
                string.IsNullOrWhiteSpace(FilePath) ? Resources.Text_NewScene : FilePath.CompactText(),
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    return Save();
                case DialogResult.No:
                    return true;
                case DialogResult.Cancel:
                    return false;
            }
            return true;
        }

        // Protected methods

        protected void Clear()
        {
            FilePath = string.Empty;
            ClearDocument();
        }

        protected abstract void ClearDocument();

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            _openFileDialog?.Dispose();
            _saveFileDialog?.Dispose();
        }

        protected abstract bool LoadFromStream(Stream stream);

        protected virtual void OnFileReopen(string filePath)
        {
            if (SaveIfModified())
                LoadFromFile(filePath);
        }

        protected override void Reopen(ToolStripItem menuItem)
        {
            if (menuItem == null)
                return;
            var filePath = menuItem.ToolTipText;
            if (!File.Exists(filePath))
            {
                if (MessageBox.Show(
                    Resources.Message_FileNotFound_Text.Format(FilePath),
                    Resources.Message_FileNotFound_Caption,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                    RemoveItem(filePath);
                return;
            }
            OnFileReopen(filePath);
        }

        protected bool Save(FilterIndex filterIndex = FilterIndex.Default) => string.IsNullOrEmpty(FilePath) || !File.Exists(FilePath) ? SaveAs(filterIndex) : SaveToFile(FilePath);

        protected bool SaveAs(FilterIndex filterIndex = FilterIndex.Default)
        {
            if (string.IsNullOrWhiteSpace(FilePath))
                OnFilePathRequest();
            _saveFileDialog.FileName = FilePath;
            filterIndex = EvalFilterIndex(filterIndex);
            InitFolderPath(_saveFileDialog, filterIndex);
            _saveFileDialog.FilterIndex = (int)filterIndex;
            return _saveFileDialog.ShowDialog() == DialogResult.OK
                && SaveToFile(_saveFileDialog.FileName);
        }

        protected abstract bool SaveToStream(Stream stream);

        protected string SelectFilePath(FilterIndex filterIndex = FilterIndex.Default)
        {
            filterIndex = EvalFilterIndex(filterIndex);
            _openFileDialog.FilterIndex = (int)filterIndex;
            InitFolderPath(_openFileDialog, filterIndex);
            return _openFileDialog.ShowDialog() != DialogResult.OK ? null : _openFileDialog.FileName;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types",
            Justification = "Can't predict what exception types the client-supplied action may throw, but the sole purpose of this method is simply to swallow them all.")]
        protected static bool UseStream(Action action)
        {
            if (action == null)
                return false;
            var result = true;
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    ex.GetType().Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }

        // Private methods

        private FilterIndex EvalFilterIndex(FilterIndex filterIndex)
        {
            if (filterIndex != FilterIndex.Default)
                return filterIndex;
            switch (Path.GetExtension(FilePath))
            {
                case ".tgf":
                    goto default;
                case ".tgt":
                    return FilterIndex.Template;
                default:
                    return FilterIndex.File;
            }
        }

        private void OnFileLoaded() => FileLoaded?.Invoke(this, EventArgs.Empty);

        private bool OnFileLoading()
        {
            var result = true;
            var fileLoading = FileLoading;
            if (fileLoading != null)
            {
                var e = new CancelEventArgs();
                fileLoading(this, e);
                result = !e.Cancel;
            }
            return result;
        }

        private void OnFilePathChanged() => FilePathChanged?.Invoke(this, EventArgs.Empty);

        private void OnFileSaved() => FileSaved?.Invoke(this, EventArgs.Empty);

        private bool OnFileSaving()
        {
            var result = true;
            var fileSaving = FileSaving;
            if (fileSaving != null)
            {
                var e = new CancelEventArgs();
                fileSaving(this, e);
                result = !e.Cancel;
            }
            return result;
        }

        private void OnFilePathRequest()
        {
            var e = new FilePathEventArgs(FilePath);
            FilePathRequest?.Invoke(this, e);
            FilePath = e.FilePath;
        }

        private bool SaveToFile(string filePath)
        {
            var result = false;
            if (OnFileSaving())
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    result = SaveToStream(stream);
                    if (result)
                    {
                        FilePath = filePath;
                        AddItem(filePath);
                        OnFileSaved();
                    }
                }
            return result;
        }

        // Private static methods

        private static void InitFolderPath(FileDialog dialog, FilterIndex filterIndex)
        {
            var folderPath = string.Empty;
            if (!string.IsNullOrWhiteSpace(dialog.FileName))
                folderPath = Path.GetDirectoryName(dialog.FileName);
            if (string.IsNullOrWhiteSpace(folderPath))
                dialog.InitialDirectory = AppCon.GetDefaultFolder(filterIndex);
        }
    }
}
