using System;
using System.Collections.Generic;
using System.Text;

namespace Quizz_PhysioUnited
{
    class FischerShuffle
    {
        private static Random rnd = new Random();

        public static List<string> ShuffleArray(List<string> array)
        {
            for (int i = array.Count - 1; i > 0; i--)
            {
                Swap(array, i, GetRandomNumber(i));
            }
            return array;
        }

        private static void Swap(List<string> array, int i, int j)
        {
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static int GetRandomNumber(int i)
        {
            return rnd.Next(i + 1);
        }


    }
}
