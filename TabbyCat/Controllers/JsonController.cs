namespace TabbyCat.Controllers
{
    using Jmk.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using TabbyCat.Models;

    /// <summary>
    /// Extend SdiController to provide concrete I/O methods using Json data format.
    /// Maintain a "WindowCaption" property for the app, including the product name,
    /// current filename if any - otherwise "(untitled)" - and the "Modified" flag.
    /// </summary>
    internal class JsonController : SdiController
    {
        #region Constructor

        internal JsonController(WorldController worldController)
            : base(worldController, Properties.Settings.Default.FileFilter, "LibraryMRU")
        { }

        #endregion

        #region Internal Methods

        internal bool ClipboardCopy(IEnumerable<Trace> traces)
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
            dataObject.SetData(AppController.DataFormat, text);
            dataObject.SetData(DataFormats.Text, text);
            Clipboard.SetDataObject(dataObject, copy: true);
            return result;
        }

        internal IEnumerable<Trace> ClipboardPaste()
        {
            IEnumerable<Trace> traces = null;
            if (AppController.CanPaste)
                using (var stream = new MemoryStream())
                using (var streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(Clipboard.GetData(AppController.DataFormat));
                    streamWriter.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    using (var streamReader = new StreamReader(stream))
                    using (var textReader = new JsonTextReader(streamReader))
                        UseStream(() => traces = GetSerializer().Deserialize<IEnumerable<Trace>>(textReader));
                }
            return traces;
        }

        #endregion

        #region Internal Properties

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

        #endregion

        #region Internal Events

        internal event EventHandler<FilePathEventArgs> FileReopen;

        #endregion

        #region Protected Methods

        protected override void ClearDocument() => Scene.Clear();

        protected override bool LoadFromStream(Stream stream)
        {
            using (var streamReader = new StreamReader(stream))
            using (var textReader = new JsonTextReader(streamReader))
                return UseStream(() => Scene = GetSerializer().Deserialize<Scene>(textReader));
        }

        protected override void OnFileReopen(string filePath) =>
            FileReopen?.Invoke(this, new FilePathEventArgs(filePath));

        protected override bool SaveToStream(Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream))
            using (var TextWriter = new JsonTextWriter(streamWriter))
                return UseStream(() => GetSerializer().Serialize(TextWriter, Scene));
        }

        #endregion

        #region Private Methods

        private static JsonSerializer GetSerializer() => new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        #endregion
    }
}
