using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кант_Вино
{
    public class ItemsDataRecived
    {
        public struct DataStruct
        {
            public double temper1;
            public double temper2;
            public double pressure;
            public double level;
        }

        public DataStruct[] ItemsValue;
        private StringBuilder _errorStrings = new StringBuilder();


        private Timer _getDataTimer = new Timer();
        private ComPort _comPort = new ComPort();

        private int _currentItem = 0;
        private int _countItems = 0;

        private bool _isDataWait = false;
        private int _waitTimeout;
        private const int WaitTimeoutLimit = 5;


        public void TestItem(int index)
        {
            
        }

        public void ScanItems()
        {
            _errorStrings.Clear();
            _isDataWait = false;
            _currentItem = 0;
            _getDataTimer.Enabled = true;
        }

        private void GetDataTimer_Tick(object sender, EventArgs e)
        {
            if (_isDataWait) //Timeout
            {
                if (++_waitTimeout > WaitTimeoutLimit)
                {
                    _errorStrings.AppendFormat("Timeout {1}", _currentItem+1);
                    _currentItem++;
                }
                else
                {
                    return;
                }
            }

            while (_currentItem < _countItems && !Properties.Settings.Default.ItemsEnale[_currentItem]) _currentItem++;

            if (_currentItem >= _countItems) //EndScan
            {
                _getDataTimer.Enabled = false;
                EndScanItems(_errorStrings);
            }


            //GetData
            byte[] outBuf = { 0xFF, 0xFF, 1, 1, 2, 2, 0xF1, 0xF1 };
            outBuf[2] = outBuf[3] = (byte)(_currentItem+1);
            if (_comPort.Write(outBuf, 8))
            {
                _isDataWait = true;
                _waitTimeout = 0;
            }
        }

        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] inBuf = new byte[256];
            int rxCount = _comPort.Read(ref inBuf, 70);
            if (!_isDataWait || rxCount < 2 || _currentItem>=_countItems) return;

            if (rxCount < 18 || rxCount > 25)
            {
                _errorStrings.AppendFormat("ErrCount {0}", _currentItem);
                _isDataWait = false;
                _currentItem++;
                return;
            }
            if (inBuf[1] != 0xFF || inBuf[2] != 0xAA || inBuf[3] != (_currentItem+1))
            {
                _errorStrings.AppendFormat("ErrAdr {0}", _currentItem);
                _isDataWait = false;
                _currentItem++;
                return;
            }


            double temp;

            temp = BitConverter.ToInt16(inBuf, 4);
            ItemsValue[_currentItem].temper1 = temp / 16;

            temp = BitConverter.ToInt16(inBuf, 6);
            ItemsValue[_currentItem].temper2 = temp / 16;

            temp = BitConverter.ToInt32(inBuf, 8);
            ItemsValue[_currentItem].pressure = temp * Properties.Settings.Default.CoefficientsPressure[_currentItem];

            temp = BitConverter.ToInt32(inBuf, 12);
            ItemsValue[_currentItem].level = temp * Properties.Settings.Default.CoefficientsLevel[_currentItem];
        
        }



      
        public void InitDataRecived(int countItems)
        {
            _countItems = countItems;
            ItemsValue = new DataStruct[countItems];
           
            _getDataTimer.Interval = 50;
            _getDataTimer.Enabled = false;
            _getDataTimer.Tick += GetDataTimer_Tick;
           
            _comPort.Open(Properties.Settings.Default.Port, Properties.Settings.Default.BaudRate);
            _comPort.DataReceived += ComPort_DataReceived;
            _comPort.PortClosed += ComPort_PortClosed;
        }

        private void ComPort_PortClosed()
        {
            _errorStrings.Clear();
            _errorStrings.AppendFormat("PortClose");
            _getDataTimer.Enabled = false;
            EndScanItems(_errorStrings);
        }

        public delegate void EndScanItemsEventHandler(StringBuilder errorStrings);
        public event EndScanItemsEventHandler EndScanItems;  




        //public const int TIME_OUT = 10;
        //public const int ERROR_COUNT = 8;
        //public const int ERROR_CRC = 6;
        //public const int ERROR_ADRES = 4;
       
        //public List<KeyValuePair<int, int>> ErrorList; 


        //public bool isReadComplit;

        //private Queue<int> _readQueue  = new Queue<int>();
        //private ComPort _comPort = new ComPort();
       
        //private int _itemCount;
        //private bool _isRead;
        //private double[] _coefficientsLevel;
        //private double[] _coefficientsPressure;
        //private int _waitTimeout;
        
        

        //public void InitItemsData(int itemCount)
        //{
        //    ItemsValue = new DataStruct[itemCount];
        //    for (int i = 0; i < itemCount; i++)
        //    {
        //        ItemsValue[i].level = 0;
        //        ItemsValue[i].pressure = 0;
        //        ItemsValue[i].temper1 = 0;
        //        ItemsValue[i].temper2 = 0;
        //    }
        //    _coefficientsLevel = Properties.Settings.Default.CoefficientsLevel;
        //     _coefficientsPressure = Properties.Settings.Default.CoefficientsPressure;

        //    _currentItem = -1;
        //    isReadComplit = true;
        //    _itemCount = itemCount;
        //    _isRead = true;
            
        //    _comPort.Open(Properties.Settings.Default.Port, Properties.Settings.Default.BaudRate);
        //    _comPort.DataReceived += ComPort_DataReceived;
        //    _comPort.PortClosed += ComPort_PortClosed;

        //    _getDataTimer.Interval = 100;
        //    _getDataTimer.Enabled = true;
        //    _getDataTimer.Tick += GetData;
        //}

        //private void ComPort_PortClosed()
        //{
        //    isReadComplit = true;
        //    _readQueue.Clear();
        //}


        //public void AddScanItems()
        //{
        //    bool[] itemsEnable = Properties.Settings.Default.ItemsEnale;
            
        //}

        ////private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        ////{
        ////    byte[] inBuf = new byte[256];
        ////    int rxCount = _comPort.Read(ref inBuf, 70);
        ////    if (_currentItem < 0) return;
        ////    _isRead = true;

        ////    if (rxCount < 18 || rxCount > 25)
        ////    {
        ////        ErrorList.Add(new KeyValuePair<int, int>(_currentItem, ERROR_COUNT));
        ////        return;
        ////    }
        ////    if (inBuf[1] != 0xFF || inBuf[2] != 0xAA || inBuf[3] != _currentItem)
        ////    {
        ////        ErrorList.Add(new KeyValuePair<int, int>(_currentItem, ERROR_ADRES));
        ////        return;
        ////    }

        ////    double temp;

        ////    temp = BitConverter.ToInt16(inBuf, 4);
        ////    ItemsValue[_currentItem].temper1 = temp/16;

        ////    temp = BitConverter.ToInt16(inBuf, 6);
        ////    ItemsValue[_currentItem].temper2 = temp / 16;

        ////    temp = BitConverter.ToInt32(inBuf, 8);
        ////    ItemsValue[_currentItem].pressure = temp * _coefficientsPressure[_currentItem];

        ////    temp = BitConverter.ToInt32(inBuf, 12);
        ////    ItemsValue[_currentItem].level = temp * _coefficientsLevel[_currentItem];
        ////}

        //private void GetData(object sender, EventArgs e)
        //{
        //    if (_readQueue.Any())
        //    {
        //        if (isReadComplit)
        //        {
        //            _waitTimeout = WaitTimeoutLimit;
        //            _isRead = true;
        //            ErrorList.Clear();
        //        }
        //        isReadComplit = false;
        //        if (!_isRead)
        //        {
        //            if (--_waitTimeout > 0) return;
        //            ErrorList.Add(new KeyValuePair<int, int>(_currentItem, TIME_OUT));
        //        }
        //        _currentItem = _readQueue.Dequeue();

        //        //Отправляем запрос на чтение данных
        //        byte[] outBuf = {0xFF, 0xFF, 1,1, 2, 2 , 0xF1, 0xF1};
        //        outBuf[2] = outBuf[3] = (byte)_currentItem;
        //        if (_comPort.Write(outBuf, 8))
        //        {
        //            _isRead = false;
        //            _waitTimeout = WaitTimeoutLimit;
        //        }
        //    }
        //    else
        //    {
        //        _currentItem = -1;
        //        isReadComplit = true;
        //    }
        //}
    }
}
