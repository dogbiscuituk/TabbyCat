namespace TabbyCat.Common.Types
{
    using System;

    public class CollectionChangedEventArgs : EventArgs
    {
        // Constructors

        public CollectionChangedEventArgs(string collectionName, bool adding, int index) : base()
        {
            CollectionName = collectionName;
            Adding = adding;
            Index = index;
        }

        // Public properties

        public string CollectionName { get; set; }
        public bool Adding { get; set; }
        public int Index { get; set; }
    }
}
