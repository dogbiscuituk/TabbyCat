namespace TabbyCat.Common.Types
{
    using System.ComponentModel;

    public class PropertyEditEventArgs : PropertyChangedEventArgs
    {
        // Constructors

        public PropertyEditEventArgs(string propertyName, int index) : base(propertyName) => Index = index;

        // Public properties

        public int Index { get; set; }
    }
}
