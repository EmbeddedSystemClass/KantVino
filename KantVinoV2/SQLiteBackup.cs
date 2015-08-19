using System;
using System.Runtime.InteropServices;
using System.Threading;

using Sqlite3DatabaseHandle = System.IntPtr;
using Sqlite3Backup = System.IntPtr;

namespace SQLite
{
    public partial class SQLiteConnection
    {
        // sqlite3_backup *sqlite3_backup_init(
        //   sqlite3 *pDest,                        /* соединение к базе назначения */
        //   const char *zDestName,                 /* псевдоним базы назначения */
        //   sqlite3 *pSource,                      /* соединение к исходной базы */
        //   const char *zSourceName                /* псевдоним исходной базы */
        // );
        [DllImport("sqlite3", EntryPoint = "sqlite3_backup_init", CallingConvention = CallingConvention.Cdecl)]
        private static extern Sqlite3Backup BackupInit(
            Sqlite3DatabaseHandle pDest,
            [MarshalAs(UnmanagedType.LPStr)] string zDestName,
            Sqlite3DatabaseHandle pSource,
            [MarshalAs(UnmanagedType.LPStr)] string zSourceName);

        // int sqlite3_backup_step(sqlite3_backup* p, int nPage);
        [DllImport("sqlite3", EntryPoint = "sqlite3_backup_step", CallingConvention = CallingConvention.Cdecl)]
        private static extern SQLite3.Result BackupStep(Sqlite3Backup p, int nPage);

        // int sqlite3_backup_finish(sqlite3_backup *p);
        [DllImport("sqlite3", EntryPoint = "sqlite3_backup_finish", CallingConvention = CallingConvention.Cdecl)]
        private static extern SQLite3.Result BackupFinish(Sqlite3Backup p);

        // int sqlite3_backup_remaining(sqlite3_backup* p);
        [DllImport("sqlite3", EntryPoint = "sqlite3_backup_remaining", CallingConvention = CallingConvention.Cdecl)]
        private static extern int BackupRemaining(Sqlite3Backup p);

        // int sqlite3_backup_pagecount(sqlite3_backup* p);
        [DllImport("sqlite3", EntryPoint = "sqlite3_backup_pagecount", CallingConvention = CallingConvention.Cdecl)]
        private static extern int BackupPagecount(Sqlite3Backup p);


        public delegate void BackupProgressEventHandler(int remaining, int pagecount);
        public event BackupProgressEventHandler BackupProgress;

        public int BackupDataBase(string backupPath)
        {
            Sqlite3DatabaseHandle backupHandle;

            if (string.IsNullOrEmpty(backupPath))
                throw new ArgumentException("Must be specified", "databasePath");
            var backupPathAsBytes = GetNullTerminatedUtf8(backupPath);
            //A
            var r = SQLite3.Open(backupPathAsBytes, out backupHandle,
                (int) (SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create), IntPtr.Zero);
            if (r != SQLite3.Result.OK)
            {
                throw SQLiteException.New(r, String.Format("Could not open database file: {0} ({1})", backupPath, r));
            }

            //Открыли БД, пора приступить к бэкапу

            Sqlite3Backup pBackup;
            //1
            pBackup = BackupInit(backupHandle, "main", Handle, "main");

            if (pBackup != IntPtr.Zero)
            {
                while(true)
                {
                    //2
                    r = BackupStep(pBackup, 25);

                    if (BackupProgress != null) BackupProgress(BackupRemaining(pBackup), BackupPagecount(pBackup));

                    if (r == SQLite3.Result.OK || r == SQLite3.Result.Busy || r == SQLite3.Result.Locked)
                    {
                        Thread.Sleep(100);
                    }
                    else
                    {
                        break;
                    }
                }

                //3
                BackupFinish(pBackup);
            }
            //B
            r = SQLite3.Close(backupHandle);
            if (r != SQLite3.Result.OK)
            {
                string msg = SQLite3.GetErrmsg(backupHandle);
                throw SQLiteException.New(r, msg);
            }

            return (int)r;
        }
    }
}
