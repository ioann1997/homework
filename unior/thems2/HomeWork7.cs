using System;

namespace unior
{
    internal class HomeWork7
    {
        public static void Hw7(string[] args)
        {
            string name = Console.ReadLine();
            char symbol = Console.ReadKey(true).KeyChar;
            string middleLine = symbol + name + symbol;
            int lenthRectangle = middleLine.Length;
            string Line = "";

            for (int i = 0; i < lenthRectangle; i++)
            {
                Line += symbol;
            }

            Console.WriteLine(Line);
            Console.WriteLine(middleLine);
            Console.WriteLine(Line);

        }
    }
}
