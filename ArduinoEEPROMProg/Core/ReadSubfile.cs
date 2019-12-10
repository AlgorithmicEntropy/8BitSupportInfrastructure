using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using CompLib;

namespace ArduinoEEPROMProg.Core
{
    class ReadSubfile
    {
        public ReadSubfile()
        {

        }

        public ControlData GetDataFromFile(string path)
        {
            var dict = new Dictionary<int, char[]>();
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var entries = line.Split(new char[] { ';' });
                char[] code = new char[entries[1].Length];
                for (int i = 0; i < entries[1].Length; i++)
                {
                    code[i] = char.Parse(entries[1].Substring(i, 1));
                }
                dict.Add(int.Parse(entries[0]), code);
            }
            return new ControlData(dict, 8);
        }
    }
}
