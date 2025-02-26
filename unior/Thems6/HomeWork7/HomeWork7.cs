using System;
using System.Collections.Generic;

namespace Unior.Thems6.HomeWork7
{
    internal class HomeWork7
    {
        public static void Main()
        {
            string stopWord = "нет";
            string input = "";
            string commandCreateTrain = "да";
            Dispatcher supervisor = new Dispatcher();

            while (input != stopWord)
            {
                Console.WriteLine($"Создать вагон - {commandCreateTrain} Выйти - {stopWord}");
                input = Console.ReadLine();
                Console.Clear();

                if (input == commandCreateTrain)
                {
                    supervisor.CreateTrain();
                    supervisor.ShowInfo();
                }
            }
        }
    }

    internal class Wagon
    {
        public Wagon()
        {
            CountPlace = 40;
        }

        public int CountPlace { get;  }
    }

    internal class Direction
    {
        private string _departure;
        private string _arrival;

        public Direction(string departure, string arrival)
        {
            _arrival = arrival;
            _departure = departure;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Место отправления: {_departure} Место прибытия: {_arrival}");
        }

        public override string ToString()
        {
            return $"{_departure}-{_arrival}";
        }
    }

    internal class Train
    {
        private List<Wagon> _wagons;
        private Direction _direction;
        private int _countSellTickets;

        public Train(Direction direction, List<Wagon> wagons, int countSellTickets)
        {
            _direction = direction;
            _wagons = wagons;
            _countSellTickets = countSellTickets;
        }

        public override string ToString()
        {
            return $"Направление {_direction} Кол-во вагонов: {_wagons.Count} Всего проданных билетов: {_countSellTickets}";
        }
    }

    internal class Dispatcher
    {
        private List<Train> _trains;

        public Dispatcher()
        {
            _trains = new List<Train>();
        }

        public Direction CreateDirection()
        {
            string departure = "";
            string ariival = "";

            while (departure == ariival)
            {
                departure = UserUtils.ReadString("Введите город отправления: ");
                ariival = UserUtils.ReadString("Введите город прибытия: ");

                if (departure == ariival)
                {
                    Console.WriteLine("Город прибытия не может быть равен городу отправления");
                }
            }

            Direction direction = new Direction(departure, ariival);

            return direction;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Информация о поездах");
            foreach (Train train in _trains)
            {
                Console.WriteLine(train.ToString());
            }
        }

        public List<Wagon> CreateWagons(int passengers)
        {
            List<Wagon> wagons = new List<Wagon>();
            int SumPlace = 0;

            while (SumPlace < passengers)
            {
                Wagon wagon = new Wagon();

                wagons.Add(wagon);
                SumPlace += wagon.CountPlace;
            }

            return wagons;
        }

        public void CreateTrain()
        {
            int passengers = SellTickets();
            List<Wagon> wagons = CreateWagons(passengers);
            Train train = new Train(CreateDirection(), wagons, passengers);
            _trains.Add(train);        
        }
        
        private int SellTickets()
        {
            int minPaassengers = 60;
            int maxPaassengers = 520;
            int passengers = UserUtils.GenerateRandomNumber(minPaassengers,maxPaassengers);

            return passengers;
        }
    }
    
    internal class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return s_random.Next(min, max + 1);
        }

        public static string ReadString(string info)
        {
            Console.Write(info);
            return Console.ReadLine();
        }
    }
}
