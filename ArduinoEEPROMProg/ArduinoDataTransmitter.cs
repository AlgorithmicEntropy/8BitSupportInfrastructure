using ArduinoEEPROMProg.Core;
using CompLib;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoEEPROMProg
{
    class ArduinoDataTransmitter
    {
        public void InitTransmitter()
        {
            string path = GetSourceFile();
            Console.WriteLine("reading data from file...");
            var data = new ReadSubfile().GetDataFromFile(path);
            Console.WriteLine("done");
            //get port
            var ports = SerialPort.GetPortNames();
            string port;
            if (ports.Length == 1)
            {
                port = ports.First();
            }
            else
            {
                WriteAvailablePorts();
                Console.WriteLine("please enter com port: ");
                port = Console.ReadLine();
            }
            SendToArduino sendToArduino = new SendToArduino(port, data);
        }

        private static string GetSourceFile()
        {
            var fileDialog = new OpenFileDialog();
            //local defaults
            fileDialog.InitialDirectory = "D:\\8BitComp\\EEPROM_Prog\\EEPROM_Data";
            fileDialog.Filter = "Control line data files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.ShowDialog();
            Console.WriteLine(fileDialog.FileName);
            return fileDialog.FileName;
        }

        private static void WriteAvailablePorts()
        {
            Console.WriteLine("Available Ports:");
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }
        }
    }
}
