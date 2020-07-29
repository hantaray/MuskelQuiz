using Quizz_PhysioUnited.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Quizz_PhysioUnited
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class StartScreen : ContentPage
    {
        public static int Kategorie;
        
        public StartScreen()
        {
            InitializeComponent();
        }

        async void GoToGamePage(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            if (clickedButton.ClassId.Equals("ButtonKatOne"))
            {
                Kategorie = 1;
                await Navigation.PushAsync(new GamePage(App.QAListKatOne,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatOne),
                                                    Int32.Parse(Settings.ScoreKatOne),
                                                    Int32.Parse(Settings.Gems)
                                                    ));
            }
            else if (clickedButton.ClassId.Equals("ButtonKatTwo"))
            {
                Kategorie = 2;
                await Navigation.PushAsync(new GamePage(App.QAListKatTwo,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatTwo),
                                                    Int32.Parse(Settings.ScoreKatTwo),
                                                    Int32.Parse(Settings.Gems)
                                                    ));
            }
            else if (clickedButton.ClassId.Equals("ButtonKatThree"))
            {
                Kategorie = 3;
                await Navigation.PushAsync(new GamePage(App.QAListKatThree,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatThree),
                                                    Int32.Parse(Settings.ScoreKatThree),
                                                    Int32.Parse(Settings.Gems)
                                                    ));
            }
            else if (clickedButton.ClassId.Equals("ButtonKatFour"))
            {
                Kategorie = 4;
                await Navigation.PushAsync(new GamePage(App.QAListKatFour,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatFour),
                                                    Int32.Parse(Settings.ScoreKatFour),
                                                    Int32.Parse(Settings.Gems)
                                                    ));
            }

        }



        async void openDataBase_Clicked(object sender, EventArgs e)
        {
            //App.Database.SetDataToDBFromList();   //schreibt liste in database, liste befindet sich in Database.cs
            await Navigation.PushAsync(new DatabasePage());

        }
    }
}
