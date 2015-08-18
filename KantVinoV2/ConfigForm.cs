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

        public ComPortLayer _comPortLayer = null;

        public ConfigForm()
        {
            InitializeComponent();
        }


        public void UpdateConfig()
        {
            for (int i = 0; i < ConfigLayer.unitCount; i++)
            {
                dgvCoefItem.Rows.Add();
                var row = dgvCoefItem.Rows[i];
                row.Cells["Number"].Value = string.Format("{0}",i+1);
                row.Cells["isEnable"].Value = ConfigLayer.unitsConfig[i].isEnable;
                row.Cells["coeffPressure"].Value = ConfigLayer.unitsConfig[i].coeffPressure;
                row.Cells["coeffLevel"].Value = ConfigLayer.unitsConfig[i].coeffLevel;
            }

            //Порт
            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(_comPortLayer.PortNames());
            cmbPort.SelectedItem = ConfigLayer.port;
            cmbBaudRate.Items.Clear();
            cmbBaudRate.Items.AddRange(_comPortLayer.BaudRates());
            cmbBaudRate.SelectedItem = ConfigLayer.baudRate;
            lblPortStatus.Text = string.Format("{0} {1} {2}", ConfigLayer.port, ConfigLayer.baudRate,
                   _comPortLayer.IsOpen() ? "Открыт" : "Закрыт");
            //Бд
            txtDbPath.Text = ConfigLayer.dataBasePath;
            txtTimeSaveCache.Text = ConfigLayer.timeSaveCache.ToString();
            txtBackupPath.Text = ConfigLayer.backupPath;
            txtTimeSaveBackup.Text = ConfigLayer.timeSaveBacup.ToString();
        }

        //Порт
        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPort.SelectedIndex >= 0 && cmbBaudRate.SelectedIndex >= 0)
            {
                ConfigLayer.port = cmbPort.SelectedItem.ToString();
                ConfigLayer.baudRate = cmbBaudRate.SelectedItem.ToString();
                _comPortLayer.PortOpen();
                lblPortStatus.Text = string.Format("{0} {1} {2}", ConfigLayer.port, ConfigLayer.baudRate,
                    _comPortLayer.IsOpen() ? "Открыт" : "Закрыт");
            }

        }

        private void cmbPort_DropDown(object sender, EventArgs e)
        {
            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(_comPortLayer.PortNames());
            cmbPort.SelectedItem = ConfigLayer.port;
        }

        //Бд
        private void btnDbPath_Click(object sender, EventArgs e)
        {

        }

        private void btnBackupPath_Click(object sender, EventArgs e)
        {

        }

        private void btnStartBackup_Click(object sender, EventArgs e)
        {

        }

        private void txtTimeSaveCache_TextEndEdit(object sender, EventArgs e)
        {

        }

        private void txtTimeSaveBackup_TextChanged(object sender, EventArgs e)
        {

        }







        private void ConfigForm_Load(object sender, EventArgs e)
        {

            UpdateConfig();

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
