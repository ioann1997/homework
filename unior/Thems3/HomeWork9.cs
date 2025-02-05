using System;

namespace Unior.Thems3
{
    internal class HomeWork9
    {
        public static void Main()
        {
            string staples = "(()(()))";
            int currentDepth = 0;
            int maxDeep = 0;
            bool isValid = true;

            for (int i = 0; i < staples.Length; i++)
            {
                if (staples[i] == '(')
                {
                    currentDepth++;
                    maxDeep = currentDepth > maxDeep ? currentDepth : maxDeep;
                }
                else
                {
                    currentDepth--;

                    if (currentDepth < 0)
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (currentDepth == 0 && isValid)
            {
                Console.WriteLine($"Корректная строка, максимальная глубина - {maxDeep}");
            }
            else
            {
                Console.WriteLine("Некорректная строка");
            }
        }
    }
}
