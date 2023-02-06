using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSpinOnline.Cards
{
    class CardFactory
    {
        public Card createCard(int value, string color, bool spin)
        {
            return new Card(value, color, spin);
        }

        public Deck generateDeck()
        {
            var deck = new Deck();

            string[] colors = { "Blue", "Green", "Red", "Yellow" };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (j < 10)
                    {
                        deck.Add(createCard(j, colors[i], false));
                    }
                    else if (j == 10)
                    {
                        //discount the second 0
                    }
                    else if (j < 16)
                    {
                        deck.Add(createCard(j - 10, colors[i], true));
                    }
                    else if (j < 20)
                    {
                        deck.Add(createCard(j - 10, colors[i], false));
                    }
                    else if (j < 22)
                    {
                        deck.Add(createCard(10, colors[i], false));
                    }
                    else if (j < 24)
                    {
                        deck.Add(createCard(11, colors[i], false));
                    }
                    else if (j < 26)
                    {
                        deck.Add(createCard(12, colors[i], false));
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                deck.Add(createCard(13, "N/A", false));
                deck.Add(createCard(14, "N/A", false));
            }

            return deck;
        }
    }
}
