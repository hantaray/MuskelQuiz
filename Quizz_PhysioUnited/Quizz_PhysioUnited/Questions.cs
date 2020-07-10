using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Quizz_PhysioUnited
{
    class Questions
    {


        static Dictionary<string, string[]> namesAndAnswers = new Dictionary<string, string[]>();

        static string[] questions =
        {
                "When did * get founded? ",
                "What is the name of *'s first album?",
                "How many members does * have?"
            };

        //int score = 0;
        //int questionCount;
        //string question;
        //List<List<string>> questionAndAnswers;

        public Questions()
        {
            //is there a better way to clear the dictionary, because if I dont clear, there's an exception
            namesAndAnswers.Clear();
            SetDicionary();
        }



        public static void SetDicionary() { 
            string[] answersBand1 = { "1990", "Undertow", "4" };
            namesAndAnswers.Add("Tool", answersBand1);

                string[] answersBand2 = { "1975", "Motörhead", "3" };
            namesAndAnswers.Add("Motörhead", answersBand2);

                string[] answersBand3 = { "1991", "Wretch", "4" };
            namesAndAnswers.Add("Kyuss", answersBand3);

                string[] answersBand4 = { "1991", "Transnational Speedway League: Anthems, Anecdotes and Undeniable Truths", "4" };
            namesAndAnswers.Add("Clutch", answersBand4);

                string[] answersBand5 = { "1995", "Frequencies From Planet Ten", "5" };
            namesAndAnswers.Add("Orange Goblin", answersBand5);

                string[] answersBand6 = { "1992", "Atomic Bitchwax", "3" };
            namesAndAnswers.Add("Atomic Bitchwax", answersBand6);

                string[] answersBand7 = { "2005", "Malverde / Favorite Son", "4" };
            namesAndAnswers.Add("Red Fang", answersBand7);

                string[] answersBand8 = { "1996", "Do or Die", "6" };
            namesAndAnswers.Add("Dropkick Murphys", answersBand8);  
        }


        public List<string> GetBandNames()
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

        public static string GetRightAnswer(string bandName, int questionNumber)
        {
            string[] answers = namesAndAnswers[bandName];
            string rightAnswer = answers[questionNumber];
            return rightAnswer;

        }

        public static List<string> GetChoices(int questionNumber, string rightAnswer)
        {
            List<string> choices = SetChoices(namesAndAnswers, questionNumber, rightAnswer);
            FischerShuffle.ShuffleArray(choices);           //gives choices rnd positions in List
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

            choices.Add(rightAnswer);

            while (true)
            {
                int rndNumber = r.Next((answerPool.Count));
                string currChoice = answerPool[rndNumber];
                if (!choices.Contains(currChoice))
                {
                    choices.Add(currChoice);
                }
                if (choices.Count == 4)
                {
                    break;
                }
            }
            
            return choices;
        }


    }
}
