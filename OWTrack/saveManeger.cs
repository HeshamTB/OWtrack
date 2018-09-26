﻿/*Copyright(c) 2018 Hesham Systems LLC.

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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWTrack
{
    class saveManeger
    {
        public enum Paths 
        {
            saves = "/saves/data.json",
            saveJsonFile = "/data.json",
        };
        private static string savesPath = Directory.GetCurrentDirectory() + "/saves/data.json";

        public static Tracker GetSavedTracker()
        {
            try
            {
                return JsonConvert.DeserializeObject<Tracker>(File.ReadAllText(savesPath));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        //TODO: use para
        public static Tracker GetSavedTracker(string customPath)
        {
            try
            {
                return JsonConvert.DeserializeObject<Tracker>(File.ReadAllText(customPath + "/data.json"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool SaveJSON(Tracker tracker)
        {
            try
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + "/data.json", JsonConvert.SerializeObject(tracker));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool saveExist()
        {
            try
            {
                if (File.Exists(savesPath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
