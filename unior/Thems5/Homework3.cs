using System;
using System.Collections.Generic;
using Unior.Thems4;

namespace Unior.Thems5
{
    internal class Homework3
    {
        public static void Hm3()
        {
            const string CommandStopWord = "exit";
            const string CommandKeyWordSum = "sum";
            const string CommandAddNumbers = "add";

            ReadType readType = new ReadType();

            List<int> numbers = new List<int>();
            string input = "";

            while (input != CommandStopWord)
            {
                Console.WriteLine($"Добавить число в массив - {CommandAddNumbers}\nПосчитать сумму массива - {CommandKeyWordSum}\n" +
                    $"Выйти - {CommandStopWord}");
                ShowList(numbers);

                input = Console.ReadLine();

                switch (input)
                {
                    case CommandStopWord:
                        break;

                    case CommandKeyWordSum:
                        Console.Clear();
                        SumList(numbers);
                        break;

                    case CommandAddNumbers:
                        numbers.Add(readType.ReadInt());
                        Console.Clear();
                        break;
                }
            }
        }

        public static int SumList(List<int> numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"Сумма массива - {sum}");
            return sum;
        }
        public static void ShowList(List<int> list)
        {
            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
