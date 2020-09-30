using Quizz_PhysioUnited.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Quizz_PhysioUnited
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class StartScreen : ContentPage
    {
        public static int Kategorie;

        
        public StartScreen()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            popUpRestart.IsVisible = false;
            ChanceCategoryButton.IsEnabled = true;
            ChanceImage.Opacity = 1;
        }

        void GoToGamePage(object sender, EventArgs e)
        {
            
            Button clickedButton = (Button)sender;
            if (clickedButton.ClassId.Equals("ButtonKatOne"))
            {
                Kategorie = 1;
                if (App.QCountKatOne < Int32.Parse(Settings.QuestionCounterKatOne))
                {
                    DisableChanceIfNoQuestions(Kategorie);
                    popUpRestart.IsVisible = true;
                } 
                else
                {
                    PageKatOne();
                }
            }
            else if (clickedButton.ClassId.Equals("ButtonKatTwo"))
            {
                Kategorie = 2;
                if (App.QCountKatTwo < Int32.Parse(Settings.QuestionCounterKatTwo))
                {
                    DisableChanceIfNoQuestions(Kategorie);
                    popUpRestart.IsVisible = true;
                }
                else
                {
                    PageKatTwo();
                }
            }
            else if (clickedButton.ClassId.Equals("ButtonKatThree"))
            {
                Kategorie = 3;
                if (App.QCountKatThree < Int32.Parse(Settings.QuestionCounterKatThree))
                {
                    DisableChanceIfNoQuestions(Kategorie);
                    popUpRestart.IsVisible = true;
                }
                else
                {
                    PageKatThree();
                }

            }
            else if (clickedButton.ClassId.Equals("ButtonKatFour"))
            {
                Kategorie = 4;
                if (App.QCountKatFour < Int32.Parse(Settings.QuestionCounterKatFour))
                {
                    DisableChanceIfNoQuestions(Kategorie);
                    popUpRestart.IsVisible = true;
                }
                else
                {
                    PageKatFour();
                }

            }

        }

        void DisableChanceIfNoQuestions(int category)
        {
            //List<Question> testList = new List<Question>();
            List<Question> testList = App.DatabaseAll.GetQuestionsByCatAndNextFalse(category);
            bool chanceAllowed = GetChanceBool(category);
            if (testList.Count == 0 || !chanceAllowed)
            {
                ChanceCategoryButton.IsEnabled = false;
                ChanceImage.Opacity = 0.6;
            }
        }

        bool GetChanceBool(int category)
        {
            if (category == 1)
            {
                return bool.Parse(Settings.ChanceBoolKatOne);
            }
            else if (category == 2)
            {
                return bool.Parse(Settings.ChanceBoolKatTwo);
            }
            else if (category == 3)
            {
                return bool.Parse(Settings.ChanceBoolKatThree);
            }
            else
            {
                return bool.Parse(Settings.ChanceBoolKatFour);
            }
        }


        async void PageKatOne()
        {
            await Navigation.PushAsync(new GamePage(App.QAListKatOne,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatOne),
                                                    Int32.Parse(Settings.ScoreKatOne),
                                                    Int32.Parse(Settings.AllQuestionsNrKatOne),
                                                    Int32.Parse(Settings.Gems),
                                                    Double.Parse(Settings.TimerValueKatOne)
                                                    )); ;
        }


        async void PageKatTwo()
        {
            await Navigation.PushAsync(new GamePage(App.QAListKatTwo,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatTwo),
                                                    Int32.Parse(Settings.ScoreKatTwo),
                                                    Int32.Parse(Settings.AllQuestionsNrKatTwo),
                                                    Int32.Parse(Settings.Gems),
                                                    Double.Parse(Settings.TimerValueKatTwo)
                                                    ));
        }

        async void PageKatThree()
        {
            await Navigation.PushAsync(new GamePage(App.QAListKatThree,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatThree),
                                                    Int32.Parse(Settings.ScoreKatThree),
                                                    Int32.Parse(Settings.AllQuestionsNrKatThree),
                                                    Int32.Parse(Settings.Gems),
                                                    Double.Parse(Settings.TimerValueKatThree)
                                                    ));
        }

        async void PageKatFour()
        {
            await Navigation.PushAsync(new GamePage(App.QAListKatFour,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatFour),
                                                    Int32.Parse(Settings.ScoreKatFour),
                                                    Int32.Parse(Settings.AllQuestionsNrKatFour),
                                                    Int32.Parse(Settings.Gems),
                                                    Double.Parse(Settings.TimerValueKatFour)
                                                    ));
        }




        async void openDataBase_Clicked(object sender, EventArgs e)
        {            
            await Navigation.PushAsync(new DatabasePage());
        }

        private void RestartCategoryButton_Clicked(object sender, EventArgs e)
        {
            if (Kategorie == 1)
            {
                QuestionsData.UpdateCurrentWithOriginalByCat(Kategorie);
                App.QAListKatOne = QuestionsData.GetCurrentQuestionsList(Kategorie);
                App.QCountKatOne = App.QAListKatOne.Count;
                Settings.AllQuestionsNrKatOne = App.QCountKatOne.ToString();
                Settings.QuestionCounterKatOne = "1";
                Settings.ScoreKatOne = "0";
                Settings.TimerValueKatOne = "30";
                Settings.ChanceBoolKatOne = "True";
                PageKatOne();
            }
            else if (Kategorie == 2)
            {
                QuestionsData.UpdateCurrentWithOriginalByCat(Kategorie);
                App.QAListKatTwo = QuestionsData.GetCurrentQuestionsList(Kategorie);
                App.QCountKatTwo = App.QAListKatTwo.Count;
                Settings.AllQuestionsNrKatTwo = App.QCountKatTwo.ToString();
                Settings.QuestionCounterKatTwo = "1";
                Settings.ScoreKatTwo = "0";
                Settings.TimerValueKatTwo = "30";
                Settings.ChanceBoolKatTwo = "True";
                PageKatTwo();
            }
            else if (Kategorie == 3)
            {
                QuestionsData.UpdateCurrentWithOriginalByCat(Kategorie);
                App.QAListKatThree = QuestionsData.GetCurrentQuestionsList(Kategorie);
                App.QCountKatThree = App.QAListKatThree.Count;
                Settings.AllQuestionsNrKatThree = App.QCountKatThree.ToString();
                Settings.QuestionCounterKatThree = "1";
                Settings.ScoreKatThree = "0";
                Settings.TimerValueKatThree = "30";
                Settings.ChanceBoolKatThree = "True";
                PageKatThree();
            }
            else if (Kategorie == 4)
            {
                QuestionsData.UpdateCurrentWithOriginalByCat(Kategorie);
                App.QAListKatFour = QuestionsData.GetCurrentQuestionsList(Kategorie);
                App.QCountKatFour = App.QAListKatFour.Count;
                Settings.AllQuestionsNrKatFour = App.QCountKatFour.ToString();
                Settings.QuestionCounterKatFour = "1";
                Settings.ScoreKatFour = "0";
                Settings.TimerValueKatFour = "30";
                Settings.ChanceBoolKatFour = "True";
                PageKatFour();
            }
           
        }

        private void ChanceCategoryButton_Clicked(object sender, EventArgs e)
        {
            if (Kategorie == 1)
            {
                QuestionsData.UpdateCurrentWithNext(Kategorie);
                App.QAListKatOne = QuestionsData.GetCurrentQuestionsList(Kategorie);
                App.QCountKatOne = App.QAListKatOne.Count;
                Settings.QuestionCounterKatOne = "1";
                Settings.TimerValueKatOne = "30";
                Settings.ChanceBoolKatOne = "False";
                PageKatOne();
            }
            else if (Kategorie == 2)
            {
                QuestionsData.UpdateCurrentWithNext(Kategorie);
                App.QAListKatTwo = QuestionsData.GetCurrentQuestionsList(Kategorie);
                App.QCountKatTwo = App.QAListKatTwo.Count;
                Settings.QuestionCounterKatTwo = "1";
                Settings.TimerValueKatTwo = "30";
                Settings.ChanceBoolKatTwo = "False";
                PageKatTwo();
            }
            else if (Kategorie == 3)
            {
                QuestionsData.UpdateCurrentWithNext(Kategorie);
                App.QAListKatThree = QuestionsData.GetCurrentQuestionsList(Kategorie);
                App.QCountKatThree = App.QAListKatThree.Count;
                Settings.QuestionCounterKatThree = "1";
                Settings.TimerValueKatThree = "30";
                Settings.ChanceBoolKatThree = "False";
                PageKatThree();
            }
            else if (Kategorie == 4)
            {
                QuestionsData.UpdateCurrentWithNext(Kategorie);
                App.QAListKatFour = QuestionsData.GetCurrentQuestionsList(Kategorie);
                App.QCountKatFour = App.QAListKatFour.Count;
                Settings.QuestionCounterKatFour = "1";
                Settings.TimerValueKatFour = "30";
                Settings.QuestionCounterKatFour = "False";
                PageKatFour();
            }
        }

        private void CancelPopUpChance_Clicked(object sender, EventArgs e)
        {
            popUpRestart.IsVisible = false;
        }

        private void ButtonKatOne_Pressed(object sender, EventArgs e)
        {
            KatOneImage_press.IsVisible = true;
        }

        private void ButtonKatOne_Released(object sender, EventArgs e)
        {
            KatOneImage_press.IsVisible = false;
        }

        private void ButtonKatTwo_Pressed(object sender, EventArgs e)
        {
            KatTwoImage_press.IsVisible = true;
        }

        private void ButtonKatTwo_Released(object sender, EventArgs e)
        {
            KatTwoImage_press.IsVisible = false;
        }

        private void ButtonKatThree_Pressed(object sender, EventArgs e)
        {
            KatThreeImage_press.IsVisible = true;
        }

        private void ButtonKatThree_Released(object sender, EventArgs e)
        {
            KatThreeImage_press.IsVisible = false;
        }

        private void ButtonKatFour_Pressed(object sender, EventArgs e)
        {
            KatFourImage_press.IsVisible = true;
        }

        private void ButtonKatFour_Released(object sender, EventArgs e)
        {
            KatFourImage_press.IsVisible = false;
        }

        private void RestartCategoryButton_Pressed(object sender, EventArgs e)
        {
            RestartImage_pres.IsVisible = true;
        }

        private void RestartCategoryButton_Released(object sender, EventArgs e)
        {
            RestartImage_pres.IsVisible = false;
        }

        private void ChanceCategoryButton_Pressed(object sender, EventArgs e)
        {
            ChanceImage_pres.IsVisible = true;
        }

        private void ChanceCategoryButton_Released(object sender, EventArgs e)
        {
            ChanceImage_pres.IsVisible = false;
        }

        private void CancelPopUpChance_Pressed(object sender, EventArgs e)
        {
            CancelImage_pres.IsVisible = true;
        }

        private void CancelPopUpChance_Released(object sender, EventArgs e)
        {
            CancelImage_pres.IsVisible = false;
        }


        //wenn chance dann wird next zu current in database und App.QAListKatFour = getCurrent
        //wenn replay delete current database 


    }
}
