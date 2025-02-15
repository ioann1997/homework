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
        public static void sfd()
        {
            Deck deck = new Deck();
            Card[] cards = deck.Cards;

            foreach (Card card in cards)
            {
                Console.Write($"{card}" + " ");
            }

            deck.ShuffleDeck(ref cards);

            foreach (Card card in cards)
            {
                Console.Write($"{card}" + " ");
            }

        }
    }

    public class Card
    {
        public char Value;
        public char Suit;

        public Card(char value, char suit) 
        { 
            char Value = value;
            this.Suit = suit;
        }
    }

    public class PlayerHomeWork4
    {
        
    }

    public class Deck
    {
        public Card[] Cards;

        public Deck() 
        { 
            char[] suits = { '♠', '♥', '♦', '♣' };
            char[] ranks = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

            Card[] Cards = new Card[52];
            int index = 0;

            foreach (char suit in suits)
            {
                foreach (char rank in ranks)
                {
                    Card card = new Card(rank, suit);
                    Cards[index] = card;
                    index++;
                }
            }
        }

        public void ShuffleDeck(ref Card[] Cards)
        {
            Random random = new Random();
            random.Shuffle(Cards);
        }


    }

    public class Dealer
    {
        Deck[] Deck;
        PlayerHomeWork4 Player;
    }
}
