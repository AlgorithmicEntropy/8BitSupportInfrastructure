using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControlLogicEEPROMGenerator.Core
{
    class DataToFileSplitter
    {
        private static readonly string fileName = "EEPROM_Data_";
        private static readonly string directoryName = "EEPROM_Data";

        public DataToFileSplitter()
        {

        }

        public List<Dictionary<int, string>> SplitData(ControlData data)
        {
            var returnList = new List<Dictionary<int, string>>();
            int fileNumber = (int)Math.Ceiling(data.GetWordLength() / 8d);     
            StringBuilder[] builders = new StringBuilder[fileNumber];

            for (int i = 0; i < fileNumber; i++)
            {
                builders[i] = new StringBuilder();
                returnList.Add(new Dictionary<int, string>());
            }

            foreach (var entry in data.GetData())
            {
                string dataLine;
                int index;

                for (int i = 0; i < fileNumber; i++)
                {
                    for (int j = 0; j < entry.Value.Length; j++)
                    {
                        builders[i].Append(entry.Value[j]);
                    }

                    //TODO fix file gen
                    dataLine = builders[i].ToString();
                    index = Math.Min(8, dataLine.Length - i * 8);
                    returnList[i].Add(entry.Key, dataLine.Substring(8*i, index));
                    builders[i].Clear();
                }
            }
            return returnList;
        }

        public void WriteFiles (List<Dictionary<int, string>> data, string path)
        {
            //create directory
            var localPath = Path.Combine(path, directoryName);
            Directory.CreateDirectory(localPath);

            int i = 0;
            foreach (var dict in data)
            {
                i++;
                var writer = new StreamWriter(localPath + "\\" + fileName + i + ".txt");
                foreach (var entry in dict)
                {
                    writer.WriteLine(entry.Key + ";" + entry.Value);
                }
                writer.Flush();
                writer.Close();

            }
        }

    }
}
