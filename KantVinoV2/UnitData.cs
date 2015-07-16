using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace KantVinoV2
{
    public class UnitData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed, NotNull]
        public DateTime Time { get; set; }

        public int Index { get; set; }

        public double Term1 { get; set; }
        public double Term2 { get; set; }
        public double Pressure { get; set; }
        public double Level { get; set; }

        [Ignore]
        public int ErrorCode { get; set; }

        public double GetValue(int i)
        {
            switch (i)
            {
                case 0:
                    return Term1;
                case 1:
                    return Term2;
                case 2:
                    return Pressure;
                case 3:
                    return Level;
                default:
                    return double.NaN;
            }
        }
    }
}
