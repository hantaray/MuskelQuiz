using SQLite;
using System.Collections.Generic;
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

        

           


        public void SetDataToDBFromList(string category)
        {
            List<List<string>> muscleList = new List<List<string>>();
            muscleList.Add(new List<string> { category + " " + "M. rhomboides major", category + " " +  "N. dorsalis scapulae (Plexus brachialis, C4-C5)", category + " " +  
                "Dornfortsätze des 1.-4. Brustwirbel",  category + " " + 
                "Margo medialis scapulae, kaudal der Spina scapulae",
                category});

            muscleList.Add(new List<string> { category + " " +  "M. rhomboides minor", category + " " +  "N. dorsalis scapulae (Plexus brachialis, C4-C5)", category + " " +  
                "Dornfortsätze des 6.-7. Brustwirbel\nLig. Nuchae", category + " " + 
                "Skalpula, Margo medialis, kranial der Spina scapulae", category });

            muscleList.Add(new List<string> { category + " " +  "M.levator scapulae",  category + " " + 
                                              "Äste des Plexus cervicalis (C3-C5)\nN. dorsalis scapulae (Plexus brachialis C4-C5)", category + " " + 
                                              "Vier kurzsehnige Zacken an den Tubercula\nposteriores der Querfortsätze des 1.-4.Halswirbels", category + " " + 
                                              "Angulus superior scapulae", category });
            muscleList.Add(new List<string> { category + " " +  "M. subclavius", category + " " + 
                "N. subclavius (Plexus brachialis, C5-C6)", category + " " + 
                "Kurzsehnig an der Knorpel-Knochen-Grenze der 1. Rippe", category + " " + 
                "Laterales Drittel der Klavikula", category });
            muscleList.Add(new List<string> { category + " " +  "M. pectoralis minor", category + " " + 
                "Nn pectorales medialis et lateralis (Plexus brachialis, C6/C7 - Th1)",  category + " " + 
                "Ventral an der 2.-5. Rippe, nahe der Knorpel-Knochen-Grenze", category + " " +  "Spitze des Proc. Coracoideus", category });
            muscleList.Add(new List<string> { category + " " +  "M. supraspinatus", category + " " +  "N. suprascapularis (Plexus brachialis, C4-C6)", category + " " +  "Skapula, Fossa supraspinata", category + " " + 
                "Humerus, proximale Facette des Tuberculum majus" , category});
            muscleList.Add(new List<string> { category + " " +  "M. infraspinatus", category + " " +  "N. suprascapularis (C4/C5-C6)",  category + " " +
                "Skapula, kaudaler Rand Spina scapulae und Fossa infraspinata",  category + " " +  "Humerus, mittlere Facette des Tuberculum majus" , category});
            muscleList.Add(new List<string> { category + " " + "M. teres minor", category + " " +  "N. axillaris (C5-C6)",  category + " " +  "Skapula, kaudaler Abschnitt der Fossa infraspinata und mittleres Drittel des Margo lateralis",
                category + " " +  "Humerus, distale Facette des Tuberculum majus" , category});
            foreach (List<string> frage in muscleList)
            {
                App.Database.SaveMuskel(new Muskel
                {
                    Name = frage[0],
                    Innervation = frage[1],
                    Ursprung = frage[2],
                    Ansatz = frage[3],
                    Kategorie = System.Int32.Parse(frage[4])
                });
            }
        }


        public List<Muskel> GetMuskel()
        {
            return _database.Table<Muskel>().ToList();
        }

        public void SaveMuskel(Muskel muskel)
        {
            _database.Insert(muskel);
        }
    }
}