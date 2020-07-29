using System;
using System.Collections.Generic;
using System.IO;
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

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "datenbank.db3"));
                    //database.SetDataToDBFromList("1");
                    //database.SetDataToDBFromList("2");
                    //database.SetDataToDBFromList("3");
                    //database.SetDataToDBFromList("4");
                }
                return database;
            }
        }
        //public static BandDB BandDB
        //{
        //    get
        //    {
        //        if (bandDB == null)
        //        {
        //            bandDB = new BandDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bands.db3"));
        //        }
        //        return bandDB;
        //    }
        //}

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartAndContinuePage());
        }

        protected override void OnStart()
        {
            Questions questions = new Questions();
            QAListKatOne = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatOne);
            QAListKatTwo = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatTwo);
            QAListKatThree = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatThree);
            QAListKatFour = questions.getAllQuestionsAndAnswers(questions.namesAndAnswersKatFour);
    }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
