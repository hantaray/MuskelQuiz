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
    public partial class BandDBPage : ContentPage
    {
        public BandDBPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //listView.ItemsSource = App.BandDB.GetBand();
        }
        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(foundedEntry.Text)
            //    && !string.IsNullOrWhiteSpace(albumEntry.Text) && !string.IsNullOrWhiteSpace(membersEntry.Text))
            //{
            //    await App.BandDB.SaveBandAsync(new Band
            //    {
            //        Name = nameEntry.Text,
            //        Founded = int.Parse(foundedEntry.Text),
            //        FirstAlbumName = albumEntry.Text,
            //        Members = int.Parse(membersEntry.Text)
            //    });

            //    nameEntry.Text = foundedEntry.Text = albumEntry.Text = membersEntry.Text = string.Empty;

            //    listView.ItemsSource = await App.BandDB.GetBandAsync();
            //}
        }
    }
}