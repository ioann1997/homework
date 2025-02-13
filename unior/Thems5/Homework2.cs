using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

//ДЗ: Очередь в магазине
//У вас есть множество целых чисел. Каждое целое число - это сумма покупки.

//Вам нужно обслуживать клиентов до тех пор, пока очередь не станет пуста. 

//После каждого обслуженного клиента деньги нужно добавлять на наш счёт и выводить его в консоль.  

//После обслуживания каждого клиента программа ожидает нажатия любой клавиши, 
//после чего затирает консоль и по новой выводит всю информацию, только уже со следующим клиентом

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
