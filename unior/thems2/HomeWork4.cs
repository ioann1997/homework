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
        public static void Hm4()
        {
            Random random = new Random();

            int max = 100;
            int numberDivision1 = 3;
            int numberDivision2 = 5;
            int number = random.Next(max);

            for (int i = 0; i <= number; i++)
            {
                if (i % numberDivision1 == 0 || i % numberDivision2 == 0)
                    Console.WriteLine(i);
            }

        }
    }
}
