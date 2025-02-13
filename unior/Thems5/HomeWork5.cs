using System;
using System.Collections.Generic;

namespace Unior.Thems5
{
    internal class HomeWork5
    {
        public static void Hm5()
        {
            string[] numbers1 = { "1", "2", "1" };
            string[] numbers2 = { "3", "2" };

            List<string> result = new List<string>();

            string[] numbersUnion = new string[numbers1.Length + numbers2.Length];
            numbers1.CopyTo(numbersUnion, 0);
            numbers2.CopyTo(numbersUnion, numbers1.Length);

            foreach (string number in numbersUnion)
            {
                if (result.Contains(number) == false)
                { 
                    result.Add(number);
                }
            }

            foreach (string number in result)
            {
                Console.WriteLine(number);
            }
        }
    }
}
