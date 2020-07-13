using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_PhysioUnited
{
    public class Muskel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ursprung { get; set; }
        public string Ansatz { get; set; }
        public int Kategorie { get; set; }

    }
}
