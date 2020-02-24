using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CompLib;

namespace ControlLogicEEPROMGenerator.Core
{
    class CSVParser
    {
        public CSVParser()
        {

        }

        public ControlData ReadControlData(string path)
        {
            var content = new Dictionary<int,char[]>();
            StreamReader reader = new StreamReader(path);
            //read whole file
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var controllValues = new char[values.Count() - 1];
                for(int i = 1; i < values.Count();i++)
                {
                    controllValues[i - 1] = Char.Parse(values[i]);
                }
                content.Add(Int32.Parse(values[0].Substring(2),System.Globalization.NumberStyles.HexNumber), controllValues);
            }

            reader.Close();
            //Console.WriteLine(content.First().Value.Count());
            return new ControlData(content, content.First().Value.Count());
        }
    }
}
