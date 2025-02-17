using System;

namespace Unior.Thems6.HomeWork3
{
    internal class HomeWork3
    {
        public static void Main()
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
                        database.AddPlayer(database.ParsePlayer());
                        break;

                    case CommandBannedPlayer:
                        database.BanPlayer();
                        break;

                    case CommandUnBannedPlayer:
                        database.UnbanPlayer();
                        break;

                    case CommandRemovePlayer:
                        database.RemovePlayer();
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

        public void Ban() => IsBanned = true;
        public void Unban() => IsBanned = false;
    }

    internal class Database
    {
        private List<Player> Players;
        private int LastId;

        public Database()
        {
            Players = new List<Player>();
            LastId = 0;
        }

        public void ShowInfo()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine($"{player.Id} {player.Login} {player.Level} {player.IsBanned}");
            }
        }

        public void AddPlayer(Player player)
        {
                Players.Add(player);
                LastId++;
        }

        public Player ParsePlayer()
        {
            Console.WriteLine("Введите имя и уровень игрока (через пробел)");
            string[] input = Console.ReadLine().Split();

            Player player = new Player(LastId, input[0], Convert.ToInt16(input[1]));

            return player;
        }

        public void BanPlayer()
        {
            if (TryGetPlayer(ReadId(), out Player player))
            { 
                player.Ban();
            }
        }

        public void UnbanPlayer()
        {
            if (TryGetPlayer(ReadId(), out Player player))
            {
                player.Unban();
            }

        }

        public void RemovePlayer()
        {
            if (TryGetPlayer(ReadId(), out Player player))
            {
                Players.Remove(player);
            }
        }

        private bool TryGetPlayer(int playerId, out Player player)
        {
            player = null;

            foreach (Player elementPlayer in Players)
            {
                if (elementPlayer.Id == playerId)
                {
                    player = elementPlayer;
                    return true; 
                }
            }

            return false; 
        }

        private int ReadId()
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
}



//public bool BanPlayer(int playerId)
//{
//    if (TryGetPlayer(playerId, out Player player))
//    {
//        player.Ban(); // Предполагается, что у Player есть метод Ban()
//        return true;
//    }
//    else
//    {

//        Console.WriteLine($"Игрок с ID {playerId} не найден.");
//        return false;
//    }
//}


