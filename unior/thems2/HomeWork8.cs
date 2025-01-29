using System;

namespace Unior
{
    internal class HomeWork8
    {
        public static void Hm8(string[] args)
        {
            string password = "Jack!1234";
            int attempts = 3;
            string input = "";
            string secretMessage = "Красавчик!";

            for (int i = attempts; i != 0; i-- )
            {
                Console.WriteLine("Введи пароль:");
                input = Console.ReadLine();

                if (input == password)
                {
                    Console.WriteLine(secretMessage);
                }
                else
                {   
                    Console.WriteLine($"Пароль не верен. Кол-во попыток {i-1}");
                }
            }
        }
    }
}
