using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Unior.Thems5
{
    internal class HomeWork5
    {
        public static void Hm5()
        {
            string[] numbers1 = { "1", "2", "1" };
            string[] numbers2 = { "3", "2" };

            List<string> result = new List<string>();

            CreatedUniqElemntList(numbers1, ref result);
            CreatedUniqElemntList(numbers2, ref result);
           
            foreach (string number in result)
            {
                Console.WriteLine(number);
            }
        }

        public static void CreatedUniqElemntList(string[] numbers, ref List<string> result)
        {
            foreach (string number in numbers)
            {
                if (result.Contains(number) == false)
                {
                    result.Add(number);
                }
            }
        }
    }
}
