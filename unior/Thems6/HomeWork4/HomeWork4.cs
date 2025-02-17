using System;
using System.Text;
using Unior.Thems6.HomeWork4;

namespace Unior.Thems6.HomeWork4
{
    internal class HomeWork4
    {
        public static void Hm4()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int countHand = ReadInt();

            Dealer dealer = new Dealer();
            dealer.ShowInfo();
            dealer.StartGame(countHand);
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
        private List<Card> _cards;

        public Player()
        {
            _cards = new List<Card>();
        }

        public List<Card>  Cards { get { return _cards; } }

        public void GetCards(List<Card> cardsDeal) => _cards = cardsDeal;
    }

    internal class Deck
    {
        public Deck()
        {
            Generate();
        }

        public List<Card> Cards { get; private set; }

        private void Generate()
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
    }

    internal class Dealer
    {
        private Deck _deck;
        private Player _player;

        public Dealer()
        {
            _deck = new Deck();
            _player = new Player();
        }

        public void StartGame(int countCards)
        {
            List<Card> cardsDeals = new List<Card>();
            cardsDeals = _deck.Cards.GetRange(0, countCards);

            _deck.Cards.RemoveRange(0, countCards);
            _player.GetCards(cardsDeals);
        }

        public void ShowInfo()
        {
            if (_player.Cards != null && _player.Cards.Count > 0)
            {
                foreach (Card card in _player.Cards)
                {
                    Console.Write($"{card}" + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("У игрока нет карт.");
            }

            Console.WriteLine($"В колоде осталось {_deck.Cards.Count} карт.");
        }
    }
}
