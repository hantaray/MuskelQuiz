﻿using Quizz_PhysioUnited.Utils;
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
            //var image = new Image { Source = "Button_lang.jpg" };


            //soll den continue button freigeben, wenn eine frage beantwortet wurde
            if (Int32.Parse(Settings.QuestionCounterKatOne) == 1 &&  //funktioniert nur bei load, nicht bei back per pop
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //soll den continue button freigeben, wenn eine frage beantwortet wurde
            if (Int32.Parse(Settings.QuestionCounterKatOne) == 1 &&  //funktioniert nur bei load, nicht bei back per pop
                Int32.Parse(Settings.QuestionCounterKatTwo) == 1 &&
                Int32.Parse(Settings.QuestionCounterKatThree) == 1 &&
                Int32.Parse(Settings.QuestionCounterKatFour) == 1)
            {
                ContinueGameButton.IsEnabled = false;
            }
            else
            {
                ContinueGameButton.IsEnabled = true;
            }
        }

        private async void NewGameButton_Clicked(object sender, EventArgs e)
        {
            await App.DatabaseAll.GetDataFromServer();
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

            Settings.Gems = "0";
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

        private async void ContinueGameButton_Clicked(object sender, EventArgs e)
        {
            await App.DatabaseAll.GetDataFromServer();
            App.setQALists();
            await Navigation.PushAsync(new StartScreen());
        }


        private void NewGameButton_Pressed(object sender, EventArgs e)
        {
            NewGameImage.Source = "Button_lang_pres.gif";
        }

        private void NewGameButton_Released(object sender, EventArgs e)
        {
            NewGameImage.Source = "Button_lang.gif";
        }

        private void ContinueGameButton_Pressed(object sender, EventArgs e)
        {
            ContinueImage.Source = "Button_lang_pres.gif";
        }

        private void ContinueGameButton_Released(object sender, EventArgs e)
        {
            ContinueImage.Source = "Button_lang.gif";
        }
    }
}