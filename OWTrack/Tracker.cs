using System;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace OWTrack
{
    class Tracker
    {
        public int wins, losses, startSR, newSR = 0;
        public string gamePath;

        private string[] commonDir = ["C:\Program Files","D:\Program Files"];
        
        public void Track() { }
        public void reset() { wins = 0; losses = 0; startSR = 0; newSR = 0; }
        public void addWin() { wins++; }
        public void addLoss() { losses++; }
        public void reduceWin() { wins--; }
        public void rediceLoss() { losses--; }
        public int GetWins() { return wins; }
        public int GetLosses() { return losses; }
        public void setNewSR(int SR) { newSR = SR; }
        public int srDiff() { return newSR - startSR; }


        public bool owRunning()
        {
            try
            {
                bool isRunning = Process.GetProcessesByName("Overwatch")
                                .FirstOrDefault(p => p.MainModule.FileName.StartsWith(gamePath)) != default(Process);
                return isRunning;
            }
            catch (Exception e)
            {
                Exception ex = new Exception("Error in tracking Overwatch.exe");
                throw ex;
            }
        }

        public void LoacteOW() 
        {
            try 
            {
                string[] files = [];
                for (int i = 0; i < commonDir.count; i++) 
                {
                    files.append(Directory.GetFiles(commonDir[i], "Overwatch*",SearchOption.AllDirectories));
                }
                if (files.contians("Overwatch.exe"))
                {
                    foreach (string "*Overwatch.exe" in files)
                    {
                        
                    }
                }

            }
            catch (Exception e)
            {
                MesssageBox.show(e.message);
            }
            
            
            
        }       
    }
}
