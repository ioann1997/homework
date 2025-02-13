using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Реализовать базу данных игроков и методы для работы с ней. Должно быть консольное
//меню для взаимодействия пользователя с возможностями базы данных.

//Игрок должен состоять из уникального номера, ника, уровня и булевого значения, забанен ли игрок.

//Реализовать возможность добавления игрока, бана игрока по уникальному номеру, разбана игрока по
//уникальному номеру и удаление игрока по уникальному номеру.

//Создавать полноценные системы баз данных не нужно, задание выполняется инструментами, которые вы уж
//е изучили в рамках курса. Надо сделать класс "База данных".

namespace Unior.Thems6
{
    internal class HomeWork3
    {
        public static void fg()
        {
            const char CommandAddPlayer = '1';
            const char CommandBannedPlayer = '2';
            const char CommandUnBannedPlayer = '3';
            const char CommandRemovePlayer  = '4';
            const char CommandStopProgramm = '5';

            BaseData baseData = new BaseData();

            char input = '0';
            int inputId = 0;
            bool currentWorkProgramm = true;

            while (currentWorkProgramm)
            {
                input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case CommandAddPlayer:
                        baseData.AddPlayer(baseData.ReadPlayer());
                        break;

                    case CommandBannedPlayer:
                        Console.WriteLine("Введите id: ");
                        inputId = int.Parse(Console.ReadLine());
                        baseData.BannedPlayer(inputId);
                        break;

                    case CommandUnBannedPlayer:
                        Console.WriteLine("Введите id: ");
                        inputId = int.Parse(Console.ReadLine());
                        baseData.UnBannedPlayer(inputId);
                        break;

                    case CommandRemovePlayer:
                        Console.WriteLine("Введите id: ");   
                        inputId = int.Parse(Console.ReadLine());
                        baseData.RemovePlayer(inputId);
                        break;

                    case CommandStopProgramm:
                        currentWorkProgramm = false;
                        break;
                }

                baseData.ShowBase();
            }
        }
    }

    public class PlayerHomeWork3
    {
        public string login;
        public int level;
        public bool IsBan;

        public PlayerHomeWork3(string login, int level, bool isBan = false)
        {
            this.login = login;
            this.level = level;
            IsBan = isBan;
        }

        public void ShowPlayer()
        {
            Console.WriteLine($"{login} {level} {IsBan}");
        }
    }

    public class BaseData
    {
        public Dictionary<int, PlayerHomeWork3>  Row;

        public void ShowBase()
        {
            foreach (var row in Row)
            {
                Console.WriteLine($"{row.Key} {row.Value.login} {row.Value.level} {row.Value.IsBan}");
            }
        }

        public void AddPlayer(PlayerHomeWork3 player)
        {
            if (Row == null)
            {
                Row = new Dictionary<int, PlayerHomeWork3>()
                { {1, player } } ;
            }
            else
            {
                Row.Add(FindMaxKey(Row) + 1, player);
            }
        }

        public PlayerHomeWork3 ReadPlayer()
        {
            Console.WriteLine("Введите имя и уровень игрока (через пробел)");
            string[] input = Console.ReadLine().Split();

            PlayerHomeWork3 player = new PlayerHomeWork3(input[0], Convert.ToInt16(input[1]));

            return player;

        }

        public void BannedPlayer(int id)
        {
            if (Row.ContainsKey(id))
            {
                Row[id].IsBan = true;
            }
        }

        public void UnBannedPlayer(int id)
        {
            if (Row.ContainsKey(id))
            {
                Row[id].IsBan = false;
            }
        }

        public void RemovePlayer(int id)
        {
            if (Row.ContainsKey(id))
            {
                Row.Remove(id);
            }
        }

        private static int FindMaxKey(Dictionary<int, PlayerHomeWork3> data)
        {
            int maxKey = 0;

            foreach (int id in data.Keys)
            {
                if (id > maxKey)
                {
                    maxKey = id;
                }
            }

            return maxKey;
        }
    }
}
