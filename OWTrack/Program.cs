using System;
using System.Windows.Forms;
using System.Deployment.Application;


namespace OWTrack
{
    static class Program
    {        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static string Version { get; } = "1.4.3a";
        //public static string Version = Application.ProductVersion;
        //public static Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

    }
}
