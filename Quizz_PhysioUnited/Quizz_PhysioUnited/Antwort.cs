using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_PhysioUnited
{
    public class Antwort
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int GruppeID { get; set; }
        public string AntwortText { get; set; }
    }
}
