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
            //get file to write
            string path = GetSourceFile();
            Console.WriteLine("reading data from file...");
            var data = new ReadSubfile().GetDataFromFile(path);
            Console.WriteLine("done");
            WriteAvailablePorts();
            Console.WriteLine("please enter com port: ");
            var port = Console.ReadLine();
            Console.WriteLine("sending data to arduino...");
            try
            {
                new SendToArduino().SendData(data, port);
                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encountered an error: ");
                Console.WriteLine(ex.Message);                
            }

            Console.ReadKey();
        }

        private static string GetSourceFile()
        {
            var fileDialog = new OpenFileDialog();
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
