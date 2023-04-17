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
    class CardTests
    {
        [Test]
        public void CardConstructor()
        {
            int mockValue = 66;
            string mockColor = "mock_color";
            bool mockSpin = true;

            Card card = new Card(mockValue, mockColor, mockSpin);

            Assert.AreEqual(mockValue, card.GetValue());
            Assert.AreEqual(mockColor, card.GetColor());
            Assert.AreEqual(mockSpin, card.GetSpin());
        }
    }
}
