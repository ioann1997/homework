using System;
using System.Text;

namespace Unior.Thems6.HomeWork4
{
    internal class HomeWork4
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int countHand = ReadInt();

            Сroupier dealer = new Сroupier();
            dealer.ShowInfo();
            dealer.PlayGame(countHand);
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

        public void TakeCards(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                _cards.Add(card);
            }
        }

        public bool IsCardEmpty => _cards == null || _cards.Count == 0;

        public void ShowInfo()
        {
            if (IsCardEmpty == false)
            {
                foreach (Card card in _cards)
                {
                    Console.Write($"{card}" + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("У игрока нет карт.");
            }        
        }
    }

    internal class Deck
    {
        private List<Card> _cards;
        public Deck()
        {
            //_cards = Generate();
            _cards = new List<Card>();
        }

        public int Count => _cards.Count;

        public List<Card> DealCard(int countCards)
        {
            if (_cards.Count >= countCards)
            {
                List<Card> cardsDeals = new List<Card>();
                cardsDeals = _cards.GetRange(0, countCards);
                _cards.RemoveRange(0, countCards);

                return cardsDeals;
            }
            else
            {
                Console.WriteLine("В колоде не хватает карт");
                return [];
            }
        }

        public void Generate()
        {
            _cards = new List<Card>();

            char[] suits = { '♠', '♥', '♦', '♣' };
            char[] ranks = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

            foreach (char suit in suits)
            {
                foreach (char rank in ranks)
                {
                    Card card = new Card(rank, suit);
                    _cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            int length = _cards.Count;

            for (int i = 0; i < length - 1; i++)
            {
                int indexNew = random.Next(i, length);

                if (indexNew != i)
                {
                    Card temp = _cards[i];
                    _cards[i] = _cards[indexNew];
                    _cards[indexNew] = temp;
                }
            }
        }
    }

    internal class Сroupier
    {
        private Deck _deck;
        private Player _player;

        public Сroupier()
        {
            _deck = new Deck();
            _player = new Player();
        }

        public void PlayGame(int countCards)
        {
            _deck.Generate();
            _deck.Shuffle();
            _player.TakeCards(_deck.DealCard(countCards));
        }

        public void ShowInfo()
        {
            _player.ShowInfo();
            Console.WriteLine($"В колоде осталось {_deck.Count} карт.");
        }
    }
}
