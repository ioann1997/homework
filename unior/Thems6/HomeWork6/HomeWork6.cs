﻿using System;
using System.Collections.Generic;

namespace Unior.Thems6.HomeWork6
{
    internal class HomeWork6
    {
        public static void Main()
        {
            Market market = new Market(new Buyer(), new Seller());
            market.Running();

        }
    }

    internal class Product
    {
        private int _id;

        public Product(int id, string name, int price)
        {
            _id = id;
            Name = name;
            Price = price;
        }

        public int Price { private set; get; }
        public string Name { private set; get; }
        public int Id => _id;
    }

    internal class ProductFactory
    {
        private int _lastid = 0;

        public Product Create(string name, int price)
        {
            Product product = new Product(_lastid, name, price);
            _lastid++;

            return product;
        }
    }

    internal class Person
    {
        protected List<Product> Products;
        public int Score { get; protected set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Cчёт: {Score}");
            Console.WriteLine("Список продуктов в наличии: ");
            foreach (Product product in Products)
            {
                Console.WriteLine($"{product.Id} {product.Name} {product.Price}");
            }
            Console.WriteLine();
        }
    }

    internal class Seller : Person
    {
        public Seller()
        {
            Products = CreateProducts();
            Score = 0;
        }

        public List<Product> TakeProducts => new List<Product>(Products);

        public List<Product> CreateProducts()
        {
            ProductFactory productFactory = new();
            List<Product> products = new List<Product>()
            {
                productFactory.Create("Ананас", 90),
                productFactory.Create("Хлеб", 20),
                productFactory.Create("Машина", 10000),
            };

            return products;
        }

        public void Sell(Product product)
        {
            Score += product.Price; ;
            Products.Remove(product);
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
            Products = new List<Product>();
            Score = 150;
        }

        public void Buy(Product product)
        {
            Score -= product.Price;
            Products.Add(product);
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

        public void Running()
        {
            const char CommandBuyProduct = '1';
            const char CommandStopProgramm = '2';

            char inputCommand = '0';
            bool isRunning = true;

            while (isRunning)
            {
                ShowInfo();
                Console.WriteLine($"Вы пришли в магазин.\n" +
                    $"если хотите уйти, введите {CommandStopProgramm}\n" +
                    $"Если хотите купить товар, введите {CommandBuyProduct}\n");

                inputCommand = Console.ReadKey().KeyChar;

                switch (inputCommand)
                {
                    case CommandBuyProduct:
                        Console.Write("Что желаете купить?");
                        Deal(UserUtils.ReadInt("Введите Id: "));
                        break;

                    case CommandStopProgramm:
                        isRunning = false;
                        break;
                }
            }

        }

        private void Deal(int inputId)
        {
            if (TryGetProduct(inputId, out Product product))
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

        private bool TryGetProduct(int id, out Product product)
        {
            product = null;

            foreach (Product elementproduct in _seller.TakeProducts)
            {
                if (elementproduct.Id == id)
                {
                    product = elementproduct;
                    return true;
                }
            }

            return false;
        }
    }

    internal class UserUtils
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
    }
}
