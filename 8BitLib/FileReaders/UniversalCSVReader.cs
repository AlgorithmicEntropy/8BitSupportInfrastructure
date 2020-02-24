using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8BitLib.FileReaders
{
    class UniversalCSVReader
    {
        public UniversalCSVReader()
        {

        }

        public List<string[]> ReadCSV(string path)
        {
            var list = new List<string[]>();
            StreamReader reader = new StreamReader(path);
            //read whole file
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                list.Add(values);
            }
            reader.Close();
            return list;
        }
    }
}
