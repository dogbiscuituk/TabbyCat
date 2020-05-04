namespace Jmk.Common
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Forms;

    public static class Processes
    {
        public static void Launch(this string path)
        {
            try
            {
                Process.Start(path);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(
                    $"{ex.Message}:\n\n{path}",
                    ex.GetType().Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void Spit(this string s) => Debug.WriteLine($"* {DateTime.Now:yyyy-MM-dd hh:mm:ss.fff} * {s}");
    }
}
