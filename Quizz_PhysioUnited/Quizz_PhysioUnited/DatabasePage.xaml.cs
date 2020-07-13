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
    public partial class DatabasePage : ContentPage
    {
        public DatabasePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetMuskelAsync();
        }
        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ursprungEntry.Text)
                && !string.IsNullOrWhiteSpace(ansastzEntry.Text) && !string.IsNullOrWhiteSpace(kategorieEntry.Text))
            {
                await App.Database.SaveMuskelAsync(new Muskel
                {
                    Name = nameEntry.Text,
                    Ursprung = ursprungEntry.Text,
                    Ansatz = ansastzEntry.Text,
                    Kategorie = int.Parse(kategorieEntry.Text)
                });

                nameEntry.Text = ursprungEntry.Text = ansastzEntry.Text = kategorieEntry.Text = string.Empty;

                listView.ItemsSource = await App.Database.GetMuskelAsync();
            }
        }
    }
}