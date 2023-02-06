using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoSpinOnline.Cards;

namespace UnoSpinOnline.GameFlow
{
    class GameLoop
    {
        private Deck deck;
        private Deck discardPile;
        private List<Player> players;
        private int numPlayers;
        private int playerTurn;
        bool clockwiseDirection;


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
        }

        public void PlayerWins()
        {
            CardFactory cardFactory = new CardFactory();
            deck = cardFactory.generateDeck();
            deck.Shuffle();
            discardPile = new Deck();
            playerTurn = 0;
            clockwiseDirection = true;
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

        public void DealCards()
        {
            foreach (Player p in players)
            {
                for (int i = 0; i < 4; i++)
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
                players.Add(new Player(name));
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
            return players[playerTurn];
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

        public Card PeekDiscardDeck()
        {
            return discardPile.Peek();
        }

        public void PickupCard()
        {
            CurrentPlayer().PickupCard(deck.Pop());
        }

    }
}
