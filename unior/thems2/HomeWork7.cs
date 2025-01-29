using System;

namespace unior
{
    internal class HomeWork7
    {
        public static void Hm7(string[] args)
        {
            string name = Console.ReadLine();
            char symbol = char.Parse(Console.ReadLine());
            int lenthRectangle = name.Length + 2;

            for (int i = 0; i < lenthRectangle; i++) Console.Write(symbol);

            Console.WriteLine($"\n{symbol}{name}{symbol}");

            for (int i = 0; i < lenthRectangle; i++) Console.Write(symbol);
        }
    }
}
