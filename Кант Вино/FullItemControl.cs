using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Кант_Вино
{
    public partial class FullItemControl : UserControl
    {
        private string _itemName;

        /// <summary>
        /// Количество отображаемых точек
        /// </summary>
        private const int Capacity = 10000;

        /// <summary>
        /// Здесь храним данные
        /// </summary>
        private RollingPointPairList _dataTemper1;
        private RollingPointPairList _dataTemper2;
        private RollingPointPairList _dataPressure;
        private RollingPointPairList _dataLevel;


        private bool _isUpdateAxis = false;

        public FullItemControl()
        {
            InitializeComponent();
            // !!! Создаем массив данных с ограниченной емкостью.
            // При превышениизаданной емкости первые элементы в массиве будут удаляться
            _dataTemper1 = new RollingPointPairList(Capacity);
            _dataTemper2 = new RollingPointPairList(Capacity);
            _dataPressure = new RollingPointPairList(Capacity);
            _dataLevel = new RollingPointPairList(Capacity);
        }

        private void FullItemControl_Load(object sender, EventArgs e)
        {
            

        }

        public void SetNumber(int number)
        {
            _itemName = string.Format(" № {0}", number);
            PrepareTemperatureGraph();
            PrepareLevelGraph();
            PreparePressureGraph();
        }

        public void AddItemData(double temper1, double temper2, double pressure, double level, DateTime curTime)
        {
            _dataTemper1.Add((XDate)curTime, temper1);
            _dataTemper2.Add((XDate)curTime, temper2);
            _dataPressure.Add((XDate)curTime, pressure);
            _dataLevel.Add((XDate)curTime, level);

            // Рассчитаем интервал по оси X, который нужно отобразить на графике
            XDate xmin = curTime;
            xmin.AddSeconds(-100); //Последние 100 секунд
            XDate xmax = curTime;

            if(_isUpdateAxis) UpdateGraph(temperatureGraph, xmin, xmax);
            UpdateGraph(pressureGraph, xmin, xmax);
            UpdateGraph(levelGraph, xmin, xmax);
        }

        private void UpdateGraph(ZedGraphControl zgControl, XDate xmin, XDate xmax, double ymin = 0, double ymax = 0, bool isyauto = true)
        {
            GraphPane pane = zgControl.GraphPane;

            //Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.Min = xmin;
            pane.XAxis.Scale.Max = xmax;

            //Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.Min = ymin;
            pane.YAxis.Scale.Max = ymax;
            // По оси Y установим автоматический подбор масштаба
            pane.YAxis.Scale.MinAuto = isyauto;
            pane.YAxis.Scale.MaxAuto = isyauto;

            // Обновим оси
            zgControl.AxisChange();

            // Обновим сам график
            zgControl.Invalidate();
        }

        private GraphPane PrepareGraph(ZedGraphControl zgControl)
        {
            // pressureGraph.MouseMoveEvent += Graph_MouseMoveEvent;
            // Включим показ всплывающих подсказок при наведении курсора на график
            //pressureGraph.IsShowPointValues = true;

            // Будем обрабатывать событие PointValueEvent, чтобы изменить формат представления координат
            // pressureGraph.PointValueEvent +=
            //  new ZedGraphControl.PointValueHandler(zedGraph_PointValueEvent);


            zgControl.EditButtons = MouseButtons.None;
            zgControl.LinkButtons = MouseButtons.None;
            zgControl.SelectButtons = MouseButtons.None;
            //Кнопка таскания
            // zgControl.PanButtons = MouseButtons.None;
            zgControl.PanModifierKeys = Keys.None;
            zgControl.PanButtons2 = MouseButtons.None;
            //Кнопка зума выделенного прямоугольника
            zgControl.ZoomButtons = MouseButtons.None;
            zgControl.ZoomButtons2 = MouseButtons.None;


            GraphPane pane = zgControl.GraphPane;

            // Отключаем заголовок
            pane.Title.IsVisible = false;

            // Не рисовать линию нуля
            pane.YAxis.MajorGrid.IsZeroLine = false;

            // Отключаем имя осям
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;

            // Для оси X установим календарный тип
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Title.Text = "Время";

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

            // Установим значение параметра IsBoundedRanges как true.
            // Это означает, что при автоматическом подборе масштаба 
            // нужно учитывать только видимый интервал графика
            pane.IsBoundedRanges = true;

            return pane;
        }

       

        private void PrepareLevelGraph()
        {
            // Инициализируем общие свойства графиков
            GraphPane pane = PrepareGraph(levelGraph);

            // Заголовок
            pane.Title.Text = "График уровня акратофора" + _itemName;

            pane.YAxis.Title.Text = "Уровень (м)";

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            // Добавим кривую пока еще без каких-либо точек

            

            pane.AddCurve("Уровень (м)", _dataLevel, Color.Blue, SymbolType.None);
        }

        private void PreparePressureGraph()
        {
            // Инициализируем общие свойства графиков
            GraphPane pane = PrepareGraph(pressureGraph);

            // Заголовок
            pane.Title.Text = "График давления акратофора" + _itemName;

            pane.YAxis.Title.Text = "Давление (атм)";

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            // Добавим кривую пока еще без каких-либо точек
            pane.AddCurve("Давление (атм)", _dataPressure, Color.Blue, SymbolType.None);

        }

        private void PrepareTemperatureGraph() 
        {
            // Инициализируем общие свойства графиков
            GraphPane pane = PrepareGraph(temperatureGraph); ;

            // Заголовок
            pane.Title.Text = "График температуры акратофора" + _itemName;
           
            pane.YAxis.Title.Text = "Температура (°C)";

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            // Добавим кривую пока еще без каких-либо точек
            pane.AddCurve("Температура 1 (°C)", _dataTemper1, Color.Blue, SymbolType.None);
            pane.AddCurve("Температура 2 (°C)", _dataTemper2, Color.Red, SymbolType.None);

            
           
        }

        private void temperatureGraph_ScrollEvent(object sender, ScrollEventArgs e)
        {
            _isUpdateAxis = false;
        }

        private void temperatureGraph_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            _isUpdateAxis = false;
        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            _isUpdateAxis = true;
        }
    }
}
