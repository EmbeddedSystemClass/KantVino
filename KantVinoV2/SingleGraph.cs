using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZedGraph;

namespace KantVinoV2
{
    internal class SingleGraph
    {
        private RollingPointPairList _dataPointList = null;
        private LineItem _myCurve = null; 

        public void InitPane(GraphPane pane, string title = "", string xTitle = "", string yTitle = "")
        {
            // Отключаем заголовок
            pane.Title.IsVisible = false;
            pane.Title.Text = title;
            // Отключаем имя осям
            pane.XAxis.Title.IsVisible = false;
            pane.XAxis.Title.Text = xTitle;
            pane.YAxis.Title.IsVisible = false;
            pane.YAxis.Title.Text = yTitle;

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
        }

        public void AddCurve(GraphPane pane, string name, string measure, Color color, SymbolType sType, int capacity)
        {
            _dataPointList = new RollingPointPairList(capacity);

            // Добавим кривую пока еще без каких-либо точек
            _myCurve = pane.AddCurve(string.Format("{0} ({1})",name,measure), _dataPointList, color, sType);
        }

        //Загрузка массива данных
        public void ReloadData(IEnumerable<UnitData> pointList, int i) 
        {
            if (_dataPointList == null) return;
            _dataPointList.Clear();
            foreach (UnitData point in pointList)
            {
                _dataPointList.Add((XDate)point.Time, point.GetValue(i));
            }
        }

        //Добавление даннх
        public void UpdateData(double data, DateTime time)
        {
            if (_dataPointList == null) return;
            _dataPointList.Add((XDate)time, data);
        }
    }
}
