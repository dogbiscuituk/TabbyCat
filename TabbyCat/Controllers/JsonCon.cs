namespace TabbyCat.Controllers
{
    using Jmk.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using TabbyCat.Models;
    using TabbyCat.Properties;

    /// <summary>
    /// Extend SdiCon to provide concrete I/O methods using Json data format.
    /// Maintain a "WindowCaption" property for the app, including the product name,
    /// current filename if any - otherwise "(untitled)" - and the "Modified" flag.
    /// </summary>
    internal class JsonCon : SdiCon
    {
        internal JsonCon(WorldCon worldCon) : base(worldCon, Properties.Settings.Default.FileFilter, "LibraryMRU") { }

        internal string WindowCaption
        {
            get
            {
                var text = Path.GetFileNameWithoutExtension(FilePath).ToFilename();
                if (Scene.IsModified)
                    text = string.Concat("* ", text);
                text = string.Concat(text, " - ", Application.ProductName);
                return text;
            }
        }

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

        protected override void ClearDocument()
        {
            CommandProcessor.Clear();
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
            Localize(Resources.Menu_File, WorldForm.FileMenu);
            Localize(Resources.Menu_File_New, WorldForm.FileNew, WorldForm.tbNew);
            Localize(Resources.Menu_File_New_EmptyScene, WorldForm.FileNewEmptyScene, WorldForm.tbNewEmptyScene);
            Localize(Resources.Menu_File_New_FromTemplate, WorldForm.FileNewFromTemplate, WorldForm.tbNewFromTemplate);
            Localize(Resources.Menu_File_Open, WorldForm.FileOpen, WorldForm.tbOpen);
            Localize(Resources.Menu_File_Reopen, WorldForm.FileReopen);
            Localize(Resources.Menu_File_Save, WorldForm.FileSave, WorldForm.tbSave);
            Localize(Resources.Menu_File_SaveAs, WorldForm.FileSaveAs);
            Localize(Resources.Menu_File_Close, WorldForm.FileClose);
            Localize(Resources.Menu_File_CloseAllAndExit, WorldForm.FileExit);
        }

        protected override void OnFileReopen(string filePath) => FileReopen?.Invoke(this, new FilePathEventArgs(filePath));

        protected override bool SaveToStream(Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream))
            using (var TextWriter = new JsonTextWriter(streamWriter))
                return UseStream(() => GetSerializer().Serialize(TextWriter, Scene));
        }

        private static JsonSerializer GetSerializer() => new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented,
            MissingMemberHandling = MissingMemberHandling.Error
        };
    }
}
