using System;

namespace Unior.Thems6
{
    internal class HomeWork3
    {
        public static void Hm3()
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
                Console.WriteLine($"{CommandAddPlayer} - Добавить игрока\n" +
                    $"{CommandBannedPlayer} - Забанить игрока\n" +
                    $"{CommandUnBannedPlayer} - Разбанить игрока\n" +
                    $"{CommandRemovePlayer} - удалить игрока\n" +
                    $"{CommandStopProgramm} - Выйти\n");
                input = Console.ReadKey().KeyChar;

                switch (input)
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
                baseData.ShowBase();
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
