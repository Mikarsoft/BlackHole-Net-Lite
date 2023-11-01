using BlackHole.CoreSupport;
using BlackHole.DataProviders;
using BlackHole.Statics;

namespace BlackHole.Internal
{
    internal class BHDatabaseSelector
    {
        internal IExecutionProvider GetExecutionProvider(string connectionString)
        {
            return new SqliteExecutionProvider(connectionString);
        }

        internal string GetPrimaryKeyCommand()
        {
            return "Id INTEGER PRIMARY KEY AUTOINCREMENT ,";
        }

        internal string GetServerConnection()
        {
            return DatabaseStatics.ServerConnection;
        }

        internal string[] SqlDatatypesTranslation()
        {
            return new[] { "varchar", "char", "int2", "integer", "bigint", "decimal", "float", "numeric", "varchar(36)", "boolean", "datetime", "blob" };
        }
    }
}
