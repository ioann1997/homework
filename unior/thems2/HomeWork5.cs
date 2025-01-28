using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;

namespace unior.циклы_и_условнй_оператор
{
    internal class HomeWork5
    {
        public static void Hm5()
        {
            const string CommandWriteText = "write";
            const string CommandRandom = "number";
            const string CommandClear = "clear";
            const string CommandExit = "exit";

            string input = "";
            Random random = new Random();

            Console.WriteLine($"Моя консоль знает команды: \n{CommandWriteText} - вывод разного текста \n" +
                $"{CommandRandom} - показать случайное число \n" +
                $"{CommandClear} - очистить консоль \n" +
                $"{CommandExit} - команда выхода");

            while (input != CommandExit)
            {
                input = Console.ReadLine();
                switch (input) 
                {
                    case CommandWriteText:
                        Console.Write("Введи текст ");
                        Console.ReadLine();
                        break;
                    case CommandRandom:
                        Console.WriteLine($"{random.Next()}");
                        break;
                    case CommandClear:
                        Console.Clear();
                        break;
                    case CommandExit:
                        input = CommandExit;
                        break;
                }
            }

        }
    }
}
