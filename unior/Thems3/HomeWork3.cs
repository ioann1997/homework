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
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            if (numbers[0] > numbers[1])
            {
                Console.Write(numbers[0] + " ");
            }

            if (numbers[^1] > numbers[^2])
            {
                Console.Write(numbers[^1] + " ");
            }

            for (int i = 1; i < numbers.Length-1; i++)
            {
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}
