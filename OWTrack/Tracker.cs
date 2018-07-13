using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWTrack
{
    class Tracker
    {
        
        public void Track()
        {

        }

        public bool owRunning()
        {        
            bool isRunning = Process.GetProcessesByName("Overwatch")
                            .FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"D:\Hesham\installed Games\Overwatch")) != default(Process);
            return isRunning;
        }
    }
}
