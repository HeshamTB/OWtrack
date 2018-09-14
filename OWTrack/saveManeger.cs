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
        public static Tracker GetSavedTracker()
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

        //private bool saveExist()
        //{
        //    try
        //    {
        //        if (File.Exists(Directory.GetCurrentDirectory() + "/data.json"))
        //        {
        //            using (StreamReader st = new StreamReader(Directory.GetCurrentDirectory() + "/data.json"))
        //            {
        //                string line = st.ReadLine();
        //                if (line.Contains("Overwatch.exe"))
        //                {
        //                    st.Close();
        //                    return true;
        //                }
        //                else
        //                {
        //                    if (!tr.LoacteOW())
        //                    {
        //                        st.Close();
        //                        getGamePath();
        //                    }
        //                    return true;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (!tr.LoacteOW())
        //            {
        //                getGamePath();
        //            }
        //            return false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //        return false;
        //    }
        //}
    }
}
