using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_PhysioUnited
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public bool Next { get; set; }
        public int RightAnwerPosition { get; set; }
        public int Category { get; set; }


        //public int OrderNumber { get; set; }
    }
}
