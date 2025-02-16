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

            result = CreatedUniqElementList(numbers1,  result);
            result = CreatedUniqElementList(numbers2,  result);

            ShowList(result);
        }

        public static List<string> CreatedUniqElementList(string[] numbers, List<string> result)
        {
            foreach (string number in numbers)
            {
                if (result.Contains(number) == false)
                {
                    result.Add(number);
                }
            }

            return result;
        }

        public static void ShowList(List<string> result)
        {
            foreach (string element in result)
            {
                Console.WriteLine(element);
            }
        }
    }
}
