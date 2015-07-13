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

        public int Index { get; set; }

        [Indexed, NotNull]
        public double Time { get; set; }

        public double Term1 { get; set; }
        public double Term2 { get; set; }
        public double Pressure { get; set; }
        public double Level { get; set; }


        [Ignore]
        public int ErrorCode { get; set; }
    }
}
