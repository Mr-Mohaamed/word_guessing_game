using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameExplorer.Core
{
    internal class Player
    {
        public string Name { get; set; }
        public TcpClient Client { get; set; }
        public Player(string name)
        {
            Name = name;
        }
    }
}
