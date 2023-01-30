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

namespace UnoSpinOnline
{
    public partial class Form1 : Form
    {
        private int handSize;
        private PictureBox[] picArr;
        private int selectedCard = -1;
        private Bitmap[] imageArr = new Bitmap[] { Properties.Resources.blue_0, Properties.Resources.blue_1,
                                                    Properties.Resources.blue_2, Properties.Resources.blue_3,
                                                    Properties.Resources.blue_4, Properties.Resources.blue_5,
                                                    Properties.Resources.blue_6, Properties.Resources.blue_7,
                                                    Properties.Resources.blue_8, Properties.Resources.blue_9
                                                    };

        public Form1()
        {
            InitializeComponent();
            picArr = new PictureBox[] { card1, card2, card3, card4, card5, card6, card7, card8, card9 };
            handSize = picArr.Length;
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

        private void allCards_MouseLeave(object sender, EventArgs e)
        {
            resetAllCards();
        }
        private void dealButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < picArr.Length; i++)
            {
                picArr[i].Image = imageArr[i];
                picArr[i].Visible = true;
            }

            handSize = picArr.Length;
            selectedCard = -1;
        }

        private void playCardButton_Click(object sender, EventArgs e)
        {
            //playerPrompt.Text = $"Index {selectedCard}";

            if (selectedCard != -1)
            {
                discardPile.Image = picArr[selectedCard].Image;

                for (int i = selectedCard; i < handSize; i++)
                {

                    if (i == handSize - 1)
                    {
                        picArr[i].Visible = false;
                        playerPrompt.Text = $"here. Index = {i}";
                    } else
                    {
                        picArr[i].Image = picArr[i + 1].Image;
                    }
                }
                handSize--;
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
    }
}
