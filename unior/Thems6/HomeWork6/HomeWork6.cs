using System;
using System.Collections.Generic;

namespace Unior.Thems6.HomeWork6
{
    internal class HomeWork6
    {
        public static void Hm6()
        {
            Market market = new Market(new Buyer(), new Seller());
            string stopWord = "exit";
            string input = "";

            Console.WriteLine($"Вы пришли в магазин, если хотите уйти, введите {stopWord}");

            while (input != stopWord)
            {
                market.ShowInfo();
                Console.Write("Что желаете купить? Введите название продукта: ");
                input = Console.ReadLine();

                market.Deal(input);
                
            }
            
        }
    }

    internal class Product
    {
        private string _name;
        private int _price;

        public Product(string name, int price)
        {
            _name = name;
            _price = price; 
        }

        public int Price => _price; 
        public string Name => _name; 
    }

    internal class Person
    {
        protected private List<Product> _product;
        public int Score { get; private protected set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Cчёт: {Score}");
            Console.Write("Список продуктов в наличии: "); 
            foreach (Product product in _product)
            {
                Console.Write($"{product.Name} ");
            }
            Console.WriteLine();
        }
    }

    internal class Seller : Person 
    {
        public Seller()
        {
            _product = new List<Product>()
            {
                new Product("Ананас", 90),
                new Product("Хлеб", 20),
                new Product("Машина", 10000),
            };
            Score = 0;
        }
        public void Sell(Product product)
        {
            Score += product.Price; ;
            _product.Remove(product);
        }

        public List<Product> TakeProducts()
        {
            List<Product> products = new List<Product>();

            foreach (Product product in _product)
            { 
                products.Add(product);
            }

            return products;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("**" + new String('-', 40) + "**");
            Console.WriteLine("Информация о продавце");
            base.ShowInfo();
        }

    }

    internal class Buyer : Person
    {
        public Buyer()
        {
            _product = new List<Product>();
            Score = 150;
        }

        public void Buy(Product product)
        {
            Score -= product.Price;
            _product.Add(product);
        }

        public override void ShowInfo()
        {
            Console.WriteLine("**" + new String('-', 40) + "**");
            Console.WriteLine("Информация о покупателе");
            base.ShowInfo();
            Console.WriteLine();
        }
    }

    internal class Market
    {
        private Buyer _buyer;
        private Seller _seller;

        public Market(Buyer buyer, Seller seller)
        {
            _buyer = buyer;
            _seller = seller;
        }

        public void ShowInfo()
        {
            _seller.ShowInfo();
            _buyer.ShowInfo();
        }

        public void Deal(string input)
        {
            if (TryGetProduct(input, out Product product))
            {
                if (_buyer.Score > product.Price)
                {
                    _seller.Sell(product);
                    _buyer.Buy(product);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("У вас не хватает денег");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Нет, такого продукта у продовца");
            }
        }

        private bool TryGetProduct(string name, out Product product)
        {
            product = null;

            foreach (Product elementproduct in _seller.TakeProducts())
            {
                if (elementproduct.Name == name)
                {
                    product = elementproduct;
                    return true;
                }
            }

            return false;
        }
    }
}
