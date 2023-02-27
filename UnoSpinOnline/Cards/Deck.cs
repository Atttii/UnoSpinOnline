using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSpinOnline.Cards
{
    [Serializable]
    class Deck
    {
        private List<Card> cards;
        

        public Deck()
        {
            cards = new List<Card>();
        }
        

        public void Add(Card c)
        {
            cards.Add(c);
        }

        public Card Pop()
        {
            if (cards.Count == 0)
            {
                return null;
            }

            Card discard = cards[cards.Count-1];
            cards.RemoveAt(cards.Count - 1);

            return discard;
        }

        public Card Peek()
        {
            if (cards.Count == 0)
            {
                return null;
            }

            return cards[cards.Count - 1];
        }

        public void Shuffle()
        {
            Random random = new Random();
            cards = cards.OrderBy(_ => random.Next()).ToList<Card>();
        }

        public int Size()
        {
            return cards.Count;
        }

    }
}
