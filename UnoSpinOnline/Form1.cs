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

namespace UnoSpinOnline
{
    public partial class Form1 : Form
    {
        private GameLoop model;
        private PictureBox[] picArr;
        private int selectedCard = -1;
        private Dictionary<string, Bitmap[]> imageMap;
        private PictureBox[] otherPlayersPictureBoxes;
        private Label[] otherPlayersLabels;
        private int forcedPickupAmount;
        private string currentColor;

        public Form1()
        {
            InitializeComponent();
            model = new GameLoop();
            picArr = new PictureBox[] { card1, card2, card3, card4, card5, card6, card7, card8, card9 };

            imageMap = new Dictionary<string, Bitmap[]>() {{"Blue", new Bitmap[] { Properties.Resources.blue_0, Properties.Resources.blue_1,
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
            
            otherPlayersPictureBoxes = new PictureBox[] { player2PictureBox, player3PictureBox, player4PictureBox, player5PictureBox, player6PictureBox };
            otherPlayersLabels = new Label[] { player1Label, player2Label, player3Label, player4Label, player5Label, player6Label };

            foreach (PictureBox p in otherPlayersPictureBoxes)
            {
                p.Visible = false;
            }

            foreach (Label l in otherPlayersLabels)
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
            player1Label.Text = "Brandon";
            player1Label.Visible = true;

            forcedPickupAmount = 0;

            model.AddPlayer("Brandon");
        }


        private void resetAllCards()
        {
            for (int i = 0; i < picArr.Length; i++)
            {
                if (i != selectedCard)
                {
                    picArr[i].BorderStyle = BorderStyle.None;
                }
            }
        }

        private void DisplayCurrentPlayerHand()
        {
            Player currentPLayer = model.CurrentPlayer();

            for (int i = 0; i < currentPLayer.HandSize(); i++)
            {
                if (currentPLayer.GetCard(i).GetColor().Equals("N/A"))
                {
                    picArr[i].Image = imageMap[currentPLayer.GetCard(i).GetColor()][currentPLayer.GetCard(i).GetValue()-13];
                } else
                {
                    picArr[i].Image = imageMap[currentPLayer.GetCard(i).GetColor()][currentPLayer.GetCard(i).GetValue()];
                }
                picArr[i].Visible = true;
            }

            for (int i = 8; i > currentPLayer.HandSize()-1; i--)
            {
                picArr[i].Visible = false;
            }

            selectedCard = -1;
        }

        private void allCards_MouseLeave(object sender, EventArgs e)
        {
            resetAllCards();
        }
        private void dealButton_Click(object sender, EventArgs e)
        {
            model.DealCards();

            DisplayCurrentPlayerHand();
            dealCardsButton.Visible = false;
            addPlayerNameTextBox.Visible = false;
            AddPlayerButton.Visible = false;
            playCardButton.Visible = true;
            drawCardButton.Visible = true;
            ColorIndicator.Visible = true;
            ColorIndicator.BackColor = Color.Gray;
            player1Label.BackColor = Color.Orange;

            Card firstDiscard = model.PeekDiscardDeck();
            
            if (firstDiscard.GetColor().Equals("N/A"))
            {
                discardPile.Image = imageMap[firstDiscard.GetColor()][firstDiscard.GetValue() - 13];
                ChangeColorSetup();
            }
            else
            {
                discardPile.Image = imageMap[firstDiscard.GetColor()][firstDiscard.GetValue()];
                SetCurrentColor(firstDiscard.GetColor());
            }

            playerPrompt.Text = $"{model.CurrentPlayer().Name()}'s turn.";
        }

        private void playCardButton_Click(object sender, EventArgs e)
        {
            //playerPrompt.Text = $"Index {selectedCard}";

            if (selectedCard != -1)
            {
              

                Card playedCard = model.CurrentPlayer().GetCard(selectedCard);
                
                if (playedCard.GetColor() == currentColor || playedCard.GetValue() == model.PeekDiscardDeck().GetValue() || playedCard.GetColor() == "N/A")
                {
                    if (model.CurrentPlayer().HandSize() == 1)
                    {
                        //Current player wins
                        model.PlayCard(selectedCard);
                        DisplayCurrentPlayerHand();
                        WinnerScreen();
                        model.PlayerWins();
                        return;

                    }

                    model.PlayCard(selectedCard);
                    discardPile.Image = picArr[selectedCard].Image;

                    if (playedCard.GetValue() == 10)
                    {
                        //pickup 2
                        Pickup2();
                    }
                    else if (playedCard.GetValue() == 11)
                    {
                        //change direction
                        model.ChangeDirection();
                        EndTurn();
                        playerPrompt.Text = $"{model.CurrentPlayer().Name()}'s turn.\nThe direction of play has changed!";
                    }
                    else if (playedCard.GetValue() == 12)
                    {
                        //skip next turn
                        EndTurn();
                        EndTurn();
                        playerPrompt.Text = $"{model.CurrentPlayer().Name()}'s turn.\nThe previous turn has been skipped!!";
                    }
                    else if (playedCard.GetValue() == 13)
                    {
                        //pickup 4, change color
                        Pickup4();
                    }
                    else if (playedCard.GetValue() == 14)
                    {
                        //change color
                        ChangeColorSetup();
                    } 
                    else
                    {
                        EndTurn();
                        playerPrompt.Text = $"{model.CurrentPlayer().Name()}'s turn.";
                    }

                    if (playedCard.GetColor() != "N/A")
                    {
                        SetCurrentColor(playedCard.GetColor());
                    }

                    DisplayCurrentPlayerHand();
                } else
                {
                    //card cannot be played
                    playerPrompt.Text = $"Card cannot be played.";
                    selectedCard = -1;
                    resetAllCards();
                }
            }

        }

        private void WinnerScreen()
        {
            playerPrompt.Text = $"{model.CurrentPlayer().Name()} wins!\nPress play again or exit.";
            playCardButton.Visible = false;
            drawCardButton.Visible = false;
            dealCardsButton.Visible = true;
            dealCardsButton.Text = "Play Again";
            AddPlayerButton.Visible = true;
            addPlayerNameTextBox.Visible = true;

            foreach (Label l in otherPlayersLabels)
            {
                l.BackColor = Control.DefaultBackColor;
            }
        }

        private void Pickup2()
        {
            EndTurn();
            playerPrompt.Text = $"{model.CurrentPlayer().Name()}'s turn !\nPickup 2!.";
            forcedPickupAmount = 2;
            playCardButton.Visible = false;
        }

        private void Pickup4()
        {
            playerPrompt.Text = $"{model.CurrentPlayer().Name()}, choose the color to change it to.";
            ChangeColorSetup();
            forcedPickupAmount = 4;
            playCardButton.Visible = false;
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
            EndTurn();
            if (forcedPickupAmount > 0)
            {
                playerPrompt.Text = $"{model.CurrentPlayer().Name()}'s turn !\nThe color has been changed to {color}!.\nAlso pickup {forcedPickupAmount}";
                playCardButton.Visible = false;
            }
            else
            {
                playerPrompt.Text = $"{model.CurrentPlayer().Name()}'s turn !\nThe color has been changed to {color}!.";
            }
            
            DisplayCurrentPlayerHand();
        }

        private void SetCurrentColor(string color)
        {
            currentColor = color;

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

        private void drawCardButton_Click(object sender, EventArgs e)
        {
            if (model.CurrentPlayer().HandSize() < 9)
            {
                if (forcedPickupAmount > 0)
                {
                    model.PickupCard();
                    forcedPickupAmount--;
                    if (forcedPickupAmount == 0)
                    {
                        playerPrompt.Text = $"{model.CurrentPlayer().Name()}'s turn.";
                        playCardButton.Visible = true;
                    } else
                    {
                        playerPrompt.Text = $"Card picked up. {forcedPickupAmount} cards to go.";
                    }
                    DisplayCurrentPlayerHand();
                } 
                else
                {
                    model.PickupCard();
                    EndTurn();
                    playerPrompt.Text = $"{model.CurrentPlayer().Name()}'s turn.";
                    DisplayCurrentPlayerHand();
                } 
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(addPlayerNameTextBox.Text))
            {
                playerPrompt.Text = "Error. Please enter a name for the player to be added.";
            } else
            {
                model.AddPlayer(addPlayerNameTextBox.Text);

                int addedPlayerNum = model.GetNumPlayers() - 2;

                playerPrompt.Text = $"Player {model.GetNumPlayers()} added.";

                otherPlayersPictureBoxes[addedPlayerNum].Visible = true;
                otherPlayersLabels[addedPlayerNum+1].Visible = true;
                otherPlayersLabels[addedPlayerNum+1].Text = addPlayerNameTextBox.Text;
                addPlayerNameTextBox.Text = String.Empty;
            }
        }

        private void EndTurn()
        {
            otherPlayersLabels[model.CurrentPLayerNumber()].BackColor = Control.DefaultBackColor;
            model.EndTurn();
            otherPlayersLabels[model.CurrentPLayerNumber()].BackColor = Color.Orange;
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

        }
    }
}
