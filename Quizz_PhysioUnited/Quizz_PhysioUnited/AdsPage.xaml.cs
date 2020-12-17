using MarcTron.Plugin;
using Quizz_PhysioUnited.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quizz_PhysioUnited
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdsPage : ContentPage
    {
        public AdsPage()
        {
            InitializeComponent();
            
            //CrossMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
            //CrossMTAdmob.Current.OnInterstitialOpened += Current_OnInterstitialOpened;
            //CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void AdButton_Clicked(object sender, EventArgs e)
        {

            AdController.LoadAndShowAd();

            //CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");

            //CrossMTAdmob.Current.ShowInterstitial();
        }

        //private void Current_OnInterstitialLoaded(object sender, EventArgs e)
        //{
        //    Debug.WriteLine(CrossMTAdmob.Current.IsInterstitialLoaded().ToString());

        //    CrossMTAdmob.Current.ShowInterstitial();

        //    Debug.WriteLine(CrossMTAdmob.Current.IsInterstitialLoaded().ToString());


        //    //CrossMTAdmob.Current.OnInterstitialLoaded -= Current_OnInterstitialLoaded;
        //}


        ////if Interstitial is closed, IsInterstitialLoaded() == false

        //private void Current_OnInterstitialOpened(object sender, EventArgs e)
        //{
        //    Debug.WriteLine("opened");
        //    Debug.WriteLine(CrossMTAdmob.Current.IsInterstitialLoaded().ToString());
        //}

        //private void Current_OnInterstitialClosed(object sender, EventArgs e)
        //{
        //    Debug.WriteLine("closed");
        //    Debug.WriteLine(CrossMTAdmob.Current.IsInterstitialLoaded().ToString());
        //}

    }
}