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

namespace UnoSpinOnline.Tests
{

    [TestFixture]
    class UITests
    {
        private List<Application> clientInstances;
        private List<Window> clientWindows;

        private static TestStack.White.Application serverInstance;
        private Window serverWindow;

        private List<String> playerNames;

        private bool serverKilled;

        [SetUp]
        public void SetUp()
        {
            clientInstances = new List<Application>();
            clientWindows = new List<Window>();
            playerNames = new List<String>() { "PLayer 1", "Player 2", "PLayer 3", "Player 4", "PLayer 5", "Player 6" };
            serverKilled = false;

            LaunchServerInstance();
        }

        [TearDown]
        public void TearDown()
        {
            if (!serverKilled)
            {
                serverInstance.Close();
            }
            
            foreach (Application client in clientInstances)
            {
                client.Close();
            }
        }

        private void LaunchClientInstance()
        {
            string baseAppDir = AppDomain.CurrentDomain.BaseDirectory;
            string clientAppPath = Path.Combine(baseAppDir, "UnoSpinOnline.exe");
           
            clientInstances.Add(Application.Launch(clientAppPath));
            clientWindows.Add(clientInstances[clientInstances.Count - 1].GetWindow("Board"));
        }

        private void LaunchServerInstance()
        {
            string baseAppDir = AppDomain.CurrentDomain.BaseDirectory;
            string serverAppPath = Path.Combine(baseAppDir, @"..\..\..\TcpServer1\bin\Debug\TcpServer1.exe");

            serverInstance = Application.Launch(serverAppPath);
            serverWindow = serverInstance.GetWindow("Server");
            Button connectButton = serverWindow.Get<Button>("ConnectButton");
            connectButton.Click();
        }

        private void ClientJoinLobby(Window clientWindow, string name)
        {
            TextBox playerNameTextBox = clientWindow.Get<TextBox>("addPlayerNameTextBox");
            playerNameTextBox.Enter(name);

            Button addPlayerButton = clientWindow.Get<Button>("AddPlayerButton");
            addPlayerButton.Click();
        } 

        [Test]
        public void AddPlayer1WorksWhenNameEntered()
        {
            //Player 1
            string player1Name = "Player 1";
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[0], player1Name);

            Button dealCardsButton = clientWindows[0].Get<Button>("dealCardsButton");
            Assert.IsTrue(dealCardsButton.Visible);

            Label player1Label = clientWindows[0].Get<Label>("player1Label");
            Assert.IsTrue(player1Label.Visible);
            Assert.AreEqual(player1Label.Text, player1Name);
        }

        [Test]
        public void AddPlayer1NameNotEntered()
        {
            //player 1
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[0], String.Empty);

            Button addPlayerButton = clientWindows[0].Get<Button>("AddPlayerButton");
            Assert.IsTrue(addPlayerButton.Visible);

