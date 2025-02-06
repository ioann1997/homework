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
            while (true)
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out var number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Преобразование завершилось неудачно");
                }
            }
        }
    }
}
