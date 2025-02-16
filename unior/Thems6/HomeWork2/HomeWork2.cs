using System;

namespace Unior.Thems6.HomeWork2
{
    internal class HomeWork2
    {
        public static void Hm2()
        {
            Renderer renderer = new Renderer();
            renderer.DrawPlayer(new Player());
        }
    }
    internal class Player
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public string View { get; private set; }

        public Player(int positionX, int positionY, string view)
        {
            PositionX = positionX ;
            PositionY = positionY;
            View = view;
        }

        public Player()
        {
            PositionX = 5;
            PositionY = 5;
            View = "@";
        }
    }

    internal class Renderer
    {
        public void DrawPlayer(Player player)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.Write(player.View);
            Console.ReadKey(true);
        }
    }
}
