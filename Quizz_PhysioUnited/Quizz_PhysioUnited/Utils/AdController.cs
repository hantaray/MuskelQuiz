using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_PhysioUnited.Utils
{
    class AdController
    {
        static string adUnit = "ca-app-pub-3940256099942544/1033173712";


        //public AdController()
        //{
        //    CrossMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
        //}

        public static void LoadAndShowAd()
        {

            CrossMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
            CrossMTAdmob.Current.LoadInterstitial(adUnit);
        }


        private static void Current_OnInterstitialLoaded(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
            CrossMTAdmob.Current.OnInterstitialLoaded -= Current_OnInterstitialLoaded;
        }








    }
}
