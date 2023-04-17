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

        public Deck(bool containsAllCards)
        {
            cards = new List<Card>();

            if (containsAllCards)
            {
                string[] colors = { "Blue", "Green", "Red", "Yellow" };

                for (int i = 0; i < colors.Length; i++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (j < 10)
                        {
                            cards.Add(new Card(j, colors[i], false));
                        }
                        else if (j == 10)
                        {
                            //discount the second 0
                        }
                        else if (j < 16)
                        {
                            cards.Add(new Card(j - 10, colors[i], true));
                        }
                        else if (j < 20)
                        {
                            cards.Add(new Card(j - 10, colors[i], false));
                        }
                        else if (j < 22)
                        {
                            cards.Add(new Card(10, colors[i], false));
                        }
                        else if (j < 24)
                        {
                            cards.Add(new Card(11, colors[i], false));
                        }
                        else if (j < 26)
                        {
                            cards.Add(new Card(12, colors[i], false));
                        }
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    cards.Add(new Card(13, "N/A", false));
                    cards.Add(new Card(14, "N/A", false));
                }
            }
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
