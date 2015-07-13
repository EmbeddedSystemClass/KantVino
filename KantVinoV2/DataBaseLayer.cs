using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace KantVinoV2
{
    class DataBaseLayer
    {
        private static SQLiteConnection _db = null;


        public bool SaveDataList(List<UnitData> datas)
        {
            _db.RunInTransaction(() => _db.InsertAll(datas));
            return true;
        }

        public bool GetDataAtTime(double dateFrom, double dateTo, int count, int unitIndex, bool isLast = false)
        {
            var temp = from s in _db.Table<UnitData>()
                       where s.Time >= dateFrom && s.Time <= dateTo && s.Index == unitIndex
                       orderby s.Time
                       select s;

            int skipCount = temp.Count()/count;
            int i;






            return true;
        }

        public bool GetLastData()
        {
            return true;
        }

        public bool IsTransaction()
        {
            return _db.IsInTransaction;
        }



        public void Open()
        {
            if (_db != null)
            {
                _db.Dispose();
            }

            _db = new SQLiteConnection("KantVino.db", true);
            if(_db.GetTableInfo("UnitData") == null)
                _db.CreateTable<UnitData>();
        }

        public void Close()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}
