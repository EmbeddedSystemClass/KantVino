﻿using System;
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

        private void MainForm_Load(object sender, EventArgs e)
        {

            InitTabPage();


        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

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
                _itemsControl[i].ItemClick += itemControl_Click;

                //по 5 в ряд и 1 отступ
                int x = (i % 5) * (_itemsControl[i].Size.Width + 1);
                int y = (i / 5) * (_itemsControl[i].Size.Height + 1);
                _itemsControl[i].Location = new Point(x, y);
                
                mainTabControl.TabPages[0].Controls.Add(_itemsControl[i]);
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


        private void itemControl_Click(object sender, EventArgs e)
        {
            int i = (int)((ItemControl)sender).Tag;
            mainTabControl.SelectedIndex = i + 1;
        }

       
    }
}