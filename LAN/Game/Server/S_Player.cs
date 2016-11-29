using LAN.Engine;
using LAN.Engine.Primitives;
using LAN.Engine.Render;

namespace LAN.Game.Server
{
    class S_Player : GameObject
    {
        private static int pC = 0;
        public int PlayerID { get; private set; }
        public NetPlayer NetPlayer { get; private set; }
        public S_Player()
        {
            this.AddComponent<Transform>();
            PlayerID = ++pC;
            NetPlayer = new NetPlayer(PlayerID);
        }
    }
}
