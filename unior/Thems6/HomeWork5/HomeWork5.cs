using System;
using System.Collections.Generic;

namespace Unior.Thems6.HomeWork5
{
    internal class HomeWork5
    {
        public static void Main()
        {
            const char CommandAddBook = '1';
            const char CommandFindBook = '2';
            const char CommandRemoveBook = '3';
            const char CommandShowAllBook = '4';
            const char CommandStopProgramm = '5';

            Library library = new Library();

            Book book = new Book("Война и мир", "Лев Толстой", 1869);

            library.AddBook(new Book("Война и мир", "Лев Толстой", 1869));
            library.AddBook(new Book("Анна Каренина", "Лев Толстой", 1877 ));
            library.AddBook(new Book("Преступление и наказание","Федор Достоевский", 1866 ));
            library.AddBook(new Book("Война и мир", "Лев Толстой", 1965 ));

            char inputCommand = '0';
            bool isCurrentWorkProgramm = true;

            while (isCurrentWorkProgramm)
            {
                Console.WriteLine($"{CommandAddBook} - Добавить книгу\n" +
                    $"{CommandFindBook} - Найти книгу\n" +
                    $"{CommandRemoveBook} - Удалить книгу\n" +
                    $"{CommandShowAllBook} - Показать все книги\n" +
                    $"{CommandStopProgramm} - Выйти\n");
                inputCommand = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (inputCommand)
                {
                    case CommandAddBook:
                        library.AddBook(new CreatorBook().CreateBook());
                        break;

                    case CommandFindBook:
                        library.FindBook();
                        break;

                    case CommandShowAllBook:
                        library.ShowAllBooks();
                        break;

                    case CommandRemoveBook:
                        library.RemoveBook();
                        break;

                    case CommandStopProgramm:
                        isCurrentWorkProgramm = false;
                        break;
                }

                //Console.Clear();
                //library.ShowAllBooks();
                Console.WriteLine();
            }
        }
    }

    internal class Book
    {
        private string _title;
        private string _author;
        private int _yearPublished;

        public Book(string name, string author, int yearPublished)
        {
            _title = name;
            _author = author;
            _yearPublished = yearPublished;
        }

        public string Name { get { return _title; } }
        public string Author { get { return _author; } }
        public int YearPublished { get { return _yearPublished; } }

        public override string ToString()
        {
            return $"Название: {_title}, Автор: {_author}, Год: {_yearPublished}";
        }
    }

    internal class CreatorBook
    {

        public Book CreateBook()
        {
            string title = ReadString("Название: ");
            string author = ReadString("Автор: ");
            int year = ReadYear();

            return new Book(title, author, year);
        }

        private string ReadString(string field)
        {
            Console.Write(field);
            return Console.ReadLine();
        }

        private int ReadYear()
        {
            int year = 0;
            Console.Write("Введите Год выпуска: ");

            while (int.TryParse(Console.ReadLine(), out year) == false)
            {
                Console.WriteLine("Вы ввели не число");
            }

            return year;
        }
    }

    internal class Library
    {
        private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public void ShowAllBooks()
        {
            int index = 0;

            foreach (Book book in _books)
            {
                Console.WriteLine($"{index.ToString()}) {book.ToString()}");
                index++;
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook()
        {
            int numberRow = ReadNumberRow();

            if (numberRow < _books.Count && numberRow >= 0)
            {
                _books.RemoveAt(numberRow);
            }
            else
            {
                Console.WriteLine("Нет такй строки");
            }
        }

        public void FindBook()
        {
            FindHandler bookDelegate = SelectFindHandler();

            Console.Write("Введите значнеие: ");
            string value = Console.ReadLine();

            bookDelegate(value);
        }

        public FindHandler SelectFindHandler()
        {
            const int CommandTitle = 0;
            const int CommandAuthor = 1;
            const int CommandYearPlayer = 2;

            Console.WriteLine($"Как вы хотите найти книгу:\n" +
                $"{CommandTitle} - по названию\n" +
                $"{CommandAuthor} - по автору\n" +
                $"{CommandYearPlayer} - по году выпуска");
            int parametr = int.Parse(Console.ReadKey().KeyChar.ToString());

            switch (parametr)
            {
                case CommandTitle:
                    return FindBookByName;
                    break;

                case CommandAuthor:
                    return FindBookByAuthor;
                    break;

                case CommandYearPlayer:
                    return FindBookByYear;
                    break;

                default: return FindBookByName;
            }
        }

        private int ReadNumberRow()
        {
            int id = 0;
            Console.Write("Введите номер строки: ");

            while (int.TryParse(Console.ReadLine(), out id) == false)
            {
                Console.WriteLine("Вы ввели не число");
            }

            return id;
        }

        private void FindBookByName(string value)
        {
            foreach (Book elementBook in _books)
            {
                if (elementBook.Name.ToLower() == value.ToLower())
                {
                    Console.WriteLine(elementBook.ToString());
                }
            }
        }

        private void FindBookByAuthor(string value)
        {
            foreach (Book elementBook in _books)
            {
                if (elementBook.Author.ToLower() == value.ToLower())
                {
                    Console.WriteLine(elementBook.ToString());
                }
            }
        }

        private void FindBookByYear(string value)
        {
            foreach (Book elementBook in _books)
            {
                if (elementBook.YearPublished.ToString() == value)
                {
                    Console.WriteLine(elementBook.ToString());
                }
            }
        }

        public delegate void FindHandler(string value);
    }
}

