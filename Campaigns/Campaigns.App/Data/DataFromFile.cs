using System.IO;
using Campaigns.App.Utils;
using System.Collections.Generic;

namespace Campaigns.App.Data
{
    public class DataFromFile : IData
    {
        public List<DataModel> Load()
        {
            var dataList = new List<DataModel>();

            var fileUtil = new FileUtil();

            var files = fileUtil.GetAllFiles(System.AppDomain.CurrentDomain.BaseDirectory + @"\SampleScenarios");

            foreach (string file in files)
            {
                var data = new DataModel();

                data.Name = Path.GetFileName(file);

                string[] lines = File.ReadAllLines(file);

                data.CommandList.AddRange(lines);

                dataList.Add(data);
            }

            return dataList;
        }
    }
}
