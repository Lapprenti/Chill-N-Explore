using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using SQLite;
using Xamarin.Forms;
using Windows.Storage;
using System.IO;
using ChillNExplore.UWP;
using static ChillNExplore.MainPage;

[assembly: Dependency(typeof(DatabaseConnection_UWP))]


namespace ChillNExplore.UWP
{
    public class DatabaseConnection_UWP : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "ProfilsDb.db3";
            var path = Path.Combine(ApplicationData.
              Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
