using System;

namespace Unior
{
    internal class HomeWork1
    {
        public static void Hm1()
        {
            int[,] numbers =
            {
                { 1, 2, 3, 4, 5, },
                { 6, 7, 8, 9, 0, },
                { 2, 4, 6, 8, 3, }
            };

            int numberRow = 2;
            int numberColumn = 1;
            int sumRow = 0;
            int resultСolumn = 1;
            int rows = numbers.GetLength(0);
            int columns = numbers.GetLength(1);

            for (int j = 0; j < columns; j++)
            {
                sumRow += numbers[numberRow-1, j];
            }

            for (int i = 0; i < rows; i++)
            {
                resultСolumn *= numbers[i, numberColumn-1];
            }

            Console.WriteLine($"Сумма {numberRow} строки - {sumRow}, произведение {numberColumn} столбца {resultСolumn}");
        }
    }
}
