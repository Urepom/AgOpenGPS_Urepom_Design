using System;
using System.Windows.Forms;
using AgOpenGPS.Updater.Forms;

namespace AgOpenGPS.Updater
{
    /// <summary>
    /// Main entry point for the AgOpenGPS Updater application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Parse command line arguments
            string currentVersion = null;
            string installPath = null;
            bool showFirmwareUpdate = false;

            var args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; i++)
            {
                string arg = args[i];

                if (arg.Equals("--current-version", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    currentVersion = args[++i];
                }
                else if (arg.Equals("--install-path", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    installPath = args[++i];
                }
                else if (arg.Equals("--firmware", StringComparison.OrdinalIgnoreCase))
                {
                    showFirmwareUpdate = true;
                }
            }

            // Show the appropriate form
            if (showFirmwareUpdate)
            {
                Application.Run(new FormFirmwareUpdate());
            }
            else
            {
                Application.Run(new FormUpdate(currentVersion, installPath));
            }
        }
    }
}
