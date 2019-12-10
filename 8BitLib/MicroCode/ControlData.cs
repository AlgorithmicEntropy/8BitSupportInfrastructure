using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompLib
{
    public class ControlData
    {
        private int wordLength;
        private Dictionary<int, char[]> data = new Dictionary<int, char[]>();

        public ControlData(Dictionary<int, char[]> content, int wordLength)
        {
            data = content;
            this.wordLength = wordLength;
        }

        public Dictionary<int, char[]> GetData()
        {
            return data;
        }

        public int GetWordLength()
        {
            return wordLength;
        }

        public override string ToString()
        {
            StringBuilder dataStringBuilder = new StringBuilder();
            foreach (var entry in data)
            {
                StringBuilder value = new StringBuilder();
                foreach (var val in entry.Value)
                {
                    value.Append(val + " ");
                }
                dataStringBuilder.Append(entry.Key);
                dataStringBuilder.Append("\t" + value.ToString());
                dataStringBuilder.Append("\n");
            }
            return dataStringBuilder.ToString();
        }

    }
}
