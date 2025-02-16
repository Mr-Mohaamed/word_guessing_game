using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameExplorer.Components;
using GameExplorer.Core;

namespace GameExplorer.Client
{
    public partial class RoomDialog : Form
    {
        private Dictionary<string, RoomComponent> _rooms = new Dictionary<string, RoomComponent>();
        private TcpClient client;
        private NetworkStream stream;
        private string playerName;
        private RoomComponent _selectedRoom;


        public RoomDialog(string name)
        {
            InitializeComponent();
            Thread serverConnectionThread = new Thread(() => connectToServer());
            serverConnectionThread.Start();
            playerName = name;
            this.FormClosing += Dialog_OnClose;
        }

        private void connectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 12345);
                stream = client.GetStream();
                RequestRoomList(stream);
                ResponsePlayerName(stream, playerName);

                // Start a listener thread to continuously listen for server messages
                Thread listenerThread = new Thread(() => ListenForServerMessages());
                listenerThread.IsBackground = true; // Ensure the thread does not prevent the application from exiting
                listenerThread.Start();

                // Request the initial room list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to server: {ex.Message}");
            }
        }
        private void ListenForServerMessages()
        {
            try
            {
                while (true)
                {
                    string response = MakeResponse();
                    Console.WriteLine($"Received from server: {response}");

                    // Handle the server response
                    ProcessServerResponse(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in listener thread: {ex.Message}");
            }
        }

        private void ProcessServerResponse(string response)
        {
            //MessageBox.Show(response);
            if (response.StartsWith("ROOMS:"))
            {
                string[] rooms = response.Split(':')[1].Split(',');
                showRooms(rooms);
            }
            else if (response.StartsWith("NO_ROOMS_FOUND"))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    roomsHeader.Text = "No Created Rooms Yet...";
                });
            }
            else if (response.StartsWith("GAME_START:"))
            {
                string roomName = response.Split(':')[1];
                MessageBox.Show($"Game started in room: {roomName}");
            }
            else if (response.StartsWith("ROOM_CREATED:"))
            {
                string roomName = response.Split(':')[1];
                MessageBox.Show($"Room created: {roomName}");
            }
            else if (response.StartsWith("JOINED_ROOM:"))
            {
                string roomName = response.Split(':')[1];
                MessageBox.Show($"Joined room: {roomName}");
            }
            else if (response.StartsWith("ROOM_FULL_OR_INVALID"))
            {
                MessageBox.Show("Room is full or invalid.");
            }
            else
            {
                Console.WriteLine($"Unknown server response: {response}");
            }
        }

        private void Dialog_OnClose(object sender, FormClosingEventArgs e)
        {
            MakeRequest("LEAVE:", playerName);
            stream.Close();
            client.Close();
        }

        private void ResponsePlayerName(NetworkStream stream, string playerName)
        {
            playerName = playerName.Trim();
            byte[] request = Encoding.UTF8.GetBytes($"NAME:{playerName}");
            stream.Write(request, 0, request.Length);
        }

        private void RequestRoomList(NetworkStream stream)
        {
            MakeRequest("LIST_ROOMS");
        }

        private string MakeResponse()
        {
            byte[] buffer = new byte[1024];
            StringBuilder responseBuilder = new StringBuilder();
            int bytesRead;

            bytesRead = stream.Read(buffer, 0, buffer.Length);
            responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            Console.WriteLine($"Server Response: {responseBuilder.ToString()}");
            return responseBuilder.ToString();
        }

        private void CreatedRoom_Click(object? sender, EventArgs e)
        {
            _selectedRoom = sender as RoomComponent;
            foreach (var room in _rooms)
            {
                if (room.Value == _selectedRoom)
                {
                    room.Value.BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    room.Value.BorderStyle = BorderStyle.None;
                }
            }
            joinRoomBtn.Enabled = true;
        }

        private void showRooms(string[] rooms)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (rooms.Length > 0)
                {
                    roomsHeader.Text = $"Available Rooms: {rooms.Length}";
                    roomsContainer.Controls.Clear(); // Clear existing controls
                    foreach (var room in rooms)
                    {
                        string[] parts = room.Split('|');
                        if (parts.Length >= 3) // Ensure the response has the expected format
                        {
                            string roomName = parts[0];
                            GameType roomGameType = (GameType)Enum.Parse(typeof(GameType), parts[1], true);
                            int roomPlayersCount = int.Parse(parts[2]);
                            var roomComponent = new RoomComponent(roomName, roomGameType, roomPlayersCount);
                            roomComponent.Click += CreatedRoom_Click;
                            _rooms.Add(roomName, roomComponent);
                            roomsContainer.Controls.Add(roomComponent); // Add the room component to the container
                        }
                    }
                    joinRoomBtn.Enabled = false;
                    joinRoomBtn.Text = "Select Your Room";
                }
                else
                {
                    joinRoomBtn.Enabled = false;
                    roomsHeader.Text = "No Rooms Created Yet...";
                }
            });
        }
        private void createRoomBtn_Click(object sender, EventArgs e)
        {
            MakeRequest("CREATE_ROOM:", playerName + "," + GameType.ShapeGuessing);
        }

        private void MakeRequest(string endPoint, string msg = "")
        {
            byte[] request = Encoding.UTF8.GetBytes($"{endPoint}{msg}\n"); // Add a newline delimiter
            stream.Write(request, 0, request.Length);
        }
    }
}
