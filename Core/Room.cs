using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameExplorer.Core
{

    internal class Room
    {
        public string RoomName;
        public GameType GameType { get; set; }
        public Player Player1;
        public Player Player2;
        public int Count = 0;

        public Room(string roomName, GameType gameType)
        {
            RoomName = roomName;
            GameType = gameType;
        }
        public void AddPlayer(Player player)
        {
            if (player != null)
            {
                
                if (Player1 == null)
                {
                    Player1 = player;
                    Count++;
                }
                else if (Player2 == null)
                {
                    Player2 = player;
                    Count++;
                }else if (Player1 != null && Player2 != null)
                {
                    return;
                }
            }
        }
        public void RemovePlayer(Player player)
        {
            if (player != null)
            {
                if (Player1 == player)
                {
                    Player1 = null;
                    Count--;
                }
                else if (Player2 == player)
                {
                    Player2 = null;
                    Count--;
                }
            }
        }
        public void AddRoomType(GameType gameType)
        {
            GameType = gameType;
        }

    }
}
