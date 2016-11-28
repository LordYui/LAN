using LAN.Engine;
using LAN.Engine.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Game
{
    class S_Player : GameObject
    {
        public S_Player()
        {
            this.AddComponent<Transform>();
        }
    }
}
