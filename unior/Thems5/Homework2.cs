using System;
using System.Collections.Generic;

namespace Unior.Thems5
{
    internal class Homework2
    {
        public static void Hm2()
        {
            Queue<int> purchases = new Queue<int>(new int[] { 30, 40, 120, 200, 300, 10, 55 });
            int score = 0;

            while (purchases.Count > 0)
            {
                score += purchases.Dequeue();

                Console.WriteLine($"мой счёт: {score}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
