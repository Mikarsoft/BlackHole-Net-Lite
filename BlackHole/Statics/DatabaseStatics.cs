
namespace BlackHole.Statics
{
    internal static class DatabaseStatics
    {
        internal static string ConnectionString { get; set; } = string.Empty;
        internal static string ServerConnection { get; set; } = string.Empty;
        internal static string DatabaseName { get; set; } = string.Empty;
        internal static string DataPath { get; set; } = string.Empty;
        internal static bool UseLogging { get; set; } = true;
        internal static bool AutoUpdate { get; set; } = true;
        internal static bool InitializeData { get; set; } = false;
        internal static string DbDateFormat { get; set; } = "yyyy-MM-dd";
    }
}
