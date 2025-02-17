using System;
using System.Text;

namespace Unior.Thems6.HomeWork4
{
    internal class HomeWork4
    {
        public static void Hm4()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int countHand = ReadInt();

            Dealer dealer = new Dealer(5);
            dealer.ShowInfo();
        }

        public static int ReadInt()
        {
            int number = 0;
            Console.Write("Введите кол-во карт: ");

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Вы ввели не число");
            }

            return number;
        }
    }

    internal class Card
    {
        private char _rank;
        private char _suit;

        public Card(char value, char suit)
        {
            _rank = value;
            _suit = suit;
        }

        public override string ToString()
        {
            return $"{_suit}{_rank}";
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
            foreach (Card card in Cards)
            {
                Console.Write($"{card}" + " ");
            }
            Console.WriteLine();
        }
    }

    internal class Dealer
    {
        private Deck _deck;
        private Player _player;
        private int _countCards;

        public Dealer(int countCards)
        {
            _deck = new Deck();

            List<Card> cardsDeals = new List<Card>();
            cardsDeals = _deck.Cards.GetRange(0, countCards);

            _player = new Player(cardsDeals);

        }

        public void ShowInfo()
        {
            foreach (Card card in _player.CardsHand)
            {
                Console.Write($"{card}" + " ");
            }
            Console.WriteLine();
        }
    }
}
