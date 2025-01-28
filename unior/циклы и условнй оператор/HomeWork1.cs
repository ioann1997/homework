using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unior.циклы_и_условнй_оператор
{
    internal class HomeWork1
    {
        public static void Hm1()
        {
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введи сообщение ");
            string message = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(message);
            }
        }
    }
}
