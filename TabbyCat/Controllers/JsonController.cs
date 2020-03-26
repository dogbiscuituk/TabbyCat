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
        #region Internal Interface

        internal JsonController(WorldController worldController)
            : base(worldController, Properties.Settings.Default.FileFilter, "LibraryMRU")
        { }

        internal IEnumerable<Trace> ClipboardRead()
        {
            return null;
        }

        internal bool ClipboardWrite(IEnumerable<Trace> selection)
        {
            bool result;
            string text;
            using (var stream = new MemoryStream())
            {
                using (var streamer = new StreamWriter(stream))
                {
                    using (var writer = new JsonTextWriter(streamer) { CloseOutput = false })
                    {
                        result = UseStream(() => GetSerializer().Serialize(writer, selection));

                        stream.Seek(0, SeekOrigin.Begin);
                        using (var reader = new StreamReader(stream))
                            text = reader.ReadToEnd();
                    }
                }
            }
            Clipboard.SetData(DataFormats.Text, text);
            return result;
        }

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

        #region Protected I/O Overrides

        protected override void ClearDocument() => Scene.Clear();

        protected override bool LoadFromStream(Stream stream)
        {
            bool result;
            using (var streamer = new StreamReader(stream))
            using (var reader = new JsonTextReader(streamer))
                result = UseStream(() => Scene = GetSerializer().Deserialize<Scene>(reader));
            return result;
        }

        protected override void OnFileReopen(string filePath) =>
            FileReopen?.Invoke(this, new FilePathEventArgs(filePath));

        internal event EventHandler<FilePathEventArgs> FileReopen;

        protected override bool SaveToStream(Stream stream)
        {
            using (var streamer = new StreamWriter(stream))
            using (var writer = new JsonTextWriter(streamer))
                return UseStream(() => GetSerializer().Serialize(writer, Scene));
        }

        #endregion

        #region Private Implementation

        private static JsonSerializer GetSerializer() => new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        #endregion
    }
}
