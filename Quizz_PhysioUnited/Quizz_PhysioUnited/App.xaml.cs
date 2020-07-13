using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quizz_PhysioUnited
{
    public partial class App : Application
    {
        static Database database;
        static BandDB bandDB;

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
        public static BandDB BandDB
        {
            get
            {
                if (bandDB == null)
                {
                    bandDB = new BandDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bands.db3"));
                }
                return bandDB;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartScreen());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
