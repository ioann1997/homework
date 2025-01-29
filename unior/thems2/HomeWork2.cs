using System;

namespace unior
{
    internal class HomeWork2
    {
        public static void Hm2()
        {
            string exitWord = "exit";
            string message = "";
                while (message != exitWord) 
            {
                Console.Write("Введи сообщение ");
                message = Console.ReadLine();

            }
        }
    }
}
