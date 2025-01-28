using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unior.циклы_и_условнй_оператор
{
    internal class HomeWork3
    {
        public static void Hm3()
        {
            int maxNum = 103;
            int startNum = 5;
            int plusNum = 7;
            for (int i = startNum; i <= maxNum; i += plusNum)
            {
                Console.WriteLine(i);
            }
        }
    }
}
