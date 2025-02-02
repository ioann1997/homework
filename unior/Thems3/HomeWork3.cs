using System;

namespace Unior
{
    internal class HomeWork3
    {
        public static void Hm3()
        {
            Random random = new Random();

            int lenghtNumbers = 10;
            int[] numbers = new int[lenghtNumbers];
            int minRandomNumber = 1;
            int maxRandomNumber = 25;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumber, maxRandomNumber + 1);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                else if (i == numbers.Length - 1)
                {
                    if (numbers[i] > numbers[i - 1])
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                else 
                {
                    if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
            }
        }
    }
}
