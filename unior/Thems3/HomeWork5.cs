using System;

namespace Unior
{
    internal class HomeWork5
    {
        public static void Hm5()
        {
            Random random = new Random();

            int lenghtNumbers = 30;
            int[] numbers = new int[lenghtNumbers];

            int minRandomNumber = 1;
            int maxRandomNumber = 10;

            int frequenceNumberNow = 0;
            int frequenceNumberResult = 0;
            int counterNow = 1;
            int counterResult = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumber, maxRandomNumber + 1);
            }

            for (int i = 0;i < numbers.Length; i++)
            {
                if (i!= numbers.Length - 1 && numbers[i] == numbers[i + 1])
                {
                    frequenceNumberNow = numbers[i];
                    counterNow++;
                }
                else if (counterNow > counterResult)
                {
                    frequenceNumberResult = frequenceNumberNow;
                    counterResult = counterNow;
                    counterNow = 1;
                }
                else
                {
                    frequenceNumberNow = 0;
                    counterNow = 1;
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine($"\nчисло {frequenceNumberResult} повторяется {counterResult} раза подряд.");
        }
    }
}
