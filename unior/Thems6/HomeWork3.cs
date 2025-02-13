using System;
using System.Numerics;

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
        public static void Main()
        {

        }
    }

    public class PlayerHomeWork3
    {
        public string login;
        public int level;
        public bool IsBan;

        public PlayerHomeWork3(string login, int level, bool isBan)
        {
            this.login = login;
            this.level = level;
            IsBan = isBan;
        }
    }

    public class BaseData
    {
        public Dictionary<int, PlayerHomeWork3>  Row;

        public BaseData(int id, PlayerHomeWork3 player) 
        {
            Row = new Dictionary<int, PlayerHomeWork3>()
            {
                {0, player}
            };
        }

    }
}
