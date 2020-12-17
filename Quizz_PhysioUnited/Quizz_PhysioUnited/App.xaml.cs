using MarcTron.Plugin;
using MarcTron.Plugin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Quizz_PhysioUnited
{
    public partial class App : Application
    {
        static Database database;
        public static List<Question> QAListKatOne;
        public static List<Question> QAListKatTwo;
        public static List<Question> QAListKatThree;
        public static List<Question> QAListKatFour;
        public static int QCountKatOne;
        public static int QCountKatTwo;
        public static int QCountKatThree;
        public static int QCountKatFour;

        public static Database DatabaseAll
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

            //CrossMTAdmob.Current.AdsId = "ca-app-pub-3940256099942544/6300978111";

            //MTAdView ads = new MTAdView();
            //ads.AdsId = "ca-app-pub-3940256099942544/6300978111";
            ////ads.PersonalizedAds = true;

            //var page = new ContentPage();
            //page.Title = "My Page";
            //var content = new StackLayout();
            //// add content controls to layout here
            //// you could prompt the user for input - ie, how many buttons, or labels, etc
            //// and populate the stack accordingly
            //content.Children.Add(ads);
            //page.Content = content;

            //MainPage = new NavigationPage(new AdsPage());
            //MainPage = new NavigationPage(new StartAndContinuePage());
            MainPage = new NavigationPage(new LoadingPage());    //final
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


        private static int getListCount(List<Question> list)
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
            QAListKatOne = QuestionsData.GetCurrentQuestionsList(1);   //GetCurrentQuestionsList(kategorie1)
            QAListKatTwo = QuestionsData.GetCurrentQuestionsList(2);    //GetCurrentQuestionsList(kategorie2)
            QAListKatThree = QuestionsData.GetCurrentQuestionsList(3);    //GetCurrentQuestionsList(kategorie3)
            QAListKatFour = QuestionsData.GetCurrentQuestionsList(4);      //GetCurrentQuestionsList(kategorie4)
            QCountKatOne = getListCount(QAListKatOne);
            QCountKatTwo = getListCount(QAListKatTwo);
            QCountKatThree = getListCount(QAListKatThree);
            QCountKatFour = getListCount(QAListKatFour);
        }

    }
}
