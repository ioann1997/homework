using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unior.циклы_и_условнй_оператор
{
    internal class HomeWork2
    {
        public static void Hm2()
        {
            string exitWhile = "exit";
            string message = "";
            while (message != exitWhile) 
            {
                Console.Write("Введи сообщение ");
                message = Console.ReadLine();

            }
        }
    }
}
