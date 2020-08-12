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


        public Dictionary<string, string[]> namesAndAnswersKatOne = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> namesAndAnswersKatTwo = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> namesAndAnswersKatThree = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> namesAndAnswersKatFour = new Dictionary<string, string[]>();

        static List<Muskel> muskelList = new List<Muskel>();

        //static List<Band> bandList = new List<Band>();

        static string[] questions =
        {
                "Was ist die Innervation des\n*? ",
                "Was ist der Ursprung des\n*?",
                "Was ist der Ansatz des\n*?"
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
            muskelList = App.Database.GetMuskel();
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
                string[] answersMuskel = { muskel.Innervation, muskel.Ursprung, muskel.Ansatz};
                if (muskel.Kategorie == 1) 
                {
                    namesAndAnswersKatOne.Add(muskel.Name, answersMuskel);
                } 
                else if (muskel.Kategorie == 2)
                {
                    namesAndAnswersKatTwo.Add(muskel.Name, answersMuskel);
                }
                else if (muskel.Kategorie == 3)
                {
                    namesAndAnswersKatThree.Add(muskel.Name, answersMuskel);
                }
                else if (muskel.Kategorie == 4)
                {
                    namesAndAnswersKatFour.Add(muskel.Name, answersMuskel);
                }
            }

        }

        public List<List<string>> getAllQuestionsAndAnswers(Dictionary<string, string[]> dic)
        {
            List<List<string>> questionsAndAnswers = new List<List<string>>();
            int numberOfQuestions = questions.Length;
            foreach (KeyValuePair<string, string[]> kvp in dic)
            {                
                string bandName = kvp.Key;
                for (int i = 0; i < numberOfQuestions; i++)
                {                    
                    string rightAnswer = GetRightAnswer(dic, bandName, i);
                    if (string.IsNullOrEmpty(rightAnswer))
                    {
                        continue;
                    }
                    List<string> choices = GetChoices(dic, i, rightAnswer);
                    string question = GetQuestion(bandName, i);

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
    

        public List<string> GetBandNames(Dictionary<string, string[]> namesAndAnswers)
        {
            List<string> bandNames = new List<string>();
            foreach (KeyValuePair<string, string[]> kvp in namesAndAnswers)
            {
                bandNames.Add(kvp.Key);
            }
            return bandNames;
        }


        public static string GetQuestion(string bandName, int questionNumber)
        {
            string question = questions[questionNumber].Replace("*", bandName);
            return question;

        }

        public string GetRightAnswer(Dictionary<string, string[]> namesAndAnswers, string bandName, int questionNumber)
        {
            string[] answers = namesAndAnswers[bandName];
            string rightAnswer = answers[questionNumber];
            return rightAnswer;

        }

        public List<string> GetChoices(Dictionary<string, string[]> namesAndAnswers, int questionNumber, string rightAnswer)
        {
            List<string> choices = SetChoices(namesAndAnswers, questionNumber, rightAnswer);
            //FischerShuffle.ShuffleArray(choices);           //gives choices rnd positions in List
            Random rnd = new Random();
            int rightAnswerPos = rnd.Next(4);
            choices.Add(rightAnswer);
            choices.Insert(rightAnswerPos, rightAnswer);
            choices.RemoveAt(choices.Count - 1);
            //bis dahin löschen und fisher shuffle nicht mehr als Kommentar
            rightAnswerPos += 1;
            choices.Add(rightAnswerPos.ToString());
            return choices;
        }



        // function getChoices gets string with for choices 3 are from the answerpool based on the given number as parameter
        // 1 is corret answer
        // they mixed rnd
        // check if right anser == poolobject
        private static List<string> SetChoices(Dictionary<string, string[]> dic, int questionNumber, string rightAnswer)
        {
            List<string> choices = new List<string>();
            List<string> answerPool = new List<string>();
            Random r = new Random();
            //maybe make an seperate funcion for answer pool, so it doesnt run every time
            foreach (KeyValuePair<string, string[]> kvp in dic)
            {
                string[] answers = kvp.Value;
                answerPool.Add(answers[questionNumber]);
            }
            while (choices.Count < 3)
            {
                int rndNumber = r.Next((answerPool.Count));
                string currChoice = answerPool[rndNumber];
                if (!choices.Contains(currChoice)&&!currChoice.Equals(rightAnswer))
                {
                    choices.Add(currChoice);
                }
            }
            return choices;
        }


    }
}
