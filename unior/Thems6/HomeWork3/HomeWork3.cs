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

            Database database = new Database();

            char inputCommand = '0';
            bool isCurrentWorkProgramm = true;

            while (isCurrentWorkProgramm)
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
                        database.AddPlayer(database.ReadPlayer());
                        break;

                    case CommandBannedPlayer:
                        database.BanPlayer(ReadId());
                        break;

                    case CommandUnBannedPlayer:
                        database.UnbanPlayer(ReadId());
                        break;

                    case CommandRemovePlayer:
                        database.RemovePlayer(ReadId());
                        break;

                    case CommandStopProgramm:
                        isCurrentWorkProgramm = false;
                        break;
                }

                Console.Clear();
                database.ShowInfo();
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
        public Player(int id,string login, int level, bool isBanned = false)
        {
            Id = id;
            Login = login;
            Level = level;
            IsBanned = isBanned;
        }

        public int Id { get; private set; }
        public string Login { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public bool Ban() => IsBanned = true;
        public bool Unban() => IsBanned = false;
    }

    internal class Database
    {
        public List<Player> Row { get; private set; }
        public int LastId { get; private set; }

        public Database()
        {
            Row = new List<Player>();
            LastId = 0;
        }

        public void ShowInfo()
        {
            foreach (Player player in Row)
            {
                Console.WriteLine($"{player.Id} {player.Login} {player.Level} {player.IsBanned}");
            }
        }

        public void AddPlayer(Player player)
        {
                Row.Add(player);
                LastId++;
        }

        public Player ReadPlayer()
        {
            Console.WriteLine("Введите имя и уровень игрока (через пробел)");
            string[] input = Console.ReadLine().Split();

            Player player = new Player(LastId, input[0], Convert.ToInt16(input[1]));

            return player;
        }

        public void BanPlayer(int id)
        {
            foreach (Player player in Row)
            {
                if (player.Id == id)
                {
                    player.Ban();
                }
            }
        }

        public void UnbanPlayer(int id)
        {
            foreach (Player player in Row)
            {
                if (player.Id == id)
                {
                    player.Unban();
                }
            }
        }

        public void RemovePlayer(int id)
        {
            for (int i = 0; i < Row.Count; i++)
            {
                if (Row[i].Id == id)
                {
                    Row.RemoveAt(i);
                }
            }
        }
    }
}
