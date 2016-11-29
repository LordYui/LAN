using LAN.Engine;
using LAN.Game.Client;
using LAN.Game.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Game
{
    class GameSystem
    {
        Action updateSystem;
        ClientSystem clientSystem;
        ServerSystem serverSystem;
        public void StartGame(object isServer)
        {
            clientSystem = new Client.ClientSystem();
            serverSystem = new Server.ServerSystem();
            bool srv = (bool)isServer;
            if (srv)
                updateSystem = serverSystem.Update;
            else
                updateSystem = clientSystem.Update;
        }

        void Update()
        {
            updateSystem.Invoke();
        }
    }
}
