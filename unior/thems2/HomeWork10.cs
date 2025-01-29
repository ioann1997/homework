using System;

namespace unior
{
    internal class HomeWork10
    {
        public static void Hm10()
        {
            Random random = new Random();
            int number = random.Next(1, 100); 
            int power = 0;
            int result = 1; 

            while (result <= number)
            {
                result = result + result; 
                power++; 
            }

            Console.WriteLine($"Заданное число: {number}");
            Console.WriteLine($"Минимальная степень двойки: 2^{power} = {result}");
        }
    }
}
