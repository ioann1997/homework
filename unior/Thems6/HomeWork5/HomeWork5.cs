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
            BookFactory bookFactory = new BookFactory();

            Book book = new Book("Война и мир", "Лев Толстой", 1869);

            library.AddBook(new Book("Война и мир", "Лев Толстой", 1869));
            library.AddBook(new Book("Анна Каренина", "Лев Толстой", 1877 ));
            library.AddBook(new Book("Преступление и наказание","Федор Достоевский", 1866 ));
            library.AddBook(new Book("Война и мир", "Лев Толстой", 1965 ));

            char inputCommand = '0';
            bool isRunning = true;

            while (isRunning)
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
                        library.AddBook(bookFactory.Create());
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
                        isRunning = false;
                        break;
                }

                Console.WriteLine();
            }
        }
    }

    internal class Book
    {
        public Book(string name, string author, int yearPublished)
        {
            Name = name;
            Author = author;
            YearPublished = yearPublished;
        }

        public string Name { get; }
        public string Author { get; }
        public int YearPublished { get; }

        public override string ToString()
        {
            return $"Название: {Name}, Автор: {Author}, Год: {YearPublished}";
        }
    }

    internal class BookFactory
    {

        public Book Create()
        {
            string title = UserUtils.ReadString("Название: ");
            string author = UserUtils.ReadString("Автор: ");
            int year = UserUtils.ReadInt("Год Публикации: ");

            return new Book(title, author, year);
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

            if (_books.Count > 0)
            {
                foreach (var book in _books)
                {
                    Console.WriteLine($"{index.ToString()}) {book.ToString()}");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Книги не найдены.");
            }
        }

        private void ShowAllFindBooks(List<Book> foundBooks)
        {
            int index = 0;

            if (foundBooks.Count > 0)
            {
                foreach (var book in foundBooks)
                {
                    Console.WriteLine($"{index.ToString()}) {book.ToString()}");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Книги не найдены.");
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook()
        {
            int index = UserUtils.ReadInt("Введите номер книги: ");

            if (index < _books.Count && index >= 0)
            {
                _books.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Нет такй строки");
            }
        }

        public void FindBook()
        {
            Predicate<Book> predicate = SelectPredicate();

            List<Book> foundBooks = FindBooks(predicate);

            ShowAllFindBooks(foundBooks);
        }

        private Predicate<Book> SelectPredicate()
        {
            const int CommandName = 0;
            const int CommandAuthor = 1;
            const int CommandYear = 2;

            Console.WriteLine($"Как вы хотите найти книгу:\n" +
                              $"{CommandName} - по названию\n" +
                              $"{CommandAuthor} - по автору\n" +
                              $"{CommandYear} - по году выпуска");

            int choice = UserUtils.ReadInt();

            Console.Write("Введите значение: ");
            string value = Console.ReadLine();

            switch (choice)
            {
                case CommandName: return book => book.Name.Equals(value, StringComparison.OrdinalIgnoreCase);
                case CommandAuthor: return book => book.Author.Equals(value, StringComparison.OrdinalIgnoreCase);
                case CommandYear: return book => book.YearPublished.ToString() == value;
                default: return book => book.Name.Equals(value, StringComparison.OrdinalIgnoreCase); 
            }       
        }

        private List<Book> FindBooks(Predicate<Book> predicate)
        {
            List<Book> foundBooks = new List<Book>();

            foreach (Book book in _books)
            {
                if (predicate(book)) 
                {
                    foundBooks.Add(book);
                }
            }
            return foundBooks;
        }
    }
    public  class UserUtils
    {
        public static int ReadInt(string info = "")
        {
            int number = 0;
            Console.Write(info);

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Вы ввели не число");
            }

            return number;
        }

        public static string ReadString(string info)
        {
            Console.Write(info);
            return Console.ReadLine();
        }
    }
}

