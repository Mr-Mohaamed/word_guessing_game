using GameExplorer.Client;
using System.IO;
using System.Net.Sockets;

namespace GameExplorer
{
    public enum GameType
    {
        None,
        AnimalGuessing,
        ShapeGuessing
    }

    public partial class Form1 : Form
    {
        private GameServer server;

        //Make The Game Server And Wait for clients to join the game

        public Form1()
        {
            InitializeComponent();

            // Start the server on a separate thread
            Thread serverThread = new Thread(() => StartServer());
            serverThread.IsBackground = true; // Ensure the thread doesn't prevent the application from exiting
            serverThread.Start();

            this.FormClosing += Form1_OnClosing;
        }

        private void Form1_OnClosing(object sender, FormClosingEventArgs e)
        {

            //server.StopServer();
        }
        private void StartServer()
        {
            try
            {
                server = new GameServer();
                //server.StartServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start server: {ex.Message}");
            }
        }

        private void joinBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }
            RoomDialog roomDialog = new RoomDialog(nameTextBox.Text);
            roomDialog.ShowDialog();

            //var newClient = new Thread(() => HandleJoin());
            //newClient.Start();
        }

        private void HandleJoin()
        {
            //TcpClient client = new TcpClient();
            //client.Connect("127.0.0.1", 12345); // Replace with your server IP and port
            RoomDialog roomDialog = new RoomDialog(nameTextBox.Text);
            roomDialog.ShowDialog();
            //client.Close();
        }
    }
}