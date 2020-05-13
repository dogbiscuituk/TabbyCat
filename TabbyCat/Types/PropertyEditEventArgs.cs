namespace TabbyCat.Types
{
    using System;

    public class PropertyEditEventArgs : EventArgs
    {
        // Constructors

        public PropertyEditEventArgs(Property property, int index) : base()
        {
            Index = index;
            Property = property;
        }

        // Public properties

        public int Index { get; }
        public Property Property { get; }
    }
}
