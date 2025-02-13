using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unior.Thems6
{
    internal class HomeWork2
    {
        public static void Hm2()
        {
            PlayerHomeWork2 player = new PlayerHomeWork2();
            player.ShowPlayer();
        }
    }
    public class PlayerHomeWork2
    {
        public int PositionX;
        public int PositionY;
        public string View ;

        public PlayerHomeWork2(int positionX, int positionY, string view)
        {
            PositionX = positionX;
            PositionY = positionY;
            View = view;
        }
        public PlayerHomeWork2()
        {
            PositionX = 5; 
            PositionY = 5;
            View = "@";
        }

        public void ShowPlayer()
        {
            for (int i = 0; i < PositionY-1; i++)
            {
                Console.WriteLine(' ');
            }
            Console.Write(new String(' ', PositionX-1) + View);
        }
    }
}
