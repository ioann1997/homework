using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;


namespace unior
{
    internal class HomeWork4
    {
        public static void  Hm4() 
        {
            Random random = new Random();
            int max = 101;
            int numDivision1 = 3;
            int numDivision2 = 5;
            int number = random.Next(max);
                for(int i = 3; i < number; i++)
            {
                if (i % numDivision1 == 0 || i % numDivision2 == 0)
                    Console.WriteLine(i);
            }

        }
    }
}
