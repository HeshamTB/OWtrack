/************************************************************************************
Copyright(c) 2018 Hesham Systems LLC.

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
SOFTWARE.
************************************************************************************/

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
        
        public void addWin() => wins++;
        public void addLoss() => losses++;
        public void reduceWin() => wins--;
        public void rediceLoss() => losses--;
        public int GetWins() { return wins; }
        public int GetLosses() { return losses; }
        public void setNewSR(int SR) { newSR = SR; }
        public int srDiff() { return newSR - startSR; }
        public Settings settings = new Settings();
        public List<Session> sessions = new List<Session>();
        public int GetTotalMatches()
        {
            int number = 0;
            foreach (var session in sessions)
            {
                number += session.TotalMatches;
            }
            return number;
        }

        public int GetCurrentSessionMatches()
        {
            return sessions.Last().TotalMatches;
        }

        public void reset()
        {
            wins = 0;
            losses = 0;
            startSR = 0;
            newSR = 0;
            settings.Reset();
            sessions.Clear();
            StartNewSeission();
        }
              
        public void StartNewSeission()
        {
            Session ses = new Session(startSR);
            sessions.Add(ses);
        }

        public Session GetCurrentSession()
        {
            return sessions.Last();
        }

        public bool owRunning()
        {
            if (settings.TrackOW)
            {
                try
                {
                    bool isRunning = Process.GetProcessesByName("Overwatch")
                                    .FirstOrDefault(p => p.MainModule.FileName.StartsWith(settings.GamePath)) != default(Process);
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

	//change func name to OWexists()
        public bool LoacteOW()
        {
            try
            {
                DriveInfo[] driveInfo = DriveInfo.GetDrives();
                List<string> paths = new List<string>();
                //Searches all drives (too long)
                //foreach (var drive in driveInfo)
                //{
                //paths.AddRange(GetFiles(drive.ToString(),"Overwatch.exe"));
                //}
                paths.AddRange(GetFiles(Paths.ProgramFiles.C, "Overwatch.exe"));
                paths.AddRange(GetFiles(Paths.ProgramFiles.D, "Overwatch.exe"));

                if (paths.Count > 1)
                {
                    //TODO: ask about correct path
                    //New Form?? 
                    return true;
                }

                else if (paths.Count == 1
                && paths[0].Contains("Overwatch.exe"))
                {
                    settings.GamePath = paths[0];
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

        public static IEnumerable<string> GetFiles(string root, string searchPattern)
        {
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;
                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                }
                catch { }
                if (next != null && next.Length != 0)
                    foreach (var file in next) yield return file;
                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next) pending.Push(subdir);
                }
                catch { }
            }
        }
    }

    class Settings
    {
        public bool TrackSR, TrackOW = true;
        public string GamePath = "";

        /// <summary>
        /// Reset All values to defult  
        /// </summary>
        public void Reset()
        {
            TrackOW = true;
            TrackSR = true;
            GamePath = "";
        }
    }

    class Session
    {
        public int TotalMatches;
        public int SkillChange;
        public int StartSR;
        public DateTime date;
        public List<Match> Matches = new List<Match>();       

        /// <summary>
        /// Start a new session with a starting Skill Rating
        ///</summary>
        public Session(int StartSR)
        {
            this.StartSR = StartSR;
            date = DateTime.Now.Date;
            TotalMatches = 0;
        }

        public bool IsNewSession()
        {
            if (Matches.Count == 0) return true;
            else return false;
        }

        public Match GetLastMatch()
        {
            return Matches.Last();
        }

        public void AddMatch(Match match)
        {
            this.Matches.Add(match);
            this.TotalMatches = Matches.Count();
        }
    }

    class Match
    {
        public Match() { }
        public DateTime dateTime { get; set; }
        public int StartSR;
        public int LastMatchSR;
        public int newSR;
        public int ChangeInSR;
    }
}
