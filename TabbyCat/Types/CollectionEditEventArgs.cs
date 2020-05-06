namespace TabbyCat.Types
{
    internal class CollectionEditEventArgs : PropertyEditEventArgs
    {
        // Constructors

        internal CollectionEditEventArgs(Property collection, int index, bool adding) : base(collection, index) => Adding = adding;

        // Internal properties

        internal bool Adding { get; set; }
    }
}
