using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

using ArduinoEEPROMProg.Core;
using CompLib;

namespace ArduinoEEPROMProg
{
    class EEPROMProgramer
    {
        [STAThread]
        static void Main(string[] args)
        {
            var transmitter = new ArduinoDataTransmitter();
            transmitter.InitTransmitter();
            Console.ReadKey();
        }

    }
}
