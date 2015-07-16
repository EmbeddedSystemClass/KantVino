using System;
using System.Threading;
using System.IO.Ports;

namespace КантВиноНастройка
{
    public class ComPort
    {
        private static SerialPort _port = new SerialPort();
        public bool Open(string portName, string baudRate)
        {
            try
            {
                if (_port.IsOpen)
                {
                    _port.Close();
                }
                _port.PortName = portName;
                _port.BaudRate = int.Parse(baudRate);
                _port.Open();
                return true;
            }
            catch 
            {
                return false; 
            }
        }
        public bool Open(string portName, int baudRate)
        {
            try
            {
                if (_port.IsOpen)
                {
                    _port.Close();
                }
                _port.PortName = portName;
                _port.BaudRate = baudRate;
                _port.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Close()
        {
            try 
            {
                if (_port.IsOpen)
                {
                    _port.Close();
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public string[] PortNames()
        {
            var temp = SerialPort.GetPortNames();
            Array.Sort(temp, ((a, b) => (a.Length == b.Length) ? a.CompareTo(b) : a.Length.CompareTo(b.Length)));
            return temp;
        }
        public string[] BaudRates()
        {
            return new string[]{"4800","9600","38400","115200"};
        }
        public event SerialDataReceivedEventHandler DataReceived
        {
            add
            {
               _port.DataReceived += value;
            }

            remove
            {
                _port.DataReceived -= value;
            }
        }
        public delegate void PortClosedEventHandler();
        public event PortClosedEventHandler PortClosed;  
        public int Read(ref byte[] inBuf,int timeout)
        {
            try
            {
                int rxIndex = 0;
                inBuf.Initialize();
                if (!_port.IsOpen) { PortClosed(); return -1; }
                while (true)
                {
                    Thread.Sleep(timeout);
                    var rxCount = _port.BytesToRead;
                    if (rxCount < 1) break;
                    _port.Read(inBuf, rxIndex, rxCount);
                    rxIndex += rxCount;
                }
                return rxIndex;
            }
            catch { return -1; }
        }
        public bool Write(string text)
        {
            try
            {
                if (!_port.IsOpen) { PortClosed(); return false; }
                _port.Write(text);
                return true;
            }
            catch
            { return false; }
        }
        public bool Write(byte[] outBuf, int count)
        {
            try
            {
                if (!_port.IsOpen) { PortClosed(); return false; }
                _port.Write(outBuf,0,count);
                return true;
            }
            catch
            { return false; }
        }
        public bool IsOpen()
        {
            return _port.IsOpen;
        }
    }
}
