using BlackHole.DataProviders;
using BlackHole.Entities;
using BlackHole.Statics;
using Microsoft.Data.Sqlite;
using System.Data;

namespace BlackHole.CoreSupport
{
    internal static class BHDataProviderSelector
    {
        internal static SqliteDataProvider GetDataProvider()
        {
            return new SqliteDataProvider(DatabaseStatics.ConnectionString);
        }

        internal static IDbConnection GetConnection()
        {
            return new SqliteConnection(DatabaseStatics.ConnectionString);
        }

        internal static bool CheckActivator(this Type entity)
        {
            return entity.GetCustomAttributes(true).Any(x => x.GetType() == typeof(UseActivator));
        }

        internal static IExecutionProvider GetExecutionProvider()
        {
            return new SqliteExecutionProvider(DatabaseStatics.ConnectionString);
        }
    }
}
