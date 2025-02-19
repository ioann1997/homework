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
            Supervisor supervisor = new Supervisor();

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

    internal class Train
    {
        private List<Wagon> _wagons;
        private string _direction;

        public Train()
        {
            _direction = CreateDirection();
            _wagons = new List<Wagon>();
        }

        public void AddWagon()
        {
            _wagons.Add(new Wagon());
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

        public string CreateDirection()
        {
            List<String> directions = new List<String>()
                { "Москва — Киров",
                "С.-Петербург — Хельсинки",
                "Москва — Екатеринбург",
                "С.-Петербург — Москва",
                "С.-Петербург — Адлер"};

            string direction = directions[UserUtils.GenerateRandomNumber(directions.Count)];

            return direction;
        }

        public override string ToString()
        {
            return $"Направление {_direction} Кол-во вагонов: {_wagons.Count} Всего мест: {SumPlace()}";
        }
    }

    internal class Supervisor
    {
        private List<Train> _train;

        public Supervisor()
        {
            _train = new List<Train>();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Информация о поездах");
            foreach (Train train in _train)
            {
                Console.WriteLine(train.ToString());
            }
        }

        public void CreateTrain()
        {
            int passengers = SellTickets();
            Train train = new Train();

            while (train.SumPlace() < passengers)
            {
                train.AddWagon();
            }

            train.CreateDirection();
            _train.Add(train);
            
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

        public static int GenerateRandomNumber(int max, int min = 0)
        {
            return s_random.Next(min, max + 1);
        }

        public static double GenerateRandomDoubleNumber()
        {
            return s_random.NextDouble();
        }
    }
}
