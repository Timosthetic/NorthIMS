using Infrastructure.Helper.Notify;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace Infrastructure.Helper.ConnectToSerilaPort
{
    public class SerialInfo : NotifyPropertyChanged
    {
        private string _portName = "COM1";
        /// <summary>
        /// 
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { SetProperty(ref _portName, value); }
        }

        private int _baudRate = 9600;
        /// <summary>
        /// 
        /// </summary>
        public int BaudRate
        {
            get { return _baudRate; }
            set { SetProperty(ref _baudRate, value); }
        }

      
        public int DataBit { get; set; } = 8;
        public Parity Parity { get; set; } = Parity.None;
        public StopBits StopBits { get; set; } = StopBits.One;
    }
}
