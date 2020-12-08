using Quizz_PhysioUnited.Utils;
using Quizz_PhysioUnited.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quizz_PhysioUnited
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartAndContinuePage : ContentPage, INotifyPropertyChanged
    {
       

        LoadingView LV = new LoadingView();

        //LoadingViewModel loadViewModel = new LoadingViewModel();

        public StartAndContinuePage()
        {
            InitializeComponent();
            //BindingContext = loadViewModel;
            //loadViewModel.IsLoading = false;
            //LoadingView LV = new LoadingView();
            LV.IsLoading = false;
            StaAConLayout.Children.Add(LV,
                xConstraint: Constraint.Constant(0),
                yConstraint: Constraint.Constant(0),
                widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));
            // Todo: wohin damit?
            //TryToGetNewData();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //TryToGetNewData();

            //soll den continue button freigeben, wenn eine frage beantwortet wurde
            if (Int32.Parse(Settings.QuestionCounterKatOne) == 1 &&  //funktioniert nur bei load, nicht bei back per pop
                Int32.Parse(Settings.QuestionCounterKatTwo) == 1 &&
                Int32.Parse(Settings.QuestionCounterKatThree) == 1 &&
                Int32.Parse(Settings.QuestionCounterKatFour) == 1)
            {
                //ContinueGameButton.Pressed -= ContinueGameButton_Pressed;
                ContinueGameButton.IsEnabled = false;
                ContinueImage.Opacity = 0.6;
            }
            else
            {
                ContinueGameButton.IsEnabled = true;
                //ContinueGameButton.Pressed += ContinueGameButton_Pressed;
                ContinueImage.Opacity = 1.0;

            }
        }

        private async void NewGameButton_Clicked(object sender, EventArgs e)
        {

            //same funktion has to exists in app start to update local muskel list (in the background)
            //to check the load just if connection to internet and check if db is modified
            LV.IsLoading = true;    //opens load screen

            //App.DatabaseAll.ResetMuskelDB();    //clears muskel table in local db; DEBUG

            if (App.DatabaseAll.IsMuskelDBEmpty())
            {
                Settings.ModifiedDateSaved = App.DatabaseAll.GetModifiedDate().ToString();
                if (InternetTester.TestConnection())
                {
                    await App.DatabaseAll.GetDataFromServer();

                    //save modified date in settings
                    Settings.ModifiedDateSaved = App.DatabaseAll.GetModifiedDate().ToString();
                    await StartNewGame();                    
                }
                else
                {
                    await DisplayAlert("Kein Internet", "Das Telefon muss für das Laden der aktuellen Fragen mit dem Internet verbunden sein", "Ok");
                }
            }
            else
            {
                if (InternetTester.TestConnection())
                {
                    DateTime modifiedDate = App.DatabaseAll.GetModifiedDate().Result;
                    DateTime lastLocalModifiedDate = Convert.ToDateTime(Settings.ModifiedDateSaved);

                    if (modifiedDate > lastLocalModifiedDate)
                    {
                        await App.DatabaseAll.GetDataFromServer();

                        //save modified date in settings
                        Settings.ModifiedDateSaved = App.DatabaseAll.GetModifiedDate().ToString();
                    }                    
                }                
                await StartNewGame();                
            }
            LV.IsLoading = false; //closes load screen
        }

        private async void ContinueGameButton_Clicked(object sender, EventArgs e)
        {
            LV.IsLoading = true;
            //await App.DatabaseAll.GetDataFromServer();
            App.setQALists();
            await Navigation.PushAsync(new StartScreen());
            LV.IsLoading = false;
        }


        private async void TryToGetNewData()
        {
            LV.IsLoading = true;    //opens load screen
            if (InternetTester.TestConnection())
            {

                DateTime modifiedDate = App.DatabaseAll.GetModifiedDate().Result;
                DateTime lastLocalModifiedDate = Convert.ToDateTime(Settings.ModifiedDateSaved);

                if (modifiedDate > lastLocalModifiedDate)
                {
                    await App.DatabaseAll.GetDataFromServer();

                    //save modified date in settings
                    Settings.ModifiedDateSaved = App.DatabaseAll.GetModifiedDate().ToString();
                }
            }
            LV.IsLoading = false; //closes load screen
        }

        private async Task StartNewGame()
        {
            QuestionsData.UpdateCurrentWithOriginal();
            App.setQALists();

            Settings.QuestionCounterKatOne = "1";
            Settings.ScoreKatOne = "0";
            Settings.AllQuestionsNrKatOne = App.QCountKatOne.ToString();
            Settings.ChanceBoolKatOne = "True";

            Settings.QuestionCounterKatTwo = "1";
            Settings.ScoreKatTwo = "0";
            Settings.AllQuestionsNrKatTwo = App.QCountKatTwo.ToString();
            Settings.ChanceBoolKatTwo = "True";

            Settings.QuestionCounterKatThree = "1";
            Settings.ScoreKatThree = "0";
            Settings.AllQuestionsNrKatThree = App.QCountKatThree.ToString();
            Settings.ChanceBoolKatThree = "True";

            Settings.QuestionCounterKatFour = "1";
            Settings.ScoreKatFour = "0";
            Settings.AllQuestionsNrKatFour = App.QCountKatFour.ToString();
            Settings.ChanceBoolKatFour = "True";

            Settings.Gems = "40";
            SetTimerValues("30");

            await Navigation.PushAsync(new StartScreen());
        }

        public static void SetTimerValues(string timerValue)
        {
            Settings.TimerValueKatOne = timerValue;
            Settings.TimerValueKatTwo = timerValue;
            Settings.TimerValueKatThree = timerValue;
            Settings.TimerValueKatFour = timerValue;
        }        


        private void NewGameButton_Pressed(object sender, EventArgs e)
        {
            NewGameImage_press.IsVisible = true;
        }

        private void NewGameButton_Released(object sender, EventArgs e)
        {
            NewGameImage_press.IsVisible = false;
        }

        private void ContinueGameButton_Pressed(object sender, EventArgs e)
        {
            ContinueImage_press.IsVisible = true;
        }

        private void ContinueGameButton_Released(object sender, EventArgs e)
        {
            ContinueImage_press.IsVisible = false;
        }

        private void CancelPopUpImpressum_Clicked(object sender, EventArgs e)
        {
            ImpressumPopUp.IsVisible = false;
        }

        private void CancelPopUpImpressum_Pressed(object sender, EventArgs e)
        {
            ImpressumCancelImage_pres.IsVisible = true;
        }

        private void CancelPopUpImpressum_Released(object sender, EventArgs e)
        {
            ImpressumCancelImage_pres.IsVisible = false;
        }

        private void ImpressumButton_Clicked(object sender, EventArgs e)
        {
            ImpressumPopUp.IsVisible = true;
        }

        private void ImpressumButton_Pressed(object sender, EventArgs e)
        {
            ImpressumImage_press.IsVisible = true;
        }

        private void ImpressumButton_Released(object sender, EventArgs e)
        {
            ImpressumImage_press.IsVisible = false;
        }
    }
}