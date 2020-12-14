using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Quizz_PhysioUnited
{
    public class Database
    {
        readonly SQLiteConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Muskel>();
            _database.CreateTable<Question>();
        }

        public List<Muskel> GetMuskeln()
        {
            return _database.Table<Muskel>().ToList();
        }

        public void SaveMuskel(Muskel muskel)
        {
            _database.Insert(muskel);
        }


        public List<Question> GetQuestions(int category)
        {
            return _database.Query<Question>("SELECT * FROM [Question] WHERE [Category] = " + category).ToList(); //sorted by ID is done automaticly
        }

        public void FilterOnlyNextQuestionsInDB(int category)
        {
            _database.Execute("Delete From [Question] WHERE [Next] = false AND [Category] = " + category);
        }

        public List<Question> GetQuestionsByCatAndNextFalse(int category)
        {
            return _database.Query<Question>("SELECT * FROM [Question] WHERE [Next] = true AND [Category] = " + category).ToList();
        }

        public void DeleteQuestionsByCategoryInDB(int category)
        {
            _database.Execute("Delete From [Question] WHERE [Category] = " + category);
        }

        public void SaveQuestion(Question question)
        {
            _database.Insert(question);
        }

        public void SetQuestionAsNextFalse(Question question)
        {
            question.Next = false;
            if (question.ID != 0)
            {
                _database.Update(question);
            }
        }


        public void ResetQuestionDB()
        {
            _database.DropTable<Question>();
            _database.CreateTable<Question>();
        }

        public void ResetMuskelDB()
        {
            _database.DropTable<Muskel>();
            _database.CreateTable<Muskel>();
        }


        public bool IsQuestionDBEmpty()
        {
            //int count2 = _database.Query<Question>("SELECT * FROM[Question]").Count;
            int count = _database.ExecuteScalar<int>("SELECT count(*) FROM [Question]");
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsMuskelDBEmpty()
        {
            //int count2 = _database.Query<Question>("SELECT * FROM[Question]").Count;
            int count = _database.ExecuteScalar<int>("SELECT count(*) FROM [Muskel]");
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

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
                    App.DatabaseAll.SaveMuskel(new Muskel
                    {
                        ID = muskel.ID,
                        Reihenfolge = muskel.Reihenfolge,
                        Name = muskel.Name,
                        Innervation = muskel.Innervation,
                        Ursprung = muskel.Ursprung,
                        Ansatz = muskel.Ansatz,
                        Kategorie = muskel.Kategorie
                    }); ;
                }
                Debug.WriteLine("online Db loaded");
                return muskelList;
            }
            catch (Exception e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

        public async Task<DateTime> GetModifiedDate()
        {
            DateTime modifiedDate = new DateTime(1111, 11, 11, 11, 11, 11);
            try
            {                
                HttpClient client = new HttpClient();
                RootMuskel muskelList = new RootMuskel();
                Uri uri = new Uri("http://hasashi.bplaced.net/physio_united/api/checkModified.php");                
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Dictionary<string, DateTime> contentDict = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(content);
                    modifiedDate = contentDict["UPDATE_TIME"];
                    Debug.WriteLine(modifiedDate);    //debug
                    return modifiedDate;                    
                }
                else
                {
                    Debug.WriteLine(modifiedDate);    //debug
                    return modifiedDate;
                }
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
                Debug.WriteLine(modifiedDate);
                return modifiedDate;
            }
        }      
    }
}