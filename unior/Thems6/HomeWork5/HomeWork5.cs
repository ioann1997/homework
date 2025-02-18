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
                        library.AddBook(new Book());
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

        public Book()
        {
            _title = ReadTitle();
            _author = ReadAuthor();
            _yearPublished = ReadYear();
        }

        public string Name { get { return _title; } }
        public string Author { get { return _author; } }
        public int YearPublished { get { return _yearPublished; } }

        private string ReadTitle()
        {
            Console.Write("Название: ");
            return Console.ReadLine();
        }

        private string ReadAuthor()
        {
            Console.Write("Автор: ");
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

        public override string ToString()
        {
            return $"Название: {_title}, Автор: {_author}, Год: {_yearPublished}";
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
            foreach (Book book in _books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook()
        {
            Console.Write("Введите название: ");

            if (TryGetBookByName(Console.ReadLine(), out Book book))
            {
                _books.Remove(book);
            }
        }

        public void FindBook()
        {
            const int CommandTitle = 0;
            const int CommandAuthor = 1;
            const int CommandYearPlayer = 2;

            Console.WriteLine($"Как вы хотите найти книгу:\n" +
                $"{CommandTitle} - по названию\n" +
                $"{CommandAuthor} - по автору\n" +
                $"{CommandYearPlayer} - по году выпуска");
            int parametr = int.Parse(Console.ReadKey().KeyChar.ToString());

            Console.Write("Введите значнеие: ");
            string value = Console.ReadLine();

            List<Book> foundBooks = new List<Book>();

            foreach (Book book in _books)
            {
                switch (parametr)
                {
                    case CommandTitle:

                        if (book.Name.Equals(value))
                        {
                            foundBooks.Add(book);
                        }
                        break;

                    case CommandAuthor:

                        if (book.Author.Equals(value))
                        {
                            foundBooks.Add(book);
                        }
                        break;

                    case CommandYearPlayer:

                        if (book.YearPublished.Equals(Convert.ToInt32(value)))
                        {
                            foundBooks.Add(book);
                        }
                        break;

                }
            }

            foreach (Book book in foundBooks)
            {
                Console.WriteLine(book.ToString());
            }
        }
        private bool TryGetBookByName(string value, out Book book)
        {
            book = null;

            foreach (Book elementBook in _books)
            {
                if (elementBook.Name == value)
                {
                    book = elementBook;
                    return true;
                }
            }

            return false;
        }
    }
}

