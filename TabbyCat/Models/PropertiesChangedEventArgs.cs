using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TabbyCat.Models
{
    internal class PropertiesChangedEventArgs : EventArgs
    {
        internal PropertiesChangedEventArgs(params string[] propertyNames)
            : base() => PropertyNames = propertyNames;

        internal string[] PropertyNames { get; set; }
    }
}
