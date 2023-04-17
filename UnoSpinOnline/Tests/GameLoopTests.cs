using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnoSpinOnline.Cards;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using System.IO;
using System.Diagnostics;
using UnoSpinOnline;
using UnoSpinOnline.GameFlow;

namespace UnoSpinOnline.Tests
{
    [TestFixture]
    class GameLoopTests
    {


        private GameLoop model;
        
        [SetUp]
        public void SetUp()
        {
            model = new GameLoop();
        }

        [Test]
        public void GameLoopConstructor()
        {
            Assert.AreEqual(0, model.GetNumPlayers());
            Assert.AreEqual(0, model.GetPlayerTurn());
            Assert.AreEqual(0, model.GetForcedPickupAmount());
            Assert.AreEqual(false, model.GetGameStarting());
            Assert.AreEqual(String.Empty, model.GetCurrentColor());
            Assert.AreEqual(-1, model.GetWinner());
            Assert.AreEqual(false, model.IsSpinning());
            Assert.AreEqual(-1, model.GetSpinnerResult());
            Assert.AreEqual(-1, model.GetUnoSpinWinner());
            Assert.AreEqual(-1, model.GetHighestCardValue());
        }

        [Test]
        public void GameLoopDeserializeConstructor()
        {
            byte[] serializedModel = model.Serialize();
            GameLoop deserializedModel = new GameLoop(serializedModel);


            Assert.AreEqual(0, deserializedModel.GetNumPlayers());
            Assert.AreEqual(0, deserializedModel.GetPlayerTurn());
            Assert.AreEqual(0, deserializedModel.GetForcedPickupAmount());
            Assert.AreEqual(false, deserializedModel.GetGameStarting());
            Assert.AreEqual(String.Empty, deserializedModel.GetCurrentColor());
            Assert.AreEqual(-1, deserializedModel.GetWinner());
            Assert.AreEqual(false, deserializedModel.IsSpinning());
            Assert.AreEqual(-1, deserializedModel.GetSpinnerResult());
            Assert.AreEqual(-1, deserializedModel.GetUnoSpinWinner());
            Assert.AreEqual(-1, deserializedModel.GetHighestCardValue());
        }

        [Test]
        public void GameLoopAddPlayerTest()
        {
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);

            Assert.AreEqual(2, model.GetNumPlayers());

        }

        [Test]
        public void GameLoopDealCards()
        {
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);

            model.DealCards();

