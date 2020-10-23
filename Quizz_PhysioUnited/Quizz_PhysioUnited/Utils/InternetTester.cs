using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Quizz_PhysioUnited.Utils
{
    class InternetTester
    {
        public static bool TestConnection()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            else
            {                
                return false;
            }
        }       

    }
}
