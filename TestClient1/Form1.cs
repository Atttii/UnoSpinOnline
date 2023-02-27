using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient1
{
    public partial class Form1 : Form
    {
        private const string IPPORT = "127.0.0.1:8080";
        SimpleTcpClient client;

        public Form1()
        {
            InitializeComponent();

            client = new SimpleTcpClient(IPPORT);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;

            try
            {
                client.Connect();
            } catch (Exception e)
            {
                //idk
            }

        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                //try catch
                RecTextBox.Text += $"{Encoding.UTF8.GetString(e.Data.Array)}{Environment.NewLine}";
            });
        }

        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {
            RecTextBox.Text += $"Disonnected from server...{Environment.NewLine}";         
        }

        private void Events_Connected(object sender, ConnectionEventArgs e)
        {
            RecTextBox.Text += $"Connected to server...{Environment.NewLine}";
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            client.Send(textBox1.Text);
        }
    }
}
