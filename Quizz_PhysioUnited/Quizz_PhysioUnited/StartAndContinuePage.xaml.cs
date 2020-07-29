using Quizz_PhysioUnited.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quizz_PhysioUnited
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartAndContinuePage : ContentPage
    {
        public StartAndContinuePage()
        {
            InitializeComponent();
            //soll den continue button freigeben, wenn eine frage beantwortet wurde
            if (Int32.Parse(Settings.QuestionCounterKatOne) == 1 &&  //funktioniert nur bei reload, nicht bei back per pop
                Int32.Parse(Settings.QuestionCounterKatTwo) == 1 &&
                Int32.Parse(Settings.QuestionCounterKatThree) == 1 &&
                Int32.Parse(Settings.QuestionCounterKatFour) == 1 )
            {
                ContinueGameButton.IsEnabled = false;
            } else
            {
                ContinueGameButton.IsEnabled = true;
            }
        }

        private async void NewGameButton_Clicked(object sender, EventArgs e)
        {
            Settings.QuestionCounterKatOne = "1";
            Settings.ScoreKatOne = "0";
            Settings.QuestionCounterKatTwo = "1";
            Settings.ScoreKatTwo = "0";
            Settings.QuestionCounterKatThree = "1";
            Settings.ScoreKatThree = "0";
            Settings.QuestionCounterKatFour = "1";
            Settings.ScoreKatFour = "0";
            Settings.Gems = "0";
            await Navigation.PushAsync(new StartScreen());
        }

        private async void ContinueGameButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartScreen());
        }
    }
}