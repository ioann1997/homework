using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Unior.Thems4
{
    internal class HomeWork1
    {
        public static void Main()
        {
            int number = ReadInt();
            Console.WriteLine($"{number}");
        }

        public static int ReadInt()
        {
            int number = 0;
            Console.Write("Введите число: ");

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                    Console.WriteLine("Преобразование завершилось неудачно");
            }

            return number;
        }
    }
}
