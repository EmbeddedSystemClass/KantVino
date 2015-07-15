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

namespace KantVinoV2
{
    public partial class ItemGraph : UserControl
    {
        private SingleGraph[] _singleGraph = new SingleGraph[4];

        private int _capacity = 8192;
        private int _periodSeconds = 100;
        private int _visibleSeconds = 100;
        private int _timeRegenerationSeconds = 5;

        private bool _isUpdateAxis = false;
        private bool _isUpdateData = false;
        private int _tickCounter = 0;

        private int _itemIndex = 0;

        public ItemGraph(int itemIndex)
        {
            _itemIndex = itemIndex;
            InitializeComponent();

            toolStrip1.Items.Insert(2, new ToolStripControlHost(dtpLoadData));


            LoadGraphSettings(); //Загружаем настройки графиков

            _isUpdateData = true;
            _isUpdateAxis = true;
            _tickCounter = 0;

            DateTime to = DateTime.Now;
            DateTime from = to.AddSeconds(-_periodSeconds);
            LoadDataFromBase(from, to);

            // События 
            zGraph.ZoomEvent += Graph_ZoomEvent;
            zGraph.ScrollEvent += Graph_ScrollEvent;
        }

        public void AddData(DataStruct data)
        {
            XDate time = data.time;
            if (_isUpdateData)
            {
                _singleGraph[0].UpdateData(data.temper1, time);
                _singleGraph[1].UpdateData(data.temper2, time);
                _singleGraph[2].UpdateData(data.pressure, time);
                _singleGraph[3].UpdateData(data.level, time);
            }
            if (_isUpdateAxis)
            {
                DateTime to = data.time;
                DateTime from = to.AddSeconds(-_visibleSeconds);
                UpdateAxis(from, to);
            }
        }

        private void UpdateAxis(DateTime tfrom, DateTime tto)
        {
            XDate from = tfrom;
            XDate to = tto;
            for (int i = 0; i < 3; i++)
            {
                zGraph.MasterPane[i].XAxis.Scale.Min = from;
                zGraph.MasterPane[i].XAxis.Scale.Max = to;
            }

            zGraph.AxisChange();
            zGraph.Invalidate();
        }

        private void Graph_ScrollEvent(object sender, ScrollEventArgs e)
        {
            _isUpdateAxis = false;
            _tickCounter = 0;
        }

        private void Graph_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            _isUpdateAxis = false;
            _tickCounter = 0;
        }

        private void LoadDataFromBase(DateTime from, DateTime to)
        {
            PointPair[][] pp = new PointPair[4][];
           

            DBDataLayer.ReadData(out pp, _itemIndex, _capacity, from, to);

            for (int i = 0; i < 4; i++)
            {
                _singleGraph[i].ReloadData(pp[i]);
            }

            UpdateAxis(from, from.AddSeconds(_visibleSeconds));
        }

        private void LoadGraphSettings()
        {
            zGraph.EditButtons = MouseButtons.None;
            zGraph.LinkButtons = MouseButtons.None;
            zGraph.SelectButtons = MouseButtons.None;
            //Кнопка таскания
            // zGraph.PanButtons = MouseButtons.None;
            zGraph.PanModifierKeys = Keys.None;
            zGraph.PanButtons2 = MouseButtons.None;
            //Кнопка зума выделенного прямоугольника
            zGraph.ZoomButtons = MouseButtons.None;
            zGraph.ZoomButtons2 = MouseButtons.None;


            // По умолчанию в MasterPane содержится один экземпляр класса GraphPane 
            // (который можно получить из свойства zedGraph.GraphPane)
            // Очистим этот список, так как потом мы будем создавать графики вручную
            MasterPane masterPane = zGraph.MasterPane;
            masterPane.PaneList.Clear();

            for (int i = 0; i < 4; i++)
            {
                _singleGraph[i] = new SingleGraph();
            }

            // Добавим три графика
            SingleGraphConfig[] configs = Properties.Settings.Default.ItemsGConfig;
            for (int i = 1; i < 4; i++)
            {
                GraphPane pane = new GraphPane();
                SingleGraphConfig config = configs[i];
                _singleGraph[i].InitPane(pane, config.ymin, config.ymax, config.isYAuto);
                if (i == 1)
                {

                    config = configs[0];
                    _singleGraph[0].AddCurve(pane, config.curveName, config.curveColor, _capacity);
                    config = configs[i];
                }
                _singleGraph[i].AddCurve(pane, config.curveName, config.curveColor, _capacity);

                masterPane.Add(pane);
            }

            // Будем размещать добавленные графики в MasterPane
            using (Graphics g = CreateGraphics())
            {
                // Графики будут размещены в один столбец друг под другом
                masterPane.SetLayout(g, PaneLayout.SingleColumn);

                //Графики будут размещены в одну строку друг за другом
                //masterPane.SetLayout (g, PaneLayout.SingleRow);

                // Графики будут размещены в две строки, 
                // в первой будет один столбец, а во второй - две
                // masterPane.SetLayout(g, PaneLayout.ExplicitCol12);
            }


            // Свойства IsSynchronizeXAxes и IsSynchronizeYAxes указывают, что
            // оси на графиках должны перемещаться и масштабироваться одновременно.
            zGraph.IsSynchronizeXAxes = true;
            //zGraph.IsSynchronizeYAxes = true;

            // Отключаем масштабирование по вертикали
            zGraph.IsEnableVZoom = false;
        }

        private void timer100ms_Tick(object sender, EventArgs e)
        {
            if (++_tickCounter>_timeRegenerationSeconds*10)
            {
                _isUpdateData = true;
                _isUpdateAxis = true;
                _tickCounter--;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            _isUpdateData = true;
            _isUpdateAxis = true;
        }

        private void dtpLoadData_ValueChanged(object sender, EventArgs e)
        {
            _isUpdateData = false;
            _isUpdateAxis = false;
            _tickCounter = 0;

            DateTime from = dtpLoadData.Value;
            DateTime to = from.AddSeconds(_periodSeconds);;
            LoadDataFromBase(from, to);
        }
    }
}
