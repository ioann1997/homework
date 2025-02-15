using System;
using System.Text;
using System.Xml.Linq;

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
            Console.OutputEncoding = Encoding.UTF8;

            Deck deck = new Deck();
            deck.deckShow();
            deck.ShuffleDeck();
            deck.deckShow();
        }
    }

    public class Card
    {
        public char Value;
        public char Suit;

        public Card(char value, char suit) 
        {
            this.Value = value;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return $"{Suit}{Value}";
        }
    }

    public class PlayerHomeWork4
    {
        public Card[] CardsHand;

        //public PlayerHomeWork4 (int countCards)
        //{
        //    for (int i = 0; i < countCards; i++)
        //    {
        //        CardsHand[i] = new Card();
        //    }
        //}
    }

    public class Deck
    {
        public Card[] Cards;

        public Deck() 
        { 
            char[] suits = { '♠', '♥', '♦', '♣' };
            char[] ranks = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

            Cards = new Card[52];
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

        public void ShuffleDeck()
        {
            Random random = new Random();
            random.Shuffle(Cards);
        }

        public void deckShow()
        {
            foreach(Card card in Cards)
            {
                Console.Write($"{card}" + " ");
            }
            Console.WriteLine();
        }


    }

    public class Dealer
    {
        Deck Deck;
        PlayerHomeWork4[] Players;

        public Dealer(int countPlayers) 
        { 
            this.Deck = new Deck();

            for (int i = 0; i < countPlayers; i++)
            {
                Players[i] = new PlayerHomeWork4(); 
            }
        }
    }
}
