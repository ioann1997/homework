using System;

namespace Unior.Thems3
{
    internal class HomeWork8
    {
        public static void Hm8()
        {
            int[] numbers = { 1, 2, 3, 4, 5 ,6,7,8};
            Console.WriteLine(string.Join(", ", numbers));

            int shift = int.Parse(Console.ReadLine());

            shift = shift > numbers.Length ? shift % numbers.Length : shift;

            Array.Reverse(numbers, 0, shift);
            Array.Reverse(numbers, shift, numbers.Length-shift);
            Array.Reverse(numbers);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
