using System;

namespace Unior
{
    internal class HomeWork7
    {
        public static void Hw7(string[] args)
        {
            string name = Console.ReadLine();
            char symbol = Console.ReadKey(true).KeyChar;
            string middleLine = symbol + name + symbol;
            int lenthRectangle = middleLine.Length;
            string line = "";

            for (int i = 0; i < lenthRectangle; i++)
            {
                line += symbol;
            }
            Console.WriteLine(line);
            Console.WriteLine(middleLine);
            Console.WriteLine(line);
        }
    }
}
