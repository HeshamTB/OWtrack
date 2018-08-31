using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Application;


namespace OWTrack
{
    static class Program
    {        
        //public static string Version = Application.ProductVersion;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
       public static Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
    }
}
