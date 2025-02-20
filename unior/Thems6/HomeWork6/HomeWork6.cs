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
                Console.Write("Что желаете купить? Введите id продукта: ");
                input = Console.ReadLine();

                market.Deal(input);            
            }         
        }
    }

    internal class Product
    {
        private int _id;
        //private string _name;
        //private int _price;

        public Product(int id, string name, int price)
        {
            _id = id;
            Name = name;
            Price = price; 
        }

        public int Price { private set; get;}
        public string Name { private set; get;} 
        public int Id => _id; 
    }

    internal class ProductFactory
    {
        private int _lastid =0;

        public Product Create(string name, int price)
        {
            _id = _lastid;
            _lastid++;

            return new Product(id, name, price);
        }
    }

    internal class Person
    {
        protected List<Product> Products;
        public int Score { get; protected set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Cчёт: {Score}");
            Console.Write("Список продуктов в наличии: "); 
            foreach (Product product in Products)
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
            Products = CreateProducts()
            Score = 0;
        }

        public TakeProducts => new List<Product>(Products);

        public List<Product> CreateProducts()
        {
            ProductFactory productFactory= new();    
            List<Product> products = new List<Product>();
            AddProduct
            {
                productFactory.Create("Ананас", 90),
                productFactory.Create("Хлеб", 20),
                productFactory.Create("Машина", 10000),
            };
            
            return products
        };
        
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

        private bool TryGetProduct(int id, out Product product)
        {
            product = null;

            foreach (Product elementproduct in _seller.TakeProducts)
            {
                if (elementproduct.Id = id)
                {
                    product = elementproduct;
                    return true;
                }
            }

            return false;
        }
    }
}
