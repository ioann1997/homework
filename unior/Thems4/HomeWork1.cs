using System;

namespace Unior.Thems4
{
    internal class ReadType
    {
        public  void Hm1()
        {
            int number = ReadInt();
            Console.WriteLine($"{number}");
        }

        public int ReadInt()
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
