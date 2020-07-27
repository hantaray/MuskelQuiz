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
    [DesignTimeVisible(false)]
    public partial class StartScreen : ContentPage
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        async void GoToGamePage(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            if (clickedButton.ClassId.Equals("ButtonKatOne"))
            {
                await Navigation.PushAsync(new GamePage(App.QAListKatOne));
            }
            else if (clickedButton.ClassId.Equals("ButtonKatTwo"))
            {
                await Navigation.PushAsync(new GamePage(App.QAListKatTwo));
            }
            else if (clickedButton.ClassId.Equals("ButtonKatThree"))
            {
                await Navigation.PushAsync(new GamePage(App.QAListKatThree));
            }
            else if (clickedButton.ClassId.Equals("ButtonKatFour"))
            {
                await Navigation.PushAsync(new GamePage(App.QAListKatFour));
            }

        }

        private async void ContinueGameButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new GamePage(
                                                    //Int32.Parse(Settings.LastUsedQuestionNumber),
                                                    //Int32.Parse(Settings.LastUsedBandCounter),
                                                    Int32.Parse(Settings.LastUsedQuestionCounter),
                                                    Int32.Parse(Settings.LastUsedScore),
                                                    Int32.Parse(Settings.LastUsedGems)
                                                    ));
        }

        async void openDataBase_Clicked(object sender, EventArgs e)
        {
            //App.Database.SetDataToDBFromList();   //schreibt liste in database, liste befindet sich in Database.cs
            await Navigation.PushAsync(new DatabasePage());

        }
    }
}
