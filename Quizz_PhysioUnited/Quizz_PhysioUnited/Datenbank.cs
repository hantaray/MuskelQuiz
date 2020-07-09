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
            _database.CreateTableAsync<Frage>().Wait();
            _database.CreateTableAsync<Antwort>().Wait();
        }

        //public Task<List<Frage>> GetFrageAsync()
        //{
        //    return _database.Table<Frage>().Where(id="1").ToListAsync();
        //}
        public Task<List<Antwort>> GetAntwortAsync()
        {
            return _database.Table<Antwort>().ToListAsync();
        }

        public Task<int> SaveFrageAsync(Frage frage)
        {
            return _database.InsertAsync(frage);
        }

        public Task<int> SaveAntwortAsync(Antwort antwort)
        {
            return _database.InsertAsync(antwort);
        }
    }
}