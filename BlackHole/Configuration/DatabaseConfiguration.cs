using BlackHole.Statics;
using BlackHole.Logger;
using BlackHole.Core;

namespace BlackHole.Configuration
{
    internal static class DatabaseConfiguration
    {
        internal static void LogsSettings(string LogsPath)
        {
            DatabaseStatics.DataPath = LogsPath;
            LoggerService.DeleteOldLogs();
            LoggerService.SetUpLogger();
            SQLitePCL.Batteries_V2.Init();
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_dynamic_cdecl());
        }

        internal static bool IsAutoUpdateOn()
        {
            if (DatabaseStatics.AutoUpdate)
            {
                DatabaseStatics.AutoUpdate = false; 
                return true;
            }
            return false;
        }

        internal static void ScanConnectionString(string connectionString)
        {
            ScanLiteString(connectionString);
        }

        private static void ScanLiteString(string connectionString)
        {
            try
            {
                string[] pathSplit = connectionString.Split('\\');
                string[] nameOnly = pathSplit[pathSplit.Length - 1].Split('.');
                DatabaseStatics.DatabaseName = nameOnly[0];
            }
            catch
            {
                DatabaseStatics.DatabaseName = connectionString;
            }

            DatabaseStatics.ServerConnection = connectionString;
            DatabaseStatics.ConnectionString = $"Data Source={connectionString};";
            BHDataProvider.SetExecutionProvider();
        }
    }
}