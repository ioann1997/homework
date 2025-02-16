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
        public Player(int positionX, int positionY, char symbol)
        {
            PositionX = positionX ;
            PositionY = positionY;
            Symbol = symbol;
        }

        public Player()
        {
            PositionX = 5;
            PositionY = 5;
            Symbol = '@';
        }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char Symbol { get; private set; }
    }

    internal class Renderer
    {
        public void DrawPlayer(Player player)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.Write(player.Symbol);
            Console.ReadKey(true);
        }
    }
}
