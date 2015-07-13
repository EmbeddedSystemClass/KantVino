using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ZedGraph;


namespace Кант_Вино
{

    public class DataStruct
    {
        public double temper1;
        public double temper2;
        public double pressure;
        public double level;
        public DateTime time;
    }

    public class DBItemData
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        [Indexed, NotNull]
        public double Time { get; set; }

        [NotNull]
        public int Index { get; set; }

        public double Temper1 { get; set; }
        public double Temper2 { get; set; }
        public double Pressure { get; set; }
        public double Level { get; set; }
    }

    public static class DBDataLayer
    {

        private static SQLiteConnection _db = new SQLiteConnection("KantVino.db", true);

        public static void DBConnect()
        {
             _db = new SQLiteConnection("KantVino.db", true);
             _db.CreateTable<DBItemData>();

            
            
        }

        public static void DBDisconnect()
        {
            _db.Dispose();
        }

        //static ~DBDataLayer()
        //{
        //    // do your work here
        //    _db.Dispose();
        //}

        public static void AddData(int indexItem, DataStruct data)
        {
            DBItemData temp = new DBItemData() 
            {   Time = (XDate)data.time, Index = indexItem,
                Temper1 = data.temper1, Temper2 = data.temper2, 
                Pressure = data.pressure, Level = data.level };
            AddData(indexItem, temp);
        }

         public static void AddData(int indexItem, DBItemData data)
         {
             data.Index = indexItem;
            _db.RunInTransaction(() => _db.Insert(data));

             
         }


         public static void ReadData(out PointPair[][] pp, int itemIndex, int capacity, DateTime timeFrom, DateTime timeTo)
         {
             double tfrom = (XDate) timeFrom;
             double tto = (XDate) timeTo;

                var temp = from s in _db.Table<DBItemData>()
                       where s.Time >= tfrom && s.Time <= tto && s.Index == itemIndex
                       orderby s.Time
                       select s;

             int cnt = Math.Min(temp.Count(), capacity);
             int i = 0;

             pp = new PointPair[4][];
             for (i = 0; i < 4; i++)
             {
                 pp[i] = new PointPair[cnt];
             }
             i = 0;

             foreach (DBItemData iData in temp)
             {
                 pp[0][i].Y = iData.Temper1;
                 pp[1][i].Y = iData.Temper2;
                 pp[2][i].Y = iData.Pressure;
                 pp[3][i].Y = iData.Level;

                 double time = iData.Time;
                 pp[0][i].X = pp[1][i].X = pp[2][i].X = pp[3][i].X = time;

                 if (++i >= cnt) return;
             }
         }
    }
}
