using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace КантВиноНастройка
{
   
    public partial class ConfigForm : Form
    {
        private ComPort _comPort = new ComPort();
        private int _devaiceAddr = 0;
        private int _lastCommandCode = 0;
        private int _dataTransferCount = 0;
        private int _dataTransferBad = 0;
        private List<PutListClass> _putList = new List<PutListClass>();
        private int _putCount = 0;
        private class PutListClass
        {
            public byte[] outBuf;
            public int count;
            public bool isLast = false;
            public bool isAddr = false;
        }
            

        private int[] _errors = new int[4]{0,0,0,0};

        public ConfigForm()
        {
            InitializeComponent();
        }

        void putPort(byte[] outBuf, int count, bool isLast = false, bool isAddr=false)
        {
            _putList.Add(new PutListClass()
            {outBuf = outBuf, count = count, isLast = isLast, isAddr =isAddr});
            //_comPort.Write()
        }

        private void timer5ms_Tick(object sender, EventArgs e)
        {
            if (_putCount < 3)
            {
                _putCount++;
            }
            else
            {
                if (_putList.Any())
                {
                    var putTemp = _putList[0];
                    _comPort.Write(putTemp.outBuf, putTemp.count);

                    if (putTemp.isAddr)
                    {
                        _devaiceAddr = putTemp.outBuf[4];
                        txtDeviceAddr.Text = _devaiceAddr.ToString();
                    }

                    if (putTemp.isLast)
                    {
                        _lastCommandCode = putTemp.outBuf[3];
                        if (putTemp.outBuf[2] == 0x10) _lastCommandCode |= 0x80;
                    }

                    _putCount = 0;
                    _putList.RemoveAt(0);
                }
            }
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            _comPort.DataReceived += ComPort_DataReceived;

            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(_comPort.PortNames());
            cmbBaudRate.Items.Clear();
            cmbBaudRate.Items.AddRange(_comPort.BaudRates());

            cmbPort.SelectedItem = Properties.Settings.Default.Port;
            cmbBaudRate.SelectedItem = Properties.Settings.Default.BaudRate;

            txtDeviceAddr.Text = Properties.Settings.Default.DeviceAddr.ToString();
            txtNewAddr.Text = txtDeviceAddr.Text;

            chbIsGetData.Checked = Properties.Settings.Default.IsGetData;
            chbIsGetError.Checked = Properties.Settings.Default.IsGetError;

            txtGetDataTime.Text = Properties.Settings.Default.GetDataTime.ToString();
            txtGetErrorTime.Text = Properties.Settings.Default.GetErrorTime.ToString();

            txtCoefPressure.Text = Properties.Settings.Default.CoefPressure.ToString();
            txtCoefLevel.Text = Properties.Settings.Default.CoefLevel.ToString();

            for (int i = 0; i < 8; i++)
            {
                _singleCurves[i] = new SingleCurve();
            }

            LoadGraphSettings();
        }

        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            int p = cmbPort.SelectedIndex;
            int b = cmbBaudRate.SelectedIndex;
            if (p < 0 || b < 0) return;

            string port = cmbPort.Items[p].ToString();
            string baudRate = cmbBaudRate.Items[b].ToString();
            if (string.IsNullOrWhiteSpace(port) || 
                string.IsNullOrWhiteSpace(baudRate)) return;

            _comPort.Open(port, baudRate);
            logAdd(_comPort.IsOpen()
                ? string.Format("Порт {0} открыт", port)
                : string.Format("Не удалось открыть порт"));
        }

        private void btnFindAddr_Click(object sender, EventArgs e)
        {
            if (_devaiceAddr >= 0 && _devaiceAddr < 256 && _comPort.IsOpen())
            {
                byte[] outBuf = new byte[256];
                outBuf[0] = 0x55;
                outBuf[1] = 0xCC;
                outBuf[2] = 0x03;
                outBuf[3] = 0x41;
                outBuf[4] = 0x00;
                _comPort.CRC16_Check(ref outBuf, 1, 1 + 4, true);
                outBuf[7] = 0x2A;

                putPort(outBuf, 8, true);
            }
        }


        private void txtDeviceAddr_TextChanged(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(txtDeviceAddr.Text, out temp) && temp >= 0 && temp < 256)
            {
                _devaiceAddr = temp;
                _dataTransferCount = 0;
                _dataTransferBad = 0;
                logAdd(string.Format("Выбрано {0} устройство", _devaiceAddr));
            }
        }

        private void txtGetDataTime_TextChanged(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(txtGetDataTime.Text, out temp) && temp >= 20 && temp < 6000 * 60 * 60)
            {
                timerGetData.Interval = temp;
                _dataTransferCount = 0;
                _dataTransferBad = 0;
                logAdd(string.Format("Интервал опроса = {0}",temp));
            }
        }

        private void txtGetErrorTime_TextChanged(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(txtGetErrorTime.Text, out temp) && temp >= 20 && temp < 6000 * 60 * 60)
            {
                timerGetError.Interval = temp;
                _dataTransferCount = 0;
                _dataTransferBad = 0;
                logAdd(string.Format("Интервал ошибок = {0}",temp));
            }
        }


        private void btnNewAddr_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(txtNewAddr.Text, out temp) && temp >= 0 && temp < 256)
            {

                if (_devaiceAddr >= 0 && _devaiceAddr < 256 && _comPort.IsOpen())
                {
                    byte[] outBuf = new byte[256];
                    outBuf[0] = 0x55;
                    outBuf[1] = (byte)_devaiceAddr;
                    outBuf[2] = 0x10;
                    outBuf[3] = 0x41;
                    outBuf[4] = (byte)temp;
                    _comPort.CRC16_Check(ref outBuf, 1, 1 + 4, true);
                    outBuf[7] = 0x2A;

                    putPort(outBuf,8,true, true);
                }

            }

        }


        private void timerGetData_Tick(object sender, EventArgs e)
        {
            if (_devaiceAddr >= 0 && _devaiceAddr < 256 && _comPort.IsOpen() && chbIsGetData.Checked)
            {
                byte[] outBuf = new byte[256];
                outBuf[0] = 0x55;
                outBuf[1] = (byte)_devaiceAddr;
                outBuf[2] = 0x03;
                outBuf[3] = 0x44;
                outBuf[4] = 0x00;
                _comPort.CRC16_Check(ref outBuf, 1, 1 + 4, true);
                outBuf[7] = 0x2A;

                putPort(outBuf, 8);
                _dataTransferCount++;
            }
        }

        private void timerGetError_Tick(object sender, EventArgs e)
        {
            if (_devaiceAddr >= 0 && _devaiceAddr < 256 && _comPort.IsOpen() && chbIsGetError.Checked)
            {
                byte[] outBuf = new byte[256];
                outBuf[0] = 0x55;
                outBuf[1] = (byte)_devaiceAddr;
                outBuf[2] = 0x03;
                outBuf[3] = 0x45;
                outBuf[4] = 0x00;
                _comPort.CRC16_Check(ref outBuf, 1, 1 + 4, true);
                outBuf[7] = 0x2A;

                putPort(outBuf,8);
                _dataTransferCount++;

                for (int i = 0; i < 2; i++)
                {
                    _errors[i] = 0;
                }
            }
        }



        private const int DEVICE_NOT_FOUND = 3;
        private const int ERROR_CRC = 1;
        private const int ERROR0 = 1;
        private const int ERROR1 = 3;


        private void AddVal(UnitData val)
        {
            int errCode = val.ErrorCode;

            double cpres, clev;
            if (double.TryParse(txtCoefPressure.Text, out cpres) &&
                double.TryParse(txtCoefLevel.Text, out clev))
            {
                val.Pressure *= cpres;
                val.Level *= clev;
            }

            lblT1.Text = string.Format("Т1 = {0}", val.Term1);
            lblT2.Text = string.Format("Т2 = {0}", val.Term2);
            lblD1.Text = string.Format("Дав = {0}", val.Pressure);
            lblD2.Text = string.Format("Ур = {0}", val.Level);
            lblTransferError.Text = string.Format("Пакетов потеряно = {0}", _dataTransferCount);
            lblBadPacket.Text = string.Format("Пакетов битых = {0}", _dataTransferBad);

            DateTime time = DateTime.Now;

            if ((errCode & 3) == 0)
            {
                _singleCurves[0].UpdateData(val.Term1, time);
            }

            if ((errCode & (3<<2)) == 0)
            {
                _singleCurves[1].UpdateData(val.Term2, time);
            }

            if ((errCode & (3<<4)) == 0)
            {
                _singleCurves[2].UpdateData(val.Pressure/10, time);
            }

            if ((errCode & (3 << 6)) == 0)
            {
                _singleCurves[3].UpdateData(val.Level/10, time);
            }

            UpdateAsis(time.AddSeconds(-60), time);

            switch (errCode & 3)
            {
                case DEVICE_NOT_FOUND:
                    lblT1.Text = string.Format("Т1 = Датчик не найден");
                    break;
                case ERROR_CRC:
                    lblT1.Text = string.Format("Т1 = Ошибка CRC");
                    break;
                default:

                    break;
            }
            errCode >>= 2;
            switch (errCode & 3)
            {
                case DEVICE_NOT_FOUND:
                    lblT2.Text = string.Format("Т2 = Датчик не найден");
                    break;
                case ERROR_CRC:
                    lblT2.Text = string.Format("Т2 = Ошибка CRC");
                    break;
                default:

                    break;
            }

            errCode >>= 2;
            switch (errCode & 3)
            {
                case ERROR0:
                    lblD1.Text = string.Format("Дав = Ошибка 0");
                    break;
                case ERROR1:
                    lblD1.Text = string.Format("Дав = Ошибка 1");
                    break;
                default:

                    break;
            }

            errCode >>= 2;
            switch (errCode & 3)
            {
                case ERROR0:
                    lblD2.Text = string.Format("Ур = Ошибка 0");
                    break;
                case ERROR1:
                    lblD2.Text = string.Format("Ур = Ошибка 1");
                    break;
                default:

                    break;
            }
        }



        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] inBuf = new byte[256];
            int rxCount = _comPort.Read(ref inBuf, 5); //Время чтения
            int rxIndex = 0;
            bool isBad = true;

            if (rxCount < 3) return; //Ошибка чтения

            if (chbIsVisiblePacket.Checked)
            {
                string tmpstr = "";
                for (rxIndex = 0; rxIndex < rxCount; rxIndex++)
                {
                    tmpstr += string.Format("{0:X2} ", inBuf[rxIndex]);
                }
                logAdd("[ " + tmpstr + " ]");
            }


            if (rxCount >= 6) //Данных хватает, начинаем разбор посылки
            {
                for (rxIndex = 0; rxIndex < rxCount - 5; rxIndex++)
                {
                    if ((inBuf[rxIndex] == _devaiceAddr || _lastCommandCode == 0x41) && //Адрес
                        (inBuf[rxIndex + 1] == 0x03 || inBuf[rxIndex + 1] == 0x10 //Код команды
                         || inBuf[rxIndex + 1] == 0x83) &&
                        (inBuf[rxIndex + 2] == 14 || inBuf[rxIndex + 2] == 19
                        || inBuf[rxIndex + 2] == 6)) //Количество байт 
                    {
                        if (_comPort.CRC16_Check(ref inBuf, rxIndex, rxIndex + inBuf[rxIndex + 2]) == 0) //CRC OK
                        {
                           
                            switch (inBuf[rxIndex + 2])
                            {
                                case 6:
                                    switch (_lastCommandCode)
                                    {
                                        case 0x41:  //Get Addr
                                            logAdd(string.Format("Адрес получен {0}", inBuf[rxIndex + 3]));
                                            _devaiceAddr = inBuf[rxIndex + 3];
                                            txtDeviceAddr.Text = _devaiceAddr.ToString();
                                            isBad = false;
                                            break;
                                        case (0x41|0x80): //Set Addr
                                            logAdd("Адрес изменен");
                                            isBad = false;
                                            break;
                                        case (0x4F|0x80): //Set Out
                                            logAdd("Состояние выходов");
                                            isBad = false;
                                            break;
                                    }
                                    _lastCommandCode = 0;
                                    break;

                                case 14: //Данные
                                    _dataTransferCount--;
                                    isBad = false;
                                     

                            // Парсим данные
                                    double temp;
                            UnitData curVal = new UnitData();

                            rxIndex += 3;
                            temp = BitConverter.ToInt16(inBuf, rxIndex);
                            curVal.Term1 = temp / 16;

                            temp = BitConverter.ToInt16(inBuf, rxIndex + 2);
                            curVal.Term2 = temp / 16;

                            temp = BitConverter.ToUInt16(inBuf, rxIndex + 4);
                            curVal.Pressure = temp;

                            temp = BitConverter.ToUInt16(inBuf, rxIndex + 6);
                            curVal.Level = temp;
                               
                            rxIndex += 8;
                            curVal.ErrorCode = inBuf[rxIndex];
                            rxIndex -= 11;

                                    AddVal(curVal);


                                    break;
                                    
                                case 19: //Ошибки

                                    _dataTransferCount--;
                                    isBad = false;

                                    rxIndex += 3;
                                    int upTime = BitConverter.ToInt32(inBuf, rxIndex);

                                    this.Text = string.Format("Настройка (UpTime = {0}:{1:00}:{2:00}.{3})", upTime / 60 / 60 / 10, (upTime / 60 / 10) % 60, (upTime / 10) % 60, upTime%10);
                                    rxIndex += 4;
                                    DateTime time = DateTime.Now;
                                    for (int i = 0; i < 4; i++)
                                    {
                                        _errors[i] += inBuf[rxIndex + i];
                                        _errors[i] += inBuf[rxIndex + i + 4];
                                        _singleCurves[i+4].UpdateData(_errors[i], time);
                                    }



                                     rxIndex -= 7;
                                    break;
                                    
                            }

                            rxIndex += inBuf[rxIndex + 2];
                        }
                    }
                }
            }

            if (isBad) _dataTransferBad++;
        }

        private void logAdd(string text)
        {
            txtLog.AppendText(
                string.Format("{1:00}:{2:00}=> {0}\r\n", text,
                DateTime.Now.Minute, DateTime.Now.Second));
        }

       
       
        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_comPort.IsOpen())
            {
                Properties.Settings.Default.Port = cmbPort.Items[cmbPort.SelectedIndex].ToString();
                Properties.Settings.Default.BaudRate = cmbBaudRate.Items[cmbBaudRate.SelectedIndex].ToString();
            }
            if (_devaiceAddr >= 0 && _devaiceAddr < 256)
            {
                Properties.Settings.Default.DeviceAddr = _devaiceAddr;
            }

            Properties.Settings.Default.IsGetData = chbIsGetData.Checked;
            Properties.Settings.Default.IsGetError = chbIsGetError.Checked;
            Properties.Settings.Default.GetDataTime = timerGetData.Interval;
            Properties.Settings.Default.GetErrorTime = timerGetError.Interval;

            double cpres, clev;
            if (double.TryParse(txtCoefPressure.Text, out cpres) &&
                double.TryParse(txtCoefLevel.Text, out clev))
            {
                Properties.Settings.Default.CoefPressure  = cpres;
                Properties.Settings.Default.CoefLevel = clev;
            }

            Properties.Settings.Default.Save();
        }


        private void LoadGraphSettings()
        {
            zGraph.EditButtons = MouseButtons.None;
            zGraph.LinkButtons = MouseButtons.None;
            zGraph.SelectButtons = MouseButtons.None;
            //Кнопка таскания
            // zGraph.PanButtons = MouseButtons.None;
            zGraph.PanModifierKeys = Keys.None;
            zGraph.PanButtons2 = MouseButtons.None;
            //Кнопка зума выделенного прямоугольника
            zGraph.ZoomButtons = MouseButtons.None;
            zGraph.ZoomButtons2 = MouseButtons.None;

            GraphPane pane = zGraph.GraphPane;

            // Отключаем заголовок
            pane.Title.IsVisible = false;

            // Отключаем имя осям
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;

            // Не рисовать линию нуля
            pane.YAxis.MajorGrid.IsZeroLine = false;

            // С помощью этого свойства указываем, что шрифты не надо масштабировать
            // при изменении размера компонента.
            pane.IsFontsScaled = false;

            // Установим размеры шрифтов для меток вдоль осей
            pane.XAxis.Scale.FontSpec.Size = 12;
            pane.YAxis.Scale.FontSpec.Size = 12;

            // Установим размеры шрифтов для подписей по осям
            pane.XAxis.Title.FontSpec.Size = 10;
            pane.YAxis.Title.FontSpec.Size = 10;

            // Установим размеры шрифта для легенды
            pane.Legend.FontSpec.Size = 12;

            // Установим размеры шрифта для заголовка
            pane.Title.FontSpec.Size = 12;


            // Для оси X установим календарный тип
            pane.XAxis.Type = AxisType.Date;

            // Установим значение параметра IsBoundedRanges как true.
            // Это означает, что при автоматическом подборе масштаба 
            // нужно учитывать только видимый интервал графика
            pane.IsBoundedRanges = true;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();


            // Включаем отображение сетки напротив крупных рисок по оси X
            pane.XAxis.MajorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси X:
            // Длина штрихов равна 10 пикселям, ... 
            pane.XAxis.MajorGrid.DashOn = 10;

            // затем 5 пикселей - пропуск
            pane.XAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;


            // Включаем отображение сетки напротив мелких рисок по оси X
            pane.YAxis.MinorGrid.IsVisible = true;

            // Задаем вид пунктирной линии для крупных рисок по оси Y: 
            // Длина штрихов равна одному пикселю, ... 
            pane.YAxis.MinorGrid.DashOn = 1;

            // затем 2 пикселя - пропуск
            pane.YAxis.MinorGrid.DashOff = 2;

            // Включаем отображение сетки напротив мелких рисок по оси Y
            pane.XAxis.MinorGrid.IsVisible = true;

            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            

            // Свойства IsSynchronizeXAxes и IsSynchronizeYAxes указывают, что
            // оси на графиках должны перемещаться и масштабироваться одновременно.
            zGraph.IsSynchronizeXAxes = true;
            //zGraph.IsSynchronizeYAxes = true;

            // Отключаем масштабирование по вертикали
            zGraph.IsEnableVZoom = false;


            int i = 0;
           

            i = 0;
            _singleCurves[i].AddCurve(pane,"T1", "C", Color.DarkGreen,SymbolType.Plus, 500);
            i = 1;
            _singleCurves[i].AddCurve(pane, "T2", "C", Color.ForestGreen, SymbolType.Star, 500);
            i = 2;
            _singleCurves[i].AddCurve(pane, "Дав", "P", Color.DarkBlue, SymbolType.Plus, 500);
            i = 3;
            _singleCurves[i].AddCurve(pane, "Ур", "P", Color.MediumBlue, SymbolType.Star, 500);

            i = 4;
            _singleCurves[i].AddCurve(pane, "Not found", "", Color.DarkMagenta, SymbolType.None, 500);
            i = 5;
            _singleCurves[i].AddCurve(pane, "Err CrC", "", Color.Red, SymbolType.None, 500);
            i = 6;
            _singleCurves[i].AddCurve(pane, "Not convert", "", Color.DarkRed, SymbolType.None, 500);
            i = 7;
            _singleCurves[i].AddCurve(pane, "Config Err", "", Color.Black, SymbolType.None, 500);
        }

        private void UpdateAsis(DateTime beginTime, DateTime endTime)
        {
           
            
                //Устанавливаем интересующий нас интервал по оси Y
                zGraph.GraphPane.YAxis.Scale.Min = 0;
                zGraph.GraphPane.YAxis.Scale.Max = 100;
                //По оси Y установим автоматический подбор масштаба
                zGraph.GraphPane.YAxis.Scale.MinAuto = false;
                zGraph.GraphPane.YAxis.Scale.MaxAuto = true;
                //Устанавливаем время по X
                zGraph.GraphPane.XAxis.Scale.Min = (XDate)beginTime;
                zGraph.GraphPane.XAxis.Scale.Max = (XDate)endTime;
            

            zGraph.AxisChange();
            zGraph.Invalidate();
        }

        private SingleCurve[] _singleCurves = new SingleCurve[8];

        private void chbIsGetData_CheckedChanged(object sender, EventArgs e)
        {
            _dataTransferCount = 0;
        }

       
       

    }


    public class SingleCurve
    {

        private RollingPointPairList _dataPointList = null;
        private LineItem _myCurve = null; 
        public void AddCurve(GraphPane pane, string name, string measure, Color color, SymbolType sType, int capacity)
        {
            _dataPointList = new RollingPointPairList(capacity);

            // Добавим кривую пока еще без каких-либо точек
            _myCurve = pane.AddCurve(string.Format("{0} ({1})", name, measure), _dataPointList, color, sType);
        }

        //Добавление даннх
        public void UpdateData(double data, DateTime time)
        {
            if (_dataPointList == null) return;
            _dataPointList.Add((XDate)time, data);
        }

    }



    public class UnitData
    {

        public int Id { get; set; }


        public DateTime Time { get; set; }

        public int Index { get; set; }

        public double Term1 { get; set; }
        public double Term2 { get; set; }
        public double Pressure { get; set; }
        public double Level { get; set; }


        public int ErrorCode { get; set; }

        public double GetValue(int i)
        {
            switch (i)
            {
                case 0:
                    return Term1;
                case 1:
                    return Term2;
                case 2:
                    return Pressure;
                case 3:
                    return Level;
                default:
                    return double.NaN;
            }
        }
    }

}
