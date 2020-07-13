using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz_PhysioUnited
{
    public class BandDB
    {
        readonly SQLiteConnection _database;

        public BandDB(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Band>();
        }

        public List<Band> GetBand()
        {
            return _database.Table<Band>().ToList();
        }
        public void SaveBand(Band band)
        {
            _database.Insert(band);
        }
    }
}