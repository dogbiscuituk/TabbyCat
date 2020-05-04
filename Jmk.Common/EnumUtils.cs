namespace Jmk.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    public static class EnumUtils
    {
        public static IEnumerable<string> GetDescriptions(this Type enumType) => enumType?.GetFields()
                .Select(p => p.GetCustomAttribute<DescriptionAttribute>())
                .OfType<DescriptionAttribute>()
                .Select(p => p.Description);
    }
}
