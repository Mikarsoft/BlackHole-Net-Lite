using BlackHole.Logger;
using BlackHole.Statics;
using Microsoft.Data.Sqlite;

namespace BlackHole.Internal
{
    internal class BHDatabaseBuilder
    {
        private readonly BHDatabaseSelector _multiDatabaseSelector = new();

        internal bool DropDatabase()
        {
            string databaseLocation = _multiDatabaseSelector.GetServerConnection();

            try
            {
                if (File.Exists(databaseLocation))
                {
                    //SqliteConnection.ClearPool(new SqliteConnection(DatabaseStatics.ConnectionString));
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(databaseLocation);
                }

                return true;
            }
            catch (Exception ex)
            {
                Task.Factory.StartNew(() => databaseLocation.CreateErrorLogs("DatabaseBuilder", ex.Message, ex.ToString()));
                return false;
            }
        }

        internal bool CreateDatabase()
        {
            string databaseLocation = _multiDatabaseSelector.GetServerConnection();

            try
            {
                if (!File.Exists(databaseLocation))
                {
                    var stream = File.Create(databaseLocation);
                    stream.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                Task.Factory.StartNew(() => databaseLocation.CreateErrorLogs("DatabaseBuilder", ex.Message, ex.ToString()));
                return false;
            }
        }

        internal bool DoesDbExists()
        {
            string databaseLocation = _multiDatabaseSelector.GetServerConnection();

            try
            {
                if (!File.Exists(databaseLocation))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Task.Factory.StartNew(() => databaseLocation.CreateErrorLogs("DatabaseBuilder", ex.Message, ex.ToString()));
                return false;
            }
        }

        internal bool IsCreatedFirstTime()
        {
            return DatabaseStatics.InitializeData;
        }
    }
}
