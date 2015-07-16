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
        private int _itemIndex = 0;

        public ItemGraph(int itemIndex)
        {
            _itemIndex = itemIndex;
            InitializeComponent();

            toolStrip1.Items.Insert(2, new ToolStripControlHost(dtpLoadData));

            LoadGraphSettings(); //Загружаем настройки графиков

            UpdateAsis(DateTime.Now);

            // События 
            zGraph.ZoomEvent += Graph_ZoomEvent;
            zGraph.ScrollEvent += Graph_ScrollEvent;
        }


        public void UpdateData(UnitData data, bool isUpdateAxis)
        {
            for (int i = 0; i < 4; i++)
            {
                if(((data.ErrorCode>>(i*2))&3) == 0)
                    _singleGraph[i].UpdateData(data.GetValue(i), data.Time);
            }

            if (isUpdateAxis)
            {
                UpdateAsis(data.Time);
            }
        }

        public void ReloadData(IEnumerable<UnitData> datas, DateTime timeStartVisible)
        {
            for (int i = 0; i < 4; i++)
            {
                _singleGraph[i].ReloadData(datas, i);
            }

            UpdateAsis(timeStartVisible, true);
        }

        private void UpdateAsis(DateTime time, bool isFromNotTo = false)
        {
            DateTime startTime = new DateTime(time.Ticks);
            DateTime endTime = new DateTime(time.Ticks);

            if (isFromNotTo)
            {
                endTime = time.AddSeconds(ConfigLayer.GraphConfig.timeVisibleLine);
            }
            else
            {
                startTime = time.AddSeconds(-ConfigLayer.GraphConfig.timeVisibleLine);
            }

            for (int i = 0; i < 3; i++)
            {
                //Устанавливаем интересующий нас интервал по оси Y
                zGraph.MasterPane[i].YAxis.Scale.Min = ConfigLayer.singleGraphConfigs[i + 1].yMin;
                zGraph.MasterPane[i].YAxis.Scale.Max = ConfigLayer.singleGraphConfigs[i + 1].yMax;
                //По оси Y установим автоматический подбор масштаба
                zGraph.MasterPane[i].YAxis.Scale.MinAuto = ConfigLayer.singleGraphConfigs[i + 1].isAuto;
                zGraph.MasterPane[i].YAxis.Scale.MaxAuto = ConfigLayer.singleGraphConfigs[i + 1].isAuto;
                //Устанавливаем время по X
                zGraph.MasterPane[i].XAxis.Scale.Min = (XDate)startTime;
                zGraph.MasterPane[i].XAxis.Scale.Max = (XDate)endTime;
            }

            zGraph.AxisChange();
            zGraph.Invalidate();
        }

#region События интерфейса

        public delegate void PauseUpdateGraphEventHandler();
        public event PauseUpdateGraphEventHandler PauseUpdateGraph;
        private void Graph_ScrollEvent(object sender, ScrollEventArgs e)
        {
            PauseUpdateGraph();
        }
        private void Graph_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            PauseUpdateGraph();
        }

        public delegate void ResumeUpdateGraphEventHandler();
        public event ResumeUpdateGraphEventHandler ResumeUpdateGraph;
        private void btnContinue_Click(object sender, EventArgs e)
        {
            ResumeUpdateGraph();
        }

        public delegate void ChangeTimeGraphEventHandler(DateTime time);
        public event ChangeTimeGraphEventHandler ChangeTimeGraph;
        private void dtpLoadData_ValueChanged(object sender, EventArgs e)
        {
             ChangeTimeGraph(dtpLoadData.Value);
        }
        
#endregion      

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
            for (int i = 1; i < 4; i++)
            {
                GraphPane pane = new GraphPane();
                var config = ConfigLayer.singleGraphConfigs[i];

                _singleGraph[i].InitPane(pane);
                if (i == 1)
                {
                    config = ConfigLayer.singleGraphConfigs[0];

                    _singleGraph[0].AddCurve(pane, config.curveName, config.curveMeasure,
                        config.curveColor, config.sType, ConfigLayer.graphPointCount);

                    config = ConfigLayer.singleGraphConfigs[1];
                }

                _singleGraph[i].AddCurve(pane, config.curveName, config.curveMeasure,
                    config.curveColor, config.sType, ConfigLayer.graphPointCount);

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
       
    }
}
