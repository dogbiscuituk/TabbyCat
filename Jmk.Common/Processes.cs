namespace Jmk.Common
{
    using System;
    using System.Diagnostics;

    public static class Processes
    {
        public static void Launch(this string url) => Process.Start(url);
        public static void Spit(this string s) => Debug.WriteLine($"* {DateTime.Now:yyyy-MM-dd hh:mm:ss.fff} * {s}");
    }
}
