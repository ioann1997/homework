using System;

namespace Unior.Thems6.HomeWork1
{
    internal class HomeWork1
    {
        public static void Main()
        {
            Player player = new Player();
            player.ShowInfo();

            Player player2 = new Player(new DateTime(1997, 02, 15), 8, "Petr");
            player2.ShowInfo();
        }
    }
    internal class Player
    {
        private DateTime _birthDay;
        private int _level;
        private string _name;

        public Player(DateTime birthDay, int level, string name)
        {
            _birthDay = birthDay;
            _level = level;
            _name = name;
        }

        public Player()
        {
            _birthDay = new DateTime(1997, 01, 20); ;
            _level = 5;
            _name = "Ioann";
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} {_level} {_birthDay}");
        }
    }
}
