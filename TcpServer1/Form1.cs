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

namespace TcpServer1
{
    public partial class Form1 : Form
    {
        private const string IPPORT = "127.0.0.1:8080";
        private SimpleTcpServer server;
        private List<string> clientIps;

        public Form1()
        {
            InitializeComponent();

            clientIps = new List<string>();
            server = new SimpleTcpServer(IPPORT);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                //textBox1.Text += $"{Encoding.UTF8.GetString(e.Data.Array)}{Environment.NewLine}";

                if (Encoding.UTF8.GetString(e.Data.Array).StartsWith("player number-"))
                {
                    server.Send(e.IpPort, $"player number-{clientIps.Count-1}-{Encoding.UTF8.GetString(e.Data.Array).Substring(14, Encoding.UTF8.GetString(e.Data.Array).Length-15)}");
                } else
                {
                    foreach (string client in clientIps)
                    {
                        server.Send(client, e.Data.Array);
                    }
                }
            });
        }

        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBox1.Text += $"Client Disconnected.{Environment.NewLine}";
                clientIps.Remove(e.IpPort);
            });
        }

        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate 
            {
                textBox1.Text += $"Client Connected.{Environment.NewLine}";
                clientIps.Add(e.IpPort);
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            server.Start();
            textBox1.Text += $"Server Started...{Environment.NewLine}";
            ConnectButton.Visible = false;
        }
    }
}
