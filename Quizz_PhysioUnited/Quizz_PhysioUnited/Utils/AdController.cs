using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static void LoadAd()
        {

            //CrossMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
            if (!CrossMTAdmob.Current.IsInterstitialLoaded())
            {
                CrossMTAdmob.Current.LoadInterstitial(adUnit);
                //Debug.WriteLine("Ad starts loading");
            }            
        }

        public static void ShowAd()
        {
            if (CrossMTAdmob.Current.IsInterstitialLoaded())
            {                
                CrossMTAdmob.Current.ShowInterstitial();                
            }
        }



        //private static void Current_OnInterstitialLoaded(object sender, EventArgs e)
        //{
            
        //    Debug.WriteLine("Ad is loaded");
        //    CrossMTAdmob.Current.OnInterstitialLoaded -= Current_OnInterstitialLoaded;
        //}








    }
}
