using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using CompLib;

namespace ArduinoEEPROMProg.Core
{
    class SendToArduino
    {
        public SendToArduino()
        {

        }

        public void SendData(ControlData data, string port)
        {
            SerialConnection connection = new SerialConnection(port);
            //init
            connection.Send(new byte[] { 0xFF });

            foreach (var entry in data.GetData())
            {
                byte[] address = BitConverter.GetBytes((Int16)entry.Key);
                connection.Send(address);
                string codeString = new string(entry.Value);
                byte codeByte = Convert.ToByte(codeString);
                connection.Send(new byte[] { codeByte });
            }
        }
    }
}
