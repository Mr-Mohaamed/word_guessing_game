using GameExplorer;
using GameExplorer.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class GameServer
{
    private static TcpListener server;
    private static Dictionary<string, Room> rooms = new();
    private static Dictionary<TcpClient, Player> players = new();

    public GameServer()
    {
        server = new TcpListener(IPAddress.Parse("127.0.0.1"), 12345);
        server.Start();
        Console.WriteLine("Server started. Waiting for connections...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected.");
            Thread clientThread = new Thread(() => HandleClientAsync(client));
            clientThread.Start();
        }
    }

    public void StartServer()
    {
        server.Start();
    }

    public void StopServer()
    {
        foreach (var room in rooms.Values)
        {
            room.RemovePlayer(room.Player1);
            room.RemovePlayer(room.Player2);
        }
        players.Clear();
        rooms.Clear();
        server.Stop();
    }

    private static async Task HandleClientAsync(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        StringBuilder dataBuilder = new StringBuilder();

        try
        {
            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) break; // Client disconnected

                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                MessageBox.Show(receivedData);
                dataBuilder.Append(receivedData);

                // Split the received data by the delimiter
                string[] messages = dataBuilder.ToString().Split('\n');
                // Process each complete message
                for (int i = 0; i < messages.Length - 1; i++) // Skip the last incomplete message
                {
                    string message = messages[i].Trim(); // Remove any extra whitespace
                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine($"Processing message: {message}");
                        await ProcessMessageAsync(stream, client, message);
                    }
                }

                // Keep the last incomplete message in the buffer
                dataBuilder = new StringBuilder(messages[messages.Length - 1]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            client.Close();
        }
    }

    private static async Task ProcessMessageAsync(NetworkStream stream, TcpClient client, string message)
    {
        if (message.StartsWith("NAME:"))
        {
            string[] parts = message.Split(':');
            if (parts.Length > 1)
            {
                string playerName = parts[1].Trim();
                players[client] = new Player(playerName);
            }
            SendResponseAsync(stream, "OKEY");
        }
        else if (message.StartsWith("CREATE_ROOM:"))
        {
            string roomDetails = message.Split(':')[1];
            string roomName = roomDetails.Split(",")[0];
            GameType roomGameType = (GameType)Enum.Parse(typeof(GameType), roomDetails.Split(",")[1], true);
            if (!rooms.ContainsKey(roomName))
            {
                var room = new Room(roomName, roomGameType);
                room.AddPlayer(players[client]);
                rooms.Add(roomName, room);
                await SendResponseAsync(stream, $"ROOM_CREATED:{roomName}");
            }
            else
            {
                await SendResponseAsync(stream, "ROOM_EXISTS");
            }
        }
        else if (message.StartsWith("JOIN_ROOM:"))
        {
            string[] parts = message.Split(':');
            string roomName = parts[1];

            if (rooms.ContainsKey(roomName) && rooms[roomName].Count < 2)
            {
                rooms[roomName].AddPlayer(players[client]);
                await SendResponseAsync(stream, $"JOINED_ROOM:{roomName}");
                if (rooms[roomName].Count == 2)
                {
                    await StartGameAsync(rooms[roomName]);
                }
            }
            else
            {
                await SendResponseAsync(stream, "ROOM_FULL_OR_INVALID");
            }
        }
        else if (message == "LIST_ROOMS")
        {
            if (rooms.Count > 0)
            {
                List<string> returnMsg = new();
                foreach (var room in rooms)
                {
                    returnMsg.Add($"{room.Key}|{room.Value.GameType}|{room.Value.Count}");
                }
                string roomList = string.Join(",", returnMsg);
                await SendResponseAsync(stream, $"ROOMS:{roomList}");
            }
            else
            {
                await SendResponseAsync(stream, "NO_ROOMS_FOUND");
            }
        }
    }
    private static async Task StartGameAsync(Room room)
    {
        await SendResponseAsync(room.Player1.Client.GetStream(), $"GAME_START:{room.RoomName}");
        await SendResponseAsync(room.Player2.Client.GetStream(), $"GAME_START:{room.RoomName}");
    }

    private static async Task SendResponseAsync(NetworkStream stream, string response)
    {
        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
        await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
    }
}