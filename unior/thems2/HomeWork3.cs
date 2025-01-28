using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unior
{
    internal class HomeWork3
    {
        public static void Hm3()
        {
            int maxNumber = 103;
            int startNumber = 5;
            int stepNumber = 7;
                for (int i = startNumber; i <= maxNumber; i += stepNumber)
            {
                Console.WriteLine(i);
            }
        }
    }
}
