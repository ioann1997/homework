using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unior.введение
{
    public class ReplacingValues
    {
        public static void Value1()
        {
            int a = 4;
            int b = 7;
            Console.WriteLine($"{a} {b}");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"{a} {b}");

            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            Console.WriteLine($"{name} {surname}");
            string temp = surname;
            surname = name;
            name = temp;
            Console.WriteLine($"{name} {surname}");

        }
    }
}
