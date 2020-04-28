namespace TabbyCat.Controllers
{
    using Common.Types;
    using Common.Utils;
    using Jmk.Common;
    using Models;
    using Newtonsoft.Json;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Extend SdiCon to provide concrete I/O methods using Json data format.
    /// Maintain a "WindowCaption" property for the app, including the product name,
    /// current filename if any - otherwise "(untitled)" - and the "Modified" flag.
    /// </summary>
    internal class JsonCon : SdiCon
    {
        internal JsonCon(WorldCon worldCon) : base(worldCon, Properties.Settings.Default.FileFilter, "LibraryMRU") { }

        private readonly List<string> ChangedPropertyNames = new List<string>();

        private int UpdateCount;

        internal string WindowCaption => $@"{(
            Scene.IsModified ? "* " : string.Empty)}{(
            string.IsNullOrWhiteSpace(FilePath) ? Resources.Text_NewScene : Path.GetFileNameWithoutExtension(FilePath).ToFilename())} - {
            Application.ProductName}";

        internal event EventHandler<FilePathEventArgs> FileReopen;

        internal static bool ClipboardCopy(IEnumerable<Trace> traces)
        {
            bool result;
            string text;
            using (var stream = new MemoryStream())
            using (var streamWriter = new StreamWriter(stream))
            using (var textWriter = new JsonTextWriter(streamWriter))
            {
                result = UseStream(() => GetSerializer().Serialize(textWriter, traces));
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
            return result;
        }

        internal static IEnumerable<Trace> ClipboardPaste()
        {
            IEnumerable<Trace> traces = null;
            if (AppCon.CanPaste)
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

        protected internal override void Connect(bool connect)
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

        protected override void ClearDocument()
        {
            CommandCon.Clear();
            Scene.Clear();
            WorldCon.UpdateAllProperties();
        }

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

        private void BeginUpdate() => ++UpdateCount;

        private void EndUpdate()
        {
            if (--UpdateCount == 0)
            {
                foreach (var propertyName in ChangedPropertyNames)
                    WorldCon.OnPropertyChanged(propertyName);
                ChangedPropertyNames.Clear();
            }
        }

        private void FileClose_Click(object sender, System.EventArgs e) => WorldForm.Close();

        private void FileExit_Click(object sender, System.EventArgs e) => AppCon.Close();

        private void FileNewEmptyScene_Click(object sender, System.EventArgs e) => NewEmptyScene();

        private void FileNewFromTemplate_Click(object sender, System.EventArgs e) => NewFromTemplate();

        private void FileOpen_Click(object sender, System.EventArgs e) => OpenFile();

        private void FileSave_Click(object sender, System.EventArgs e) => SaveFile();

        private void FileSaveAs_Click(object sender, System.EventArgs e) => SaveFileAs();

        private static JsonSerializer GetSerializer() => new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented,
            MissingMemberHandling = MissingMemberHandling.Error
        };

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

        private void JsonCon_FilePathRequest(object sender, SdiCon.FilePathEventArgs e) => OnFilePathRequest(e);

        private void JsonCon_FileReopen(object sender, SdiCon.FilePathEventArgs e) => OpenFile(e.FilePath);

        private void JsonCon_FileSaved(object sender, EventArgs e) => OnSave();

        private void JsonCon_FileSaving(object sender, CancelEventArgs e) => e.Cancel = false;

        private void NewEmptyScene() => GetNewWorldCon();

        private void NewFromTemplate()
        {
            var worldCon = OpenFile(FilterIndex.Template);
            if (worldCon != null)
                worldCon.JsonCon.FilePath = string.Empty;
        }

        private void OnFilePathRequest(SdiCon.FilePathEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.FilePath))
                e.FilePath = Scene.Title.ToFilename();
        }

        private void OnLoad()
        {
            WorldCon.ConnectCons(false);
            Scene.WorldCon = WorldCon;
            BeginUpdate();
            Scene.AttachTraces();
            CommandCon.Clear();
            EndUpdate();
            WorldCon.ConnectCons(true);
            SceneCon.RecreateSceneControl();
            SetDefaultCamera();
            UpdateAllProperties();
        }

        private void OnSave()
        {
            BeginUpdate();
            CommandCon.Save();
            EndUpdate();
            SetDefaultCamera();
            UpdateAllProperties();
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

        private bool SaveFile() => JsonCon.Save();

        private bool SaveFileAs() => JsonCon.SaveAs();

        private bool SaveOrSaveAs() => Scene.IsModified ? SaveFile() : SaveFileAs();

        private void SetDefaultCamera() => CameraCon.SetDefaultCamera();

        private void TbOpen_DropDownOpening(object sender, EventArgs e) => WorldForm.FileReopen.CloneTo(WorldForm.tbOpen);

        private void TbSave_Click(object sender, EventArgs e) => SaveOrSaveAs();

        private void UpdateCaption() { WorldForm.Text = JsonCon.WindowCaption; }
    }
}
