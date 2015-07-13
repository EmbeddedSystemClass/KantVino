using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Кант_Вино
{
    public class GraphTemp
    {
        private ZedGraphControl _gControl = null;
        private RollingPointPairList _dataPointList = null;

        private int _visibleSeconds = 0;
        private bool _isUpdateAxis = false;
        private bool _isUpdateData = false;
        private bool _isUpdateMain = false;
        //private delegate void UpdateAxisEventHandler();
        //private event UpdateAxisEventHandler GraphUpdateAxis;  


        public GraphTemp(ZedGraphControl gControl)
        {
            _gControl = gControl;
        }

        public void GraphName(string title = "", string xTitle = "", string yTitle = "")
        {
            GraphPane pane = _gControl.GraphPane;

            _gControl.EditButtons = MouseButtons.None;
            _gControl.LinkButtons = MouseButtons.None;
            _gControl.SelectButtons = MouseButtons.None;
            //Кнопка таскания
            // zgControl.PanButtons = MouseButtons.None;
            _gControl.PanModifierKeys = Keys.None;
            _gControl.PanButtons2 = MouseButtons.None;
            //Кнопка зума выделенного прямоугольника
            _gControl.ZoomButtons = MouseButtons.None;
            _gControl.ZoomButtons2 = MouseButtons.None;


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


            _gControl.ZoomEvent += Graph_ZoomEvent;
            _gControl.ScrollEvent += Graph_ScrollEvent;
            _isUpdateMain = true;
        }

        public void AddCurve(string name, Color color, int capacity = 8192)
        {
            _dataPointList = new RollingPointPairList(capacity);

            GraphPane pane = _gControl.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            // Добавим кривую пока еще без каких-либо точек
            pane.AddCurve(name, _dataPointList, color, SymbolType.None);
        }



        public void ReloadData() //Загрузка массива данных
        {
            _isUpdateData = false;
            _isUpdateAxis = false;
        }


        public void UpdateData() //Добавление даннх
        {
            if (!_isUpdateData) return;
        }

        private void UpdateAxis() //Обновление осей
        {
            if (!(_isUpdateMain && _isUpdateAxis)) return;

        }

        private void UpdateContinue() //Возобновление обновления данных
        {
            _isUpdateData = true;
            _isUpdateAxis = true;
        }


        private void Graph_ScrollEvent(object sender, ScrollEventArgs e)
        {
            _isUpdateAxis = false;
        }

        private void Graph_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            _isUpdateAxis = false;
        }

    }
}
