using System;

namespace Unior.Thems4
{
    internal static class HomeWork4
    {
        public static void Hm4()
        {
            const char CommandAddDossier = '1';
            const char CommandShowDossier = '2';
            const char CommandRemoveDossier = '3';
            const char CommandSearchDossier = '4';
            const char CommandExit = '5';

            string[] fullNameArray = null;
            string[] postArray = null;
            char input = '0';

            while (input != CommandExit)
            {
                Console.WriteLine($"Выберите действие:\n{CommandAddDossier}) добавить досье\n{CommandShowDossier}) вывести все досье\n" +
                    $"{CommandRemoveDossier}) удалить досье\n{CommandSearchDossier}) поиск по фамилии\n{CommandExit}) выход ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (input)
                {
                    case CommandAddDossier:
                        AddDossier(ref fullNameArray, ref postArray);
                        break;

                    case CommandShowDossier:
                        ShowDossier(ref fullNameArray, ref postArray);
                        break;

                    case CommandRemoveDossier:
                        RemoveDossier(ref fullNameArray, ref postArray);
                        break;

                    case CommandSearchDossier:
                        SearchForSurname(ref fullNameArray, ref postArray);
                        break;

                    case CommandExit:
                        break;
                }
            }
        }
        public static void SearchForSurname(ref string[] fullNameArray, ref string[] postArray)
        {
            Console.Write("Введите фамилию: ");
            string inputSurname = Console.ReadLine();

            for (int i = 0; i < fullNameArray.Length; i++)
            {
                string surname = fullNameArray[i].Split()[0];
                if (surname == inputSurname)
                {
                    Console.WriteLine($"{i + 1}) {fullNameArray[i]} {postArray[i]}");
                }
            }
        }

        public static void ShowDossier(ref string[] fullNameArray, ref string[] postArray)
        {
            for (int i = 0; i < fullNameArray.Length; i++)
            {
                Console.Write($"{i + 1}) {fullNameArray[i]} {postArray[i]} - ");
            }
        }

        public static void RemoveDossier(ref string[] fullNameArray, ref string[] postArray)
        {
            Console.Write("Элемент на какой позиции хотите удалить? ");
            int index = int.Parse(Console.ReadLine());
            fullNameArray = RemoveElement(fullNameArray, index);
            postArray = RemoveElement(postArray, index);
        }

        public static void AddDossier(ref string[] fullNameArray, ref string[] postArray)
        {
            Console.Write("Введите ваше ФИО: ");
            string fullName = Console.ReadLine();
            fullNameArray = AddElement(fullNameArray, fullName);
            Console.Write("Введите важу должность: ");
            string post = Console.ReadLine();
            postArray = AddElement(postArray, post);
        }

        public static string[] RemoveElement(string[] array, int indexToRemove)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Ваш массив пустой");
                return array;
            }

            if (indexToRemove < 0 || indexToRemove >= array.Length)
            {
                Console.WriteLine($"{indexToRemove} - индекса не существует");
                return array;
            }

            string[] newArray = new string[array.Length - 1];
            Array.Copy(array, 0, newArray, 0, indexToRemove);
            Array.Copy(array, indexToRemove + 1, newArray, indexToRemove, array.Length - indexToRemove - 1);
            return newArray;
        }

        public static string[] AddElement(string[] array, string elementToAdd)
        {
            if (array == null)
            {
                return new string[] { elementToAdd };
            }

            string[] newArray = new string[array.Length + 1];
            Array.Copy(array, newArray, array.Length);
            newArray[array.Length] = elementToAdd;
            return newArray;
        }
    }
}
