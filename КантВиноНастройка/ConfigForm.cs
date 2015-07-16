using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КантВиноНастройка
{
    public partial class ConfigForm : Form
    {
        private ComPort _comPort = new ComPort();
        private int _devaiceAddr = 0;

        public ConfigForm()
        {
            InitializeComponent();
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

            chbIsGetData.Checked = true;
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
                ? string.Format("Порт {0} открыт\r\n", port)
                : string.Format("Не удалось открыть порт\r\n"));
        }

        private void txtDeviceAddr_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtDeviceAddr.Text, out _devaiceAddr))
            {
                logAdd(string.Format("Выбрано {0} устройство", _devaiceAddr));
            }
        }

        private const int DEVICE_NOT_FOUND = 3;
        private const int ERROR_CRC = 1;
        private const int ERROR0 = 1;
        private const int ERROR1 = 3;


        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] inBuf = new byte[256];
            int rxCount = _comPort.Read(ref inBuf, 10);
            if (rxCount < 2) return;


            string text = "Принято: ";
            for (int i = 0; i < rxCount; i++)
            {
                text += string.Format("0x{0:X} ", inBuf[i]);
            }
            logAdd(text);


            if (inBuf[1] != _devaiceAddr || (inBuf[2] & 0x7F) != 0x03 || inBuf[3] != 20)
            {
                return;
            }

            double temp;

            temp = BitConverter.ToInt16(inBuf, 4);
            lblT1.Text = string.Format("Температура1 = {0} С", temp/16);

            temp = BitConverter.ToInt16(inBuf, 6);
            lblT2.Text = string.Format("Температура2 = {0} С", temp/16);

            temp = BitConverter.ToInt32(inBuf, 8);
            lblD1.Text = string.Format("Давление = {0}", temp);

            temp = BitConverter.ToInt32(inBuf, 12);
            lblD2.Text = string.Format("Уровень = {0}", temp);

            if (inBuf[2] == 0x83)
            {
                int errCode = inBuf[16];
                switch (errCode & 3)
                {
                    case DEVICE_NOT_FOUND:
                        lblT1.Text = string.Format("Температура1 = Датчик не найден");
                        break;
                    case ERROR_CRC:
                        lblT1.Text = string.Format("Температура1 = Ошибка CRC");
                        break;
                    default:
                        
                        break;
                }
                errCode >>= 2;
                switch (errCode & 3)
                {
                    case DEVICE_NOT_FOUND:
                        lblT2.Text = string.Format("Температура2 = Датчик не найден");
                        break;
                    case ERROR_CRC:
                        lblT2.Text = string.Format("Температура2 = Ошибка CRC");
                        break;
                    default:
                       
                        break;
                }

                errCode >>= 2;
                switch (errCode & 3)
                {
                    case ERROR0:
                        lblD1.Text = string.Format("Давление = Ошибка 0");
                        break;
                    case ERROR1:
                        lblD1.Text = string.Format("Давление = Ошибка 1");
                        break;
                    default:
                       
                        break;
                }

                errCode >>= 2;
                switch (errCode & 3)
                {
                    case ERROR0:
                        lblD2.Text = string.Format("Уровень = Ошибка 0");
                        break;
                    case ERROR1:
                        lblD2.Text = string.Format("Уровень = Ошибка 1");
                        break;
                    default:
                        
                        break;
                }
            }

        }

        private void timer900ms_Tick(object sender, EventArgs e)
        {
            if (_devaiceAddr >= 0 && _devaiceAddr < 256 && _comPort.IsOpen() &&chbIsGetData.Checked)
            {
                byte[] outBuf = new byte[256];
                outBuf[0] = 0x55;
                outBuf[1] = (byte)_devaiceAddr;
                outBuf[2] = 0x03;
                outBuf[3] = 0x44;
                outBuf[4] = 0x00;
                CRC16_all(ref outBuf, 1, 5);
                CRC16_all(ref outBuf, 1, 7);
                outBuf[7] = 0x2A;
                _comPort.Write(outBuf, 8);
               
            }
        }


        private void logAdd(string text)
        {
            txtLog.AppendText(
                string.Format("{1}:{2}=> {0}\r\n", text,
                DateTime.Now.Minute, DateTime.Now.Second));
        }

        private int CRC16_all(ref byte[] p, int i, int n)
        {
            int j;
            int crc_hi;
            int crc_lo;
            crc_hi = 0xFF; // high byte of CRC initialized  
            crc_lo = 0xFF; // low byte of CRC initialized

            for (; i < n; i++)
            {
                j = crc_hi ^ p[i]; // will index into CRC lookup table
                crc_hi = crc_lo ^ auchCRCHi[j]; // calculate the CRC
                crc_lo = auchCRCLo[j];
            }
            p[i++] = (byte) crc_hi;
            p[i++] = (byte) crc_lo;

            return (crc_hi << 8) | crc_lo;
        }

        private int[] auchCRCHi = new int[256]
        {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40
        };

        private int[] auchCRCLo = new int[256]
        {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4,
            0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
            0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD,
            0x1D, 0x1C, 0xDC, 0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7,
            0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
            0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE,
            0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2,
            0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
            0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB,
            0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 0x50, 0x90, 0x91,
            0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
            0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88,
            0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80,
            0x40
        };

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

            Properties.Settings.Default.Save();
        }

        private void btnNewAddr_Click(object sender, EventArgs e)
        {
            int temp=0;
            if (int.TryParse(txtNewAddr.Text, out temp) && temp>=0 && temp <256)
            {

                if (_devaiceAddr >= 0 && _devaiceAddr < 256 && _comPort.IsOpen())
                {
                    byte[] outBuf = new byte[256];
                    outBuf[0] = 0x55;
                    outBuf[1] = (byte)_devaiceAddr;
                    outBuf[2] = 0x10;
                    outBuf[3] = 0x41;
                    outBuf[4] = (byte)temp;
                    CRC16_all(ref outBuf, 1, 5);
                    outBuf[7] = 0x2A;
                    _comPort.Write(outBuf, 8);


                    txtDeviceAddr.Text = temp.ToString();
                    _devaiceAddr = temp;
                }
                
            }

        }

    }
}
