using System;

namespace Unior.Thems4
{
    internal static class HomeWork3
    {
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            Shuffle(arr);
            Console.WriteLine(string.Join(", ", arr));
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
