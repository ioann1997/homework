using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;


namespace unior.циклы_и_условнй_оператор
{
    internal class HomeWork4
    {
        public static void  Hm4() 
        {
            Random rnd = new Random();
            int numDiv3 = 3;
            int numDiv5 = 5;
            int number = rnd.Next(101);
            for (int i = 3; i < number; i++) 
            {
                if (i % numDiv3 == 0 || i % numDiv5 == 0)
                    Console.WriteLine(i);
            }

        }
    }
}
