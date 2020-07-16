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
        //int questionNumber = 0;
        //int bandCounter = 0;
        int questionCounter = 1;
        List<List<string>> questionsAndAnswers;
        //string bandName;
        int totalQuestions;
        //List<string> choices;
        string rightAnswer;
        int score = 0;
        int gems = 0;
        double gameTime = 30.0;
        double timerCounter;
        bool timerBool = true;
        bool answerButtonIsClicked = false;
        int jokerCosts = 2;
        bool jokerIsUsed = false;

        
        




        public GamePage()
        {
            InitializeComponent();
            BindingContext = this;
            InitializeGameData();
            SetQuestionAndAnswer();
            SetLevel();
            SetScore();
            SetGems();
            EnableButtons();
            SetTimer();
        }

        public GamePage(int questionCounter, int score, int gems)
        {
            //this.questionNumber = questionNumber;
            //this.bandCounter = bandCounter;
            this.questionCounter = questionCounter;
            this.score = score;
            this.gems = gems;
            InitializeComponent();
            InitializeGameData();
            SetQuestionAndAnswer();
            SetLevel();
            SetScore();
            SetGems();
            EnableButtons();
            SetTimer();
        }


        private void answerButton_Clicked(object sender, EventArgs e)
        {
            if (jokerIsUsed)
            {
                CheckWithJoker(sender);
                SaveUserData();
            }
            else
            {
                answerButtonIsClicked = true;
                CheckAnswer(sender);
                DisableButtons();
                StopTimer();
                SetBandAndQuestionNumber();
                SaveUserData();
            }
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


        private void jokerButton_Clicked(object sender, EventArgs e)
        {            
            jokerUsed();
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
                jokerCosts = 2;
                SetQuestionAndAnswer();
                SetLevel();
                EnableButtons();
                SetTimer();
            }

        }
        //work with xaml elements: e.g. answerButton1.Text = "dick"; answerButton1.IsEnabled = false;

        public void SaveUserData()
        {
            //Settings.LastUsedQuestionNumber = questionNumber.ToString();
            //Settings.LastUsedBandCounter = bandCounter.ToString();
            Settings.LastUsedQuestionCounter = questionCounter.ToString();
            Settings.LastUsedScore = score.ToString();
            Settings.LastUsedGems = gems.ToString();
        }

        public void SetQuestionAndAnswer()
        {
            List<string> questionAndAnswer = questionsAndAnswers[(questionCounter - 1)];
            rightAnswer = questionAndAnswer[5];
            labelQuestion.Text = questionAndAnswer[0];
            answerButton1.Text = questionAndAnswer[1];
            answerButton2.Text = questionAndAnswer[2];
            answerButton3.Text = questionAndAnswer[3];
            answerButton4.Text = questionAndAnswer[4];
        }

        public void SetBandAndQuestionNumber()
        {
            questionCounter++;
            //questionNumber++;
            //if (questionNumber >= 3)
            //{
            //    questionNumber = 0;
            //    bandCounter++;
            //}
        }

        public void SetLevel()
        {
            labelLevel.Text = "Lvl " + questionCounter + "/" + totalQuestions;

        }

        public void SetScore()
        {
            labelScore.Text = "Score " + score;
        }

        public void SetGems()
        {
            labelGems.Text = $"Gems {gems}";
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
                gems++;
            }
            else
            {
                clickedButton.BackgroundColor = Color.FromHex("#FF0000");
            }
            SetScore();
            SetGems();
        }


        public void CheckWithJoker( object sender)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton.Text.Equals(rightAnswer))
            {
                clickedButton.BackgroundColor = Color.FromHex("#00FF00");
                clickedButton.IsEnabled = false;
                score++;
                gems++;
                SetScore();
                SetGems();
                DisableButtons();
                StopTimer();
                SetBandAndQuestionNumber();
                SaveUserData();
                score++;
                gems++;
            }
            else
            {
                clickedButton.BackgroundColor = Color.FromHex("#7D0000");
                clickedButton.IsEnabled = false;
            }
            jokerIsUsed = false;
            jokerButton.BackgroundColor = Color.FromHex("#000000");
        }



        public void jokerUsed()
        {
            if (jokerCosts <= gems)
            {
                gems -= jokerCosts;
                SetGems();
                jokerCosts = jokerCosts * 2;
                jokerIsUsed = true;
                jokerButton.BackgroundColor = Color.FromHex("#FFFFFF");
            }
            else
            {
                AlertNotEnoughGems();
            }
        }

        public void EnableButtons()
        {
            nextButton.IsEnabled = false;
            nextButton.BackgroundColor = Color.Gray;
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
            nextButton.BackgroundColor = Color.Black;
            answerButton1.IsEnabled = false;
            answerButton2.IsEnabled = false;
            answerButton3.IsEnabled = false;
            answerButton4.IsEnabled = false;
        }

        async private void AlertGameEnd()
        {
            await DisplayAlert("Congratulation!!!", "You have finished the game. Please end the game to restart", "OK");
        }

        async private void AlertNotEnoughGems()
        {
            await DisplayAlert("Sorry!!!", "You do not have enough GEMS", "OK");
        }

        public void InitializeGameData()
        {
            Questions questions = new Questions();
            questionsAndAnswers = questions.getAllQuestionsAndAnswers(questions.namesAndAnswers);
            //bandNames = questions.GetBandNames();
            totalQuestions = questionsAndAnswers.Count;
        }


    }
}