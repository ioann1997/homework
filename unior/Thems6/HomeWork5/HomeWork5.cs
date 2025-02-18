using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ДЗ: Хранилище книг
//Создать хранилище книг. 
//Каждая книга имеет название, автора и год выпуска (можно добавить еще параметры).
//В хранилище можно добавить книгу, убрать книгу, показать все книги и показать найденные
//книги по указанному параметру (по названию, по автору, по году выпуска).

//Пример поиска.
//Выбирается поиск по названию, вводится название и показываются все книги с данным названием.

namespace Unior.Thems6.HomeWork5
{
    internal class HomeWork5
    {
        public static void Hm5()
        {
            //var property = book.GetType().GetProperty(propertyName);
        }
    }

    internal class Book
    {
        private string _title;
        private string _author;
        private int _yearPublished;

        public Book(string name, string author, int yearPublished)
        {
            _author = author;
            _title = name;   
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

    internal class Library
    {
        private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public void ShowInfo()
        {
            foreach (Book book in _books)
            {
                Console.WriteLine($"{book.Name} {book.Author} {book.YearPublished}");
            }
        }

        public void AddBook()
        {
            Console.WriteLine("Введите название книги, автора книги и год выпуска через пробел");
            string[] input = Console.ReadLine().Split();

            Book book = new Book(input[0], input[1], Convert.ToInt16(input[2]));

            _books.Add(book);
        }

        public void FindBook()
        {
            const char CommandTitle = '0';
            const char CommandAuthor = '1';
            const char CommandYearPlayer = '2';

            Console.WriteLine($"Как вы хотите найти книгу:\n{CommandTitle} - по автору\n" +
                $"{CommandAuthor} - по названию\n {CommandYearPlayer} - по году выпуска ");
            char parametr = Console.ReadKey().KeyChar;

            switch (parametr)
            {
                case CommandTitle:
                    Console.WriteLine("Введите название книги: ");
                    string input = Console.ReadLine();
                    foreach (Book book in _books)
                    {
                        if (book.Name == input)
                        {

                        }
                    }
                    break;

                case CommandAuthor:
                    Console.WriteLine("Введите автора: ");
                    break;

                case CommandYearPlayer:
                    Console.WriteLine("Введите год: ");
                    break;

            }
        }
        private bool TryGetBook(string propertyName, string propertyValue, out Book book)
        {
            book = null;

            foreach (Book elementBook in _books)
            {
                var property = elementBook.GetType().GetProperty(propertyName);
                if (property == null)
                {
                    Console.WriteLine($"Свойство '{propertyName}' не найдено.");
                    return false;
                }

                var value = property.GetValue(elementBook)?.ToString();
            }

            return false;
        }
    }
}
