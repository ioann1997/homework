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
        private int _countPlace;
        private int _minCountPlace = 30;
        private int _maxCountPlace = 52;

        public Wagon(Random random)
        {
            _countPlace = random.Next(_minCountPlace, _maxCountPlace+1);
        }

        public int CountPlace { get { return _countPlace; } }
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

        public void AddWagon(Wagon wagon)
        {
            _wagons.Add(wagon);
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
            Random random = new Random();

            List<String> directions = new List<String>()
                { "Москва — Киров",
                "С.-Петербург — Хельсинки",
                "Москва — Екатеринбург",
                "С.-Петербург — Москва",
                "С.-Петербург — Адлер"};
            string direction = directions[random.Next(directions.Count)];

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
            int passengers = SellTickets(new Random());
            Train train = new Train();

            while (train.SumPlace() < passengers)
            {
                train.AddWagon( new Wagon(new Random()));
            }

            train.CreateDirection();
            _train.Add(train);
            
        }
        private int SellTickets(Random random)
        {
            int minPaassengers = 60;
            int maxPaassengers = 520;
            int passengers = random.Next(minPaassengers, maxPaassengers+1);

            return passengers;
        }
    }
}
