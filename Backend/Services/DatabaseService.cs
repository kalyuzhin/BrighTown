using Microsoft.Data.Sqlite;

namespace Backend.Services
{
    public class DatabaseService : IDatabaseService
    {
        private SqliteConnection _connection;

        public DatabaseService(string databasePath)
        {
            _connection = new SqliteConnection(databasePath);
        }

        public void SaveUser(User user)
        {
            //_connection.
        }

        public bool CheckUserExists(string email)
        {
            //var user = _connection.Table<User>().FirstOrDefault(u => u.Email == email);
            return true; // заглушка
        }
    }
}
