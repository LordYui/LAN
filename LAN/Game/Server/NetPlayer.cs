using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Game.Server
{
    class NetPlayer
    {
        public int NetID { get; private set; }

        public NetPlayer(int ID)
        {
            NetID = ID;
        }
    }
}
