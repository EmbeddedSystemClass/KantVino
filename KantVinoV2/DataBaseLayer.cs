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
        private List<UnitData>[] _dataCache = new List<UnitData>[2];
        private int _swapIndex = 0;
        private Timer _saveCacheTimer = new Timer();

        private void SaveCacheTimer_Tick(object sender, EventArgs e)
        {
            SaveCache();
        }

        public void AddDataToCache(IEnumerable<UnitData> datas)
        {
            _dataCache[_swapIndex].AddRange(datas);
        }
        public void AddDataToCache(UnitData data)
        {
            _dataCache[_swapIndex].Add(data);
        }


        private bool SaveCache()
        {
            if (!_dataCache[_swapIndex].Any()) return true;
            if (_db == null) return false;

            _swapIndex ^= 1; //Свапаем буфер кэша

            for (int i = 0; i < 2; i++) //Делаем 2 попытки записи
            {
                try
                {
                    _db.RunInTransaction(() => _db.InsertAll(_dataCache[_swapIndex ^ 1]));
                    _dataCache[_swapIndex ^ 1].Clear(); //Очищаем кэш
                    return true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            _dataCache[_swapIndex ^ 1].Clear(); //Очищаем кэш
            return false;
        }


        //Взять записи из бд за период
        public void GetDataAtTime(double timeFrom, double timeTo, int unitIndex, 
            out IEnumerable<UnitData> datas)
        {
            int cnt = ConfigLayer.graphPointCount;

            var temp = from s in _db.Table<UnitData>()
                where s.Time >= timeFrom && s.Time <= timeTo && s.Index == unitIndex
                orderby s.Time
                select s;

            //Если набралось больше, чем надо, надо что-то пропустить
            int nStep = Math.Max((temp.Count() - 1) / cnt + 1, 1);
            datas = temp.Where((x, i) => i%nStep == 0);
        }

        //Взять последние записи из бд + кеша
        public void GetLastData(int unitIndex, out IEnumerable<UnitData> datas)
        {
            int cnt = ConfigLayer.graphPointCount;
            int maxCnt = ConfigLayer.unitCount * cnt - _dataCache[_swapIndex].Count;

            //Получаем maxCnt последних записей + данные из кэша
            var temp = from s in _db.Table<UnitData>()
                .Skip(Math.Max(_db.Table<UnitData>().Count() - maxCnt, 0))
                .Concat(_dataCache[_swapIndex])
                where s.Index == unitIndex
                orderby s.Time
                select s;

            datas = temp.Skip(Math.Max(temp.Count() - cnt, 0));
        }

        public void Open()
        {
            if (_db != null)
            {
                _saveCacheTimer.Enabled = false;
                while(_db.IsInTransaction);
                _db.Dispose();
            }

            _db = new SQLiteConnection("KantVino.db", true);
            _db.CreateTable<UnitData>();

            _dataCache[0] = new List<UnitData>();
            _dataCache[1] = new List<UnitData>();
            _dataCache[0].Clear();
            _dataCache[1].Clear();

            _saveCacheTimer.Interval = ConfigLayer.timeSaveCache * 1000;
            _saveCacheTimer.Enabled = true;
            _saveCacheTimer.Tick += SaveCacheTimer_Tick;
        }

        public void Close()
        {
            if (_db != null)
            {
                _saveCacheTimer.Enabled = false;
                SaveCache();
                while (_db.IsInTransaction) ;
                _db.Dispose();
            }
        }
    }
}
