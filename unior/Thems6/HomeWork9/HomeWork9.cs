using System;
using System.Collections.Generic;

//ДЗ: Супермаркет
//Написать программу администрирования супермаркетом.
//Супермаркет содержит список товаров, которые он продает, очередь клиентов, которых надо обслужить и количество денег, 
//которые заработаны. Список товаров у супермаркета не уменьшаем, считаем их бесконечное количество. Очередь клиентов можно 
//задавать сразу, так и добавлять по необходимости. Но при обслуживании одного клиента, он удаляется из очереди. 
//У клиента есть деньги, корзина и сумка. В корзине все товары, что не куплены, а в сумке все купленные. 
//При обслуживании клиента проверяется, может ли он оплатить товар, то есть сравнивается итоговая сумма покупки и количество денег.
//Если оплатить клиент не может, то он случайный товар из корзины выкидывает до тех пор, пока его денег не хватит для оплаты.

namespace Unior.Thems6.HomeWork9
{
    internal class HomeWork9
    {

    }

    internal class Client
    {
        private int money;
        private List<Product> _basket;
        private List<Product> Bag;

    }

    internal class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public int Price { private set; get; }
        public string Name { private set; get; }
    }

    internal class Supermarket
    {
        private List<Product> _products;
        private Queue<Client> _lients;
        private int income;

        private void UploadProducts()
        {
            //List<Product> products = 
            //{
                
            //};
            //Create("Ананас", 90),
            //    Create("Хлеб", 20),
            //    Create("Машина", 10000),
        }

        public void AddClient()
        {

        }

        public void ServeClient()
        {

        }
    }
}
