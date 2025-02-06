using System;

namespace Unior.Thems4
{
    internal static class HomeWork3
    {
        public static void Hm3()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Shuffle(numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }

        public static void Shuffle<T>(this T[] values)
        {
            Random random = new Random();

            int  length = values.Length;

            for (int i = 0; i < length - 1; i++)
            {
                int j = random.Next(i, length);

                if (j != i)
                {
                    T temp = values[i];
                    values[i] = values[j];
                    values[j] = temp;
                }
            }
        }
    }
}
