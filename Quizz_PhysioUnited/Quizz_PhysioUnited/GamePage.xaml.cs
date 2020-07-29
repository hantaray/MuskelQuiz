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


        //der next button zählt den questionCounter hoch und wenn größer als totalQuestions dann Ende

        int questionCounter;
        List<List<string>> questionsAndAnswers;
        int totalQuestions;
        string rightAnswer;
        int score;
        int gems;
        double gameTime = 30.0;
        double timerCounter;
        bool timerBool = true;
        bool questionRoundIsFinished = false;         //checks if answerButton was used or timer ran out, if not it starts timer again after pausing the game
        int jokerCosts = 2;
        bool jokerIsUsed = false;

        
        




        public GamePage(List<List<string>> questionsAndAnswers)
        {
            this.questionsAndAnswers = questionsAndAnswers;
            InitializeComponent();
            InitializeGameData();
            SetQuestionAndAnswer();
            SetLevel();
            SetScore();
            SetGems();
            EnableButtons();
            SetTimer();
        }

        public GamePage(List<List<string>> questionsAndAnswers, int questionCounter, int score, int gems)
        {
            this.questionsAndAnswers = questionsAndAnswers;
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
                questionRoundIsFinished = true;
                CheckAnswer(sender);
                DisableButtons();
                StopTimer();
                QuestionCounterPlus();
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
                if (!questionRoundIsFinished)
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
            if (questionCounter > totalQuestions)
            {
                AlertGameEnd();
            }
            else
            {
                questionRoundIsFinished = false;
                jokerCosts = 2;
                SetQuestionAndAnswer();
                SetLevel();
                EnableButtons();
                SetTimer();
            }

        }

        public void SaveUserData()
        {
            int kat = StartScreen.Kategorie;
            if (kat == 1)
            {
                Settings.QuestionCounterKatOne = questionCounter.ToString();
                Settings.ScoreKatOne = score.ToString();
            } 
            else if (kat == 2)
            {
                Settings.QuestionCounterKatTwo = questionCounter.ToString();
                Settings.ScoreKatTwo = score.ToString();
            } else if (kat == 3)
            {
                Settings.QuestionCounterKatThree = questionCounter.ToString();
                Settings.ScoreKatThree = score.ToString();
            } else if (kat == 4)
            {
                Settings.QuestionCounterKatFour = questionCounter.ToString();
                Settings.ScoreKatFour = score.ToString();
            }
            Settings.Gems = gems.ToString();
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

        public void QuestionCounterPlus()
        {
            questionCounter++;            
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
            GameTimer();
        }

        public void StopTimer()
        {
            timerBool = false;
        }

        public void StartTimerAgain()
        {
            timerBool = true;
            GameTimer();
        }

        private void GameTimer()
        {
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 100), () =>
            {
                // do something every 0.1 seconds
                timerCounter = Math.Round(timerCounter, 1) - 0.1;
                if (timerCounter == 0.0)
                {
                    timerBool = false;
                    DisableButtons();
                    questionRoundIsFinished = true;

                }
                labelTimer.Text = timerCounter.ToString("0.0");
                return timerBool; // true => runs again, false => stops
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
                QuestionCounterPlus();
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
            totalQuestions = questionsAndAnswers.Count;
        }


    }
}