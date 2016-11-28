using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Network
{
    class NetworkMessageEventArgs
    {
        public Packet p { get; private set; }
        public int ID { get; private set; }

        public NetworkMessageEventArgs(Packet p)
        {
            this.p = p;
        }
    }
}
