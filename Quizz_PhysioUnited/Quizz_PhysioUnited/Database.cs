using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Quizz_PhysioUnited
{
    public class Database
    {
        readonly SQLiteConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Muskel>();
        }

        public List<Muskel> GetMuskel()
        {
            return _database.Table<Muskel>().ToList();
        }

        public void SaveMuskel(Muskel muskel)
        {
            _database.Insert(muskel);
        }

        //Es wird die ganze SQLite-DB ausgetauscht - vielleicht besser nur die Daten zu ziehen, die geändert wurden?
        public async Task<RootMuskel> GetDataFromServer()
        {
            try
            {
                HttpClient client = new HttpClient();

                RootMuskel muskelList = new RootMuskel();
                Uri uri = new Uri("http://hasashi.bplaced.net/physio_united/api/read.php");
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    muskelList = JsonConvert.DeserializeObject<RootMuskel>(content);
                }

                _database.DropTable<Muskel>();
                _database.CreateTable<Muskel>();

                foreach (Muskel muskel in muskelList.Muskeln)
                {
                    App.Database.SaveMuskel(new Muskel
                    {
                        ID = muskel.ID,
                        Name = muskel.Name,
                        Innervation = muskel.Innervation,
                        Ursprung = muskel.Ursprung,
                        Ansatz = muskel.Ansatz,
                        Kategorie = muskel.Kategorie
                    });
                }
                return muskelList;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}