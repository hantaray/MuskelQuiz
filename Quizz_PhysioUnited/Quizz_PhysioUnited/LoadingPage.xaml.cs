using Quizz_PhysioUnited.Utils;
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
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
            LoadData();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //InitializeComponent();
            //LoadData();
        }

        //try to start LoadData with OnAppearing

        private async void LoadData()
        {
            if (InternetTester.TestConnection())
            {


                DateTime modifiedDate = await App.DatabaseAll.GetModifiedDate();
                DateTime lastLocalModifiedDate = Convert.ToDateTime(Settings.ModifiedDateSaved);

                if (modifiedDate > lastLocalModifiedDate)
                {
                    await App.DatabaseAll.GetDataFromServer();

                    //save modified date in settings
                    DateTime modiDate = await App.DatabaseAll.GetModifiedDate();
                    Settings.ModifiedDateSaved = modiDate.ToString();
                }
            }

            await Navigation.PushAsync(new StartAndContinuePage());
        }
    }
}