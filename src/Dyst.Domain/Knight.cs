using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Dyst.Domain
{
    public class Knight
    {
        private IList<ICard> _cards;
        private IList<ICard> _hand;
        private IList<ICard> _graveyard;

        public Knight(string name, IEnumerable<ICard> cards, int health, int maxHand, bool isAlive = true, int whiteStones = 12, int redStones = 4)
        {
            MaxHand = maxHand;
            RedStones = redStones;
            WhiteStones = whiteStones;
            Graveyard = new List<ICard>(); 
            Hand = new List<ICard>();
            IsAlive = isAlive;
            Health = health;
            Cards = cards;
            Name = name;
        }


        public bool IsAlive { get; private set; }
        public string Name { get; private set; }
        public int Health  { get; private set; }
        public int MaxHand { get; private set; }

        public IEnumerable<ICard> Cards
        {
            get { return _cards; }
            private set { _cards = value.ToList(); }
        }

        public IEnumerable<ICard> Hand
        {
            get { return _hand; }
            private set { _hand = value.ToList(); }
        }

        public IEnumerable<ICard> Graveyard
        {
            get { return _graveyard; }
            private set { _graveyard = value.ToList(); }
        }

        public int WhiteStones { get; private set; }
        public int RedStones { get; private set; }

        public void DrawCardsUpToMaxHand()
        {
            var currentHandCount = _hand.Count;
            var randomHand = Shuffle(_cards);
            var numberOfCardsToDraw = MaxHand - currentHandCount;
            for (int i = 0; i < numberOfCardsToDraw; i++)
            {
                var card = randomHand.First(); 
                _hand.Add(card);
                _cards.Remove(card);
            }
        }

        private IList<T> Shuffle<T>(IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public ICard PlayCard(ICard card)
        {
            if (!_hand.Contains(card))
            {
                throw new CardNotFoundException();
            }
            _hand.Remove(card);
            _graveyard.Add(card);
            return card;
        }

        public void DrawSpecificCardFromGraveyard(ICard card)
        {
            if (!_graveyard.Contains(card))
            {
                throw new CardNotFoundException();
            }

            _graveyard.Remove(card);
            _hand.Add(card);
        }

        public void DrawSpecificCard(ICard card)
        {
            if (!_cards.Contains(card))
            {
                throw new CardNotFoundException();
            }
            _cards.Remove(card);
            _hand.Add(card);
        }
    }
}
