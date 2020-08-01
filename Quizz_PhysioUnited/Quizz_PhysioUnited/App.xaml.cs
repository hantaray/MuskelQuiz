using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quizz_PhysioUnited
{
    public partial class App : Application
    {
        static Database database;
        public static List<List<string>> QAListKatOne;
        public static List<List<string>> QAListKatTwo;
        public static List<List<string>> QAListKatThree;
        public static List<List<string>> QAListKatFour;
        public static int QCountKatOne;
        public static int QCountKatTwo;
        public static int QCountKatThree;
        public static int QCountKatFour;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "datenbank.db3"));
                }
                return database;
            }
        }
        

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartAndContinuePage());
        }

        protected override void OnStart()
        {            
        }

        protected override void OnSleep()
        {
            stopTimerOnSleep();
        }

        protected override void OnResume()
        {

            startTimerOnResume();
        }


        private static int getListCount(List<List<string>> list)
        {
            return list.Count;
        }


        private void stopTimerOnSleep()
        {
            Page currPage = MainPage.Navigation.NavigationStack.LastOrDefault();            
            if (currPage is GamePage && currPage != null)
            {
                GamePage gamePage = currPage as GamePage;
                gamePage.SaveTimerValue(gamePage.timerCounter);
                gamePage.StopTimer();
            }
        }

        private void startTimerOnResume()
        {
            Page currPage = MainPage.Navigation.NavigationStack.LastOrDefault();
            if (currPage is GamePage && currPage != null)
            {
                GamePage gamePage = currPage as GamePage;
                if (gamePage.questionRoundIsFinished != true)
                {
                    gamePage.StartTimerAgain();
                }
            }
        }

        public static void setQALists()
        {
            Questions questions = new Questions();
            QAListKatOne = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatOne);
            QAListKatTwo = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatTwo);
            QAListKatThree = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatThree);
            QAListKatFour = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatFour);
            QCountKatOne = getListCount(QAListKatOne);
            QCountKatTwo = getListCount(QAListKatOne);
            QCountKatThree = getListCount(QAListKatOne);
            QCountKatFour = getListCount(QAListKatOne);
        }

    }
}
