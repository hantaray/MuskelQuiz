using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz_PhysioUnited
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Muskel>().Wait();
        }

        public Task<List<Muskel>> GetMuskelAsync()
        {
            return _database.Table<Muskel>().ToListAsync();
        }

        public Task<int> SaveMuskelAsync(Muskel muskel)
        {
            return _database.InsertAsync(muskel);
        }
    }
}