            Label playerPrompt = clientWindows[0].Get<Label>("playerPrompt");
            Assert.AreEqual(playerPrompt.Text, "Error. Please enter a name for the player to be added.");
        }


        [Test]
        public void AddPlayer6WorksWhenNameEntered()
        {
            

            //player 1
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[0], playerNames[0]);

            //player 2
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[1], playerNames[1]);

            //player 3
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[2], playerNames[2]);

            //player 4
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[3], playerNames[3]);

            //player 5
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[4], playerNames[4]);

            //player 6
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[5], playerNames[5]);

            Button dealCardsButton1 = clientWindows[0].Get<Button>("dealCardsButton");
            Assert.IsTrue(dealCardsButton1.Visible);

            //test all playerLabels
            for (int i = 0; i < clientWindows.Count; i++)
            {
                Label player1Label = clientWindows[i].Get<Label>("player1Label");
                Assert.IsTrue(player1Label.Visible);
                Assert.AreEqual(player1Label.Text, playerNames[i]);

                List<Label> otherPlayerLabels = new List<Label>() { clientWindows[i].Get<Label>("player2Label"), clientWindows[i].Get<Label>("player3Label"),
                                                    clientWindows[i].Get<Label>("player4Label"), clientWindows[i].Get<Label>("player5Label"),clientWindows[i].Get<Label>("player6Label")};

                for (int j = 0; j < playerNames.Count; j++)
                {
                   if (i > j)
                    {
                        Console.WriteLine(otherPlayerLabels[j].Text + " 1== " + playerNames[j]);
                        Assert.AreEqual(otherPlayerLabels[j].Text, playerNames[j]);
                    }
                    else if (i < j)
                    {
                        Console.WriteLine(otherPlayerLabels[j-1].Text + " 2== " + playerNames[j]);
                        Assert.AreEqual(otherPlayerLabels[j-1].Text, playerNames[j]);
                    }
                }
            }
        }

        [Test]
        public void StartGame6PlayersTest()
        {
            List<String> playerNames = new List<String>() { "PLayer 1", "Player 2", "PLayer 3", "Player 4", "PLayer 5", "Player 6" };

            //player 1
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[0], playerNames[0]);

            //player 2
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[1], playerNames[1]);

            //player 3
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[2], playerNames[2]);

            //player 4
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[3], playerNames[3]);

            //player 5
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[4], playerNames[4]);

            //player 6
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[5], playerNames[5]);

            Button dealCardsButton = clientWindows[0].Get<Button>("dealCardsButton");
            dealCardsButton.Click();

            for (int i = 0; i < clientWindows.Count; i++)
            {
                List<Label> cardCountLabels = new List<Label>() { clientWindows[i].Get<Label>("player2CardCount"), clientWindows[i].Get<Label>("player3CardCount"),
                                            clientWindows[i].Get<Label>("player4CardCount"), clientWindows[i].Get<Label>("player5CardCount"), clientWindows[0].Get<Label>("player6CardCount") };


                if (i == 0)
                {
                    Label playerPrompt = clientWindows[0].Get<Label>("playerPrompt");
                    Assert.AreEqual(playerPrompt.Text, "Your turn.");

                }
                else
                {
                    Label playerPrompt = clientWindows[i].Get<Label>("playerPrompt");
                    Assert.AreEqual(playerPrompt.Text,  $"{playerNames[0]}'s turn.");

                }

                foreach(Label cardCount in cardCountLabels)
                {
                    Assert.AreEqual(cardCount.Text,"7 Cards");
                }
            }

        }

        [Test]
        public void StartGame1PlayersTest()
        {
            //player 1
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[0], "Player 1");

            Button dealCardsButton = clientWindows[0].Get<Button>("dealCardsButton");
            dealCardsButton.Click();

            Label playerPrompt = clientWindows[0].Get<Label>("playerPrompt");
            Assert.AreEqual(playerPrompt.Text, "Error. 1 more player required to start the game.");

        }

       
        [Test]
        public void Add7PlayersTest()
        {
            List<String> playerNames = new List<String>() { "PLayer 1", "Player 2", "PLayer 3", "Player 4", "PLayer 5", "Player 6" };

            //player 1
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[0], playerNames[0]);

            //player 2
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[1], playerNames[1]);

            //player 3
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[2], playerNames[2]);

            //player 4
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[3], playerNames[3]);

            //player 5
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[4], playerNames[4]);

            //player 6
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[5], playerNames[5]);

            //player 7, cannot join
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[6], "Player 7");

            Label playerPrompt = clientWindows[6].Get<Label>("playerPrompt");
            Assert.AreEqual(playerPrompt.Text, "Lobby full.");

        }

        [Test]
        public void Add1PlayerWorksWhenServerDisconnected()
        {
            serverInstance.Kill();
            serverKilled = true;

            //Player 1
            string player1Name = "Player 1";
            LaunchClientInstance();
            ClientJoinLobby(clientWindows[0], player1Name);

            Label playerPrompt = clientWindows[0].Get<Label>("playerPrompt");
            Assert.AreEqual(playerPrompt.Text, "Server not connected. Try Again.");
        }
    }
}
