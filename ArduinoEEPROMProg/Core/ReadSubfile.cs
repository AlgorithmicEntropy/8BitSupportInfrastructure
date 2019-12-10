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
                char[] code = new char[entries.Length-1];
                for (int i = 1; i < entries.Length; i++)
                {
                    code[i - 1] = char.Parse(entries[i]);
                }
                dict.Add(int.Parse(entries[0]), code);
            }
            return new ControlData(dict, 8);
        }
    }
}
