using System;

namespace unior
{
    internal class HomeWork1
    {
        public static void Hm1()
        {
            int countСycle = int.Parse(Console.ReadLine());
            Console.Write("Введи сообщение ");
            string message = Console.ReadLine();
                for (int i = 0; i < countСycle; i++)
            {
                Console.WriteLine(message);
            }
        }
    }
}
