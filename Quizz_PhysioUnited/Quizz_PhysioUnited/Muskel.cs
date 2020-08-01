using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_PhysioUnited
{
    public class Muskel
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("innervation")]
        public string Innervation { get; set; }
        [JsonProperty("ursprung")]
        public string Ursprung { get; set; }
        [JsonProperty("ansatz")]
        public string Ansatz { get; set; }
        [JsonProperty("kategorie")]
        public int Kategorie { get; set; } 

    }
    //Wird für die Iteration über das JsonConvert.DeserializeObject benötigt - sie Database.cs -> GetDataFromServer()
    public class RootMuskel
    {
        public List<Muskel> Muskeln { get; set; }
    }
}
