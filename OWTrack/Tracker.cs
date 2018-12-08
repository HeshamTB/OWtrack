/*Copyright(c) 2018 Hesham Systems LLC.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/

using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace OWTrack
{
    class Tracker
    {
        public int wins, losses, startSR, newSR, totalMatches = 0;
        public string gamePath;       
        
        public void Track() { }//Deserailize here
        public void reset() { wins = 0; losses = 0; startSR = 0; newSR = 0; gamePath = null; }
        public void addWin() => wins++;
        public void addLoss() => losses++;
        public void reduceWin() => wins--;
        public void rediceLoss() => losses--;
        public int GetWins() { return wins; }
        public int GetLosses() { return losses; }
        public int GetTotalMatches() { return wins + losses; }
        public void setNewSR(int SR) { newSR = SR; }
        public int srDiff() { return newSR - startSR; }
        public bool TrackOW = true;
        public bool TrackSR = true;

        struct ProgramFiles
        {
            public static readonly string C = "C:\\Program Files";
            public static readonly string D = "D:\\Program Files";
            public static readonly string E = "E:\\Program Files";
            public static readonly string F = "F:\\Program Files";
            public static readonly string G = "G:\\Program Files";
        }

        public bool owRunning()
        {
            if (TrackOW)
            {
                try
                {
                    bool isRunning = Process.GetProcessesByName("Overwatch")
                                    .FirstOrDefault(p => p.MainModule.FileName.StartsWith(gamePath)) != default(Process);
                    return isRunning;
                }
                catch (Exception)
                {
                    Exception ex = new Exception("Error");
                    throw ex;
                }
            }
            else return false;
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

    struct Settings
    {
        bool TrackSR, TrackOW;
        string OWpath;
    }
}
