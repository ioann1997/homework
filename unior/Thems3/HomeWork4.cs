using System;

namespace Unior
{
    internal class HomeWork4
    {
        public static void Hm4()
        {
            string input = "";
            string stopWord = "exit";
            string keyWordSum = "sum";
            int[] numbers = new int[0];
            int[] tempNumbers = new int[numbers.Length + 1];
            int total = 0;

            while (input != stopWord)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write(numbers[i] + " ");
                }
                Console.WriteLine();

                input = Console.ReadLine(); 

                if (input == keyWordSum)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        total += numbers[i];
                    }

                    Console.WriteLine($"Сумма массива - {total}");
                }
                else if (input != stopWord)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempNumbers[i] = numbers[i];
                    }

                    tempNumbers[tempNumbers.Length - 1] = Convert.ToInt32(input);
                    numbers = tempNumbers;
                    tempNumbers = new int[numbers.Length + 1];
                }
            }
        }
    }
}
