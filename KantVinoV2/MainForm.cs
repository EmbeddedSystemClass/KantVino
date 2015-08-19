using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ZedGraph;

namespace KantVinoV2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        //Контролы
        private ItemControl[] _itemsControl = new ItemControl[ConfigLayer.unitCount];
        private ItemGraph[] _itemsGraph = new ItemGraph[ConfigLayer.unitCount];

        //Слои
        private InterfaceLayer[] _interfaceLayers = new InterfaceLayer[ConfigLayer.unitCount];
        private ComPortLayer _comPortLayer = new ComPortLayer();
        private DataBaseLayer _dataBaseLayer = new DataBaseLayer();

        private void InitInterface()
        {
            for (int i = 0; i < ConfigLayer.unitCount; i++)
            {
                _interfaceLayers[i] = new InterfaceLayer(i);
                
                //бд
                _interfaceLayers[i].LoadDataAtTime += _dataBaseLayer.GetDataAtTime;
                _interfaceLayers[i].LoadLastData += _dataBaseLayer.GetLastData;
                
                //вьюха
                _interfaceLayers[i].InitControl += _itemsControl[i].InitData;
                _interfaceLayers[i].UpdateDataInControl += _itemsControl[i].UpdateData;

                _interfaceLayers[i].UpdateDataInGraph += _itemsGraph[i].UpdateData;
                _interfaceLayers[i].ReloadDataInGraph += _itemsGraph[i].ReloadData;

                _itemsGraph[i].ResumeUpdateGraph += _interfaceLayers[i].ContinueUpdate;
                _itemsGraph[i].PauseUpdateGraph += _interfaceLayers[i].PauseUpdate;
                _itemsGraph[i].ChangeTimeGraph += _interfaceLayers[i].UserChangeTime;

                //порт
                //_interfaceLayers[i].UpdateData();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainStatus.Items.Insert(1, new ToolStripControlHost (rtbStatus));

            _dataBaseLayer.Open();

            InitTabPage();
            InitInterface();

            _comPortLayer.InterviewComplete += ReceiviDataComplete;
            _comPortLayer.PortOpen();

            interviewTimer.Interval = ConfigLayer.timeInterview * 1000;
            interviewTimer.Enabled = true;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dataBaseLayer.Close();
            _comPortLayer.PortClose();
        }

        private class rtfText
        {
            private RichTextBox rtb;

            public rtfText(RichTextBox myRtb)
            {
                rtb = myRtb;
            }

            public void AppendText(Color color, string text)
            {
                int start = rtb.TextLength;
                int len = text.Length;
                rtb.AppendText(text + " ");
                rtb.SelectionStart = start;
                rtb.SelectionLength = len;
                rtb.SelectionColor = color;
                rtb.SelectionLength = 0;
            }
        }


        private void ReceiviDataComplete(bool isPortOK, UnitData[] datas)
        {
            rtbStatus.Text = " ";

            rtfText rtf = new rtfText(rtbStatus);

            if (!isPortOK)
            {
                rtf.AppendText(Color.Red, string.Format("Порт {0} закрыт!", ConfigLayer.port));
                return;
            }

            DateTime curTime = DateTime.Now;

            for (int i = 0; i < ConfigLayer.unitCount; i++)
            {
                if (ConfigLayer.unitsConfig[i].isEnable)
                {
                    datas[i].Time = curTime;
 
                    if ((datas[i].ErrorCode & 0xFF00) == 0)
                    {
                        _dataBaseLayer.AddDataToCache(datas[i]);
                        rtf.AppendText(((datas[i].ErrorCode & 0xFF) == 0) ? Color.Green : Color.Orange, (i + 1).ToString());
                    }
                    else
                    {
                        rtf.AppendText(Color.Red, (i + 1).ToString());
                    }

                    _interfaceLayers[i].UpdateData(datas[i]);
                }
            }

            rtf.AppendText(Color.Gray, string.Format("at {0}", curTime));
        }

        private void InitTabPage()
        {
            mainTabControl.TabPages.Clear();
            mainTabControl.TabPages.Add("0", "Main");
            mainTabControl.TabPages[0].AutoScroll = true;

            for (int i = 0; i < ConfigLayer.unitCount; i++)
            {
                /*** Вкладки **********************************
                ***********************************************/
                mainTabControl.TabPages.Add((i + 1).ToString(), "  " + (i + 1).ToString());

                _itemsGraph[i] = new ItemGraph(i);
                _itemsGraph[i].Dock = DockStyle.Fill;
                mainTabControl.TabPages[i + 1].Controls.Add(_itemsGraph[i]);

                /*** Квадраты на главной ***********************
                ************************************************/
                _itemsControl[i] = new ItemControl(i);
                _itemsControl[i].Tag = i;
                _itemsControl[i].ItemClick += ItemsControl_Click;

                //по 5 в ряд и 1 отступ
                int x = (i % 5) * (_itemsControl[i].Size.Width + 1);
                int y = (i / 5) * (_itemsControl[i].Size.Height + 1);
                _itemsControl[i].Location = new Point(x, y);
                
                mainTabControl.TabPages[0].Controls.Add(_itemsControl[i]);
            }
        }

        // Переключение вкладок
        private void ItemsControl_Click(object sender, EventArgs e)
        {
            int i = (int)((ItemControl)sender).Tag;
            mainTabControl.SelectedIndex = i + 1;
        }

      

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = mainTabControl.SelectedIndex - 1;
            if (i >= 0 && i < ConfigLayer.unitCount)
            {
                _interfaceLayers[i].ContinueUpdate();
            }
        }

        private void interviewTimer_Tick(object sender, EventArgs e)
        {
            _comPortLayer.InterviewAllSensor();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm._comPortLayer = _comPortLayer;
            configForm._dataBaseLayer = _dataBaseLayer;
            if (configForm.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        





















        //Random rnd = new Random();

        //private void pollTimer_Tick(object sender, EventArgs e)
        //{
        //    DateTime curTime = DateTime.Now;
        //    for (int i = 0; i < ItemCount; i++)
        //    {
        //        int temper1 = rnd.Next(-5, 55);
        //        int temper2 = rnd.Next(-5, 55);
        //        int pressure = rnd.Next(0, 10);
        //        int level = rnd.Next(0, 20);

        //        DataStruct ds = new DataStruct()
        //        {temper1 = temper1, temper2 = temper2, 
        //            pressure = pressure, level = level, 
        //            time = curTime};

        //        _itemControl[i].UpdateItemData(temper1, temper2, pressure, level);
        //        _itemGraph[i].AddData(ds);
        //        DBDataLayer.AddData(i,ds);
        //    }
        //}

        //private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ConfigForm form = new ConfigForm();
        //    form.ItemCount = ItemCount;
        //    form.ShowDialog();
        //}

        //private void toolStripMenuItem1_Click(object sender, EventArgs e)
        //{

        //}


        

       
    }
}
