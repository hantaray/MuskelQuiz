using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quizz_PhysioUnited
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class GamePage : ContentPage
    {

        //der next button zählt die questionNumber hoch und wenn größer als 2 dann auf null gesetzt und bandCounter geht eins hoch
        int questionNumber = 0;
        int bandCounter = 0;
        int questionCounter = 1;
        List<string> bandNames;
        string bandName;
        int totalQuestions;
        List<string> choices;
        string rightAnswer;
        int score = 0;



        public GamePage()
        {
            InitializeComponent();
            InitializeGameData();
            SetQuestionAndAnswer();
            SetLevel();
            SetScore();
            EnableButtons();
            nextButton.IsEnabled = false;
        }


        private void answerButton_Clicked(object sender, EventArgs e)
        {
            CheckAnswer(sender);
            nextButton.IsEnabled = true;
        }

        private async void endButton_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Sure?", "Would you like to end the game?", "Yes", "No");
            if (answer)
            {
                await Navigation.PopAsync();
            }
        }

        private void nextButton_Clicked(object sender, EventArgs e)
        {
            SetBandAndQuestionNumber();
            if (questionCounter > totalQuestions)
            {
                AlertGameEnd();
                //return;
            } else
            {                
                SetQuestionAndAnswer();
                SetLevel();
                EnableButtons();
                nextButton.IsEnabled = false;
            }

        }
        //work with xaml elements: e.g. answerButton1.Text = "dick"; answerButton1.IsEnabled = false;

        public void SetQuestionAndAnswer()
        {
            bandName = bandNames[bandCounter];
            rightAnswer = Questions.GetRightAnswer(bandName, questionNumber);
            choices = Questions.GetChoices(questionNumber, rightAnswer);
            labelQuestion.Text = Questions.GetQuestion(bandName, questionNumber);
            answerButton1.Text = choices[0];
            answerButton2.Text = choices[1];
            answerButton3.Text = choices[2];
            answerButton4.Text = choices[3];
        }

        public void SetBandAndQuestionNumber()
        {
            questionCounter++;
            questionNumber++;
            if (questionNumber >= 3)
            {
                questionNumber = 0;
                bandCounter++;
            }
        }

        public void SetLevel()
        {
            labelLevel.Text = "Lvl " + questionCounter + "/" + totalQuestions;
            
        }

        public void SetScore()
        {
            labelScore.Text = "Score " + score;
        }

        public void CheckAnswer(object sender)
        {
            DisableButtons();
            Button clickedButton = (Button)sender;
            if (clickedButton.Text.Equals(rightAnswer))
            {
                clickedButton.BackgroundColor = Color.FromHex("#00FF00");
                score++;
            } 
            else
            {
                clickedButton.BackgroundColor = Color.FromHex("#FF0000");
            }
            SetScore();
        }

        public void EnableButtons()
        {
            answerButton1.IsEnabled = true;
            answerButton2.IsEnabled = true;
            answerButton3.IsEnabled = true;
            answerButton4.IsEnabled = true;
            answerButton1.BackgroundColor = Color.DarkGray;
            answerButton2.BackgroundColor = Color.DarkGray;
            answerButton3.BackgroundColor = Color.DarkGray;
            answerButton4.BackgroundColor = Color.DarkGray;
        }

        public void DisableButtons()
        {
            answerButton1.IsEnabled = false;
            answerButton2.IsEnabled = false;
            answerButton3.IsEnabled = false;
            answerButton4.IsEnabled = false;
        }

        async private void AlertGameEnd()
        {
            await DisplayAlert("Congratulation!!!", "You have finished the game. Please end the game to restart", "OK");
        }

        public void InitializeGameData()
        {
            Questions questions = new Questions();
            bandNames = questions.GetBandNames();
            totalQuestions = bandNames.Count * 3;
        }



    }
}