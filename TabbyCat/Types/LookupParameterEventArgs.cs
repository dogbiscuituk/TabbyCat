namespace TabbyCat.Types
{
    using System;

    public class LookupParameterEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
