using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Unior.Thems4
{
    internal class HomeWork1
    {
        public static void Hm1()
        {
            int number = ReadInt();
            Console.WriteLine($"{number}");
        }
        
        public static int ReadInt()
        {
            int number =0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out  number);

                if (!isValid)
                {
                    Console.WriteLine("Преобразование завершилось неудачно");
                }
            }

            return number;
        }
    }
}
