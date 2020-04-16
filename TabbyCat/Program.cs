namespace TabbyCat
{
    using System;
    using System.Windows.Forms;
    using TabbyCat.Controllers;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            ParseCommandLine(args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(AppCon.AboutDialog);
        }

        private static void ParseCommandLine(string[] args)
        {
            if (args.Length < 1)
                return;
            var culture = new System.Globalization.CultureInfo(args[0]);
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
