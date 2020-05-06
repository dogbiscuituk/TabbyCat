namespace TabbyCat.Types
{
    using System;

    internal class PropertyEditEventArgs : EventArgs
    {
        // Constructors

        internal PropertyEditEventArgs(Property property, int index) : base()
        {
            Index = index;
            Property = property;
        }

        // Internal properties

        internal int Index { get; set; }
        internal Property Property { get; set; }
    }
}
