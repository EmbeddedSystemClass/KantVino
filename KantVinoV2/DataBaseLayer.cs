using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;

namespace KantVinoV2 //end 14_07_2015
{
    class DataBaseLayer  
    {
        private SQLiteConnection _db = null;

        public bool SaveDataList(IEnumerable<UnitData> datas)
        {
            try
            {
                _db.RunInTransaction(() => _db.InsertAll(datas));
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool GetDataAtTime(double dateFrom, double dateTo, int unitIndex, out IEnumerable<KeyValuePair<double, double>[]> datas)
        {
            datas = from s in _db.Table<UnitData>()
                where s.Time >= dateFrom && s.Time <= dateTo && s.Index == unitIndex
                orderby s.Time
                select new KeyValuePair<double, double>[]
                {
                    new KeyValuePair<double, double>(s.Time, s.Term1),
                    new KeyValuePair<double, double>(s.Time, s.Term2),
                    new KeyValuePair<double, double>(s.Time, s.Pressure),
                    new KeyValuePair<double, double>(s.Time, s.Level)
                };
            return true;
        }

        public bool GetLastData(int unitIndex, out IEnumerable<KeyValuePair<double, double>[]> datas)
        {
            int cnt = ConfigLayer.graphPointCount;
            int maxCnt = ConfigLayer.unitCount*cnt;
            
            datas = from s in
                (from t in _db.Table<UnitData>()  //Получаем maxCnt последних записей
                    .OrderByDescending(c => c.Id)
                    .Take(maxCnt)
                    where t.Index == unitIndex
                    select t)
                    .Take(cnt) 
                orderby s.Time
                select new KeyValuePair<double,double>[]
                {
                    new KeyValuePair<double, double>(s.Time,s.Term1), 
                    new KeyValuePair<double, double>(s.Time,s.Term2), 
                    new KeyValuePair<double, double>(s.Time,s.Pressure), 
                    new KeyValuePair<double, double>(s.Time,s.Level)
                };
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
