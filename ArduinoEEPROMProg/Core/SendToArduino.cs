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
        private SerialConnection connection;
        private ControlData data;

        public SendToArduino(string port, ControlData data)
        {
            this.data = data;
            connection = new SerialConnection(port);
            connection.ArduinoReady += OnArduinoReady;
            Console.WriteLine("waiting for arduino...");
        }

        private void OnArduinoReady(object sender, EventArgs e)
        {
            Console.WriteLine("Arduino ready, writing data");
            SendData(data);
        }

        private void SendData(ControlData data)
        {
            foreach (var entry in data.GetData())
            {
                //convert string to 2 byte address
                byte[] address = BitConverter.GetBytes((Int16)entry.Key);
                Console.WriteLine("add: " + BitConverter.ToInt16(address, 0));
                connection.Send(address);

                byte codeByte = 0;
                //convert value to byte
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
