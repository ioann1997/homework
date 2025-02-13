using System;
using System.Collections.Generic;

namespace Unior.Thems5
{
    internal class HomeWork4
    {
        public static void Hm4()
        {
            const char CommandAddDossier = '1';
            const char CommandShowDossier = '2';
            const char CommandRemoveDossier = '3';
            const char CommandExit = '4';

            var dossier = new Dictionary<string, List<string>>();

            char input = '0';

            while (input != CommandExit)
            {
                Console.WriteLine($"Выберите действие:\n{CommandAddDossier}) добавить досье\n{CommandShowDossier}) вывести все досье\n" +
                    $"{CommandRemoveDossier}) удалить досье\n{CommandExit}) выход ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (input)
                {
                    case CommandAddDossier:
                        AddDossier(ref dossier);
                        Console.Clear();
                        break;

                    case CommandShowDossier:
                        Console.Clear();
                        ShowDossier(ref dossier);
                        break;

                    case CommandRemoveDossier:
                        RemoveDossier(ref dossier);
                        Console.Clear();
                        break;

                    case CommandExit:
                        break;
                }
            }
        }

        public static void ShowDossier(ref Dictionary<string, List<string>> dossier)
        {
            foreach (var dossie in dossier)
            {
                foreach (var fullName in dossie.Value)
                {
                    Console.WriteLine($"Должность: {dossie.Key}  ФИО: {fullName}");
                }
            }
        }

        public static void RemoveDossier(ref Dictionary<string, List<string>> dossier)
        {
            Console.Write("Кого хотите уволить? ");
            string fullName = Console.ReadLine();

            foreach (var dossie in dossier)
            {
                if (dossie.Value.Remove(fullName))
                {
                    if (dossie.Value.Count == 0)
                    {
                        dossier.Remove(dossie.Key);
                    }
                }
            }

        }

        public static void AddDossier(ref Dictionary<string, List<string>> dossier)
        {
            Console.Write("Введите ваше ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите должность, если есть ");
            string post = Console.ReadLine();

            if (post == "")
            {
                post = "Worker";
            }

            if (dossier.ContainsKey(post))
            {
                List<string> fullNames = dossier[post];
                fullNames.Add(fullName);
                dossier[post] = fullNames;
            }
            else
            {
                dossier.Add(post, new List<string> { fullName });
            }
        }
    }
}
