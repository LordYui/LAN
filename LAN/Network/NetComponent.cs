using LAN.Engine.ECS;
using LAN.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Network
{
    class NetComponent : Component
    {
        public bool Dirty { get; private set; }
        private int PlayerID;
    }
}
