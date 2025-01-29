using System;

namespace Unior
{
    class HomeWork9
    {
        public static void Hm9()
        {
            Random random = new Random();
            int startRandomNumber = 10;
            int endRandomNumber = 25;
            int startNumber = 50;
            int endNumber = 150;
            int number = random.Next(startRandomNumber, endRandomNumber+1); 
            int counter = 0;

            Console.WriteLine($"Сгенерированное значение number: {number}");

            for (int i = number; i <= endNumber; i+=number)
            {
                if (i >= startNumber)
                {
                    counter++;
                }
            }
            Console.WriteLine($"Количество чисел от {startNumber} до {endNumber}, кратных {number}: {counter}");
        }
    }
}
