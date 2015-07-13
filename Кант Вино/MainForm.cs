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
using SQLite;


namespace Кант_Вино
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private const int ItemCount = 20;
        private ItemControl[] _itemControl = new ItemControl[ItemCount];
        private ItemGraph[] _itemGraph = new ItemGraph[ItemCount];
        private ItemsDataRecived _itemsDataRecived = new ItemsDataRecived();

        private void GetDataInPort()
        {
            
        }


        private void initTabPage()
        {
            mainTabControl.TabPages.Clear();
            mainTabControl.TabPages.Add("0", "Main");
            mainTabControl.TabPages[0].AutoScroll = true;

            for (int i = 0; i < ItemCount; i++)
            {
                //Вкладки
                mainTabControl.TabPages.Add((i + 1).ToString(), "  " + (i + 1).ToString());

                _itemGraph[i] = new ItemGraph(i);
                //_itemGraph[i].SetNumber(i + 1);
                _itemGraph[i].Dock = DockStyle.Fill;
                mainTabControl.TabPages[i + 1].Controls.Add(_itemGraph[i]);


                _itemControl[i] = new ItemControl();

                //по 5 в ряд
                int x = (i%5)*_itemControl[i].Size.Width;
                int y = (i/5)*_itemControl[i].Size.Height;

                _itemControl[i].Location = new Point(x, y);
                _itemControl[i].SetNumber(i + 1);
                _itemControl[i].Tag = i;

                _itemControl[i].ItemClick += itemControl_Click;
                mainTabControl.TabPages[0].Controls.Add(_itemControl[i]);
            }

            pollTimer.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            initTabPage();
            _itemsDataRecived.InitDataRecived(ItemCount);
        }

        private void itemControl_Click(object sender, EventArgs e)
        {
            int i = (int) ((ItemControl) sender).Tag;

            mainTabControl.SelectedIndex = i+1;
        }

        Random rnd = new Random();

        private void pollTimer_Tick(object sender, EventArgs e)
        {
            DateTime curTime = DateTime.Now;
            for (int i = 0; i < ItemCount; i++)
            {
                int temper1 = rnd.Next(-5, 55);
                int temper2 = rnd.Next(-5, 55);
                int pressure = rnd.Next(0, 10);
                int level = rnd.Next(0, 20);

                DataStruct ds = new DataStruct()
                {temper1 = temper1, temper2 = temper2, 
                    pressure = pressure, level = level, 
                    time = curTime};

                _itemControl[i].UpdateItemData(temper1, temper2, pressure, level);
                _itemGraph[i].AddData(ds);
                DBDataLayer.AddData(i,ds);
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm form = new ConfigForm();
            form.ItemCount = ItemCount;
            form.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
