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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.GetMuskel();
        }
        void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) 
                && !string.IsNullOrWhiteSpace(innervationEntry.Text)
                && !string.IsNullOrWhiteSpace(ursprungEntry.Text) 
                && !string.IsNullOrWhiteSpace(ansatzEntry.Text))
            {
                 App.Database.SaveMuskel(new Muskel
                {
                    Name = nameEntry.Text,
                    Innervation = innervationEntry.Text,
                    Ursprung = ursprungEntry.Text,
                    Ansatz = ansatzEntry.Text
                });

                nameEntry.Text = innervationEntry.Text = ursprungEntry.Text = ansatzEntry.Text = string.Empty;

                listView.ItemsSource = App.Database.GetMuskel();
            }
        }
    }
}