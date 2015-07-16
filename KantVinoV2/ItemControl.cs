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

            lblNumber.Text = string.Format("№ {0}", _itemIndex+1);
            //Событие клика генерируем при клике любого элемента
            foreach (Control control in this.Controls)
            {
                control.Click += ItemControl_Click;
            }

            InitData(false);
        }

        private string DataFormatStr(int errCode, bool isADC, string formatStr, double val)
        {
            if (isADC)
            {
                switch (errCode & 0x03)
                {
                    case 1:
                        return "Датчика нет!";
                    case 2:
                        return "?";
                    case 3:
                        return "Датчика нет!";
                }
            }
            else
            {
                switch (errCode & 0x03)
                {
                    case 1:
                        return "Ошибка CRC";
                    case 2:
                        return "?";
                    case 3:
                        return "Датчика нет!";
                }
            }
            return string.Format(formatStr, val);
        }

        public void UpdateData(UnitData data)
        {
            var measure = ConfigLayer.singleGraphConfigs;
            lblTemper1.Text = DataFormatStr(data.ErrorCode >> 0, false, 
                "{0} "+ measure[0].curveMeasure, data.Term1);
            lblTemper2.Text = DataFormatStr(data.ErrorCode >> 2, false, 
                "{0} " + measure[1].curveMeasure, data.Term2);
            lblPressure.Text = DataFormatStr(data.ErrorCode >> 4, true, 
                "{0} "+ measure[2].curveMeasure, data.Pressure);
            lblLevel.Text = DataFormatStr(data.ErrorCode >> 6, true, 
                "{0} "+ measure[3].curveMeasure, data.Level);  
        }

        public void InitData(bool isError)
        {
            string text = (isError) ? "Err":"NaN";
            lblTemper1.Text = text;
            lblTemper2.Text = text;
            lblPressure.Text = text;
            lblLevel.Text = text;
        }
    }
}
