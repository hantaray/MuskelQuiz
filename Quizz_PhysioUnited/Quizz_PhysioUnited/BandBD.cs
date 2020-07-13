using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz_PhysioUnited
{
    public class BandDB
    {
        readonly SQLiteAsyncConnection _database;

        public BandDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Band>().Wait();
        }

        public Task<List<Band>> GetBandAsync()
        {
            return _database.Table<Band>().ToListAsync();
        }

        public Task<int> SaveBandAsync(Band band)
        {
            return _database.InsertAsync(band);
        }
    }
}