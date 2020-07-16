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

        

           


        public void SetDataToDBFromList()
        {
            List<List<string>> muscleList = new List<List<string>>();
            muscleList.Add(new List<string> { "M. rhomboides major", "N. dorsalis scapulae (Plexus brachialis, C4-C5)", 
                "Dornfortsätze des 1.-4. Brustwirbel", 
                "Margo medialis scapulae, kaudal der Spina scapulae"});

            muscleList.Add(new List<string> { "M. rhomboides minor", "N. dorsalis scapulae (Plexus brachialis, C4-C5)", 
                "Dornfortsätze des 6.-7. Brustwirbel\nLig. Nuchae",
                "Skalpula, Margo medialis, kranial der Spina scapulae" });

            muscleList.Add(new List<string> { "M.levator scapulae", 
                                              "Äste des Plexus cervicalis (C3-C5)\nN. dorsalis scapulae (Plexus brachialis C4-C5)",
                                              "Vier kurzsehnige Zacken an den Tubercula\nposteriores der Querfortsätze des 1.-4.Halswirbels",
                                              "Angulus superior scapulae" });
            muscleList.Add(new List<string> { "M. subclavius",
                "N. subclavius (Plexus brachialis, C5-C6)",
                "Kurzsehnig an der Knorpel-Knochen-Grenze der 1. Rippe",
                "Laterales Drittel der Klavikula" });
            muscleList.Add(new List<string> { "M. pectoralis minor",
                "Nn pectorales medialis et lateralis (Plexus brachialis, C6/C7 - Th1)", 
                "Ventral an der 2.-5. Rippe, nahe der Knorpel-Knochen-Grenze", "Spitze des Proc. Coracoideus" });
            muscleList.Add(new List<string> { "M. supraspinatus", "N. suprascapularis (Plexus brachialis, C4-C6)", "Skapula, Fossa supraspinata",
                "Humerus, proximale Facette des Tuberculum majus" });
            muscleList.Add(new List<string> { "M. infraspinatus", "N. suprascapularis (C4/C5-C6)",
                "Skapula, kaudaler Rand Spina scapulae und Fossa infraspinata", "Humerus, mittlere Facette des Tuberculum majus" });
            muscleList.Add(new List<string> { "M. teres minor", "N. axillaris (C5-C6)", "Skapula, kaudaler Abschnitt der Fossa infraspinata und mittleres Drittel des Margo lateralis",
                "Humerus, distale Facette des Tuberculum majus" });
            foreach (List<string> frage in muscleList)
            {
                App.Database.SaveMuskel(new Muskel
                {
                    Name = frage[0],
                    Innervation = frage[1],
                    Ursprung = frage[2],
                    Ansatz = frage[3]
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