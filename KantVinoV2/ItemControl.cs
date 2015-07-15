using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantVinoV2
{
    public partial class ItemControl : UserControl
    {
         private int _itemIndex = 0;

         public event EventHandler ItemClick;
         private void ItemControl_Click(object sender, EventArgs e)
         {
             ItemClick(this, e);
         }

        public ItemControl(int itemIndex)
        {
            _itemIndex = itemIndex;
            InitializeComponent();

            lblNumber.Text = string.Format("№ {0}", _itemIndex);
            //Событие клика генерируем при клике любого элемента
            foreach (Control control in this.Controls)
            {
                control.Click += ItemControl_Click;
            }
        }

        
        public void UpdateItemData(double temper1, double temper2, double pressure, double level)
        {
            lblTemper1.Text = string.Format("{0} °C", temper1);
            lblTemper2.Text = string.Format("{0} °C", temper2);
            lblPressure.Text = string.Format("{0} атм", pressure);
            lblLevel.Text = string.Format("{0} м", level);
        }
    }
}
