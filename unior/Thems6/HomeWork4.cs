using System;

//ДЗ: Колода карт
//Есть крупье(или игральный стол), который содержит колоду карт и игрока.
//Пользователь задает количество карт, которое надо получить игроку и крупье передает из колоды в игрока данное количество карт. 
//После выводится вся информация о картах игрока. 
//Будут классы: Крупье, Игрок, Колода, Карта.

namespace Unior.Thems6
{
    internal class HomeWork4
    {
        public static void hm()
        {
            
        }
    }

    public class Card
    {
        char Value;
        char Suit;
    }

    public class PlayerHomeWork4
    {
        
    }

    public class Deck
    {
        Card[] Cards;
    }

    public class Dealer
    {
        Deck[] Deck;
        PlayerHomeWork4 Player;
    }
}
