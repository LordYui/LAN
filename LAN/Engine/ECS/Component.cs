using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine.ECS
{
    abstract class Component
    {
        public virtual void Update() { }
        public virtual void Start() { }
    }
}
