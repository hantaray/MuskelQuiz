using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_PhysioUnited
{
    public class Frage
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FrageText { get; set; }
        public int AntwortID { get; set; }
    }
}
