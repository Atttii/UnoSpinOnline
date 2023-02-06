using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoSpinOnline.Cards;

namespace UnoSpinOnline.GameFlow
{
    class Player
    {
        private string name;
        private List<Card> hand;

        public Player(string n)
        {
            name = n;
            hand = new List<Card>();
        }

        public void PickupCard(Card c)
        {
            hand.Add(c);
        }

        public Card GetCard(int i)
        {
            return hand[i];
        }

        public Card PlayCard(int i)
        {
            Card discard = hand[i];
            hand.RemoveAt(i);
            return discard;
        }

        public int HandSize()
        {
            return hand.Count;
        }

        public string Name()
        {
            return name;
        }

    }
}
