using System;
using System.Text;

//ДЗ: Колода карт
//Есть крупье(или игральный стол), который содержит колоду карт и игрока.
//Пользователь задает количество карт, которое надо получить игроку и крупье передает из колоды в игрока данное количество карт. 
//После выводится вся информация о картах игрока. 
//Будут классы: Крупье, Игрок, Колода, Карта.

namespace Unior.Thems6
{
    internal class HomeWork4
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Deck deck = new Deck();
            deck.ShowInfo();
        }
    }

    internal class Card
    {
        public char Rank;
        public char Suit;

        public Card(char value, char suit) 
        {
            this.Rank = value;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return $"{Suit}{Rank}";
        }
    }

    internal class Player
    {
        public List<Card> CardsHand;

        public Player(List<Card> cardsDeal)
        {
            CardsHand = cardsDeal;
        }
    }

    internal class Deck
    {
        public Deck() 
        { 
            char[] suits = { '♠', '♥', '♦', '♣' };
            char[] ranks = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

            Cards = new List<Card>();

            foreach (char suit in suits)
            {
                foreach (char rank in ranks)
                {
                    Card card = new Card(rank, suit);
                    Cards.Add(card);
                }
            }

            Shuffle();
        }

        public List<Card> Cards { get; private set; }

        private void Shuffle()
        {
            Random random = new Random();

            int length = Cards.Count;

            for (int i = 0; i < length - 1; i++)
            {
                int indexNew = random.Next(i, length);

                if (indexNew != i)
                {
                    Card temp = Cards[i];
                    Cards[i] = Cards[indexNew];
                    Cards[indexNew] = temp;
                }
            }
        }

        public void ShowInfo()
        {
            foreach(Card card in Cards)
            {
                Console.Write($"{card}" + " ");
            }
            Console.WriteLine();
        }
    }

    internal class Dealer
    {
        public Deck Deck;
        public Player Player;
        public int CountCards;

        public Dealer(int countCards)
        {
            this.Deck = new Deck();

            List<Card> cardsDeals = new List<Card>();
            cardsDeals = Deck.Cards.GetRange(0, countCards);

            this.Player = new Player(cardsDeals);

        }
    }
}
