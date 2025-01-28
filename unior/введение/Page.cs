using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unior.введение
{
    public class Page
    {
        public static void Page1()
        {
            int numLine = int.Parse(Console.ReadLine()); //3
            int Total = int.Parse(Console.ReadLine()); //52
            int result = Total/ numLine;
            int leftOver = Total%numLine;
            Console.WriteLine("полностью заполненные ряды {0} " +
                " картинок  сверх меры {1}", result, leftOver);
        }
    }
}
