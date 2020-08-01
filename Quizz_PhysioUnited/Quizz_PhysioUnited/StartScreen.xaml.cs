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
    [DesignTimeVisible(true)]
    public partial class StartScreen : ContentPage
    {
        public static int Kategorie;

        
        public StartScreen()
        {
            InitializeComponent();
        }        

        async void GoToGamePage(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton.ClassId.Equals("ButtonKatOne"))
            {                
                if (App.QCountKatOne < Int32.Parse(Settings.QuestionCounterKatOne))
                {
                    bool answer = await DisplayAlert("You finnished the category!!!", "Would you like to restart the category?", "Yes", "No");
                    if (answer)
                    {
                        Settings.QuestionCounterKatOne = "1";
                        Settings.ScoreKatOne = "0";
                        Settings.TimerValueKatOne = "30";
                        Kategorie = 1;
                        PageKatOne();
                    }
                } 
                else
                {
                    Kategorie = 1;
                    PageKatOne();
                }
            }
            else if (clickedButton.ClassId.Equals("ButtonKatTwo"))
            {
                if (App.QCountKatTwo < Int32.Parse(Settings.QuestionCounterKatTwo))
                {
                    bool answer = await DisplayAlert("You finnished the category!!!", "Would you like to restart the category?", "Yes", "No");
                    if (answer)
                    {
                        Settings.QuestionCounterKatTwo = "1";
                        Settings.ScoreKatTwo = "0";
                        Settings.TimerValueKatTwo = "30";
                        Kategorie = 2;
                        PageKatTwo();
                    }
                }
                else
                {
                    Kategorie = 2;
                    PageKatTwo();
                }

            }
            else if (clickedButton.ClassId.Equals("ButtonKatThree"))
            {
                if (App.QCountKatThree < Int32.Parse(Settings.QuestionCounterKatThree))
                {
                    bool answer = await DisplayAlert("You finnished the category!!!", "Would you like to restart the category?", "Yes", "No");
                    if (answer)
                    {
                        Settings.QuestionCounterKatThree = "1";
                        Settings.ScoreKatThree = "0";
                        Settings.TimerValueKatThree = "30";
                        Kategorie = 3;
                        PageKatThree();
                    }
                }
                else
                {
                    Kategorie = 3;
                    PageKatThree();
                }

            }
            else if (clickedButton.ClassId.Equals("ButtonKatFour"))
            {
                if (App.QCountKatFour < Int32.Parse(Settings.QuestionCounterKatFour))
                {
                    bool answer = await DisplayAlert("You finnished the category!!!", "Would you like to restart the category?", "Yes", "No");
                    if (answer)
                    {
                        Settings.QuestionCounterKatFour = "1";
                        Settings.ScoreKatFour = "0";
                        Settings.TimerValueKatFour = "30";
                        Kategorie = 4;
                        PageKatFour();
                    }
                }
                else
                {
                    Kategorie = 4;
                    PageKatFour();
                }

            }

        }


        async void PageKatOne()
        {
            await Navigation.PushAsync(new GamePage(App.QAListKatOne,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatOne),
                                                    Int32.Parse(Settings.ScoreKatOne),
                                                    Int32.Parse(Settings.Gems),
                                                    Double.Parse(Settings.TimerValueKatOne)
                                                    ));
        }


        async void PageKatTwo()
        {
            await Navigation.PushAsync(new GamePage(App.QAListKatTwo,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatTwo),
                                                    Int32.Parse(Settings.ScoreKatTwo),
                                                    Int32.Parse(Settings.Gems),
                                                    Double.Parse(Settings.TimerValueKatTwo)
                                                    ));
        }

        async void PageKatThree()
        {
            await Navigation.PushAsync(new GamePage(App.QAListKatThree,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatThree),
                                                    Int32.Parse(Settings.ScoreKatThree),
                                                    Int32.Parse(Settings.Gems),
                                                    Double.Parse(Settings.TimerValueKatThree)
                                                    ));
        }

        async void PageKatFour()
        {
            await Navigation.PushAsync(new GamePage(App.QAListKatFour,               //startet gamepage mit passende QaA Liste und übergibt attribute aus settings
                                                    Int32.Parse(Settings.QuestionCounterKatFour),
                                                    Int32.Parse(Settings.ScoreKatFour),
                                                    Int32.Parse(Settings.Gems),
                                                    Double.Parse(Settings.TimerValueKatFour)
                                                    ));
        }



        async void openDataBase_Clicked(object sender, EventArgs e)
        {
            await App.Database.GetDataFromServer();
            //App.Database.SetDataToDBFromList();   //schreibt liste in database, liste befindet sich in Database.cs
            await Navigation.PushAsync(new DatabasePage());

        }
    }
}
