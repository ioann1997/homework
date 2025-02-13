using System;
using System.Collections.Generic;

namespace Unior.Thems5
{
    internal class HomeWork1
    {
        public static void Main()
        {
            var explanatoryDictionary = new Dictionary<string, string>()
            {
                { "Рибонуклеиновая кислота", "одна из трёх основных макромолекул," +
                " которые содержатся в клетках всех живых организмов и играют " +
                "важную роль в кодировании, прочтении, регуляции и экспрессии генов."},
                { "Дезоксирибонуклеиновая кислота", "макромолекула , обеспечивающая хранение, передачу из поколения " +
                "в поколение и реализацию генетической программы развития и функционирования организмов. "},
                { "Белки", "высокомолекулярные органические вещества, состоящие из альфа-аминокислот, соединённых" +
                " в цепочку пептидной связью."}
            };

            string input = "";
            string stopWord = "exit";

            while (input != stopWord)
            {
                Console.WriteLine("Введите слово. значение, которого вы хотите узнать");
                input = Console.ReadLine();

                if (explanatoryDictionary.ContainsKey(input))
                {
                    Console.WriteLine(explanatoryDictionary[input]);
                }
                else
                {
                    Console.WriteLine("Слова нет в словарею.");
                }        
            }
        }
    }
}
