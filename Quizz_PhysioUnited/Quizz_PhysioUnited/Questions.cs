using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz_PhysioUnited
{
    class Questions
    {


        public SortedDictionary<int, string[]> namesAndAnswersKatOne = new SortedDictionary<int, string[]>();  // UMBAU key wird int und sortedDictionary CHECK
        public SortedDictionary<int, string[]> namesAndAnswersKatTwo = new SortedDictionary<int, string[]>(); // UMBAU key wird int und sortedDictionary CHECK
        public SortedDictionary<int, string[]> namesAndAnswersKatThree = new SortedDictionary<int, string[]>();   // UMBAU key wird int und sortedDictionary CHECK
        public SortedDictionary<int, string[]> namesAndAnswersKatFour = new SortedDictionary<int, string[]>();    // UMBAU key wird int und sortedDictionary CHECK

        static List<Muskel> muskelList = new List<Muskel>();

        public List<List<string>> answerPool = new List<List<string>> { new List<string>() , new List<string>(), new List<string>() } ; 

        static string[] questions =
        {
                "Was ist die Innervation des *? ",
                "Was ist der Ursprung des *?",
                "Was ist der Ansatz des *?"
            };

        //int score = 0;
        //int questionCount;
        //string question;
        //List<List<string>> questionAndAnswers;

        public Questions()
        {
            //is there a better way to clear the dictionary, because if I dont clear, there's an exception
            namesAndAnswersKatOne.Clear();
            namesAndAnswersKatTwo.Clear();
            namesAndAnswersKatThree.Clear();
            namesAndAnswersKatFour.Clear();
            muskelList = App.DatabaseAll.GetMuskeln();
            SetDicionaries();
        }





        //public static void SetDicionary() { 
        //    string[] answersBand1 = { "1990", "Undertow", "4" };
        //    namesAndAnswers.Add("Tool", answersBand1);

        //        string[] answersBand2 = { "1975", "Motörhead", "3" };
        //    namesAndAnswers.Add("Motörhead", answersBand2);

        //        string[] answersBand3 = { "1991", "Wretch", "4" };
        //    namesAndAnswers.Add("Kyuss", answersBand3);

        //        string[] answersBand4 = { "1991", "Transnational Speedway League: Anthems, Anecdotes and Undeniable Truths", "4" };
        //    namesAndAnswers.Add("Clutch", answersBand4);

        //        string[] answersBand5 = { "1995", "Frequencies From Planet Ten", "5" };
        //    namesAndAnswers.Add("Orange Goblin", answersBand5);

        //        string[] answersBand6 = { "1992", "Atomic Bitchwax", "3" };
        //    namesAndAnswers.Add("Atomic Bitchwax", answersBand6);

        //        string[] answersBand7 = { "2005", "Malverde / Favorite Son", "4" };
        //    namesAndAnswers.Add("Red Fang", answersBand7);

        //        string[] answersBand8 = { "1996", "Do or Die", "6" };
        //    namesAndAnswers.Add("Dropkick Murphys", answersBand8);  
        //}



        public void SetDicionaries()
        {
            foreach (Muskel muskel in muskelList)
            {
                string[] answersAndName = { muskel.Innervation, muskel.Ursprung, muskel.Ansatz, muskel.Name}; // UMBAU list gets 4 strings CHECK
                if (muskel.Kategorie == 1) 
                {
                    namesAndAnswersKatOne.Add(muskel.Reihenfolge, answersAndName);
                } 
                else if (muskel.Kategorie == 2)
                {
                    namesAndAnswersKatTwo.Add(muskel.Reihenfolge, answersAndName);
                }
                else if (muskel.Kategorie == 3)
                {
                    namesAndAnswersKatThree.Add(muskel.Reihenfolge, answersAndName);
                }
                else if (muskel.Kategorie == 4)
                {
                    namesAndAnswersKatFour.Add(muskel.Reihenfolge, answersAndName);
                }
            }

        }

        public List<List<string>> getAllQuestionsAndAnswers(SortedDictionary<int, string[]> dic)
        {
            List<List<string>> questionsAndAnswers = new List<List<string>>();
            int countOfQuestions = questions.Length;
            SetAnswerPool(dic);

            foreach (KeyValuePair<int, string[]> kvp in dic)
            {                
                //wird int Reihenfolge
                //string bandName = kvp.Key;
                string[] anwersAndName = kvp.Value;
                string muskelName = anwersAndName[3];
                for (int questionNr = 0; questionNr < countOfQuestions; questionNr++)
                {
                    string rightAnswer = anwersAndName[questionNr];
                    //string rightAnswer = GetRightAnswer(dic, bandName, questionNr);
                    if (string.IsNullOrEmpty(rightAnswer))
                    {
                        continue;
                    }                    
                    
                    List<string> choices = GetChoices(questionNr, rightAnswer);
                    
                    
                    //name has to come from answer list, muskelName
                    string question = GetQuestion(muskelName, questionNr);

                    questionsAndAnswers.Add(new List<string> { question,
                                                               choices[0],
                                                               choices[1],
                                                               choices[2],
                                                               choices[3],
                                                               choices[4]
                                                              });                    
                }
            }
            return questionsAndAnswers;
        }    

       


        public static string GetQuestion(string muskelName, int questionNumber)
        {
            string question = questions[questionNumber].Replace("*", muskelName);
            return question;
        }


        //bandname muss zu index i as key werden
        ////public string GetRightAnswer(Dictionary<string, string[]> namesAndAnswers, string bandName, int questionNumber)
        ////{
        ////    string[] answers = namesAndAnswers[bandName];
        ////    string rightAnswer = answers[questionNumber];
        ////    return rightAnswer;

        ////}

        public List<string> GetChoices(int questionNumber, string rightAnswer)
        {
            List<string> choices = SetChoices(questionNumber, rightAnswer);            
            // adds the right randomly to choices
            Random rnd = new Random();
            int rightAnswerPos = rnd.Next(4);
            choices.Add(rightAnswer);
            choices.Insert(rightAnswerPos, rightAnswer);
            choices.RemoveAt(choices.Count - 1);
            // adds the position number of the right answer to choices
            rightAnswerPos += 1;
            choices.Add(rightAnswerPos.ToString());
            return choices;
        }



        // function getChoices gets string with for choices 3 are from the answerpool based on the given number as parameter
        // 1 is corret answer
        // they mixed rnd
        // check if right anser == poolobject


        //change dictionary type
        public List<string> SetChoices(int questionNumber, string rightAnswer)
        {
            List<string> choices = new List<string>();
            Random r = new Random();
            
            while (choices.Count < 3)
            {
                int rndNumber = r.Next((answerPool[questionNumber].Count));
                string currChoice = answerPool[questionNumber] [rndNumber];
                if (!choices.Contains(currChoice)&&!currChoice.Equals(rightAnswer))
                {
                    choices.Add(currChoice);
                }
            }
            return choices;
        }


        private void SetAnswerPool(SortedDictionary<int, string[]> dic)
        {
            foreach (List<string> list in answerPool)
            {
                list.Clear();
            }
            
            foreach (KeyValuePair<int, string[]> kpv in dic)
            {
                for (int i = 0; i < answerPool.Count; i++)
                {
                    answerPool[i].Add(kpv.Value[i]);
                }
            }
        }

        
        //private static List<string> SetChoices(SortedDictionary<int, string[]> dic, int questionNumber, string rightAnswer)
        //{
        //    List<string> choices = new List<string>();
        //    List<string> answerPool = new List<string>();
        //    Random r = new Random();
        //    //maybe make an seperate funcion for answer pool, so it doesnt run every time
        //    foreach (KeyValuePair<int, string[]> kvp in dic)
        //    {
        //        string[] answers = kvp.Value;
        //        answerPool.Add(answers[questionNumber]);
        //    }
        //    while (choices.Count < 3)
        //    {
        //        int rndNumber = r.Next((answerPool.Count));
        //        string currChoice = answerPool[rndNumber];
        //        if (!choices.Contains(currChoice)&&!currChoice.Equals(rightAnswer))
        //        {
        //            choices.Add(currChoice);
        //        }
        //    }
        //    return choices;
        //}
    }
}
