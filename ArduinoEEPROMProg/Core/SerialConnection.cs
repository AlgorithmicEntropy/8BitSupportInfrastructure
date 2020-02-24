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

        #region events

        public event EventHandler ArduinoReady;
        protected virtual void OnArduinoReady(EventArgs e)
        {
            ArduinoReady?.Invoke(this, e);
        }

        #endregion

        public SerialConnection(string port)
        {
            serial = new SerialPort
            {
                PortName = port,
                BaudRate = 9600,
                Parity = Parity.None
            };
            serial.Open();
            serial.DiscardInBuffer();
            serial.DiscardOutBuffer();
            serial.DataReceived += OnStartDataReceived;
        }

        public void Dispose()
        {
            serial.Dispose();
        }

        public void Send(byte[] data)
        {
            serial.Write(data, 0, data.Length);
        }

        private void OnStartDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte data = (byte)serial.ReadByte();
            if(data == 0x55)
            {
                serial.DataReceived -= OnStartDataReceived;
                Console.WriteLine("Arduino Ready");
                OnArduinoReady(EventArgs.Empty);
            }
        }

        
    }
}
