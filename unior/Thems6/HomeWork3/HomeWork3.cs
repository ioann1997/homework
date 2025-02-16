using System;

namespace Unior.Thems6.HomeWork3
{
    internal class HomeWork3
    {
        public static void Hm3()
        {
            const char CommandAddPlayer = '1';
            const char CommandBannedPlayer = '2';
            const char CommandUnBannedPlayer = '3';
            const char CommandRemovePlayer = '4';
            const char CommandStopProgramm = '5';

            BaseData baseData = new BaseData();

            char inputCommand = '0';
            bool currentWorkProgramm = true;

            while (currentWorkProgramm)
            {
                Console.WriteLine($"{CommandAddPlayer} - Добавить игрока\n" +
                    $"{CommandBannedPlayer} - Забанить игрока\n" +
                    $"{CommandUnBannedPlayer} - Разбанить игрока\n" +
                    $"{CommandRemovePlayer} - удалить игрока\n" +
                    $"{CommandStopProgramm} - Выйти\n");
                inputCommand = Console.ReadKey().KeyChar;

                switch (inputCommand)
                {
                    case CommandAddPlayer:
                        baseData.AddPlayer(baseData.ReadPlayer());
                        break;

                    case CommandBannedPlayer:
                        baseData.BannedPlayer(ReadId());
                        break;

                    case CommandUnBannedPlayer:
                        baseData.UnBannedPlayer(ReadId());
                        break;

                    case CommandRemovePlayer:
                        baseData.RemovePlayer(ReadId());
                        break;

                    case CommandStopProgramm:
                        currentWorkProgramm = false;
                        break;
                }

                Console.Clear();
                baseData.ShowInfo();
                Console.WriteLine();
            }
        }
        public static int ReadId()
        {
            int id = 0;
            Console.Write("Введите id: ");

            while (int.TryParse(Console.ReadLine(), out id) == false)
            {
                Console.WriteLine("Не верный id");
            }

            return id;
        }
    }

    internal class Player
    {
        private string _login;
        private int _level;
        private bool _isBan;

        public Player(string login, int level, bool isBan = false)
        {
            this._login = login;
            this._level = level;
            _isBan = isBan;
        }

        public void ShowPlayer()
        {
            Console.WriteLine($"{_login} {_level} {_isBan}");
        }
    }

    internal class BaseData
    {
        public Dictionary<int, Player> Row;

        public void ShowInfo()
        {
            foreach (var player in Row)
            {
                Console.WriteLine($"{player.Key} {player.Value._login} {player.Value._level} {player.Value._isBan}");
            }
        }

        public void AddPlayer(Player player)
        {
            if (Row == null)
            {
                Row = new Dictionary<int, Player>()
                { {1, player } };
            }
            else
            {
                Row.Add(FindMaxKey(Row) + 1, player);
            }
        }

        public Player ReadPlayer()
        {
            Console.WriteLine("Введите имя и уровень игрока (через пробел)");
            string[] input = Console.ReadLine().Split();

            Player player = new Player(input[0], Convert.ToInt16(input[1]));

            return player;

        }

        public void BannedPlayer(int id)
        {
            if (Row.ContainsKey(id))
            {
                Row[id]._isBan = true;
            }
        }

        public void UnBannedPlayer(int id)
        {
            if (Row.ContainsKey(id))
            {
                Row[id]._isBan = false;
            }
        }

        public void RemovePlayer(int id)
        {
            if (Row.ContainsKey(id))
            {
                Row.Remove(id);
            }
        }

        private static int FindMaxKey(Dictionary<int, Player> data)
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
