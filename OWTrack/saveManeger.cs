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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWTrack
{
    static class Paths
    {
        private static string curDir = Directory.GetCurrentDirectory();
        public static string SAVES = curDir + "/saves/data.json";
        public static string JSON = curDir + "/data.json";
    }

    class saveManeger
    {        
        /// <summary>
        /// Deserialize saved tracker instance.
        /// </summary>
        /// <returns></returns>
        public static Tracker GetSavedTracker()
        {
            try
            {
                return JsonConvert.DeserializeObject<Tracker>(File.ReadAllText(Paths.SAVES));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public static Tracker GetSavedTracker(string customPath)
        {
            try
            {
                return JsonConvert.DeserializeObject<Tracker>(File.ReadAllText(customPath));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///Saves the Tracker Object. 
        /// </summary>
        /// <param name="tracker"></param>
        /// <returns></returns>
        public static bool SaveJSON(Tracker tracker)
        {
            try
            {
                JsonConvert json = new JsonConvert();//Not tested
                json.Formatting = Formatting.Indented;
                File.WriteAllText(Paths.SAVES, json.SerializeObject(tracker));//check if (Indented) Parameter exists
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if a 'data.json' exists in the default location '../saves/data.json'.
        /// </summary>
        /// <returns>Boolean Value</returns>
        public static bool saveExist()
        {
            try
            {
                if (File.Exists(Paths.SAVES))
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
