using System;
using System.Collections.Generic;

namespace Unior.Thems6.HomeWork7
{
    internal class HomeWork7
    {
        public static void Hm7()
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
        private int _minCountPlace = 30;
        private int _maxCountPlace = 52;

        public Wagon()
        {
            CountPlace = UserUtils.GenerateRandomNumber(_minCountPlace, _maxCountPlace);
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

        public Train(Direction direction)
        {
            _direction = direction;
            _wagons = new List<Wagon>();
        }

        public void AddWagons(int passengers)
        {
            while (SumPlace() < passengers)
            {
                _wagons.Add(new Wagon());
            }
        }

        public int SumPlace()
        {
            int result = 0;

            if (_wagons != null && _wagons.Count > 0)
            {
                foreach (Wagon wagon in _wagons)
                {
                    result += wagon.CountPlace;
                }
            }

            return result;
        }

        public override string ToString()
        {
            return $"Направление {_direction} Кол-во вагонов: {_wagons.Count} Всего мест: {SumPlace()}";
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
            string departure = UserUtils.ReadString("Введите город отправления: ");
            string ariival = UserUtils.ReadString("Введите город прибытия: ");
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

        public void CreateTrain()
        {
            int passengers = SellTickets();
            Train train = new Train(CreateDirection());
            train.AddWagons(passengers);
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
