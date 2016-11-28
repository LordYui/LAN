using LAN.Engine.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine.Primitives
{
    class Transform : Component
    {
        public Vector2 Position;

        public override void Start()
        {
            Position = new Vector2(0, 0);
        }
    }
}
