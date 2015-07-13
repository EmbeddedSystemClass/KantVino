using System;
using System.Collections.Generic;
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


        public static int unitCount = 20;

        //Параметры порта, требуется перезагрузка настроек
        public static string port = "COM1";
        public static string baudRate = "9600";


        public class AllConfig
        {
            //Параметры оси Y графика
            public double[] yMin = new double[4];
            public double[] yMax = new double[4];
            public bool[] isAuto = new bool[4];
        }
    }
}
