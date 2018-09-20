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
                return JsonConvert.DeserializeObject<Tracker>(File.ReadAllText(Directory.GetCurrentDirectory() + "/data.json"));
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
