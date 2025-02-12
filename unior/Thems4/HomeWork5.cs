using System;
using System.IO;

namespace Unior.Thems4
{
    internal class HomeWork5
    {
        public static void Main()
        {
            Console.CursorVisible = false;

            char[,] map = ReadMap("map.txt");
            int dogX = 1;
            int dogY = 1;

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                ShowMap(map);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(dogX, dogY);
                Console.Write("@");

                char movementKey = Console.ReadKey(true).KeyChar;
                MovementDog(movementKey, ref dogX, ref dogY, map);

            }


        }
        public static void MovementDog(char movementKey, ref int dogX, ref int dogY, char[,] map)
        {
            int[] direction = GetDirection(movementKey);

            int nextPositionDogX = dogX + direction[0];
            int nextPositionDogY = dogY + direction[1];

            if(map[nextPositionDogY , nextPositionDogX] == ' ')
            {
                dogX = nextPositionDogX;
                dogY = nextPositionDogY;
            }
        }
        public static int[] GetDirection(char movementKey)
        {
            const char CommandLeft = 'a';
            const char CommandRight = 'd';
            const char CommandUp = 'w';
            const char CommandDoun = 's';

            int[] direction = { 0, 0 };

            switch (movementKey)
            {
                case CommandLeft:
                    direction[0] = -1;
                    break;

                case CommandRight:
                    direction[0] = 1;
                    break;

                case CommandUp:
                    direction[1] = -1;
                    break;

                case CommandDoun:
                    direction[1] = 1;
                    break;
            }

            return direction;
        }
        public static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);
            char[,] map = new char[file.Length, file[0].Length];

            for (int i = 0; i < map.GetLength(0); i++) 
            {
                for (int j = 0; j < map.GetLength(1); j++) 
                {
                    map[i, j] = file[i][j];
                }
            }

            return map;
        }
        public static void ShowMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
