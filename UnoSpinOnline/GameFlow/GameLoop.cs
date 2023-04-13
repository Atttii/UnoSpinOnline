using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnoSpinOnline.Cards;

namespace UnoSpinOnline.GameFlow
{
    [Serializable]
    class GameLoop
    {
        protected Deck deck;
        protected Deck discardPile;
        protected List<Player> players;
        protected int numPlayers;
        protected int playerTurn;
        protected bool clockwiseDirection;
        protected int forcedPickupAmount;
        protected bool gameStarting;
        protected string color;
        protected int winner;
        protected bool isSpinnerSpinning;
        protected int spinnerResult;
        protected int unoSpinWinner;
        protected int highestCommunityCard;


        public GameLoop()
        {
            CardFactory cardFactory = new CardFactory();
            deck = cardFactory.generateDeck();
            deck.Shuffle();
            discardPile = new Deck();
            players = new List<Player>();
            numPlayers = 0;
            playerTurn = 0;
            clockwiseDirection = true;
            forcedPickupAmount = 0;
            gameStarting = false;
            color = String.Empty;
            winner = -1;
            isSpinnerSpinning = false;
            spinnerResult = 1;
            unoSpinWinner = -1;
            highestCommunityCard = -1;
        }

        public GameLoop(byte[] message)
        {
            GameLoop g = Deserialize(message);

            CardFactory cardFactory = new CardFactory();
            deck = g.deck;
            discardPile = g.discardPile;
            players = g.players;
            numPlayers = g.numPlayers;
            playerTurn = g.playerTurn;
            clockwiseDirection = g.clockwiseDirection;
            forcedPickupAmount = g.forcedPickupAmount;
            gameStarting = g.gameStarting;
            color = g.color;
            winner = g.winner;
            isSpinnerSpinning = g.isSpinnerSpinning;
            spinnerResult = g.spinnerResult;
            unoSpinWinner = g.unoSpinWinner;
            highestCommunityCard = g.highestCommunityCard;
        }

        public void Winner()
        {
            winner = CurrentPLayerNumber();
        }

        public void ResetGame()
        {
            CardFactory cardFactory = new CardFactory();
            deck = cardFactory.generateDeck();
            deck.Shuffle();
            discardPile = new Deck();
            playerTurn = 0;
            clockwiseDirection = true;
            winner = -1;
            forcedPickupAmount = 0;
            color = String.Empty;
            gameStarting = false;

            foreach (Player p in players)
            {
                p.EmptyHand();
            }
        }

        public void ChangeDirection()
        {
            if (clockwiseDirection)
            {
                clockwiseDirection = false;
            } else
            {
                clockwiseDirection = true;
            }
        }

        public int GetHighestCardValue()
        {
            return highestCommunityCard;
        }

        public void ResetHighestCardValue()
        {
            highestCommunityCard = -1;
        }

        public void SetHighestCardValue()
        {
            foreach (Player p in players)
            {
                if (p.GetHighestCardValue() > highestCommunityCard)
                {
                    highestCommunityCard = p.GetHighestCardValue();
                }
            }
        }

        public void SetSpinnerResult()
        {
            Random rand = new Random();
            spinnerResult = rand.Next(1, 10);
        }

        public int GetSpinnerResult()
        {
            return spinnerResult;
        }

        public void DealCards()
        {
            foreach (Player p in players)
            {
                for (int i = 0; i < 7; i++)
                {
                    p.PickupCard(deck.Pop());
                }
            }

            discardPile.Add(deck.Pop());
        }


        public bool AddPlayer(string name)
        {
            if (numPlayers >= 6)
            {
                return false;
            } else
            {
                players.Add(new Player(name, players.Count));
                numPlayers++;
                return true;
            }
        }

        public int GetNumPlayers()
        {
            return numPlayers;
        }

        public void EndTurn()
        {
            if (clockwiseDirection)
            {
                if (playerTurn == numPlayers-1)
                {
                    playerTurn = 0;
                } else
                {
                    playerTurn++;
                }
            } else
            {
                if (playerTurn == 0)
                {
                    playerTurn = numPlayers-1;
                }
                else
                {
                    playerTurn--;
                }
            }
        }


        public Player CurrentPlayer()
        {
            foreach (Player p in players)
            {
                if (p.GetNumber() == playerTurn)
                {
                    return p;
                }
            }
            return null;
        }


        public int CurrentPLayerNumber()
        {
            return playerTurn;
        }

        public void PlayCard(int i)
        {
            //card playability is handled in the view
            discardPile.Add(CurrentPlayer().PlayCard(i));
        }

        public void PlayCardForPlayer(int player, int card)
        {
            //card playability is handled in the view
            discardPile.Add(players[player].PlayCard(card));
        }

        public Card PeekDiscardDeck()
        {
            return discardPile.Peek();
        }

        public Card PickupCard()
        {
            Card c = deck.Pop();
            CurrentPlayer().PickupCard(c);
            return c;
        }


        public int GetPlayerTurn()
        {
            return playerTurn;
        }

        public Player GetPlayer(int i)
        {
            foreach (Player p in players)
            {
                if (p.GetNumber() == i)
                {
                    return p;
                }
            }

            return null;
        }

        public int GetWinner()
        {
            return winner;
        }

        public void SetWinner(int i)
        {
            winner = i;
        }

        public int GetUnoSpinWinner()
        {
            return unoSpinWinner;
        }

        public void SetUnoSpinWinner(int value)
        {
            unoSpinWinner = value;
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public int GetForcedPickupAmount()
        {
            return forcedPickupAmount;
        }

        public void AddToForcedPickupAmount(int i)
        {
            forcedPickupAmount += i;
        }

        public void DecrementForcedPickupAmount()
        {
            forcedPickupAmount--;
        }

        public bool GetGameStarting()
        {
            return gameStarting;
        }

        public void SetGameStarting(bool s)
        {
            gameStarting = s;
        }

        public void SetCurrentColor(string c)
        {
            color = c;
        }

        public string GetCurrentColor()
        {
            return color;
        }

        public void SetSpinning(bool spin)
        {
            isSpinnerSpinning = spin;
        }

        public bool IsSpinning()
        {
            return isSpinnerSpinning;
        }


        public void TradeHands()
        {
            List<Card> temp = players[0].GetHand();

            for (int i = 0; i < players.Count; i++)
            {
                if (i == 0)
                {
                    temp = players[i].SetHand(players[players.Count-1].GetHand());
                } else
                {
                    temp = players[i].SetHand(temp);
                }
            }
        }

        public byte[] Serialize()
        {

            using (var memoryStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(memoryStream, this);
                return memoryStream.ToArray();
            }
        }

        public GameLoop Deserialize(byte[] message)
        {
            using (var memoryStream = new MemoryStream(message))
            {
                return (GameLoop)(new BinaryFormatter()).Deserialize(memoryStream);
            }
        }

    }
}
