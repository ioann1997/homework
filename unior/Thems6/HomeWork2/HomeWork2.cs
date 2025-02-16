using System;

namespace Unior.Thems6.HomeWork2
{
    internal class HomeWork2
    {
        public static void Hm2()
        {
            Player player = new Player();
            player.ShowInfo();
        }
    }
    internal class Player
    {
        private int _positionX;
        private int _positionY;
        private string _view;

        public Player(int positionX, int positionY, string view)
        {
            _positionX = positionX;
            _positionY = positionY;
            _view = view;
        }
        public Player()
        {
            _positionX = 5;
            _positionY = 5;
            _view = "@";
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _positionY - 1; i++)
            {
                Console.WriteLine(' ');
            }
            Console.Write(new string(' ', _positionX - 1) + _view);
        }
    }
}
