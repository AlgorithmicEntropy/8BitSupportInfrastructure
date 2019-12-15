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

            foreach (var entry in data.GetData())
            {
                byte[] address = BitConverter.GetBytes((Int16)entry.Key);
                Console.WriteLine("Add: " + BitConverter.ToInt16(address, 0));
                connection.Send(address);

                byte codeByte = 0;
                for (int b = 0; b <= 7; b++)
                {
                    codeByte |= (byte)((entry.Value[b] == '1' ? 1 : 0) << (7 - b));
                }
                Console.WriteLine("value: " + codeByte);
                connection.Send(new byte[] { codeByte });
            }

            //cleanup
            connection.Dispose();
        }
    }
}
