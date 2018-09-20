﻿using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace OWTrack
{
    class Tracker
    {
        public int wins, losses, startSR, newSR = 0;
        public string gamePath;       
        
        public void Track() { }
        public void reset() { wins = 0; losses = 0; startSR = 0; newSR = 0; gamePath = null; }
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
            catch (Exception)
            {
                Exception ex = new Exception("Error in tracking Overwatch.exe");
                throw ex;
            }
        }
      
        public bool LoacteOW() 
        {
            try 
            {
                List<string> paths = new List<string>();
                string[] filesC = null;
                string[] filesD = null;

                if (ProgramFilesExist('c')) { filesC = Directory.GetFiles("C:\\Program Files", "Overwatch.exe", SearchOption.AllDirectories); }
                if (ProgramFilesExist('d')) { filesD = Directory.GetFiles("D:\\Program Files", "Overwatch.exe", SearchOption.AllDirectories); }

                if (filesC != null)
                {
                    for (int i = 0; i < filesC.Length; i++)
                    {
                        if (filesC[i].Contains("Overwatch.exe"))
                        {
                            paths.Add(filesC[i]);
                        }
                    }
                }

                if (filesD != null)
                {
                    for (int i = 0; i < filesD.Length - 1; i++)
                    {
                        if (filesD[i].Contains("Overwatch.exe"))
                        {
                            paths.Add(filesD[i]);
                        }
                    } 
                }

                if (paths.Count > 1)
                {
                    //TODO: ask about correct path
                    return true;
                }

                else if (paths.Count == 1)
                {
                    gamePath = paths[0];
                    return true;
                }

                else return false;
                
            }
            catch (Exception e)
            {
                 MessageBox.Show(e.Message);
                return false;
            }                        
        }
        
        private bool ProgramFilesExist(char drive)
        {
           return Directory.Exists(drive+":\\Program Files");
        }
    }
}
