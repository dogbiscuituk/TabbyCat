namespace TabbyCat.Types
{
    public class CollectionEditEventArgs : PropertyEditEventArgs
    {
        // Constructors

        public CollectionEditEventArgs(string collectionName, int index, bool adding) : base(collectionName, index)
        {
            Adding = adding;
        }

        // Public properties

        public bool Adding { get; set; }
    }
}
