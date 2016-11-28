using LAN.Engine;
using LAN.Engine.Primitives;
using LAN.Engine.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Game.Client
{
    class C_Player : GameObject
    {
        public C_Player()
        {
            RenderComponent r = this.AddComponent<RenderComponent>();
            r.Char = '@';
            this.AddComponent<Transform>();
        }
    }
}
