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
        public static void s()
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
                Console.WriteLine(book.ToString());
            }
        }

        public void AddBook()
        {
            Console.WriteLine("Введите название книги, автора книги и год выпуска через пробел");
            string[] input = Console.ReadLine().Split();

            Book book = new Book(input[0], input[1], Convert.ToInt16(input[2]));

            _books.Add(book);
        }

        private void Find(int parametr)
        {
            foreach (Book book in _books)
            {
              //  book[parametr];
            }
        }

        public void FindBook()
        {
            const int CommandTitle = 0;
            const int CommandAuthor = 1;
            const int CommandYearPlayer = 2;

            Console.WriteLine($"Как вы хотите найти книгу:\n{CommandTitle} - по автору\n" +
                $"{CommandAuthor} - по названию\n {CommandYearPlayer} - по году выпуска ");
            int parametr = int.Parse(Console.ReadKey().KeyChar.ToString());

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
        //private bool TryGetBook(int playerId, out Player player)
        //{
        //    player = null;

        //    foreach (Player elementPlayer in _players)
        //    {
        //        if (elementPlayer.Id == playerId)
        //        {
        //            player = elementPlayer;
        //            return true;
        //        }
        //    }

        //    return false;
        //}
    }
}

//int result1 = DoOperation(6, DoubleNumber); // 12
//Console.WriteLine(result1);

//int result2 = DoOperation(6, SquareNumber); // 36
//Console.WriteLine(result2);

//int DoOperation(int n, Func<int, int> operation) => operation(n);
//int DoubleNumber(int n) => 2 * n;
//int SquareNumber(int n) => n * n;
//int SquareNumber(int n) => n * n;