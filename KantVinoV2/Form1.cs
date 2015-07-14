using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace KantVinoV2
{
    public partial class Form1 : Form
    {
        DataBaseLayer dbl = new DataBaseLayer();
        public Form1()
        {
            InitializeComponent();


            ComPortLayer cpl = new ComPortLayer();
            
            
            dbl.Open();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<UnitData> q = new List<UnitData>();
            UnitData c = new UnitData();
            c.Index = 2;
            c.Time = (XDate)DateTime.Now;
            c.Term1 = 50.1;
            c.Term2 = 52.3;
            c.Pressure = 11.2;
            c.Level = 5.54;
            c.ErrorCode = 0;
            q.Add(c);
            dbl.SaveDataList(q);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbl.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDate toDate = DateTime.Now;
            XDate fromDate = toDate;
            fromDate.AddHours(-1);
            List<UnitData> q = new List<UnitData>();
            dbl.GetDataAtTime(fromDate, toDate, 0, out q);

            foreach (var i in q)
            {
                textBox1.AppendText(string.Format("{0} {1} {2}\r\n",i.Id, i.Time, i.Level));
            }
        }
    }
}
