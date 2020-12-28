using SQLite;

namespace DesktopContactApp.Api
{
    public static class DatabaseConnection
    {
        public static SQLiteConnection Connection()
        {
            return new SQLiteConnection(App.databasePath);
        }
    }
}
