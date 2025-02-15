using System;
using System.Collections.Generic;

namespace Unior.Thems5
{
    internal class HomeWork4
    {
        public static void Main()
        {
            const char CommandAddDossier = '1';
            const char CommandShowDossier = '2';
            const char CommandRemoveDossier = '3';
            const char CommandExit = '4';

            bool isCurrentWork = true;

            var dossier = new Dictionary<string, List<string>>();

            char input = '0';

            while (isCurrentWork)
            {
                Console.WriteLine($"Выберите действие:\n{CommandAddDossier}) добавить досье\n{CommandShowDossier}) вывести все досье\n" +
                    $"{CommandRemoveDossier}) удалить досье\n{CommandExit}) выход ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (input)
                {
                    case CommandAddDossier:
                        AddDossier( dossier);
                        Console.Clear();
                        break;

                    case CommandShowDossier:
                        Console.Clear();
                        ShowDossier( dossier);
                        break;

                    case CommandRemoveDossier:
                        RemoveDossier( dossier);
                        Console.Clear();
                        break;

                    case CommandExit:
                        isCurrentWork = false;
                        break;
                }
            }
        }

        public static void ShowDossier( Dictionary<string, List<string>> dossier)
        {
            int counter = 0;

            foreach (var employee in dossier)
            {
                foreach (var fullName in employee.Value)
                {
                    counter++;
                    Console.WriteLine($"{counter} Должность: {employee.Key}  ФИО: {fullName}");
                }
            }
        }

        public static void RemoveDossier( Dictionary<string, List<string>> dossier)
        {   
            Console.Write("Какая у него должность? ");
            string post = Console.ReadLine();

            if (dossier.ContainsKey(post))
            {
                Console.Write("Какой у него номер? ");
                int index = ReadInt() - 1;

                if (index < dossier[post].Count && index >= 0)
                {
                    dossier[post].RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Нет такого номера работника");
                }

                if (dossier[post].Count == 0)
                {
                    dossier.Remove(post);
                }
            }
        }

        public static void AddDossier( Dictionary<string, List<string>> dossier)
        {
            string defaultPost = "Worker";
            Console.Write("Введите ваше ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите должность, если есть ");
            string post = Console.ReadLine();

            if (post == "")
            {
                post = defaultPost;
            }

            if (dossier.ContainsKey(post) == false)
            {
                dossier.Add(post, new List<string>());
            }

            dossier[post].Add(fullName);
        }

        public static int ReadInt()
        {
            int number = 0;
            Console.Write("Введите число: ");

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Преобразование завершилось неудачно");
            }

            return number;
        }
    }
}
