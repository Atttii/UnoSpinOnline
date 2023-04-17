using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnoSpinOnline.GameFlow;
using UnoSpinOnline.Cards;

namespace UnoSpinOnline.Tests
{
    [TestFixture]
    class PlayerTests
    {
        private Player player;

        [SetUp]
        public void SetUp()
        {
            player = new Player("mock_name", 66);
        }

        [Test]
        public void PlayerConstructor()
        {
            Assert.AreEqual("mock_name", player.Name());
            Assert.AreEqual(66, player.GetNumber());
            Assert.AreEqual(0, player.GetHandSize());
        }

        [Test]
        public void PlayerHighestCard()
        {
            Card highestCard = new Card(9, String.Empty, false);
            Card middleCard = new Card(8, String.Empty, false);
            Card lowestCard = new Card(7, String.Empty, false);

            player.PickupCard(highestCard);
            player.PickupCard(middleCard);
            player.PickupCard(lowestCard);

            Card recievedCard = player.GetHighestCard();
            Assert.AreEqual(highestCard, recievedCard);
            Assert.AreEqual(highestCard.GetValue(), player.GetHighestCardValue());
            Assert.AreEqual(0, player.GetHighestCardIndex());
        }

        [Test]
        public void PlayerHighestCardEmptyHand()
        {
            Card recievedCard = player.GetHighestCard();
            Assert.AreEqual(null, recievedCard);
        }

        [Test]
        public void PlayerEmptyHand()
        {
            for (int i = 0; i < 5; i++)
            {
                player.PickupCard(new Card(0, String.Empty, false));
            }
            
            Assert.AreEqual(5, player.GetHandSize());

            player.EmptyHand();

            Assert.AreEqual(0, player.GetHandSize());
        }

        [Test]
        public void PlayerPlayCard()
        {
            Card highestCard = new Card(9, String.Empty, false);
            Card middleCard = new Card(8, String.Empty, false);
            Card lowestCard = new Card(7, String.Empty, false);

            player.PickupCard(highestCard);
            player.PickupCard(middleCard);
            player.PickupCard(lowestCard);

            Card playedCard = player.PlayCard(0);

            Assert.AreEqual(highestCard, playedCard);
            Assert.AreEqual(2, player.GetHandSize());
        }

        [Test]
        public void PlayerSetHand()
        {
            List<Card> oldHand = new List<Card>() { new Card(1, String.Empty, false), new Card(2, String.Empty, false) };
            List<Card> newHand = new List<Card>() { new Card(5, String.Empty, false), new Card(8, String.Empty, false), new Card(7, String.Empty, false) };
            
            foreach (Card card in oldHand)
            {
                player.PickupCard(card);
            }

            Assert.AreEqual(oldHand, player.GetHand());

            List<Card> returnHand = player.SetHand(newHand);

            Assert.AreEqual(newHand, player.GetHand());
            Assert.AreEqual(oldHand, returnHand);
        }

        [Test]
        public void PlayerSetNumber()
        {
            int mockNumber = 2;
            player.SetNumber(mockNumber);
            Assert.AreEqual(mockNumber, player.GetNumber());
        }
    }
}
