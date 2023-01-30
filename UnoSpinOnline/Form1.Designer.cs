
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dealCardsButton = new System.Windows.Forms.Button();
            this.playerPrompt = new System.Windows.Forms.Label();
            this.card1 = new System.Windows.Forms.PictureBox();
            this.playerHand1 = new System.Windows.Forms.PictureBox();
            this.card9 = new System.Windows.Forms.PictureBox();
            this.card8 = new System.Windows.Forms.PictureBox();
            this.card5 = new System.Windows.Forms.PictureBox();
            this.card4 = new System.Windows.Forms.PictureBox();
            this.card3 = new System.Windows.Forms.PictureBox();
            this.card2 = new System.Windows.Forms.PictureBox();
            this.card6 = new System.Windows.Forms.PictureBox();
            this.card7 = new System.Windows.Forms.PictureBox();
            this.discardPile = new System.Windows.Forms.PictureBox();
            this.playCardButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerHand1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardPile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Hand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Discard Pile";
            // 
            // dealCardsButton
            // 
            this.dealCardsButton.Location = new System.Drawing.Point(21, 179);
            this.dealCardsButton.Name = "dealCardsButton";
            this.dealCardsButton.Size = new System.Drawing.Size(75, 23);
            this.dealCardsButton.TabIndex = 3;
            this.dealCardsButton.Text = "Deal Cards";
            this.dealCardsButton.UseVisualStyleBackColor = true;
            this.dealCardsButton.Click += new System.EventHandler(this.dealButton_Click);
            // 
            // playerPrompt
            // 
            this.playerPrompt.AutoSize = true;
            this.playerPrompt.Location = new System.Drawing.Point(24, 578);
            this.playerPrompt.Name = "playerPrompt";
            this.playerPrompt.Size = new System.Drawing.Size(72, 13);
            this.playerPrompt.TabIndex = 4;
            this.playerPrompt.Text = "Player Prompt";
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
            // discardPile
            // 
            this.discardPile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.discardPile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.discardPile.Location = new System.Drawing.Point(501, 144);
            this.discardPile.Name = "discardPile";
            this.discardPile.Size = new System.Drawing.Size(103, 139);
            this.discardPile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.discardPile.TabIndex = 14;
            this.discardPile.TabStop = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 719);
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
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Board";
            ((System.ComponentModel.ISupportInitialize)(this.card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerHand1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardPile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
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
    }
}

