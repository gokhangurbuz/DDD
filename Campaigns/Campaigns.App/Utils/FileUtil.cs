using System;
using System.IO;
using System.Collections.Generic;

namespace Campaigns.App.Utils
{
   public class FileUtil
    {
        public List<string> GetAllFiles(string sDirt)
        {
            List<string> files = new List<string>();

            try
            {
                foreach (string file in Directory.GetFiles(sDirt))
                {
                    files.Add(file);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return files;
        }
    }
}
