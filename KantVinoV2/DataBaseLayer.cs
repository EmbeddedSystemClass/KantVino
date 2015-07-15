﻿using System;
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

        public bool GetDataAtTime(double timeFrom, double timeTo, int unitIndex,
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
            return true;
        }

        public bool GetLastData(int unitIndex, out IEnumerable<UnitData> datas)
        {
            //Возвращаем чуть меньше, т.к. будут добавлятся свежие данные
            int cnt = ConfigLayer.graphPointCount - 2;
            int maxCnt = ConfigLayer.unitCount*cnt;

            //Получаем maxCnt последних записей
            var temp = from s in _db.Table<UnitData>()
                .Skip(Math.Max(_db.Table<UnitData>().Count() - maxCnt, 0))
                where s.Index == unitIndex
                orderby s.Time
                select s;

            datas = temp.Skip(Math.Max(temp.Count() - cnt, 0));
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
