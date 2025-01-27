using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unior
{
    public class Page
    {
        public static void Page1()
        { 
            int numLine = int.Parse(Console.ReadLine()); //3
            int total = int.Parse(Console.ReadLine()); //52
            int result = total/ numLine;
            int leftOver = total%numLine;
            Console.WriteLine("полностью заполненные ряды {0} " +
                " картинок  сверх меры {1}", result, leftOver);
        }
    }
}
