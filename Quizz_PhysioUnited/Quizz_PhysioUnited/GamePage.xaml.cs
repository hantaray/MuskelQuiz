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
        List<Question> questionsAndAnswers;
        Question questionAndAnswer;
        int totalQuestions;
        int rightAnswer;
        int score;
        int allQuestionsNr;
        int gems;
        double gameTime = 30.0;
        public double timerCounter;
        bool timerBool = true;
        public bool questionRoundIsFinished = false;         //checks if answerButton was used or timer ran out, if not it starts timer again after pausing the game
        int jokerCosts = 2;
        bool jokerIsUsed = false;
        bool TimerRestarts = false;


        public static string responseBody; //was is das?



        public GamePage(List<Question> questionsAndAnswers, int questionCounter, int score, int allQuestionsNr, int gems, double timerCounter)
        {            
            this.questionsAndAnswers = questionsAndAnswers;
            this.questionCounter = questionCounter;
            this.score = score;
            this.allQuestionsNr = allQuestionsNr;
            this.gems = gems;
            this.timerCounter = timerCounter;
            InitializeComponent();
            InitializeGameData();            
            SetQuestionAndAnswer();
            SetLevel();
            SetScore();
            SetGems();
            EnableButtons();
            StartTimerAgain();            
        }


        private void answerButton_Clicked(object sender, EventArgs e)
        {
            if (jokerIsUsed)
            {
                CheckWithJoker(sender);
                SaveUserData();
                jokerButton.IsEnabled = true;
                JokerImage.Opacity = 1;
                TextBubbleGrid.IsVisible = false;
            }
            else
            {
                questionRoundIsFinished = true;
                CheckAnswer(sender);
                DisableButtons();
                StopTimer();
                TimerRestarts = true;
                QuestionCounterPlus();
                SaveUserData();
            }
        }

        private void endButton_Clicked(object sender, EventArgs e)
        {
            SaveTimerValue(timerCounter);
            endBack();
        }

        public async void endBack()
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
            jokerButton.IsEnabled = false;
            JokerImage.Opacity = 0.45;
            TextBubbleGrid.IsVisible = true;
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

        public void SaveTimerValue(double timerCounter)
        {
            int kat = StartScreen.Kategorie;
            if (kat == 1)
            {
                Settings.TimerValueKatOne = timerCounter.ToString();                
            }
            else if (kat == 2)
            {
                Settings.TimerValueKatTwo = timerCounter.ToString();
            }
            else if (kat == 3)
            {
                Settings.TimerValueKatThree = timerCounter.ToString();
            }
            else if (kat == 4)
            {
                Settings.TimerValueKatFour = timerCounter.ToString();
            }
        }

        public void SetQuestionAndAnswer()
        {
            questionAndAnswer = questionsAndAnswers[(questionCounter - 1)];
            rightAnswer = questionAndAnswer.RightAnwerPosition;
            labelQuestion.Text = questionAndAnswer.QuestionText;
            answerButton1.Text = questionAndAnswer.Choice1;
            answerButton2.Text = questionAndAnswer.Choice2;
            answerButton3.Text = questionAndAnswer.Choice3;
            answerButton4.Text = questionAndAnswer.Choice4;
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
            double scoreProcent = (((double)score * 100) / (double)allQuestionsNr);
            scoreProcent = Math.Round(scoreProcent, 0);
            labelScore.Text = "Score " + scoreProcent + "%";
        }

        public void SetGems()
        {
            jokerButton_Label.Text = $"{gems}";
        }


        public void SetTimer()
        {
            timerBool = true;
            timerCounter = gameTime;
            TimerRestarts = false;
            GameTimer();
        }

        public void StopTimer()
        {
            timerBool = false;
        }

        public void StartTimerAgain()
        {
            timerBool = true;
            TimerRestarts = false;
            GameTimer();
        }

        private void GameTimer()
        {
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 100), () =>
            {
                // do something every 0.1 seconds
                timerCounter = Math.Round(timerCounter, 1) - 0.1;
                if (timerCounter < 0.00000)
                {
                    timerBool = false;
                    DisableButtons();
                    SetAnswerButtonTransperent();
                    questionRoundIsFinished = true;
                    labelTimer.Text = "0,0";
                    QuestionCounterPlus();
                    timerCounter = gameTime;
                    SaveUserData();
                }
                else
                {
                    labelTimer.Text = timerCounter.ToString("0.0");
                }
                if (TimerRestarts)
                {
                    timerCounter = gameTime;
                }
                return timerBool; // true => runs again, false => stops
            });
        }

        public void CheckAnswer(object sender)

        {            
            Button clickedButton = (Button)sender;
            int buttonNumber = (int)Char.GetNumericValue(clickedButton.ClassId.Last());
            if (buttonNumber == rightAnswer)
            {
                //clickedButton.BackgroundColor = Color.FromHex("#00FF00");
                SetImageForCorrectAnswer(buttonNumber);
                score++;
                gems++;
                //remove question from NextQuestionsList database by setting next attribue to false
                App.DatabaseAll.SetQuestionAsNextFalse(questionAndAnswer);
            }
            else
            {
                //clickedButton.BackgroundColor = Color.FromHex("#FF0000");
                SetImageForWrongAnswer(buttonNumber);
            }
            SetScore();
            SetGems();
        }


        public void CheckWithJoker( object sender)
        {
            Button clickedButton = (Button)sender;
            int buttonNumber = (int)Char.GetNumericValue(clickedButton.ClassId.Last());
            if (buttonNumber == rightAnswer)
            {
                //clickedButton.BackgroundColor = Color.FromHex("#00FF00");
                SetImageForCorrectAnswer(buttonNumber);
                score++;
                gems++;
                //remove question from NextQuestionsList database by setting next attribue to false
                App.DatabaseAll.SetQuestionAsNextFalse(questionAndAnswer);
                SetScore();
                SetGems();
                DisableButtons();
                StopTimer();
                TimerRestarts = true;
                QuestionCounterPlus();
                SaveUserData();                
            }
            else
            {
                //clickedButton.BackgroundColor = Color.FromHex("#7D0000");
                SetImageWrongAnswerJoker(buttonNumber);
                clickedButton.InputTransparent = true;

            }
            jokerIsUsed = false;
            //jokerButton.BackgroundColor = Color.FromHex("#000000");
        }



        public void jokerUsed()
        {
            if (jokerCosts <= gems)
            {
                gems -= jokerCosts;
                SetGems();
                jokerCosts *= 2;
                jokerIsUsed = true;
                //jokerButton.BackgroundColor = Color.FromHex("#FFFFFF");
            }
            else
            {
                AlertNotEnoughGems();
            }
        }

        public void EnableButtons()
        {
            double opacity = 1.0;
            nextButton.IsEnabled = false;
            NextImage.Opacity = 0.45;
            AnswerOneImage.Opacity = opacity;
            AnswerTwoImage.Opacity = opacity;
            AnswerThreeImage.Opacity = opacity;
            AnswerFourImage.Opacity = opacity;
            answerButton1.InputTransparent = false;
            answerButton2.InputTransparent = false;
            answerButton3.InputTransparent = false;
            answerButton4.InputTransparent = false;
            //answerButton1.BackgroundColor = Color.Transparent;
            //answerButton2.BackgroundColor = Color.DarkGray;
            //answerButton3.BackgroundColor = Color.DarkGray;
            //answerButton4.BackgroundColor = Color.DarkGray;
            AnswerOneImage.Source = "button_lang.png";
            AnswerTwoImage.Source = "button_lang.png";
            AnswerThreeImage.Source = "button_lang.png";
            AnswerFourImage.Source = "button_lang.png";
        }

        
        public void SetAnswerButtonTransperent()
        {
            double opacity = 0.6;
            AnswerOneImage.Opacity = opacity;
            AnswerTwoImage.Opacity = opacity;
            AnswerThreeImage.Opacity = opacity;
            AnswerFourImage.Opacity = opacity;
        }
        
        public void DisableButtons()
        {
            nextButton.IsEnabled = true;
            NextImage.Opacity = 1.0;
            //answerButton1.IsEnabled = false;
            //answerButton2.IsEnabled = false;
            //answerButton3.IsEnabled = false;
            //answerButton4.IsEnabled = false;
            answerButton1.InputTransparent = true;
            answerButton2.InputTransparent = true;
            answerButton3.InputTransparent = true;
            answerButton4.InputTransparent = true;
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

        protected override bool OnBackButtonPressed()
        {
            SaveTimerValue(timerCounter);
            endBack();
            //return base.OnBackButtonPressed();
            return true;
        }

        void SetImageForCorrectAnswer(int buttonNumber)
        {
            double opacity = 0.6;
            if (buttonNumber == 1)
            {
                AnswerOneImage.Source = "button_lang_gruen_press.png";
                AnswerTwoImage.Opacity = opacity;
                AnswerThreeImage.Opacity = opacity;
                AnswerFourImage.Opacity = opacity;
            }
            if (buttonNumber == 2)
            {
                AnswerTwoImage.Source = "button_lang_gruen_press.png";
                AnswerOneImage.Opacity = opacity;
                AnswerThreeImage.Opacity = opacity;
                AnswerFourImage.Opacity = opacity;
            }
            if (buttonNumber == 3)
            {
                AnswerThreeImage.Source = "button_lang_gruen_press.png";
                AnswerOneImage.Opacity = opacity;
                AnswerTwoImage.Opacity = opacity;
                AnswerFourImage.Opacity = opacity;
            }
            if (buttonNumber == 4)
            {
                AnswerFourImage.Source = "button_lang_gruen_press.png";
                AnswerOneImage.Opacity = opacity;
                AnswerTwoImage.Opacity = opacity;
                AnswerThreeImage.Opacity = opacity;
            }
        }

        void SetImageForWrongAnswer(int buttonNumber)
        {
            double opacity = 0.6;
            if (buttonNumber == 1)
            {
                AnswerOneImage.Source = "button_lang_rot_press.png";
                AnswerTwoImage.Opacity = opacity;
                AnswerThreeImage.Opacity = opacity;
                AnswerFourImage.Opacity = opacity;
            }
            if (buttonNumber == 2)
            {
                AnswerTwoImage.Source = "button_lang_rot_press.png";
                AnswerOneImage.Opacity = opacity;
                AnswerThreeImage.Opacity = opacity;
                AnswerFourImage.Opacity = opacity;
            }
            if (buttonNumber == 3)
            {                
                AnswerThreeImage.Source = "button_lang_rot_press.png";
                AnswerOneImage.Opacity = opacity;
                AnswerTwoImage.Opacity = opacity;
                AnswerFourImage.Opacity = opacity;
            }
            if (buttonNumber == 4)
            {
                AnswerFourImage.Source = "button_lang_rot_press.png";
                AnswerOneImage.Opacity = opacity;
                AnswerTwoImage.Opacity = opacity;
                AnswerThreeImage.Opacity = opacity;
            }
        }

        void SetImageWrongAnswerJoker(int buttonNumber)
        {
            if (buttonNumber == 1)
            {
                AnswerOneImage.Source = "button_lang_rot_press.png";                
            }
            if (buttonNumber == 2)
            {
                AnswerTwoImage.Source = "button_lang_rot_press.png";                
            }
            if (buttonNumber == 3)
            {
                AnswerThreeImage.Source = "button_lang_rot_press.png";                
            }
            if (buttonNumber == 4)
            {
                AnswerFourImage.Source = "button_lang_rot_press.png";               
            }
        }

        private void endButton_Pressed(object sender, EventArgs e)
        {
            MenueImage_press.IsVisible = true;
        }

        private void endButton_Released(object sender, EventArgs e)
        {
            MenueImage_press.IsVisible = false;
        }

        private void jokerButton_Pressed(object sender, EventArgs e)
        {
            JokerImage_press.IsVisible = true;
        }

        private void jokerButton_Released(object sender, EventArgs e)
        {
            JokerImage_press.IsVisible = false;
        }

        private void nextButton_Pressed(object sender, EventArgs e)
        {
            NextImage_press.IsVisible = true;
        }

        private void nextButton_Released(object sender, EventArgs e)
        {
            NextImage_press.IsVisible = false;
        }
    }
}