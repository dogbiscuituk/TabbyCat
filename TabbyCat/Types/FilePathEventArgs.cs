namespace TabbyCat.Types
{
    using System;

    public class FilePathEventArgs : EventArgs
    {
        public FilePathEventArgs(string filePath) => FilePath = filePath;
        public string FilePath { get; set; }
    }
}
