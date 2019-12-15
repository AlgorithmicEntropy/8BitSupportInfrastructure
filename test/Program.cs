using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            byte output = 0;
            var bitString = "11111111";

            for (int b = 0; b <= 7; b++)
            {
                output |= (byte)((bitString[b] == '1' ? 1 : 0) << (7 - b));
            }

            Console.WriteLine(output);

            Console.ReadLine();
        }
    }
}
