using Quizz_PhysioUnited.Utils;
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
        //if you reached the end of the game and press continue gamae after closing the app, theres a excetion


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
        double gameTime = 30.0;
        double timerCounter;
        bool timerBool = true;
        bool answerButtonIsClicked = false;





        public GamePage()
        {
            InitializeComponent();
            InitializeGameData();
            SetQuestionAndAnswer();
            SetLevel();
            SetScore();
            EnableButtons();
            SetTimer();
        }

        public GamePage(int questionNumber, int bandCounter, int questionCounter, int score)
        {
            this.questionNumber = questionNumber;
            this.bandCounter = bandCounter;
            this.questionCounter = questionCounter;
            this.score = score;
            InitializeComponent();
            InitializeGameData();
            SetQuestionAndAnswer();
            SetLevel();
            SetScore();
            EnableButtons();
            SetTimer();
        }


        private void answerButton_Clicked(object sender, EventArgs e)
        {
            answerButtonIsClicked = true;
            CheckAnswer(sender);
            DisableButtons();
            StopTimer();
            SetBandAndQuestionNumber();
            SaveUserData();
        }

        private async void endButton_Clicked(object sender, EventArgs e)
        {
            StopTimer();
            bool answer = await DisplayAlert("Sure?", "Would you like to end the game?", "Yes", "No");
            if (answer)
            {
                await Navigation.PopAsync();
            }
            else
            {
                if (!answerButtonIsClicked)
                {
                    StartTimerAgain();
                };
            }
        }

        private void nextButton_Clicked(object sender, EventArgs e)
        {
            //SetBandAndQuestionNumber();            
            if (questionCounter > totalQuestions)
            {
                AlertGameEnd();
                //return;
            }
            else
            {
                answerButtonIsClicked = false;
                SetQuestionAndAnswer();
                SetLevel();
                EnableButtons();
                SetTimer();
            }

        }
        //work with xaml elements: e.g. answerButton1.Text = "dick"; answerButton1.IsEnabled = false;

        public void SaveUserData()
        {
            Settings.LastUsedQuestionNumber = questionNumber.ToString();
            Settings.LastUsedBandCounter = bandCounter.ToString();
            Settings.LastUsedQuestionCounter = questionCounter.ToString();
            Settings.LastUsedScore = score.ToString();
        }

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

        public void SetTimer()
        {
            timerBool = true;
            timerCounter = gameTime;
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 100), () =>
            {
                // do something every 1 seconds
                timerCounter = Math.Round(timerCounter, 1) - 0.1;
                if (timerCounter == 0.0)
                {
                    timerBool = false;
                    DisableButtons();

                }
                labelTimer.Text = timerCounter.ToString("0.0");
                return timerBool; // runs again, or false to stop
            });
        }

        public void StopTimer()
        {
            timerBool = false;
        }

        public void StartTimerAgain()
        {
            timerBool = true;
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 100), () =>
            {
                // do something every 1 seconds
                timerCounter = Math.Round(timerCounter, 1) - 0.1;
                if (timerCounter == 0.0)
                {
                    timerBool = false;
                    DisableButtons();

                }
                labelTimer.Text = timerCounter.ToString("0.0");
                return timerBool; // runs again, or false to stop
            });
        }

        public void CheckAnswer(object sender)
        {

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
            nextButton.IsEnabled = false;
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
            nextButton.IsEnabled = true;
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