using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_PhysioUnited
{
    public static class QuestionsData
    {




        public static List<Question> GetCurrentQuestionsList(int category)
        {            
            if (App.DatabaseAll.IsQuestionDBEmpty())
            {
                UpdateCurrentWithOriginal();
            }
            //List<Question> questionList = new List<Question>();
            List<Question>  questionList = App.DatabaseAll.GetQuestions(category);
            return questionList;
        }

        public static void UpdateCurrentWithOriginal()
        {
            //lösche Einträge aus Datenbank
            App.DatabaseAll.ResetQuestionDB();
            Questions questions = new Questions();
            List<List<string>> QAListKatOne = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatOne);   
            List<List<string>> QAListKatTwo = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatTwo);    
            List<List<string>> QAListKatThree = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatThree);    
            List<List<string>> QAListKatFour = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatFour);
            AddQuestionListToDB(QAListKatOne, 1);
            AddQuestionListToDB(QAListKatTwo, 2);
            AddQuestionListToDB(QAListKatThree, 3);
            AddQuestionListToDB(QAListKatFour, 4);
        }

        public static void UpdateCurrentWithOriginalByCat(int category)
        {
            Questions questions = new Questions();
            //bei Fehler testen ob dicionaries gebaut werden
            if (category == 1)
            {
                App.DatabaseAll.DeleteQuestionsByCategoryInDB(category);
                List<List<string>> QAListKatOne = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatOne);
                AddQuestionListToDB(QAListKatOne, 1);
            } 
            else if (category == 2)
            {
                App.DatabaseAll.DeleteQuestionsByCategoryInDB(category);
                List<List<string>> QAListKatTwo = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatTwo);
                AddQuestionListToDB(QAListKatTwo, 2);
            }
            else if (category == 3)
            {
                App.DatabaseAll.DeleteQuestionsByCategoryInDB(category);
                List<List<string>> QAListKatThree = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatThree);
                AddQuestionListToDB(QAListKatThree, 3);
            } 
            else if (category == 4)
            {
                App.DatabaseAll.DeleteQuestionsByCategoryInDB(category);
                List<List<string>> QAListKatFour = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatFour);
                AddQuestionListToDB(QAListKatFour, 4);
            }
        }

        static void AddQuestionListToDB(List<List<string>> questionList, int category)
        {
            foreach (List<string> question in questionList)
            {
                Question questionNew = new Question
                {
                    QuestionText = question[0],
                    Choice1 = question[1],
                    Choice2 = question[2],
                    Choice3 = question[3],
                    Choice4 = question[4],
                    RightAnwerPosition = Int32.Parse(question[5]),
                    Category = category,
                    Next = true
                };
                App.DatabaseAll.SaveQuestion(questionNew);
            }
        }


        public static void UpdateCurrentWithNext(int category)
        {
            App.DatabaseAll.FilterOnlyNextQuestionsInDB(category);
        }



    }
}
