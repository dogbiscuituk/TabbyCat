﻿namespace TabbyCat.Controllers
{
    using CustomControls;
    using Models;
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;
    using Types;

    /// <summary>
    /// "Single Document Interface" Controller.
    /// 
    /// Extend MruCon to provide file Open and Save dialogs.
    /// Keep track of the document/model's "Modified" state, prompting for "Save" as necessary
    /// (for example, prior to "File|New" or "File|Open", or application closing).
    /// </summary>
    public abstract class SdiCon : MruCon
    {
        protected SdiCon(WorldCon worldCon, string filter, string subKeyName)
            : base(worldCon, subKeyName)
        {
            OpenFileDialog = new OpenFileDialog { Filter = filter, Title = Resources.OpenFileDialog_Title };
            SaveFileDialog = new SaveFileDialog { Filter = filter, Title = Resources.SaveFileDialog_Title };
        }

        public class FilePathEventArgs : EventArgs
        {
            public FilePathEventArgs(string filePath) => FilePath = filePath;
            public string FilePath { get; set; }
        }

        public event EventHandler<CancelEventArgs>
            FileLoading,
            FileSaving;

        public event EventHandler
            FileLoaded,
            FilePathChanged,
            FileSaved;

        public event EventHandler<FilePathEventArgs> FilePathRequest;

        private string _filePath = string.Empty;

        private readonly OpenFileDialog OpenFileDialog;

        private readonly SaveFileDialog SaveFileDialog;

        public string FilePath
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

        public void Clear()
        {
            FilePath = string.Empty;
            ClearDocument();
        }

        public string SelectFilePath(FilterIndex filterIndex = FilterIndex.Default)
        {
            filterIndex = EvalFilterIndex(filterIndex);
            OpenFileDialog.FilterIndex = (int)filterIndex;
            InitFolderPath(OpenFileDialog, filterIndex);
            return OpenFileDialog.ShowDialog() != DialogResult.OK ? null : OpenFileDialog.FileName;
        }

        public override void Reopen(ToolStripItem menuItem)
        {
            var filePath = menuItem.ToolTipText;
            if (!File.Exists(filePath))
            {
                if (MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.Message_FileNotFound_Text, filePath),
                    Resources.Message_FileNotFound_Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    RemoveItem(filePath);
                return;
            }
            OnFileReopen(filePath);
        }

        protected virtual void OnFileReopen(string filePath)
        {
            if (SaveIfModified())
                LoadFromFile(filePath);
        }

        public bool Save(FilterIndex filterIndex = FilterIndex.Default) => string.IsNullOrEmpty(FilePath) || !File.Exists(FilePath) ? SaveAs(filterIndex) : SaveToFile(FilePath);

        public bool SaveAs(FilterIndex filterIndex = FilterIndex.Default)
        {
            if (string.IsNullOrWhiteSpace(FilePath))
                OnFilePathRequest();
            SaveFileDialog.FileName = FilePath;
            filterIndex = EvalFilterIndex(filterIndex);
            InitFolderPath(SaveFileDialog, filterIndex);
            SaveFileDialog.FilterIndex = (int)filterIndex;
            return SaveFileDialog.ShowDialog() == DialogResult.OK
                && SaveToFile(SaveFileDialog.FileName);
        }

        private FilterIndex EvalFilterIndex(FilterIndex filterIndex)
        {
            if (filterIndex == FilterIndex.Default)
                switch (Path.GetExtension(FilePath))
                {
                    case ".tgt":
                        return FilterIndex.Template;
                    case ".tgf":
                    default:
                        return FilterIndex.File;
                }
            return filterIndex;
        }

        private static void InitFolderPath(FileDialog dialog, FilterIndex filterIndex)
        {
            var folderPath = string.Empty;
            if (!string.IsNullOrWhiteSpace(dialog.FileName))
                folderPath = Path.GetDirectoryName(dialog.FileName);
            if (string.IsNullOrWhiteSpace(folderPath))
                dialog.InitialDirectory = AppCon.GetDefaultFolder(filterIndex);
        }

        public bool SaveIfModified()
        {
            if (Scene.IsModified)
            {
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
            }
            return true;
        }

        protected abstract void ClearDocument();

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            OpenFileDialog?.Dispose();
            SaveFileDialog?.Dispose();
        }

        protected abstract bool LoadFromStream(Stream stream);

        protected abstract bool SaveToStream(Stream stream);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types",
            Justification = "Can't predict what exception types the client-supplied action may throw, but the sole purpose of this method is simply to swallow them all.")]
        protected static bool UseStream(Action action)
        {
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

        protected virtual void OnFilePathChanged() => FilePathChanged?.Invoke(this, EventArgs.Empty);

        protected virtual void OnFileLoaded() => FileLoaded?.Invoke(this, EventArgs.Empty);

        protected virtual bool OnFileLoading()
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

        protected virtual void OnFileSaved() => FileSaved?.Invoke(this, EventArgs.Empty);

        protected virtual bool OnFileSaving()
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

        public bool LoadFromFile(string filePath)
        {
            var result = false;
            if (OnFileLoading())
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    result = LoadFromStream(stream);
                if (result)
                {
                    FilePath = filePath;
                    AddItem(filePath);
                    OnFileLoaded();
                }
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
    }
}
