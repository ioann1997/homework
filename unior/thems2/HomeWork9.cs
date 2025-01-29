using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unior.thems2
{
    class HomeWork9
    {
        public static void Hm9()
        {
            Random random = new Random();
            int number = random.Next(10, 26); 
            int count = 0;

            Console.WriteLine($"Сгенерированное значение N: {number}");

            for (int i = 50; i <= 150; i++)
            {
                int temp = i;

                while (temp >= number)
                {
                    temp -= number; 
                }

                if (temp == 0)
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество чисел от 50 до 150, кратных {number}: {count}");
        }
    }
}
