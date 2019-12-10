using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ArduinoEEPROMProg.Core
{
    public class SerialConnection : IDisposable
    {
        private SerialPort serial;

        public SerialConnection(string port)
        {
            serial = new SerialPort();
            serial.PortName = port;
            serial.BaudRate = 9600;
        }

        public void Dispose()
        {
            serial.Dispose();
        }

        public void Send(byte[] data)
        {
            serial.Open();
            serial.Write(data, 0, data.Length);
            serial.Close();
        }

        
    }
}
