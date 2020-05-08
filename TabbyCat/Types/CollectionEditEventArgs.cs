namespace TabbyCat.Types
{
    public class CollectionEditEventArgs : PropertyEditEventArgs
    {
        // Constructors

        public CollectionEditEventArgs(Property collection, int index, bool adding) : base(collection, index) => Adding = adding;

        // Public properties

        public bool Adding { get; set; }
    }
}
