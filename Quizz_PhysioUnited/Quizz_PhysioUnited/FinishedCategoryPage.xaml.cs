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
    public partial class FinishedCategoryPage : ContentPage
    {

        private double scorePercent;
        int backCount = 2;  //var for contolling how many pages the cancel button goes back

        public string ScorePrecent
        {
            get
            {
                return (this.scorePercent.ToString() + "%");
            }
            //set
            //{
            //    this.scorePercent = value;
            //}
        }

        
        public FinishedCategoryPage(double scorePercent)
        {
            this.scorePercent = scorePercent;
            InitializeComponent();
            BindingContext = this;
        }

        private async void CancelFinishedPage_Clicked(object sender, EventArgs e)
        {
            for (var counter = 1; counter < backCount; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            await Navigation.PopAsync();
        }

        private void CancelFinishedPage_Pressed(object sender, EventArgs e)
        {
            FinishedCancelImage_pres.IsVisible = true;
        }

        private void CancelFinishedPage_Released(object sender, EventArgs e)
        {
            FinishedCancelImage_pres.IsVisible = false;
        }
    }
}