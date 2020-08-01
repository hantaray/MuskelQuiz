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
        public string bla = "";
        public DatabasePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.GetMuskel();

            Page currPage = Navigation.NavigationStack.LastOrDefault();

            if (currPage is DatabasePage)
            {
                (currPage as DatabasePage).bla = "kh";
            }

            string st = "";
        }
    }
}