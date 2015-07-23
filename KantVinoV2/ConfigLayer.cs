using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace KantVinoV2
{
    class ConfigLayer
    {
        public class UnitConfig
        {
            //Опрашивать?
            public bool isEnable;

            //Коэффициенты
            public double coeffPressure;
            public double coeffLevel;  
        }

        //Параметры калибровки
        public static UnitConfig[] unitsConfig = new UnitConfig[20]
        {
            new UnitConfig(){isEnable = true, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512},
            new UnitConfig(){isEnable = false, coeffLevel = 1.0/512, coeffPressure = 1.0/512}
        };

        //Константные параметры
        public static int unitCount = 20;
        public static int graphPointCount = 8192;

        //Параметры бд, требуется перезагрузка настроек Open();
        public static int timeSaveCache = 10; //*
        public static int timeSaveBacup = 1000000;
        public static string dataBasePath = ""; //*
        public static string backupPath = "";

        //Параметры порта, требуется перезагрузка настроек PortOpen()
        public static string port = "COM4"; //*
        public static string baudRate = "38400"; //*
       
        //Время опроса датчиков
        public static int timeInterview = 1;


        public class SingleGraphConfig
        {
            public double yMin;
            public double yMax;
            public bool isAuto;

            public string curveMeasure;
            public string curveName;
            public Color curveColor;
            public SymbolType sType;
        }

        public static SingleGraphConfig[] singleGraphConfigs = new SingleGraphConfig[4]
        {
            new SingleGraphConfig()
            {
                yMin = -10.0,
                yMax = 90.0,
                isAuto = true,
                curveName = "Температура1",
                curveMeasure = "C",
                curveColor = Color.Green,
                 sType = SymbolType.Plus
            },
            new SingleGraphConfig()
            {
                yMin = 20.0,
                yMax = 40.0,
                isAuto = false,
                curveName = "Температура2",
                curveMeasure = "C",
                curveColor = Color.Red,
                 sType = SymbolType.Star
            },
            new SingleGraphConfig()
            {
                yMin = 0.0,
                yMax = 10.0,
                isAuto = true,
                curveName = "Давление",
                curveMeasure = "атм",
                curveColor = Color.Green,
                 sType = SymbolType.Plus
            },
            new SingleGraphConfig()
            {
                yMin = 0.0,
                yMax = 10.0,
                isAuto = true,
                curveName = "Уровень",
                curveMeasure = "м",
                curveColor = Color.Green,
                 sType = SymbolType.Plus
            }
        };


        public class GraphConfig
        {
            public static int timeContinueAtPause = 10;
            public static int timeContinueAtReload = 20;
            public static int timeVisibleLine = 100;
            public static int timeLoadLeftLine = 100;
            public static int timeLoadRightLine = 900;
        }
    }


    /*
    [Serializable]
    public class SingleGraphConfig
    {
        public double ymin { get; set; }
        public double ymax { get; set; }
        public bool isYAuto { get; set; }
        public string curveName { get; set; }

        [XmlIgnore]
        public Color curveColor = Color.Black;
        [XmlElement("curveColor")] //Заставим колор сериализоваться
        [Browsable(false)]
        public int curveColor_ForXml
        {
            get { return curveColor.ToArgb(); }
            set { curveColor = Color.FromArgb(value); }
        }
        
    }*/
}
