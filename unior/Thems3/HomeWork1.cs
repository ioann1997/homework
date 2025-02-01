using System;

namespace Unior
{
    internal class HomeWork1
    {
        public static void Hm1()
        {
            int[,] array =
            {
                { 1, 2, 3, 4, 5, },
                { 6, 7, 8, 9, 0, },
                { 2, 4, 6, 8, 3, }
            };

            int sumSecondRow = 0;
            int resultFirstСolumn = 1;
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int j = 0; j < columns; j++)
            {
                sumSecondRow += array[1, j];
            }

            for (int i = 0; i < rows; i++)
            {
                resultFirstСolumn *= array[i, 0];
            }

            Console.WriteLine($"Сумма второй строки - {sumSecondRow}, произведение первого столбца {resultFirstСolumn}");
        }
    }
}
