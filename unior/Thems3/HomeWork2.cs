using System;

namespace Unior
{
    internal class HomeWork2
    {
        public static void Hm2()
        {
            Random random = new Random();

            int rows = 10;
            int columns = 10;
            int minRandomNumber = 1;
            int maxRandomNumber = 100;
            int[,] numbers = new int[rows, columns];
            int maxNumber = 0;

            for (int i = 0; i < numbers.GetLength(0); i++)
            { 
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = random.Next(minRandomNumber, maxRandomNumber+1);
                    Console.Write(numbers[i, j] + " ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (numbers[i, j] > maxNumber)
                    {
                        maxNumber = numbers[i, j];
                    }
                }
            }

            Console.WriteLine($"Максимальное число - {maxNumber}");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (numbers[i, j] == maxNumber)
                    {
                        numbers[i, j] = 0;
                    }

                    Console.Write(numbers[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
