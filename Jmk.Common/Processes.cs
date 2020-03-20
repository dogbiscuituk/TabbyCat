namespace Jmk.Common
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Forms;

    public static class Processes
    {
        public static void Launch(this string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Win32Exception e)
            {
                MessageBox.Show(
                    $"{e.Message}:\n\n{url}",
                    e.GetType().Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void Spit(this string s) => Debug.WriteLine($"* {DateTime.Now:yyyy-MM-dd hh:mm:ss.fff} * {s}");
    }
}
