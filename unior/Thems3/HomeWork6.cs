using System;

namespace Unior
{
    internal class HomeWork6
    {
        public static void Hm6()
        {
            Random random = new Random();

            int minRandomNumber = 1;
            int maxRandomNumber = 10;

            int lenghtNumbers = 10;
            int[] numbers = new int[lenghtNumbers];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumber, maxRandomNumber + 1);
            }

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            foreach (int i in numbers)
            { 
                Console.Write(i + " ");
            }
        }
    }
}
