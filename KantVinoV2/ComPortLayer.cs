using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantVinoV2 //end 13_07_2015
{
    class ComPortLayer
    {
        private Timer _readDataTimer = new Timer();
        private ComPort _comPort = new ComPort();

        private int _unitsIndex = 0;
        private UnitData[] _unitsData = new UnitData[ConfigLayer.unitCount];

        private int _waitTime = 0;
        private bool _isWaitData = false;


        public void PortOpen() //Перезагрузка настроек
        {
            _comPort.Open(ConfigLayer.port, ConfigLayer.baudRate);
        }

        public void PortClose()
        {
            _comPort.Close();
        }

        public ComPortLayer()
        {
            _readDataTimer.Interval = 30;
            _readDataTimer.Enabled = false;
            _readDataTimer.Tick += ReadDataTimer_Tick;

            _comPort.DataReceived += ComPort_DataReceived;
             _comPort.PortClosed += ComPort_PortClosed;
        }

        private void ReadDataTimer_Tick(object sender, EventArgs e)
        {
            if (_isWaitData && _waitTime > 3) // 90 - 120 ms
            {
                _unitsData[_unitsIndex].ErrorCode = InputErrors.ERROR_TIMEOUT;
                _isWaitData = false;
                _unitsIndex++;
            }

            if (!_isWaitData && _waitTime > 0) // 0 - 30 ms + Время чтения
            {
                while (_unitsIndex < ConfigLayer.unitCount && 
                    !ConfigLayer.unitsConfig[_unitsIndex].isEnable) _unitsIndex++;
                if (_unitsIndex == ConfigLayer.unitCount)
                {
                    _readDataTimer.Enabled = false;
                    InterviewComplete(true, _unitsData);
                    return;
                }

                /* Запрос данных
                  *  0x55 Address 0x03 0x44 0x00 CRC16(2) 0x2A
                 */
                                                    //'D'
                byte[] outBuf = { 0x55, 0xFF, 0x03, 0x44, 0x00, 0xFF, 0xFF, 0x2A };

                outBuf[1] = (byte)(_unitsIndex + 1);
                _comPort.CRC16_Check(ref outBuf, 1, 1 + 4, true);

                //GetData
                if (_comPort.Write(outBuf, 8))
                {
                    _isWaitData = true;
                    _waitTime = 0;
                }
                return;
            }

            if(_waitTime < int.MaxValue) _waitTime++;
        }



        public bool InterviewAllSensor() //Опрос всех сенсоров
        {
            if (_readDataTimer.Enabled) return false;

            for (int i = 0; i < ConfigLayer.unitCount; i++)
            {
                _unitsData[i] = new UnitData();
            }

            _readDataTimer.Enabled = true;
            _unitsIndex = 0;
            _waitTime = 0;
            _isWaitData = false;

            return true;
        }

        //Опрос завершен
        public delegate void InterviewCompleteEventHandler(bool isPortOK, UnitData[] datas);
        public event InterviewCompleteEventHandler InterviewComplete;

        //Ошибка порта
        private void ComPort_PortClosed()
        {
            _readDataTimer.Enabled = false;
            InterviewComplete(false, _unitsData);
        }


        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] inBuf = new byte[256];
            int rxCount = _comPort.Read(ref inBuf, 10); //Время чтения
            int rxIndex = 0;
            int errorCode = 0;

            if (rxCount < 3 || !_isWaitData) return; //Ошибка чтения


            /* Ответ
             * 0x55 Address 0x83 0x14 Term1(2) Term2(2) Pres1(4) Pres2(4) ErrCode(1) CRC16(2) 0x2A
             *   0      1    2     3    4  5    6  7  8 9 10 11 12 13 14 15  16       17 18    19 
            */

            if (rxCount >= 14) //Данных хватает, начинаем разбор посылки
            {
                for (rxIndex = 0; rxIndex < rxCount - 13; rxIndex++)
                {
                    if (inBuf[rxIndex] == (_unitsIndex + 1) &&  //Адрес
                        (inBuf[rxIndex + 1] & 0x7F) == 0x03 &&  //Код команды
                        inBuf[rxIndex + 2] == 14)               //Количество байт
                    {
                        if (_comPort.CRC16_Check(ref inBuf, rxIndex, rxIndex + inBuf[rxIndex + 2]) == 0) //CRC OK
                        {
                            rxIndex += 3;

                            // Парсим данные
                            double temp;
                            temp = BitConverter.ToInt16(inBuf, rxIndex);
                            _unitsData[_unitsIndex].Term1 = temp / 16;

                            temp = BitConverter.ToInt16(inBuf, rxIndex + 2);
                            _unitsData[_unitsIndex].Term2 = temp / 16;

                            temp = BitConverter.ToUInt16(inBuf, rxIndex + 4);
                            _unitsData[_unitsIndex].Pressure =
                                temp * ConfigLayer.unitsConfig[_unitsIndex].coeffPressure;

                            temp = BitConverter.ToUInt16(inBuf, rxIndex + 6);
                            _unitsData[_unitsIndex].Level =
                                temp * ConfigLayer.unitsConfig[_unitsIndex].coeffLevel;

                            rxIndex += 8;

                            errorCode = (ushort)inBuf[rxIndex];

                            break; //Выходим, чтоб следующие данные не затерли текущие

                        }
                        else
                        {
                            errorCode |= InputErrors.ERROR_CRC;
                        }
                    }
                    else
                    {
                        errorCode |= InputErrors.ERROR_DATA;
                    }
                } 
            }
            else
            {
                errorCode |= InputErrors.ERROR_COUNT;
            }

            _unitsData[_unitsIndex].Index = _unitsIndex;
            _unitsData[_unitsIndex].ErrorCode = errorCode;

            _isWaitData = false;
            _unitsIndex++;
            _waitTime = 0;
        }

        public class InputErrors
        {
            public static int ERROR_COUNT = 1 << 10;
            public static int ERROR_DATA = 1 << 11;
            public static int ERROR_CRC = 1 << 12;
            public static int ERROR_TIMEOUT = 1 << 13;
        }

    }
}
