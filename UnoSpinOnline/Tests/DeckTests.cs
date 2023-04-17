using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnoSpinOnline.Cards;

namespace UnoSpinOnline.Tests
{
    [TestFixture]
    class DeckTests
    {
        private Deck fullDeckUnshuffled;

        [SetUp]
        public void SetUp()
        {
            fullDeckUnshuffled = new Deck(true);
        }

        [TearDown]
        public void TearDown()
        {
            //
        }

        [Test]
        public void DeckContainsAllCardsTrue()
        {
            Assert.AreEqual(106, fullDeckUnshuffled.Size());
        }

        [Test]
        public void DeckContainsAllCardsFalse()
        {
            Deck emptyDeck = new Deck(false);

            Assert.AreEqual(0, emptyDeck.Size());
        }

        [Test]
        public void FullDeckInitializesCardsProperly()
        {
            while(fullDeckUnshuffled.Size() !=0)
            {
                Assert.IsNotNull(fullDeckUnshuffled.Pop());
            }
        }

        [Test]
        public void FullDeckShuffle()
        {
           
            Deck shuffled = new Deck(true);
            shuffled.Shuffle();

            Assert.AreNotEqual(fullDeckUnshuffled.Peek(), shuffled.Peek());

        }

        [Test]
        public void AddPutsCardOnTop()
        {
            Card addedCard = new Card(66, "mock_color", true);

            Deck shuffled = new Deck(true);
            shuffled.Shuffle();
            shuffled.Add(addedCard);

            Assert.AreEqual(addedCard, shuffled.Peek());
        }


        [Test]
        public void PopEmptyDeck()
        {
            Deck emptyDeck = new Deck(false);

            Card popCard = emptyDeck.Pop();

            Assert.IsNull(popCard);
        }

        [Test]
        public void PeekEmptyDeck()
        {
            Deck emptyDeck = new Deck(false);

            Card peekCard = emptyDeck.Pop();

            Assert.IsNull(peekCard);
        }

    }
}
