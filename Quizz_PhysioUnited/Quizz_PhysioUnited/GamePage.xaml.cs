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
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
        }


        private async void GoToStartScreen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private void answerButton_Clicked(object sender, EventArgs e)
        {
            answerButton1.BackgroundColor = Color.FromHex("#FF0000");
        }
        //work with xaml elements: e.g. answerButton1.Text = "dick"; answerButton1.IsEnabled = false;
    }
}