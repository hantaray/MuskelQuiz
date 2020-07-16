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
            await Navigation.PushAsync(new GamePage());
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
            await Navigation.PushAsync(new BandDBPage());
        }
    }
}