            Assert.AreEqual(7, model.GetPlayer(0).GetHandSize());
            Assert.AreEqual(7, model.GetPlayer(1).GetHandSize());
            Assert.AreEqual(7, model.GetPlayer(2).GetHandSize());
        }

        [Test]
        public void GameLoopTradeHands()
        {
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);

            model.GetPlayer(0).SetHand(new List<Card>() { new Card(1, String.Empty, false) });
            model.GetPlayer(1).SetHand(new List<Card>() { new Card(2, String.Empty, false) });
            model.GetPlayer(2).SetHand(new List<Card>() { new Card(3, String.Empty, false) });

            List<Card> p1Hand = model.GetPlayer(0).GetHand();
            List<Card> p2Hand = model.GetPlayer(1).GetHand();
            List<Card> p3Hand = model.GetPlayer(2).GetHand();

            model.TradeHands();

            Assert.AreEqual(p3Hand, model.GetPlayer(0).GetHand());
            Assert.AreEqual(p1Hand, model.GetPlayer(1).GetHand());
            Assert.AreEqual(p2Hand, model.GetPlayer(2).GetHand());
        }

        [Test]
        public void GameLoopEndTurnClockwise()
        {
            model.AddPlayer("Player 1");
            model.AddPlayer("Player 2");
            model.AddPlayer("Player 3");

            Assert.AreEqual(0, model.GetPlayerTurn());

            model.EndTurn();

            Assert.AreEqual(1, model.GetPlayerTurn());

            model.EndTurn();

            Assert.AreEqual(2, model.GetPlayerTurn());

            model.EndTurn();

            Assert.AreEqual(0, model.GetPlayerTurn());
        }

        [Test]
        public void GameLoopEndTurnCounterClockwise()
        {
            model.AddPlayer("Player 1");
            model.AddPlayer("Player 2");
            model.AddPlayer("Player 3");

            model.ChangeDirection();

            Assert.AreEqual(0, model.GetPlayerTurn());

            model.EndTurn();

            Assert.AreEqual(2, model.GetPlayerTurn());

            model.EndTurn();

            Assert.AreEqual(1, model.GetPlayerTurn());

            model.EndTurn();

            Assert.AreEqual(0, model.GetPlayerTurn());
        }

        [Test]
        public void GameLoopChangeDirectionBackToClockwise()
        {
            model.AddPlayer("Player 1");
            model.AddPlayer("Player 2");
            model.AddPlayer("Player 3");

            model.ChangeDirection();
            model.ChangeDirection();

            Assert.AreEqual(0, model.GetPlayerTurn());

            model.EndTurn();

            Assert.AreEqual(1, model.GetPlayerTurn());

            model.EndTurn();

            Assert.AreEqual(2, model.GetPlayerTurn());

            model.EndTurn();

            Assert.AreEqual(0, model.GetPlayerTurn());
        }

        [Test]
        public void GameLoopResetGame()
        {
            model.ResetGame();

            Assert.IsNull(model.PeekDiscardDeck());
            Assert.AreEqual(0, model.GetPlayerTurn());
            Assert.AreEqual(-1, model.GetWinner());
            Assert.AreEqual(0, model.GetForcedPickupAmount());
            Assert.AreEqual(String.Empty, model.GetCurrentColor());
            Assert.AreEqual(false, model.GetGameStarting());
            Assert.AreEqual(0, model.GetPlayerTurn());
        }

        [Test]
        public void GameLoopResetGameEmptyPlayerHands()
        {
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);

            model.DealCards();

            foreach (Player player in model.GetPlayers())
            {
                Assert.AreNotEqual(0, player.HandSize());
            }

            model.ResetGame();

            foreach (Player player in model.GetPlayers())
            {
                Assert.AreEqual(0, player.HandSize());
            }
        }

        [Test]
        public void GameLoopSetAndResetHighestCardValue()
        {
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);

            int highestValue = 8;

            model.GetPlayer(0).PickupCard(new Card(highestValue, String.Empty, false));
            model.GetPlayer(1).PickupCard(new Card(1, String.Empty, false));
            model.GetPlayer(2).PickupCard(new Card(2, String.Empty, false));

            model.SetHighestCardValue();

            Assert.AreEqual(highestValue, model.GetHighestCardValue());

            model.ResetHighestCardValue();

            Assert.AreEqual(-1, model.GetHighestCardValue());
        }

        [Test]
        public void SetSpinnerResult()
        {
            model.SetSpinnerResult();
            int result = model.GetSpinnerResult();

            Assert.LessOrEqual(1, result);
            Assert.GreaterOrEqual(9, result);
        }

        [Test]
        public void GameLoopWinner()
        {
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);

            model.Winner();

            Assert.AreEqual(0, model.GetWinner());

            model.ResetGame();
            model.EndTurn();
            model.Winner();

            Assert.AreEqual(1, model.GetWinner());
        }

        [Test]
        public void GameLoopPlayCard()
        {
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);

            Card player1Card = new Card(1, String.Empty, false);
            Card player2Card = new Card(2, String.Empty, false);
            Card player3Card = new Card(3, String.Empty, false);

            model.GetPlayer(0).PickupCard(player1Card);
            model.GetPlayer(1).PickupCard(player2Card);
            model.GetPlayer(2).PickupCard(player3Card);

            model.PlayCard(0);
            Assert.AreEqual(player1Card, model.PeekDiscardDeck());
            model.EndTurn();

            model.PlayCard(0);
            Assert.AreEqual(player2Card, model.PeekDiscardDeck());
            model.EndTurn();

            model.PlayCard(0);
            Assert.AreEqual(player3Card, model.PeekDiscardDeck());
        }

        [Test]
        public void GameLoopPlayCardForPlayer()
        {
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);

            Card player1Card = new Card(1, String.Empty, false);
            Card player2Card = new Card(2, String.Empty, false);
            Card player3Card = new Card(3, String.Empty, false);

            model.GetPlayer(0).PickupCard(player1Card);
            model.GetPlayer(1).PickupCard(player2Card);
            model.GetPlayer(2).PickupCard(player3Card);

            model.PlayCardForPlayer(0, 0);
            Assert.AreEqual(player1Card, model.PeekDiscardDeck());
            
            model.PlayCardForPlayer(1, 0);
            Assert.AreEqual(player2Card, model.PeekDiscardDeck());
           
            model.PlayCardForPlayer(2, 0);
            Assert.AreEqual(player3Card, model.PeekDiscardDeck());
        }

        
        [Test]
        public void GameLoopPickupCard()
        {
            model.AddPlayer(String.Empty);
            model.PickupCard();

            Assert.IsNotNull(model.GetPlayer(0).GetCard(0));
        }

        [Test]
        public void GameLoopGetPlayerReturnsNull()
        {
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);
            
            Assert.IsNull(model.GetPlayer(99));
        }

        [Test]
        public void GameLoopSetWinner()
        {
            int winnerNo = 5;

            model.SetWinner(winnerNo);
            Assert.AreEqual(winnerNo, model.GetWinner());
        }

        [Test]
        public void GameLoopCurrentPlayerNull()
        {
            Assert.IsNull(model.CurrentPlayer());
        }

        [Test]
        public void GameLoopForcedPickupAmount()
        {
            Assert.AreEqual(0, model.GetForcedPickupAmount());

            model.AddToForcedPickupAmount(4);
            Assert.AreEqual(4, model.GetForcedPickupAmount());

            model.AddToForcedPickupAmount(2);
            Assert.AreEqual(6, model.GetForcedPickupAmount());

            model.DecrementForcedPickupAmount();
            Assert.AreEqual(5, model.GetForcedPickupAmount());
        }

        [Test]
        public void GameLoopSetUnoSpinWinner()
        {
            int unoWinner = 5;

            model.SetUnoSpinWinner(5);
            Assert.AreEqual(unoWinner, model.GetUnoSpinWinner());
        }

        [Test]
        public void GameLoopGetPlayers()
        {
            Assert.AreEqual(0, model.GetPlayers().Count);

            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);
            model.AddPlayer(String.Empty);

            Assert.AreEqual(3, model.GetPlayers().Count);
            Assert.AreEqual(String.Empty, model.GetPlayers()[0].Name());
        }

        [Test]
        public void GameLoopSetColor()
        {
            string mockColor = "mock_color";
            model.SetCurrentColor(mockColor);
            Assert.AreEqual(mockColor, model.GetCurrentColor());
        }

        [Test]
        public void GameLoopSetSpinning()
        {
            bool mockSpin = false;
            model.SetSpinning(mockSpin);
            Assert.AreEqual(mockSpin, model.IsSpinning());
        }
    }
}
