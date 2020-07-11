using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quizz_PhysioUnited
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatabasePage : ContentPage
    {
        public DatabasePage()
        {
            InitializeComponent();
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    listView.ItemsSource = await App.Database.GetFrageAsync();

        //    internetLabel.Text = $"Internetverbindung: {Connectivity.NetworkAccess}";
        //}
        //async void OnAddButtonClicked(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrWhiteSpace(frageEntry.Text) && !string.IsNullOrWhiteSpace(gruppeIDEntry.Text)
        //        && !string.IsNullOrWhiteSpace(antwortEntry.Text))
        //    {
        //        int antwrtID = 0;

        //        antwrtID = await App.Database.SaveAntwortAsync(new Antwort
        //        {
        //            AntwortText = antwortEntry.Text,
        //            GruppeID = int.Parse(gruppeIDEntry.Text)
        //        });

        //        await App.Database.SaveFrageAsync(new Frage
        //        {
        //            FrageText = frageEntry.Text,
        //            AntwortID = antwrtID
        //        });

        //        frageEntry.Text = gruppeIDEntry.Text = antwortEntry.Text = string.Empty;

        //        listView.ItemsSource = await App.Database.GetFrageAsync();
        //    }
        //}
    }
}