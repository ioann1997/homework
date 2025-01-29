using System;

namespace unior
{
    internal class HomeWork8
    {
        public static void Variant1(string[] args)
        {
            string password = "Jack!1234";
            int attempts = 3;
            string input = "";
            string secretMessage = "Красавчик!";

            while (input != password)
            {
                Console.WriteLine("Введи пароль:");
                input = Console.ReadLine();

                if (input == password)
                {
                    Console.WriteLine(secretMessage);
                    break;
                }
                else
                {   
                    attempts--;

                    if (attempts == 0) break;
                    else Console.WriteLine($"Пароль не верен, введи ещё раз. Кол-во попыток {attempts}");
                }
            }
        }
        public static void Variant2(string[] args)
        {
            string password = "Jack!1234";
            int attempts = 3;
            string secretMessage = "Красавчик!";

            for (int i = 0; i < attempts; i++) 
            {
                Console.WriteLine("Введи пароль:");
                string input = Console.ReadLine();

                if (input == password)
                {
                    Console.WriteLine(secretMessage);
                    break;
                }
                else
                {
                    Console.WriteLine($"Пароль не верен, введи ещё раз. Кол-во попыток {attempts-(i+1)}");
                }
            }
        }
    }
}
