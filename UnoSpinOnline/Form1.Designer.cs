
namespace UnoSpinOnline
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dealCardsButton = new System.Windows.Forms.Button();
            this.playerPrompt = new System.Windows.Forms.Label();
            this.playCardButton = new System.Windows.Forms.Button();
            this.drawCardButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Spinner = new System.Windows.Forms.Label();
            this.player6Label = new System.Windows.Forms.Label();
            this.player5Label = new System.Windows.Forms.Label();
            this.player4Label = new System.Windows.Forms.Label();
            this.player3Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.AddPlayerButton = new System.Windows.Forms.Button();
            this.addPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.changeToRedButton = new System.Windows.Forms.Button();
            this.changeToBlueButton = new System.Windows.Forms.Button();
            this.changeToYellowButton = new System.Windows.Forms.Button();
            this.changeToGreenButton = new System.Windows.Forms.Button();
            this.ColorIndicator = new System.Windows.Forms.Button();
            this.player2PictureBox = new System.Windows.Forms.PictureBox();
            this.player3PictureBox = new System.Windows.Forms.PictureBox();
            this.player4PictureBox = new System.Windows.Forms.PictureBox();
            this.player6PictureBox = new System.Windows.Forms.PictureBox();
            this.player5PictureBox = new System.Windows.Forms.PictureBox();
            this.discardPile = new System.Windows.Forms.PictureBox();
            this.card7 = new System.Windows.Forms.PictureBox();
            this.card6 = new System.Windows.Forms.PictureBox();
            this.card2 = new System.Windows.Forms.PictureBox();
            this.card3 = new System.Windows.Forms.PictureBox();
            this.card4 = new System.Windows.Forms.PictureBox();
            this.card5 = new System.Windows.Forms.PictureBox();
            this.card8 = new System.Windows.Forms.PictureBox();
            this.card9 = new System.Windows.Forms.PictureBox();
            this.card1 = new System.Windows.Forms.PictureBox();
            this.playerHand1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player6PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player5PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardPile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerHand1)).BeginInit();
            this.SuspendLayout();
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(126, 466);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(45, 13);
            this.player1Label.TabIndex = 0;
            this.player1Label.Text = "Player 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Discard Pile";
            // 
            // dealCardsButton
            // 
            this.dealCardsButton.Location = new System.Drawing.Point(1201, -2);
            this.dealCardsButton.Name = "dealCardsButton";
            this.dealCardsButton.Size = new System.Drawing.Size(75, 23);
            this.dealCardsButton.TabIndex = 3;
            this.dealCardsButton.Text = "Ready";
            this.dealCardsButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.dealCardsButton.UseVisualStyleBackColor = true;
            this.dealCardsButton.Click += new System.EventHandler(this.dealButton_Click);
            // 
            // playerPrompt
            // 
            this.playerPrompt.AutoSize = true;
            this.playerPrompt.Location = new System.Drawing.Point(12, 259);
            this.playerPrompt.Name = "playerPrompt";
            this.playerPrompt.Size = new System.Drawing.Size(0, 13);
            this.playerPrompt.TabIndex = 4;
            // 
            // playCardButton
            // 
            this.playCardButton.Location = new System.Drawing.Point(12, 516);
            this.playCardButton.Name = "playCardButton";
            this.playCardButton.Size = new System.Drawing.Size(75, 23);
            this.playCardButton.TabIndex = 15;
            this.playCardButton.Text = "Play Card";
            this.playCardButton.UseVisualStyleBackColor = true;
            this.playCardButton.Click += new System.EventHandler(this.playCardButton_Click);
            // 
            // drawCardButton
            // 
            this.drawCardButton.Location = new System.Drawing.Point(21, 194);
            this.drawCardButton.Name = "drawCardButton";
            this.drawCardButton.Size = new System.Drawing.Size(75, 23);
            this.drawCardButton.TabIndex = 16;
            this.drawCardButton.Text = "Draw Card";
            this.drawCardButton.UseVisualStyleBackColor = true;
            this.drawCardButton.Click += new System.EventHandler(this.drawCardButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.Spinner);
            this.panel1.Location = new System.Drawing.Point(347, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 370);
            this.panel1.TabIndex = 17;
            // 
            // Spinner
            // 
            this.Spinner.AutoSize = true;
            this.Spinner.Location = new System.Drawing.Point(190, 182);
            this.Spinner.Name = "Spinner";
            this.Spinner.Size = new System.Drawing.Size(43, 13);
            this.Spinner.TabIndex = 0;
            this.Spinner.Text = "Spinner";
            // 
            // player6Label
            // 
            this.player6Label.AutoSize = true;
            this.player6Label.Location = new System.Drawing.Point(1026, 396);
            this.player6Label.Name = "player6Label";
            this.player6Label.Size = new System.Drawing.Size(49, 13);
            this.player6Label.TabIndex = 23;
            this.player6Label.Text = "PLayer 6";
            // 
            // player5Label
            // 
            this.player5Label.AutoSize = true;
            this.player5Label.BackColor = System.Drawing.SystemColors.ControlLight;
            this.player5Label.Location = new System.Drawing.Point(923, 396);
            this.player5Label.Name = "player5Label";
            this.player5Label.Size = new System.Drawing.Size(45, 13);
            this.player5Label.TabIndex = 24;
            this.player5Label.Text = "Player 5";
            // 
            // player4Label
            // 
            this.player4Label.AutoSize = true;
            this.player4Label.Location = new System.Drawing.Point(1087, 204);
            this.player4Label.Name = "player4Label";
            this.player4Label.Size = new System.Drawing.Size(45, 13);
            this.player4Label.TabIndex = 25;
            this.player4Label.Text = "Player 4";
            // 
            // player3Label
            // 
            this.player3Label.AutoSize = true;
            this.player3Label.Location = new System.Drawing.Point(972, 204);
            this.player3Label.Name = "player3Label";
            this.player3Label.Size = new System.Drawing.Size(45, 13);
            this.player3Label.TabIndex = 26;
            this.player3Label.Text = "Player 3";
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Location = new System.Drawing.Point(867, 204);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(45, 13);
            this.player2Label.TabIndex = 27;
            this.player2Label.Text = "Player 2";
            // 
            // AddPlayerButton
            // 
            this.AddPlayerButton.Location = new System.Drawing.Point(1201, 76);
            this.AddPlayerButton.Name = "AddPlayerButton";
            this.AddPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.AddPlayerButton.TabIndex = 28;
            this.AddPlayerButton.Text = "Join Lobby";
            this.AddPlayerButton.UseVisualStyleBackColor = true;
            this.AddPlayerButton.Click += new System.EventHandler(this.AddPlayerButton_Click);
            // 
            // addPlayerNameTextBox
            // 
            this.addPlayerNameTextBox.Location = new System.Drawing.Point(1189, 105);
            this.addPlayerNameTextBox.Name = "addPlayerNameTextBox";
            this.addPlayerNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.addPlayerNameTextBox.TabIndex = 30;
            // 
            // changeToRedButton
            // 
            this.changeToRedButton.Location = new System.Drawing.Point(143, 76);
            this.changeToRedButton.Name = "changeToRedButton";
            this.changeToRedButton.Size = new System.Drawing.Size(75, 23);
            this.changeToRedButton.TabIndex = 31;
            this.changeToRedButton.Text = "Red";
            this.changeToRedButton.UseVisualStyleBackColor = true;
            this.changeToRedButton.Click += new System.EventHandler(this.changeToRedButton_Click);
            // 
            // changeToBlueButton
            // 
            this.changeToBlueButton.Location = new System.Drawing.Point(143, 107);
            this.changeToBlueButton.Name = "changeToBlueButton";
            this.changeToBlueButton.Size = new System.Drawing.Size(75, 23);
            this.changeToBlueButton.TabIndex = 32;
            this.changeToBlueButton.Text = "Blue";
            this.changeToBlueButton.UseVisualStyleBackColor = true;
            this.changeToBlueButton.Click += new System.EventHandler(this.changeToBlueButton_Click);
            // 
            // changeToYellowButton
            // 
            this.changeToYellowButton.Location = new System.Drawing.Point(143, 136);
            this.changeToYellowButton.Name = "changeToYellowButton";
            this.changeToYellowButton.Size = new System.Drawing.Size(75, 23);
            this.changeToYellowButton.TabIndex = 33;
            this.changeToYellowButton.Text = "Yellow";
            this.changeToYellowButton.UseVisualStyleBackColor = true;
            this.changeToYellowButton.Click += new System.EventHandler(this.changeToYellowButton_Click);
            // 
            // changeToGreenButton
            // 
            this.changeToGreenButton.Location = new System.Drawing.Point(143, 165);
            this.changeToGreenButton.Name = "changeToGreenButton";
            this.changeToGreenButton.Size = new System.Drawing.Size(75, 23);
            this.changeToGreenButton.TabIndex = 34;
            this.changeToGreenButton.Text = "Green";
            this.changeToGreenButton.UseVisualStyleBackColor = true;
            this.changeToGreenButton.Click += new System.EventHandler(this.changeToGreenButton_Click);
            // 
            // ColorIndicator
            // 
            this.ColorIndicator.BackColor = System.Drawing.Color.Yellow;
            this.ColorIndicator.Location = new System.Drawing.Point(143, 47);
            this.ColorIndicator.Name = "ColorIndicator";
            this.ColorIndicator.Size = new System.Drawing.Size(75, 23);
            this.ColorIndicator.TabIndex = 35;
            this.ColorIndicator.Text = "Color";
            this.ColorIndicator.UseVisualStyleBackColor = false;
            this.ColorIndicator.Click += new System.EventHandler(this.ColorIndicator_Click);
            // 
            // player2PictureBox
            // 
            this.player2PictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.player2PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.player2PictureBox.Location = new System.Drawing.Point(836, 49);
            this.player2PictureBox.Name = "player2PictureBox";
            this.player2PictureBox.Size = new System.Drawing.Size(103, 139);
            this.player2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player2PictureBox.TabIndex = 22;
            this.player2PictureBox.TabStop = false;
            // 
            // player3PictureBox
            // 
            this.player3PictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.player3PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.player3PictureBox.Location = new System.Drawing.Point(945, 49);
            this.player3PictureBox.Name = "player3PictureBox";
            this.player3PictureBox.Size = new System.Drawing.Size(103, 139);
            this.player3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player3PictureBox.TabIndex = 21;
            this.player3PictureBox.TabStop = false;
            // 
            // player4PictureBox
            // 
            this.player4PictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.player4PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.player4PictureBox.Location = new System.Drawing.Point(1054, 49);
            this.player4PictureBox.Name = "player4PictureBox";
            this.player4PictureBox.Size = new System.Drawing.Size(103, 139);
            this.player4PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player4PictureBox.TabIndex = 20;
            this.player4PictureBox.TabStop = false;
            // 
            // player6PictureBox
            // 
            this.player6PictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.player6PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.player6PictureBox.Location = new System.Drawing.Point(1001, 240);
            this.player6PictureBox.Name = "player6PictureBox";
            this.player6PictureBox.Size = new System.Drawing.Size(103, 139);
            this.player6PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player6PictureBox.TabIndex = 19;
            this.player6PictureBox.TabStop = false;
            // 
            // player5PictureBox
            // 
            this.player5PictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.player5PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.player5PictureBox.Location = new System.Drawing.Point(892, 240);
            this.player5PictureBox.Name = "player5PictureBox";
            this.player5PictureBox.Size = new System.Drawing.Size(103, 139);
            this.player5PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player5PictureBox.TabIndex = 18;
            this.player5PictureBox.TabStop = false;
            // 
            // discardPile
            // 
            this.discardPile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.discardPile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.discardPile.Location = new System.Drawing.Point(12, 49);
            this.discardPile.Name = "discardPile";
            this.discardPile.Size = new System.Drawing.Size(103, 139);
            this.discardPile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.discardPile.TabIndex = 14;
            this.discardPile.TabStop = false;
            // 
            // card7
            // 
            this.card7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card7.Location = new System.Drawing.Point(783, 516);
            this.card7.Name = "card7";
            this.card7.Size = new System.Drawing.Size(103, 139);
            this.card7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card7.TabIndex = 13;
            this.card7.TabStop = false;
            this.card7.Click += new System.EventHandler(this.card7_Click);
            this.card7.MouseEnter += new System.EventHandler(this.card7_MouseEnter);
            this.card7.MouseLeave += new System.EventHandler(this.allCards_MouseLeave);
            // 
            // card6
            // 
            this.card6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card6.Location = new System.Drawing.Point(674, 516);
            this.card6.Name = "card6";
            this.card6.Size = new System.Drawing.Size(103, 139);
            this.card6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card6.TabIndex = 12;
            this.card6.TabStop = false;
            this.card6.Click += new System.EventHandler(this.card6_Click);
            this.card6.MouseEnter += new System.EventHandler(this.card6_MouseEnter);
            this.card6.MouseLeave += new System.EventHandler(this.allCards_MouseLeave);
            // 
            // card2
            // 
            this.card2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card2.Location = new System.Drawing.Point(238, 516);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(103, 139);
            this.card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card2.TabIndex = 11;
            this.card2.TabStop = false;
            this.card2.Click += new System.EventHandler(this.card2_Click);
            this.card2.MouseEnter += new System.EventHandler(this.card2_MouseEnter);
            this.card2.MouseLeave += new System.EventHandler(this.allCards_MouseLeave);
            // 
            // card3
            // 
            this.card3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card3.Location = new System.Drawing.Point(347, 516);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(103, 139);
            this.card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card3.TabIndex = 10;
            this.card3.TabStop = false;
            this.card3.Click += new System.EventHandler(this.card3_Click);
            this.card3.MouseEnter += new System.EventHandler(this.card3_MouseEnter);
            this.card3.MouseLeave += new System.EventHandler(this.allCards_MouseLeave);
            // 
            // card4
            // 
            this.card4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card4.Location = new System.Drawing.Point(456, 516);
            this.card4.Name = "card4";
            this.card4.Size = new System.Drawing.Size(103, 139);
            this.card4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card4.TabIndex = 9;
            this.card4.TabStop = false;
            this.card4.Click += new System.EventHandler(this.card4_Click);
            this.card4.MouseEnter += new System.EventHandler(this.card4_MouseEnter);
            this.card4.MouseLeave += new System.EventHandler(this.allCards_MouseLeave);
            // 
            // card5
            // 
            this.card5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card5.Location = new System.Drawing.Point(565, 516);
            this.card5.Name = "card5";
            this.card5.Size = new System.Drawing.Size(103, 139);
            this.card5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card5.TabIndex = 8;
            this.card5.TabStop = false;
            this.card5.Click += new System.EventHandler(this.card5_Click);
            this.card5.MouseEnter += new System.EventHandler(this.card5_MouseEnter);
            this.card5.MouseLeave += new System.EventHandler(this.allCards_MouseLeave);
            // 
            // card8
            // 
            this.card8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card8.Location = new System.Drawing.Point(892, 516);
            this.card8.Name = "card8";
            this.card8.Size = new System.Drawing.Size(103, 139);
            this.card8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card8.TabIndex = 7;
            this.card8.TabStop = false;
            this.card8.Click += new System.EventHandler(this.card8_Click);
            this.card8.MouseEnter += new System.EventHandler(this.card8_MouseEnter);
            this.card8.MouseLeave += new System.EventHandler(this.allCards_MouseLeave);
            // 
            // card9
            // 
            this.card9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card9.Location = new System.Drawing.Point(1001, 516);
            this.card9.Name = "card9";
            this.card9.Size = new System.Drawing.Size(103, 139);
            this.card9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card9.TabIndex = 6;
            this.card9.TabStop = false;
            this.card9.Click += new System.EventHandler(this.card9_Click);
            this.card9.MouseEnter += new System.EventHandler(this.card9_MouseEnter);
            this.card9.MouseLeave += new System.EventHandler(this.allCards_MouseLeave);
            // 
            // card1
            // 
            this.card1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card1.Location = new System.Drawing.Point(129, 516);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(103, 139);
            this.card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card1.TabIndex = 5;
            this.card1.TabStop = false;
            this.card1.Click += new System.EventHandler(this.card1_Click);
            this.card1.MouseEnter += new System.EventHandler(this.card1_MouseEnter);
            this.card1.MouseLeave += new System.EventHandler(this.allCards_MouseLeave);
            // 
            // playerHand1
            // 
            this.playerHand1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.playerHand1.ImageLocation = "";
            this.playerHand1.InitialImage = null;
            this.playerHand1.Location = new System.Drawing.Point(102, 502);
            this.playerHand1.Name = "playerHand1";
            this.playerHand1.Size = new System.Drawing.Size(1030, 163);
            this.playerHand1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerHand1.TabIndex = 2;
            this.playerHand1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1351, 719);
            this.Controls.Add(this.ColorIndicator);
            this.Controls.Add(this.changeToGreenButton);
            this.Controls.Add(this.changeToYellowButton);
            this.Controls.Add(this.changeToBlueButton);
            this.Controls.Add(this.changeToRedButton);
            this.Controls.Add(this.addPlayerNameTextBox);
            this.Controls.Add(this.AddPlayerButton);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player3Label);
            this.Controls.Add(this.player4Label);
            this.Controls.Add(this.player5Label);
            this.Controls.Add(this.player6Label);
            this.Controls.Add(this.player2PictureBox);
            this.Controls.Add(this.player3PictureBox);
            this.Controls.Add(this.player4PictureBox);
            this.Controls.Add(this.player6PictureBox);
            this.Controls.Add(this.player5PictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.drawCardButton);
            this.Controls.Add(this.playCardButton);
            this.Controls.Add(this.discardPile);
            this.Controls.Add(this.card7);
            this.Controls.Add(this.card6);
            this.Controls.Add(this.card2);
            this.Controls.Add(this.card3);
            this.Controls.Add(this.card4);
            this.Controls.Add(this.card5);
            this.Controls.Add(this.card8);
            this.Controls.Add(this.card9);
            this.Controls.Add(this.card1);
            this.Controls.Add(this.playerPrompt);
            this.Controls.Add(this.dealCardsButton);
            this.Controls.Add(this.playerHand1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.player1Label);
            this.Name = "Form1";
            this.Text = "Board";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player6PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player5PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardPile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerHand1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox playerHand1;
        private System.Windows.Forms.Button dealCardsButton;
        private System.Windows.Forms.Label playerPrompt;
        private System.Windows.Forms.PictureBox card1;
        private System.Windows.Forms.PictureBox card9;
        private System.Windows.Forms.PictureBox card8;
        private System.Windows.Forms.PictureBox card5;
        private System.Windows.Forms.PictureBox card4;
        private System.Windows.Forms.PictureBox card3;
        private System.Windows.Forms.PictureBox card2;
        private System.Windows.Forms.PictureBox card6;
        private System.Windows.Forms.PictureBox card7;
        private System.Windows.Forms.PictureBox discardPile;
        private System.Windows.Forms.Button playCardButton;
        private System.Windows.Forms.Button drawCardButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Spinner;
        private System.Windows.Forms.PictureBox player5PictureBox;
        private System.Windows.Forms.PictureBox player6PictureBox;
        private System.Windows.Forms.PictureBox player4PictureBox;
        private System.Windows.Forms.PictureBox player3PictureBox;
        private System.Windows.Forms.PictureBox player2PictureBox;
        private System.Windows.Forms.Label player6Label;
        private System.Windows.Forms.Label player5Label;
        private System.Windows.Forms.Label player4Label;
        private System.Windows.Forms.Label player3Label;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Button AddPlayerButton;
        private System.Windows.Forms.TextBox addPlayerNameTextBox;
        private System.Windows.Forms.Button changeToRedButton;
        private System.Windows.Forms.Button changeToBlueButton;
        private System.Windows.Forms.Button changeToYellowButton;
        private System.Windows.Forms.Button changeToGreenButton;
        private System.Windows.Forms.Button ColorIndicator;
    }
}

