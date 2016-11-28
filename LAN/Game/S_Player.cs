using LAN.Engine;
using LAN.Engine.Primitives;
using LAN.Engine.Render;

namespace LAN.Game
{
    class S_Player : GameObject
    {
        public S_Player()
        {
            this.AddComponent<Transform>();
            this.AddComponent<RenderComponent>();
        }
    }
}
