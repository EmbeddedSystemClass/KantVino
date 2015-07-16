using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantVinoV2
{
    public partial class ConfigForm : Form
    {
        //private ComPort _comPort = new ComPort();
        //private bool _isInit = false;
        //public int ItemCount=20;
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            //cmbBaudRate.Items.Clear();
            //cmbBaudRate.Items.AddRange(_comPort.BaudRates());
            //cmbBaudRate.SelectedItem = Properties.Settings.Default.BaudRate;
            
            //cmbPort.Items.Clear();
            //cmbPort.Items.AddRange(_comPort.PortNames());
            //cmbPort.SelectedItem =  Properties.Settings.Default.Port;

            //lblPortStatus.Text = _comPort.IsOpen()
            //    ? string.Format("Порт {0} открыт", cmbPort.SelectedItem)
            //    : string.Format("Не удалось открыть");
            //_isInit = true;

            //nmrInterval.Value = Properties.Settings.Default.PollingInterval;

            //chkWhoScan.Items.Clear();
            //for (int i = 0; i < ItemCount; i++)
            //{
            //    chkWhoScan.Items.Add((i + 1).ToString(), Properties.Settings.Default.ItemsEnale[i]);
            //}
        }

        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!_isInit) return;
            //_comPort.Open(cmbPort.SelectedItem as string, cmbBaudRate.SelectedItem as string);
            //lblPortStatus.Text = _comPort.IsOpen()
            //    ? string.Format("Порт {0} открыт", cmbPort.SelectedItem)
            //    : string.Format("Не удалось открыть");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (_comPort.IsOpen())
            //{
            //    Properties.Settings.Default.BaudRate = cmbBaudRate.SelectedItem as string;
            //    Properties.Settings.Default.Port = cmbPort.SelectedItem as string;
            //}

            //Properties.Settings.Default.PollingInterval = (int)nmrInterval.Value;

            //bool[] temp = new bool[ItemCount];
           
            //for (int i = 0; i < ItemCount; i++)
            //{
            //    temp[i] = chkWhoScan.CheckedIndices.Contains(i);
            //}
            //Properties.Settings.Default.ItemsEnale = temp;
           
            //Properties.Settings.Default.Save();
            //Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Reload();
            //_comPort.Open(Properties.Settings.Default.Port, Properties.Settings.Default.BaudRate);
            //Close();
        }

        private void txtNumberDevice_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

       
    }
}
