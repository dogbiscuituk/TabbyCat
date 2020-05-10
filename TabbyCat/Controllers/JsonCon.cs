namespace TabbyCat.Controllers
{
    using Models;
    using Newtonsoft.Json;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using Types;
    using Utils;

    /// <summary>
    /// Extend SdiCon to provide concrete I/O methods using Json data format.
    /// Maintain a "WindowCaption" property for the app, including the product name,
    /// current filename if any - otherwise "(untitled)" - and the "Modified" flag.
    /// </summary>
    public class JsonCon : SdiCon
    {
        // Constructors

        public JsonCon(WorldCon worldCon) : base(worldCon, Settings.Default.FileFilter, "LibraryMRU") { }

        // Public properties

        public string WindowCaption => $@"{(
            Scene.IsModified ? "* " : string.Empty)}{(
            string.IsNullOrWhiteSpace(FilePath) ? Resources.Text_NewScene : Path.GetFileNameWithoutExtension(FilePath).ToFilename())} - {
            Application.ProductName}";

        // Public events

        public event EventHandler<FilePathEventArgs> FileReopen;

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.FileNewEmptyScene.Click += FileNewEmptyScene_Click;
                WorldForm.FileNewFromTemplate.Click += FileNewFromTemplate_Click;
                WorldForm.FileOpen.Click += FileOpen_Click;
                WorldForm.FileSave.Click += FileSave_Click;
                WorldForm.FileSaveAs.Click += FileSaveAs_Click;
                WorldForm.FileClose.Click += FileClose_Click;
                WorldForm.FileExit.Click += FileExit_Click;
                WorldForm.tbNew.ButtonClick += FileNewEmptyScene_Click;
                WorldForm.tbNewEmptyScene.Click += FileNewEmptyScene_Click;
                WorldForm.tbNewFromTemplate.Click += FileNewFromTemplate_Click;
                WorldForm.tbOpen.ButtonClick += FileOpen_Click;
                WorldForm.tbOpen.DropDownOpening += TbOpen_DropDownOpening;
                WorldForm.tbSave.Click += TbSave_Click;
                FileLoaded += JsonCon_FileLoaded;
                FilePathChanged += JsonCon_FilePathChanged;
                FilePathRequest += JsonCon_FilePathRequest;
                FileReopen += JsonCon_FileReopen;
                FileSaving += JsonCon_FileSaving;
                FileSaved += JsonCon_FileSaved;
            }
            else
            {
                WorldForm.FileNewEmptyScene.Click -= FileNewEmptyScene_Click;
                WorldForm.FileNewFromTemplate.Click -= FileNewFromTemplate_Click;
                WorldForm.FileOpen.Click -= FileOpen_Click;
                WorldForm.FileSave.Click -= FileSave_Click;
                WorldForm.FileSaveAs.Click -= FileSaveAs_Click;
                WorldForm.FileClose.Click -= FileClose_Click;
                WorldForm.FileExit.Click -= FileExit_Click;
                WorldForm.tbNew.ButtonClick -= FileNewEmptyScene_Click;
                WorldForm.tbNewEmptyScene.Click -= FileNewEmptyScene_Click;
                WorldForm.tbNewFromTemplate.Click -= FileNewFromTemplate_Click;
                WorldForm.tbOpen.ButtonClick -= FileOpen_Click;
                WorldForm.tbOpen.DropDownOpening -= TbOpen_DropDownOpening;
                WorldForm.tbSave.Click -= TbSave_Click;
                FileLoaded -= JsonCon_FileLoaded;
                FilePathChanged -= JsonCon_FilePathChanged;
                FilePathRequest -= JsonCon_FilePathRequest;
                FileReopen -= JsonCon_FileReopen;
                FileSaving -= JsonCon_FileSaving;
                FileSaved -= JsonCon_FileSaved;
            }
        }

        // Public static methods

        public static void ClipboardCopy(IEnumerable<Trace> traces)
        {
            string text;
            using (var stream = new MemoryStream())
            using (var streamWriter = new StreamWriter(stream))
            using (var textWriter = new JsonTextWriter(streamWriter))
            {
                UseStream(() => GetSerializer().Serialize(textWriter, traces));
                textWriter.Flush();
                streamWriter.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(stream))
                    text = streamReader.ReadToEnd();
            }
            var dataObject = new DataObject();
            dataObject.SetData(AppCon.DataFormat, text);
            dataObject.SetData(DataFormats.Text, text);
            Clipboard.SetDataObject(dataObject, copy: true);
        }

        public static IEnumerable<Trace> ClipboardPaste()
        {
            if (!AppCon.CanPaste)
                return null;
            IEnumerable<Trace> traces = null;
            using (var stream = new MemoryStream())
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.Write(Clipboard.GetData(AppCon.DataFormat));
                streamWriter.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(stream))
                using (var textReader = new JsonTextReader(streamReader))
                    UseStream(() => traces = GetSerializer().Deserialize<IEnumerable<Trace>>(textReader));
            }
            return traces;
        }

        // Protected methods

        protected override void ClearDocument() => OnClear();

        protected override bool LoadFromStream(Stream stream)
        {
            using (var streamReader = new StreamReader(stream))
            using (var textReader = new JsonTextReader(streamReader))
                return UseStream(() => Scene = GetSerializer().Deserialize<Scene>(textReader));
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_FileMenu, WorldForm.FileMenu);
            Localize(Resources.WorldForm_FileNew, WorldForm.FileNew, WorldForm.tbNew);
            Localize(Resources.WorldForm_FileNewEmptyScene, WorldForm.FileNewEmptyScene, WorldForm.tbNewEmptyScene);
            Localize(Resources.WorldForm_FileNewFromTemplate, WorldForm.FileNewFromTemplate, WorldForm.tbNewFromTemplate);
            Localize(Resources.WorldForm_FileOpen, WorldForm.FileOpen, WorldForm.tbOpen);
            Localize(Resources.WorldForm_FileReopen, WorldForm.FileReopen);
            Localize(Resources.WorldForm_FileSave, WorldForm.FileSave, WorldForm.tbSave);
            Localize(Resources.WorldForm_FileSaveAs, WorldForm.FileSaveAs);
            Localize(Resources.WorldForm_FileClose, WorldForm.FileClose);
            Localize(Resources.WorldForm_FileCloseAllAndExit, WorldForm.FileExit);
        }

        protected override void OnFileReopen(string filePath) => FileReopen?.Invoke(this, new FilePathEventArgs(filePath));

        protected override bool SaveToStream(Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream))
            using (var TextWriter = new JsonTextWriter(streamWriter))
                return UseStream(() => GetSerializer().Serialize(TextWriter, Scene));
        }

        // Private methods

        private void FileClose_Click(object sender, EventArgs e) => WorldForm.Close();

        private void FileExit_Click(object sender, EventArgs e) => AppCon.Close();

        private void FileNewEmptyScene_Click(object sender, EventArgs e) => NewEmptyScene();

        private void FileNewFromTemplate_Click(object sender, EventArgs e) => NewFromTemplate();

        private void FileOpen_Click(object sender, EventArgs e) => OpenFile();

        private void FileSave_Click(object sender, EventArgs e) => SaveFile();

        private void FileSaveAs_Click(object sender, EventArgs e) => SaveFileAs();

        private WorldCon GetNewWorldCon()
        {
            if (AppCon.Options.OpenInNewWindow)
                return AppCon.AddNewWorldCon();
            if (!JsonCon.SaveIfModified())
                return null;
            JsonCon.Clear();
            SetDefaultCamera();
            return WorldCon;
        }

        private void JsonCon_FileLoaded(object sender, EventArgs e) => OnLoad();

        private void JsonCon_FilePathChanged(object sender, EventArgs e) => UpdateCaption();

        private void JsonCon_FilePathRequest(object sender, FilePathEventArgs e) => OnFilePathRequest(e);

        private void JsonCon_FileReopen(object sender, FilePathEventArgs e) => OpenFile(e.FilePath);

        private void JsonCon_FileSaved(object sender, EventArgs e) => OnSave();

        private void JsonCon_FileSaving(object sender, CancelEventArgs e) => e.Cancel = false;

        private void NewEmptyScene() => GetNewWorldCon();

        private void NewFromTemplate()
        {
            var worldCon = OpenFile(FilterIndex.Template);
            if (worldCon != null)
                worldCon.JsonCon.FilePath = string.Empty;
        }

        private void OnClear()
        {
            CommandCon.Clear();
            Scene.Clear();
            SignalsCon.Clear();
            Reset();
        }

        private void OnFilePathRequest(FilePathEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.FilePath))
                e.FilePath = Scene.Title.ToFilename();
        }

        private void OnLoad()
        {
            WorldCon.ConnectCons(false);
            Scene.WorldCon = WorldCon;
            Scene.AttachTraces();
            CommandCon.Clear();
            WorldCon.ConnectCons(true);
            SceneCon.RecreateSceneControl();
            SignalsCon.Load();
            Reset();
        }

        private void OnSave()
        {
            CommandCon.Save();
            Reset();
        }

        private WorldCon OpenFile(FilterIndex filterIndex = FilterIndex.File) => OpenFile(JsonCon.SelectFilePath(filterIndex));

        private WorldCon OpenFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;
            var worldCon = GetNewWorldCon();
            worldCon?.LoadFromFile(filePath);
            return worldCon;
        }

        private void Reset()
        {
            SetDefaultCamera();
            WorldCon.UpdateAllProperties();
        }

        private bool SaveFile() => JsonCon.Save();

        private bool SaveFileAs() => JsonCon.SaveAs();

        private bool SaveOrSaveAs() => Scene.IsModified ? SaveFile() : SaveFileAs();

        private void SetDefaultCamera() => CameraCon.SetDefaultCamera();

        private void TbOpen_DropDownOpening(object sender, EventArgs e) => WorldForm.FileReopen.CloneTo(WorldForm.tbOpen, ToolStripUtils.CloneOptions.All);

        private void TbSave_Click(object sender, EventArgs e) => SaveOrSaveAs();

        private void UpdateCaption() => WorldForm.Text = JsonCon.WindowCaption;

        // Private static methods

        private static JsonSerializer GetSerializer() => new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented,
            MissingMemberHandling = MissingMemberHandling.Error
        };
    }
}
