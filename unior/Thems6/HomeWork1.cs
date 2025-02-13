using System;

namespace Unior.Thems6
{
    internal class HomeWork1
    {
        public static void Hm1()
        {
            PlayerHomeWork1 player = new PlayerHomeWork1();
            player.ShowPlayer();

            PlayerHomeWork1 player2 = new PlayerHomeWork1(new DateTime(1997, 02, 15), 8, "Petr");
            player2.ShowPlayer();
        }
    }
    public class PlayerHomeWork1
    {
        public DateTime BirthDay;
        public int Level;
        public string Name ;

        public PlayerHomeWork1(DateTime birthDay, int level, string name)
        {
            BirthDay = birthDay;
            Level = level;
            Name = name;
        }

        public PlayerHomeWork1()
        {
            BirthDay = new DateTime(1997, 01, 20); ;
            Level = 5;
            Name = "Ioann";
        }

        public void ShowPlayer()
        {
            Console.WriteLine($"{Name} {Level} {BirthDay}");
        }
    }
}
