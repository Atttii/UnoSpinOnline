using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoSpinOnline.Cards;

namespace UnoSpinOnline.GameFlow
{
    [Serializable]
    class Player
    {
        private string name;
        private List<Card> hand;
        private int number;

        public Player(string n, int i)
        {
            name = n;
            hand = new List<Card>();
            number = i;
        }

        public void PickupCard(Card c)
        {
            hand.Add(c);
        }

        public int GetHandSize()
        {
            return hand.Count;
        }

        public Card GetCard(int i)
        {
            return hand[i];
        }

        public int GetHighestCardValue()
        {
            int highestValue = -1;

            foreach (Card c in hand)
            {
                if (c.GetValue() > highestValue && c.GetValue() < 10)
                {
                    highestValue = c.GetValue();
                }
            }

            return highestValue;
        }

        public Card GetHighestCard()
        {
            if (GetHighestCardIndex() != -1)
            {
                return hand[GetHighestCardIndex()];
            } else
            {
                return null;
            }
        }

        public int GetHighestCardIndex()
        {
            int i;
            int highestCardValue = GetHighestCardValue();

            for (i=0;  i < hand.Count; i++)
            {
                if (hand[i].GetValue()==highestCardValue)
                {
                    return i;
                }
            }
            return -1;
        }

        public Card PlayCard(int i)
        {
            Card discard = hand[i];
            hand.RemoveAt(i);
            return discard;
        }

        public List<Card> GetHand()
        {
            return hand;
        }

        public List<Card> SetHand(List<Card> newHand)
        {
            List<Card> oldHand = hand;
            hand = newHand;
            return oldHand;
        }

        public int HandSize()
        {
            return hand.Count;
        }

        public string Name()
        {
            return name;
        }

        public void SetNumber(int i)
        {
            number = i;
        }

        public int GetNumber()
        {
            return number;
        }

        public void EmptyHand()
        {
            hand.Clear();
        }

    }
}
