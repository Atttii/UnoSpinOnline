using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSpinN_Unit.Cards
{
    class CardFactory
    {
        public Card createCard(int value, string color, bool spin)
        {
            return new Card(value, color, spin);
        }

        public Queue<Card> generateDeck()
        {
            var deck = new Queue<Card>();

            string[] colors = { "Blue", "Green", "Red", "Yellow" };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (j < 10)
                    {
                        deck.Enqueue(createCard(j, colors[i], false));
                    }
                    else if (j == 10)
                    {
                        //discount the second 0
                    }
                    else if (j < 16)
                    {
                        deck.Enqueue(createCard(j - 10, colors[i], true));
                    }
                    else if (j < 20)
                    {
                        deck.Enqueue(createCard(j - 10, colors[i], false));
                    }
                    else if (j < 22)
                    {
                        deck.Enqueue(createCard(10, colors[i], false));
                    }
                    else if (j < 24)
                    {
                        deck.Enqueue(createCard(13, colors[i], false));
                    }
                    else if (j < 26)
                    {
                        deck.Enqueue(createCard(14, colors[i], false));
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                deck.Enqueue(createCard(11, "N/A", false));
                deck.Enqueue(createCard(12, "N/A", false));
            }

            return deck;
        }
    }
}
