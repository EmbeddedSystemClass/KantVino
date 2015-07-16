using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0},
            new UnitConfig(){isEnable = true, coeffLevel = 1.0, coeffPressure = 1.0}
        };

        //Константные параметры
        public static int unitCount = 20;
        public static int graphPointCount = 8192;

        //Параметры бд
        public static int timeSaveCache = 10;

        //Параметры порта, требуется перезагрузка настроек
        public static string port = "COM1";
        public static string baudRate = "9600";

        public static int timeInterview = 1;


        public class SingleGraphConfig
        {
            public double yMin;
            public double yMax;
            public bool isAuto;

            public string curveName;
            public Color curveColor;
        }

        public static SingleGraphConfig[] singleGraphConfigs = new SingleGraphConfig[4]
        {
            new SingleGraphConfig()
            {
                yMin = 0.0,
                yMax = 10.0,
                isAuto = true,
                curveName = "Температура1 С",
                curveColor = Color.Green
            },
            new SingleGraphConfig()
            {
                yMin = 0.0,
                yMax = 10.0,
                isAuto = true,
                curveName = "Температура2 С",
                curveColor = Color.Red
            },
            new SingleGraphConfig()
            {
                yMin = 0.0,
                yMax = 10.0,
                isAuto = true,
                curveName = "Давление атм",
                curveColor = Color.Green
            },
            new SingleGraphConfig()
            {
                yMin = 0.0,
                yMax = 10.0,
                isAuto = true,
                curveName = "Уровень м",
                curveColor = Color.Green
            }
        };


        public class GraphConfig
        {
            public static int timeContinueAtPause = 2;
            public static int timeContinueAtReload = 5;
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
