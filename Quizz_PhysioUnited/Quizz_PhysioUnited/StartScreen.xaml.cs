﻿using System;
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
    [DesignTimeVisible(false)]
    public partial class StartScreen : ContentPage
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        async void GoToGamePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GamePage());
        }

        async void GoToDatabasePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatabasePage());
        }
    }
}
