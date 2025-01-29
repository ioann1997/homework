using System;

namespace unior
{
    internal class HomeWork10
    {
        public static void Main()
        {
            Random random = new Random();
            int startRandomNumber = 1;
            int endRandomNumber = 100;
            int numberBase = 3;
            int number = random.Next(startRandomNumber, endRandomNumber+1); 
            int power = 0;
            int result = 1; 

            while (result <= number)
            {
                result *= numberBase; 
                power++; 
            }

            Console.WriteLine($"Заданное число: {number}");
            Console.WriteLine($"Минимальная степень: {numberBase}^{power} = {result}");
        }
    }
}
