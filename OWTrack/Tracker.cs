using System;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace OWTrack
{
    class Tracker
    {
        public int wins, losses = 0;
        
        public void Track()
        {
            
        }                

        public bool owRunning()
        {
            try
            {
                bool isRunning = Process.GetProcessesByName("Overwatch")
                                .FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"D:\Hesham\installed Games\Overwatch")) != default(Process);
                return isRunning;
            }
            catch (Exception e)
            {
                Exception ex = new Exception("Error in tracking Overwatch.exe");
                throw ex;
            }
        }

        public void reset() { wins = 0; losses = 0; }
        public void addWin() { wins++; }
        public void addLoss() { losses++; }
        public void reduceWin() { wins--; }
        public void rediceLoss() { losses--; }
        public int GetWins() { return wins; }
        public int GetLosses() { return losses; }
    }
}
