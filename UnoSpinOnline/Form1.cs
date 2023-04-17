using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnoSpinOnline.GameFlow; 
using UnoSpinOnline.Cards;
using SuperSimpleTcp;
using System.Threading;
using System.Timers;

namespace UnoSpinOnline
{
    public partial class Board1 : Form
    {
        private GameLoop model;
        private SimpleTcpClient client;
        private PictureBox[] cardPicArr;
        private int selectedCard = -1;
        private Dictionary<string, Bitmap[]> cardImageMap;
        private Dictionary<string, Bitmap[]> spinCardImageMap;
        private PictureBox[] otherPlayersPictureBoxes;
        private Label[] otherPlayersLabels;
        private Label[] otherPlayersCardCounts;
        private bool gameStarted;
        private int playerNumber;
        private const string IPPORT = "127.0.0.1:8080";
        private Bitmap[] spinnerPicArr;
        private int currentSpinnerImage;
        private int spinCount;
        private bool drawBlue;
        private bool drawRed;
        private bool discardNumber;
        private bool discardColor;
        private int forcedPlayCardAmount;

        public Board1()
        {
            InitializeComponent();
            model = new GameLoop();
            playerNumber = -1;
            gameStarted = false;
            
            cardPicArr = new PictureBox[] { card1, card2, card3, card4, card5, card6, card7, card8, card9,
                                            card10, card11, card12, card13, card14, card15, card16, card17, card18};
            spinnerPicArr = new Bitmap[] { Properties.Resources.spinner0, Properties.Resources.spinner1, Properties.Resources.spinner2,
                                            Properties.Resources.spinner3, Properties.Resources.spinner4, Properties.Resources.spinner5,
                                            Properties.Resources.spinner6, Properties.Resources.spinner7, Properties.Resources.spinner8,
                                            Properties.Resources.spinner9, Properties.Resources.spinner10, Properties.Resources.spinner11,
                                            Properties.Resources.spinner12, Properties.Resources.spinner13, Properties.Resources.spinner14,
                                            Properties.Resources.spinner15, Properties.Resources.spinner16, Properties.Resources.spinner17 };
            currentSpinnerImage = 0;
            drawBlue = false;
            drawRed = false;
            discardColor = false;
            discardNumber = false;
            forcedPlayCardAmount = 0;

            cardImageMap = new Dictionary<string, Bitmap[]>() {{"Blue", new Bitmap[] { Properties.Resources.blue_0, Properties.Resources.blue_1,
                                                    Properties.Resources.blue_2, Properties.Resources.blue_3,
                                                    Properties.Resources.blue_4, Properties.Resources.blue_5,
                                                    Properties.Resources.blue_6, Properties.Resources.blue_7,
                                                    Properties.Resources.blue_8, Properties.Resources.blue_9,
                                                    Properties.Resources.blue_pickup2, Properties.Resources.blue_changedirection,
                                                    Properties.Resources.blue_skipturn
                                                    } }, {"Red", new Bitmap[] { Properties.Resources.red_0, Properties.Resources.red_1,
                                                    Properties.Resources.red_2, Properties.Resources.red_3,
                                                    Properties.Resources.red_4, Properties.Resources.red_5,
                                                    Properties.Resources.red_6, Properties.Resources.red_7,
                                                    Properties.Resources.red_8, Properties.Resources.red_9,
                                                    Properties.Resources.red_pickup2, Properties.Resources.red_changedirection,
                                                    Properties.Resources.red_skipturn
                                                    } }, {"Green", new Bitmap[] { Properties.Resources.green_0, Properties.Resources.green_1,
                                                    Properties.Resources.green_2, Properties.Resources.green_3,
                                                    Properties.Resources.green_4, Properties.Resources.green_5,
                                                    Properties.Resources.green_6, Properties.Resources.green_7,
                                                    Properties.Resources.green_8, Properties.Resources.green_9,
                                                    Properties.Resources.green_pickup2, Properties.Resources.green_changedirection,
                                                    Properties.Resources.green_skipturn
                                                    } }, {"Yellow", new Bitmap[] { Properties.Resources.yellow_0, Properties.Resources.yellow_1,
                                                    Properties.Resources.yellow_2, Properties.Resources.yellow_3,
                                                    Properties.Resources.yellow_4, Properties.Resources.yellow_5,
                                                    Properties.Resources.yellow_6, Properties.Resources.yellow_7,
                                                    Properties.Resources.yellow_8, Properties.Resources.yellow_9,
                                                    Properties.Resources.yellow_pickup2, Properties.Resources.yellow_changedirection,
                                                    Properties.Resources.yellow_skipturn
                                                    } }, { "N/A", new Bitmap[] { Properties.Resources.NA_pickup4, Properties.Resources.NA_changecolor }} };

            spinCardImageMap = new Dictionary<string, Bitmap[]>() {{"Blue", new Bitmap[] { Properties.Resources.blue_1_spin,
                                                    Properties.Resources.blue_2_spin, Properties.Resources.blue_3_spin,
                                                    Properties.Resources.blue_4_spin, Properties.Resources.blue_5_spin,
                                                   } }, {"Red", new Bitmap[] {Properties.Resources.red_1_spin,
                                                    Properties.Resources.red_2_spin, Properties.Resources.red_3_spin,
                                                    Properties.Resources.red_4_spin, Properties.Resources.red_5_spin,
                                                    } }, {"Green", new Bitmap[] { Properties.Resources.green_1_spin,
                                                    Properties.Resources.green_2_spin, Properties.Resources.green_3_spin,
                                                    Properties.Resources.green_4_spin, Properties.Resources.green_5_spin,
                                                    } }, {"Yellow", new Bitmap[] { Properties.Resources.yellow_1_spin,
                                                    Properties.Resources.yellow_2_spin, Properties.Resources.yellow_3_spin,
                                                    Properties.Resources.yellow_4_spin, Properties.Resources.yellow_5_spin,
                                                    }} };


            otherPlayersPictureBoxes = new PictureBox[] { player2PictureBox, player3PictureBox, player4PictureBox, player5PictureBox, player6PictureBox };
            otherPlayersLabels = new Label[] { player2Label, player3Label, player4Label, player5Label, player6Label };
            otherPlayersCardCounts = new Label[] { player2CardCount, player3CardCount, player4CardCount, player5CardCount, player6CardCount };

            foreach (PictureBox p in otherPlayersPictureBoxes)
            {
                p.Visible = false;
            }

            foreach (Label l in otherPlayersLabels)
            {
                l.Visible = false;
            }

            foreach (PictureBox p in cardPicArr)
            {
                p.Visible = false;
            }

            foreach (Label l in otherPlayersCardCounts)
            {
                l.Visible = false;
            }

            playCardButton.Visible = false;
            drawCardButton.Visible = false;
            changeToBlueButton.Visible = false;
            changeToGreenButton.Visible = false;
            changeToRedButton.Visible = false;
            changeToYellowButton.Visible = false;
            ColorIndicator.Visible = false;
            player1Label.Visible = false;
            playerHand1.Visible = false;
            playerHand2.Visible = false;
            dealCardsButton.Visible = false;
            SpinButton.Visible = false;
            ChooseButton.Visible = false;
            UnoSpinButton.Visible = false;

            client = new SimpleTcpClient(IPPORT);
            client.Events.DataReceived += Events_DataReceived;

            SpinnerPictureBox.Image = spinnerPicArr[0];
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (gameStarted)
                {
                    model = new GameLoop(e.Data.Array);

                    SetCurrentColor(model.GetCurrentColor());
                    DisplayCurrentPlayerHand();
                    resetPlayerImages();

                    if (Encoding.UTF8.GetString(e.Data.Array).StartsWith("disconnect")) 
                    {
                        Disconnect();
                    } 
                    else if (model.IsSpinning())
                    {
                        SpinSpinner(model.GetSpinnerResult());

                    }
                    else if (model.GetHighestCardValue() != -1)
                    {
                        War();
                    }
                    else if (model.GetUnoSpinWinner() != -1) {

                        UnoSpinButton.Visible = false;

                        if (model.GetUnoSpinWinner() == playerNumber)
                        {
                            model.SetUnoSpinWinner(-1);
                            forcedPlayCardAmount = 1;
                            playCardButton.Visible = true;
                            UpdatePlayerPrompt("You pressed 'Uno Spin' first! Discard 1 card.");
                        } else
                        {
                            UpdatePlayerPrompt(model.GetPlayer(model.GetUnoSpinWinner()).Name() ," pressed 'Uno Spin' first! They will discard 1 card.");
                        }
                    
                    } 
                    else if (playerNumber == model.GetPlayerTurn() && model.GetWinner() == -1)
                    {
                        StartTurn();
                    }
                    else if (model.GetWinner() != -1)
                    {
                        WinnerScreen(model.GetWinner());
                        gameStarted = false;

                        model.ResetGame();
                        UpdateAllClients();

                        if (playerNumber == 0)
                        {
                            model.ResetGame();
                            UpdateAllClients();
                        }
                    }
                    else
                    {

                        foreach (Label l in otherPlayersLabels)
                        {
                            l.BackColor = Color.Black;
                        }

                        UpdatePlayerCardCounts();

                        if (model.GetPlayerTurn() < playerNumber)
                        {
                            otherPlayersLabels[model.GetPlayerTurn()].BackColor = Color.Orange;
                        }
                        else
                        {
                            otherPlayersLabels[model.GetPlayerTurn() - 1].BackColor = Color.Orange;
                        }

                        UpdatePlayerPrompt(model.GetPlayer(model.GetPlayerTurn()).Name(), "'s turn.");
                        DisplayCurrentPlayerHand();
                    }
                }
                else
                {
                    //Pregame server actions
                    if (Encoding.UTF8.GetString(e.Data.Array).StartsWith("new player-"))
                    {
                        if (playerNumber == 0)
                        {
                            dealCardsButton.Visible = true;
                            model.AddPlayer(Encoding.UTF8.GetString(e.Data.Array).Substring(11, Encoding.UTF8.GetString(e.Data.Array).Length - 12));
                            UpdateAllClients();
                        }

                        player1Label.Visible = true;
                        player1Label.Text = addPlayerNameTextBox.Text;
                        playerHand1.Visible = true;
                        AddPlayerButton.Visible = false;
                        addPlayerNameTextBox.Visible = false;


                        for (int i = 0; i < 18; i++)
                        {
                            cardPicArr[i].Visible = true;
                            cardPicArr[i].Visible = false;
                        }

                    } 
                    else if (Encoding.UTF8.GetString(e.Data.Array).StartsWith("lobby-full")) 
                    {
                        UpdatePlayerPrompt("Lobby full.");
                    } 
                    else if (Encoding.UTF8.GetString(e.Data.Array).StartsWith("player number-"))
                    {

                        if (playerNumber == -1)
                        {
                            playerNumber = Encoding.UTF8.GetString(e.Data.Array)[14] - '0';
                        }

                        client.Send($"new player-{Encoding.UTF8.GetString(e.Data.Array).Substring(16, Encoding.UTF8.GetString(e.Data.Array).Length - 17)}");
                    }
                    else
                    {
                        model = new GameLoop(e.Data.Array);

                        if (model.GetGameStarting())
                        {
                            //model.SetGameStarting(false);
                            gameStarted = true;
                            StartGame();
                            return;
                        }


                        for (int i = 0; i < model.GetNumPlayers(); i++)
                        {
                            if (i < playerNumber)
                            {
                                otherPlayersPictureBoxes[i].Visible = true;
                                otherPlayersLabels[i].Visible = true;
                                otherPlayersLabels[i].Text = model.GetPlayer(i).Name();

                            }
                            else if (i > playerNumber)
                            {
                                otherPlayersPictureBoxes[i - 1].Visible = true;
                                otherPlayersLabels[i - 1].Visible = true;
                                otherPlayersLabels[i - 1].Text = model.GetPlayer(i).Name();
                            }
                        }
                    }
                }
            });
        }

        private void StartGame()
        {
            DisplayCurrentPlayerHand();
            UpdatePlayerCardCounts();

            dealCardsButton.Visible = false;
            addPlayerNameTextBox.Visible = false;
            AddPlayerButton.Visible = false;

            Card firstDiscard = model.PeekDiscardDeck();

            discardPile.Image = GetCardImage(firstDiscard);
            SetColor(firstDiscard);


            if (model.GetPlayerTurn() == playerNumber)
            {
                StartTurn();
            } else if (model.GetPlayerTurn() < playerNumber)
            {
                UpdatePlayerPrompt(model.CurrentPlayer().Name(), "'s turn.");
                otherPlayersLabels[model.GetPlayerTurn()].BackColor = Color.Orange;
            } else
            {
                UpdatePlayerPrompt(model.CurrentPlayer().Name(), "'s turn.");
                otherPlayersLabels[model.GetPlayerTurn() - 1].BackColor = Color.Orange;
            }
        }

        private void StartTurn()
        {
            playCardButton.Visible = true;
            drawCardButton.Visible = true;
            ColorIndicator.Visible = true;
            player1Label.BackColor = Color.Orange;

            foreach(Label l in otherPlayersLabels) 
            {
                l.BackColor = Color.Black;
            }

            UpdatePlayerCardCounts();

            if (model.GetForcedPickupAmount() > 0)
            {
                playCardButton.Visible = false;
                playerPrompt.Text = "Pickup " + model.GetForcedPickupAmount() + "!";
            } else
            {
                playerPrompt.Text = "Your turn.";
            }

            DisplayCurrentPlayerHand();          
        }


        private void resetAllCards()
        {
            for (int i = 0; i < cardPicArr.Length; i++)
            {
                if (i != selectedCard)
                {
                    cardPicArr[i].BorderStyle = BorderStyle.None;
                }
            }
        }

        private void UpdatePlayerCardCounts()
        {
            for (int i = 0; i < model.GetNumPlayers(); i++)
            {
                if (i < playerNumber)
                {
                    otherPlayersCardCounts[i].Visible = true;
                    otherPlayersCardCounts[i].Text = model.GetPlayer(i).GetHandSize().ToString();
                    otherPlayersCardCounts[i].Text += " Cards";

                }
                else if (i > playerNumber)
                {
                    otherPlayersCardCounts[i-1].Visible = true;
                    otherPlayersCardCounts[i-1].Text = model.GetPlayer(i).GetHandSize().ToString();
                    otherPlayersCardCounts[i-1].Text += " Cards";
                }
            }
        }

        private void resetPlayerImages()
        {
            foreach (PictureBox p in otherPlayersPictureBoxes)
            {
                p.Image = Properties.Resources.back_of_card;
            }
        }

        private void War()
        {
            //add winning player names to prompt
            UpdatePlayerPrompt("War! The player(s) with the highest card discards it!");

            for (int i = 0; i < model.GetNumPlayers(); i++)
            {
                if (i < playerNumber)
                {
                    Card playerHighestCard = model.GetPlayer(i).GetHighestCard();

                    if (playerHighestCard != null)
                    {
                        otherPlayersPictureBoxes[i].Image = GetCardImage(playerHighestCard);
                    }
                    else
                    {
                        otherPlayersPictureBoxes[i - 1].Image = Properties.Resources.back_of_card;
                    }

                }
                else if (i > playerNumber)
                {
                    Card playerHighestCard = model.GetPlayer(i).GetHighestCard();

                    if (playerHighestCard != null)
                    {
                        otherPlayersPictureBoxes[i - 1].Image = GetCardImage(playerHighestCard);
                    }
                    else
                    {
                        otherPlayersPictureBoxes[i - 1].Image = Properties.Resources.back_of_card;
                    }
                }
                else
                {
                    int highestCardindex = model.GetPlayer(i).GetHighestCardIndex();

                    if (highestCardindex != -1)
                    {
                        for (int j = 0; j < cardPicArr.Length; j++)
                        {
                            if (j != highestCardindex)
                            {
                                cardPicArr[j].Visible = false;
                            }
                        }

                    }
                    else
                    {
                        //do nothing
                    }
                }
                if (model.GetPlayerTurn() == playerNumber)
                {
                    if (model.GetPlayer(i).GetHighestCardValue() == model.GetHighestCardValue())
                    {
                        model.GetPlayer(i).PlayCard(model.GetPlayer(i).GetHighestCardIndex());
                    }
                }
            }


            if (model.GetPlayerTurn() == playerNumber)
            {
                model.ResetHighestCardValue();
                System.Timers.Timer timer = new System.Timers.Timer(10000);
                timer.Elapsed += (s, e2) => { EndTurn(); };
                timer.AutoReset = false;
                timer.Start();
            }
        }

        private void DisplayCurrentPlayerHand()
        {
            Player currentPLayer = model.GetPlayer(playerNumber);

            if (currentPLayer.HandSize() > 9)
            {
                playerHand2.Visible = true;
            } else
            {
                playerHand2.Visible = false;
            }

            for (int i = 0; i < currentPLayer.HandSize(); i++)
            {
                cardPicArr[i].Visible = true;
                cardPicArr[i].Image = GetCardImage(currentPLayer.GetCard(i));
            }

            for (int i = 17; i > currentPLayer.HandSize()-1; i--)
            {
                cardPicArr[i].Visible = false;
            }

            discardPile.Image = GetCardImage(model.PeekDiscardDeck());

            selectedCard = -1;
        }

        private void DisplayPlayerHand(int player)
        {
            UpdatePlayerPrompt("Show Hand! Showing the hand of ", model.GetPlayer(player).Name(), "!");

            Player currentPLayer = model.GetPlayer(player);

            for (int i = 0; i < currentPLayer.HandSize(); i++)
            {
                cardPicArr[i].Image = GetCardImage(currentPLayer.GetCard(i));
                cardPicArr[i].Visible = true;
            }

            for (int i = 8; i > currentPLayer.HandSize() - 1; i--)
            {
                cardPicArr[i].Visible = false;
            }

            selectedCard = -1;
        }

        private void allCards_MouseLeave(object sender, EventArgs e)
        {
            resetAllCards();
        }
        private void dealButton_Click(object sender, EventArgs e)
        {
            if (model.GetNumPlayers() > 1)
            {
                model.SetGameStarting(true);
                model.DealCards();
                UpdateAllClients();
            } else
            {
                UpdatePlayerPrompt("Error. 1 more player required to start the game.");
            }
        }

        private void playCardButton_Click(object sender, EventArgs e)
        {
            if (selectedCard != -1)
            {
                Card playedCard = model.CurrentPlayer().GetCard(selectedCard);

                if (forcedPlayCardAmount>0) {
                    //different method to account for playing cards not on the player's turn
                    model.PlayCardForPlayer(playerNumber, selectedCard);
                    forcedPlayCardAmount--;

                    if (model.CurrentPlayer().HandSize() == 0)
                    {
                        //Current player wins
                        DisplayCurrentPlayerHand();
                        model.SetWinner(playerNumber);
                        UpdateAllClients();
                        return;
                    }

                    if (forcedPlayCardAmount==0)
                    {
                        EndTurn();
                    } else
                    {
                        UpdatePlayerPrompt(forcedPlayCardAmount.ToString(), " cards to go!");
                        DisplayCurrentPlayerHand();
                    }
                } 
                else if (playedCard.GetColor() == model.GetCurrentColor() || playedCard.GetValue() == model.PeekDiscardDeck().GetValue() || playedCard.GetColor() == "N/A" || playedCard.GetColor() == model.PeekDiscardDeck().GetColor())
                {
                    if (model.CurrentPlayer().HandSize() == 1)
                    {
                        //Current player wins
                        model.PlayCard(selectedCard);
                        DisplayCurrentPlayerHand();
                        model.SetWinner(playerNumber);
                        UpdateAllClients();
                        return;
                    }

                    model.PlayCard(selectedCard);
                    discardPile.Image = cardPicArr[selectedCard].Image;

                    //use new SetColor(Card) function

                    if (playedCard.GetValue() == model.PeekDiscardDeck().GetValue())
                    {
                        model.SetCurrentColor(playedCard.GetColor());
                    }

                    if (playedCard.GetSpin()) 
                    {
                        SpinButton.Visible = true;
                        playCardButton.Visible = false;
                        drawCardButton.Visible = false;

                    } else if (playedCard.GetValue() == 10)
                    {
                        Pickup2();
                    }
                    else if (playedCard.GetValue() == 11)
                    {
                        model.ChangeDirection();
                        EndTurn();
                    }
                    else if (playedCard.GetValue() == 12)
                    {
                        //skip next turn
                        model.EndTurn();
                        EndTurn();
                    }
                    else if (playedCard.GetValue() == 13)
                    {
                        //pickup 4, change color
                        Pickup4();
                    }
                    else if (playedCard.GetValue() == 14)
                    {
                        ChangeColorSetup();
                    } 
                    else
                    {
                        EndTurn();
                    }

                    if (playedCard.GetColor() != "N/A")
                    {
                        SetCurrentColor(playedCard.GetColor());
                    }

                    DisplayCurrentPlayerHand();
                } else
                {
                    //card cannot be played
                    selectedCard = -1;
                    resetAllCards();
                }
            }

        }

        private void WinnerScreen(int i)
        {
            UpdatePlayerPrompt(model.GetPlayer(i).Name(), " wins!\nPress play again or exit.");

            foreach (Label l in otherPlayersCardCounts)
            {
                l.Visible = false;
            }

            playCardButton.Visible = false;
            drawCardButton.Visible = false;
            dealCardsButton.Text = "Play Again";
           
            if (playerNumber==0)
            {
                dealCardsButton.Visible = true;
            }


            foreach (Label l in otherPlayersLabels)
            {
                l.BackColor = Color.Black;
            }

            foreach (PictureBox p in cardPicArr)
            {
                p.Visible = false;
            }
        }

        private void Pickup2()
        {
            model.AddToForcedPickupAmount(2);
            playCardButton.Visible = false;
            EndTurn();
        }

        private void Pickup4()
        {
            UpdatePlayerPrompt(model.CurrentPlayer().Name(), ", choose the color to change it to.");
            model.AddToForcedPickupAmount(4);
            ChangeColorSetup();
        }

        private void ChangeColorSetup()
        {
            changeToBlueButton.Visible = true;
            changeToGreenButton.Visible = true;
            changeToRedButton.Visible = true;
            changeToYellowButton.Visible = true;
            playCardButton.Visible = false;
            drawCardButton.Visible = false;
        }

        private void changeColor(string color)
        {
            changeToBlueButton.Visible = false;
            changeToGreenButton.Visible = false;
            changeToRedButton.Visible = false;
            changeToYellowButton.Visible = false;
            playCardButton.Visible = true;
            drawCardButton.Visible = true;
            
            SetCurrentColor(color);
            model.SetCurrentColor(color);
            EndTurn();
        }

        private void SetCurrentColor(string color)
        {

            if (color == "Green")
            {
                ColorIndicator.BackColor = Color.Lime;
            } else if (color == "Red")
            {
                ColorIndicator.BackColor = Color.Red;
            } else if (color == "Yellow")
            {
                ColorIndicator.BackColor = Color.Yellow;
            } else if (color == "Blue")
            {
                ColorIndicator.BackColor = Color.Blue;
            }
        }

        private void drawCardButton_Click(object sender, EventArgs e)
        {
            if (model.CurrentPlayer().HandSize() < 18)
            {
                if (model.GetForcedPickupAmount() > 0)
                {
                    model.PickupCard();
                    model.DecrementForcedPickupAmount();
                    if (model.GetForcedPickupAmount() == 0)
                    {
                        UpdatePlayerPrompt(model.CurrentPlayer().Name(), "'s turn.");
                        playCardButton.Visible = true;
                    }
                    else
                    {
                        playerPrompt.Text = "Card picked up. " + model.GetForcedPickupAmount() + " cards to go.";
                    }
                    DisplayCurrentPlayerHand();
                }
                else if (drawBlue)
                {
                    if (model.PickupCard().GetColor() == "Blue")
                    {
                        //prompt player
                        drawBlue = false;
                        DisplayCurrentPlayerHand();
                        EndTurn();
                    } else
                    {
                        DisplayCurrentPlayerHand();
                    }
                }
                else if (drawRed)
                {
                    if (model.PickupCard().GetColor() == "Red")
                    {
                        //prompt player
                        drawRed = false;
                        DisplayCurrentPlayerHand();
                        EndTurn();
                    }
                    else
                    {
                        DisplayCurrentPlayerHand();
                    }
                }
                else
                {
                    model.PickupCard();
                    DisplayCurrentPlayerHand();
                    EndTurn();
                }
            } else
            {
                UpdatePlayerPrompt("Card limit readched.");
                drawCardButton.Visible = false;
            }
        }


        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(addPlayerNameTextBox.Text))
            {
                playerPrompt.Text = "Error. Please enter a name for the player to be added.";
            }
            else
            {
                while (true)
                {
                    try
                    {
                        client.Connect();
                        client.Send($"player number-{addPlayerNameTextBox.Text}");
                        break;
                    }
                    catch (Exception)
                    {
                        playerPrompt.Text = "Server not connected. Try Again.";
                    }
                }
            }
        }

        private void EndTurn()
        {
            this.Invoke((MethodInvoker)delegate
            {
                drawCardButton.Visible = false;
                playCardButton.Visible = false;

                player1Label.BackColor = Color.Black;
                model.EndTurn();
                UpdateAllClients();
            });
        }

        private void SpinSpinner(int result)
        {
            //timer interval is spinner speed
            System.Timers.Timer timer = new System.Timers.Timer(15);

            spinCount = Math.Abs(currentSpinnerImage - (result - 1) * 2) + 18*3;
            
            timer.Elapsed += (s, e) => { if (ChangeSpinnerImage()) { timer.Stop(); } else { timer.Interval += 1; } };
            timer.Start();

            model.SetSpinning(false);

            System.Timers.Timer timer2 = new System.Timers.Timer(3500);
            timer2.AutoReset = false;
            timer2.Elapsed += (s, e) => { SpinnerAction(result); };
            timer2.Start();
        }

        private void SpinnerAction(int result)
        {

            if (result == 1)
            {
                //discard number
                discardNumber = true;

                if (model.GetPlayerTurn() == playerNumber)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ChooseButton.Visible = true;
                        playerPrompt.Text = "Discard number! Choose a card, all cards of that number will be discarded.";
                    });
                }
                else
                {
                    UpdatePlayerPrompt("Discard color! ", model.CurrentPlayer().Name(), " is discarding \nall cards of the number of their choice.");
                }
            } else if (result == 2)
            {
                //war
                if (model.GetPlayerTurn() == playerNumber)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        model.SetHighestCardValue();
                        UpdateAllClients();
                    });
                }
            }
            else if (result == 3)
            {
                if (model.GetPlayerTurn() == playerNumber)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        drawBlue = true;
                        drawCardButton.Visible = true;
                        playerPrompt.Text = "Draw Blue! Keep drawing cards until you pick up\n a blue one!";
                    });
                } else
                {
                    UpdatePlayerPrompt("Draw Blue! ", model.CurrentPlayer().Name(), " is drawing \ncards until they pick up a blue one!");
                }
            }
            else if (result == 4)
            {
                //discard color
                discardColor = true;
                
                if (model.GetPlayerTurn() == playerNumber)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ChooseButton.Visible = true;
                        playerPrompt.Text = "Discard color! Choose a card, all cards of that color will be discarded.";
                    });
                }
                else
                {
                    UpdatePlayerPrompt("Discard color! ", model.CurrentPlayer().Name(), " is discarding \nall cards of the color of their choice.");
                }
            }
            else if (result == 5)
            {
                //uno spin
                UpdatePlayerPrompt("Uno Spin! First to press 'Uno Spin' discards 1 card!");

                this.Invoke((MethodInvoker)delegate
                {
                    UnoSpinButton.Visible = true;
                });
            }
            else if (result == 6)
            {
                //draw red
                if (model.GetPlayerTurn() == playerNumber)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        drawRed = true;
                        drawCardButton.Visible = true;
                        playerPrompt.Text = "Draw Red! Keep drawing cards until you pick up\n a red one!";
                    });
                }
                else
                {
                    UpdatePlayerPrompt("Draw Red! ", model.CurrentPlayer().Name(), " is drawing \ncards until they pick up a red one!");
                }
            }
            else if (result == 7)
            {
                //almost uno
                if (model.GetPlayerTurn() == playerNumber)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (model.CurrentPlayer().HandSize() - 2 >= 0)
                        {
                            playCardButton.Visible = true;
                            forcedPlayCardAmount = model.CurrentPlayer().HandSize() - 2;
                            playerPrompt.Text = "Almost Uno! Discard all but 2 cards!";
                        }
                        else
                        {
                            playerPrompt.Text = "Almost Uno! Play on, you don't have\nover 2 cards!";
                            System.Timers.Timer timer = new System.Timers.Timer(5000);
                            timer.Elapsed += (s, e) => { EndTurn(); };
                            timer.AutoReset = false;
                            timer.Start();
                        }
                    });
                } else
                {
                    UpdatePlayerPrompt("Almost Uno! ", model.CurrentPlayer().Name(), " will discard all but 2 cards!");
                }
            }
            else if (result == 8)
            {
                //trade hands
                UpdatePlayerPrompt("Trade Hands! All player hands will\nbe traded to the left!");
                System.Timers.Timer timer = new System.Timers.Timer(5000);
                timer.Elapsed += (s, e) => { TradeHands(); };
                timer.AutoReset = false;
                timer.Start();
            }
            else if (result == 9)
            {
                //show hand
                this.Invoke((MethodInvoker)delegate
                {
                    DisplayPlayerHand(model.GetPlayerTurn());
                    System.Timers.Timer timer = new System.Timers.Timer(10000);
                    timer.Elapsed += (s, e) => { EndTurn(); };
                    timer.AutoReset = false;
                    timer.Start();
                });
            }
        }


        private void TradeHands()
        {
            if (model.GetPlayerTurn() == playerNumber)
            {
                model.TradeHands();
                EndTurn();
            }
        }
       
        private bool ChangeSpinnerImage()
        {
            if (spinCount != 0)
            {
                if (currentSpinnerImage + 1 == spinnerPicArr.Length)
                {
                    currentSpinnerImage = 0;
                }
                else
                {
                    currentSpinnerImage++;
                }

                SpinnerPictureBox.Image = spinnerPicArr[currentSpinnerImage];
                spinCount--;
                return false;
            } else
            {
                return true;
            }
        }

        private Bitmap GetCardImage(Card c)
        {
            if (c.GetColor().Equals("N/A"))
            {
                return cardImageMap[c.GetColor()][c.GetValue() - 13];
            }
            else if (c.GetSpin())
            {
                return spinCardImageMap[c.GetColor()][c.GetValue() -1];
            }
            else
            {
                return cardImageMap[c.GetColor()][c.GetValue()];
            }
        }

        private void SetColor(Card c)
        {
            if (c.GetColor().Equals("N/A") && model.GetPlayerTurn() == playerNumber)
            {
                ChangeColorSetup();
            }
            else
            {
                SetCurrentColor(c.GetColor());
            }
        }

        private void UpdatePlayerPrompt(string var1)
        {
            this.Invoke((MethodInvoker)delegate
            {
                playerPrompt.Text = var1;
            });
        }
        private void UpdatePlayerPrompt(string var1, string var2)
        {
            this.Invoke((MethodInvoker)delegate
            {
                playerPrompt.Text = var1;
                playerPrompt.Text += var2;
            });
        }

        private void UpdatePlayerPrompt(string var1, string var2, string var3)
        {
            this.Invoke((MethodInvoker)delegate
            {
                playerPrompt.Text = var1;
                playerPrompt.Text += var2;
                playerPrompt.Text += var3;
            });
        }

        private void UpdateAllClients()
        {
            client.Send(model.Serialize());
        }

        private void Disconnect()
        {
            System.Windows.Forms.Application.Exit();
        }

        private void card1_Click(object sender, EventArgs e)
        {
            resetAllCards();
            card1.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 0;
        }

        private void card1_MouseEnter(object sender, EventArgs e)
        {
            card1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card2_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card2.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card2_MouseEnter(object sender, EventArgs e)
        {
            card2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card3_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card3.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 2;
        }

        private void card3_MouseEnter(object sender, EventArgs e)
        {
            card3.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card4_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card4.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 3;
        }

        private void card4_MouseEnter(object sender, EventArgs e)
        {
            card4.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card5_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card5.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 4;
        }

        private void card5_MouseEnter(object sender, EventArgs e)
        {
            card5.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card6_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card6.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 5;
        }

        private void card6_MouseEnter(object sender, EventArgs e)
        {
            card6.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card7_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card7.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 6;
        }

        private void card7_MouseEnter(object sender, EventArgs e)
        {
            card7.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card8_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card8.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 7;
        }

        private void card8_MouseEnter(object sender, EventArgs e)
        {
            card8.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card9_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card9.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 8;
        }

        private void card9_MouseEnter(object sender, EventArgs e)
        {
            card9.BorderStyle = BorderStyle.Fixed3D;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void changeToRedButton_Click(object sender, EventArgs e)
        {
            changeColor("Red");
        }

        private void changeToBlueButton_Click(object sender, EventArgs e)
        {
            changeColor("Blue");
        }

        private void changeToYellowButton_Click(object sender, EventArgs e)
        {
            changeColor("Yellow");
        }

        private void changeToGreenButton_Click(object sender, EventArgs e)
        {
            changeColor("Green");
        }

        private void ColorIndicator_Click(object sender, EventArgs e)
        {
            //do nothing
        }

        private void SpinButton_Click(object sender, EventArgs e)
        {
            SpinButton.Visible = false;
            model.SetSpinning(true);
            model.SetSpinnerResult();
            UpdateAllClients();
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            if (selectedCard != -1)
            {
               
                Card playedCard = model.CurrentPlayer().GetCard(selectedCard);

                for (int i = model.CurrentPlayer().HandSize()-1; i >= 0; i--)
                {
                    if (discardNumber)
                    {
                        if (playedCard.GetValue() == model.CurrentPlayer().GetCard(i).GetValue())
                        {
                            model.PlayCard(i);
                        }
                    } else if (discardColor)
                    {
                        if (playedCard.GetColor() == model.CurrentPlayer().GetCard(i).GetColor())
                        {
                            model.PlayCard(i);
                        }
                    }
                }

                discardColor = false;
                discardNumber = false;

                if (model.CurrentPlayer().HandSize() == 0)
                {
                    //Current player wins 
                    DisplayCurrentPlayerHand();
                    model.SetWinner(playerNumber);
                    UpdateAllClients();
                    return;
                } else
                {
                    DisplayCurrentPlayerHand();
                    ChooseButton.Visible = false;
                    EndTurn();
                }
            } else
            {
                //card cannot be played
                selectedCard = -1;
                resetAllCards();
            }
        }

        private void UnoSpinButton_Click(object sender, EventArgs e)
        {
            model.SetUnoSpinWinner(playerNumber);
            UpdateAllClients();
        }

        private void card10_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card10.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card11_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card11.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card12_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card12.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card13_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card13.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card14_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card14.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card15_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card15.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card16_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card16.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card17_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card17.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card18_Click(object sender, EventArgs e)
        {
            resetAllCards();

            card2.BorderStyle = BorderStyle.FixedSingle;
            selectedCard = 1;
        }

        private void card10_MouseEnter(object sender, EventArgs e)
        {
            card10.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card11_MouseEnter(object sender, EventArgs e)
        {
            card11.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card12_MouseEnter(object sender, EventArgs e)
        {
            card12.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card13_MouseEnter(object sender, EventArgs e)
        {
            card13.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card14_MouseEnter(object sender, EventArgs e)
        {
            card14.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card15_MouseEnter(object sender, EventArgs e)
        {
            card15.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card16_MouseEnter(object sender, EventArgs e)
        {
            card16.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card17_MouseEnter(object sender, EventArgs e)
        {
            card17.BorderStyle = BorderStyle.Fixed3D;
        }

        private void card18_MouseEnter(object sender, EventArgs e)
        {
            card18.BorderStyle = BorderStyle.Fixed3D;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void player6CardCount_Click(object sender, EventArgs e)
        {

        }
    }
}
