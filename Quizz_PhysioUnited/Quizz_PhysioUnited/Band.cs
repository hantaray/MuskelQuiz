using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_PhysioUnited
{
    public class Band
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Founded { get; set; }
        public string FirstAlbumName { get; set; }
        public int Members { get; set; }
    }
}
