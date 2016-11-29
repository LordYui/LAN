using LAN.Engine.ECS;
using LAN.Engine.Render;
using LAN.Game;
using LAN.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LAN.Engine
{
    class Core
    {
        NetCore netCore;
        ComponentManager compManager = new ComponentManager();
        RenderService renderServ = new RenderService();
        GameObjectManager goManager = new GameObjectManager();
        GameSystem gameSystem = new GameSystem();
        public Core(bool isServer = false)
        {
            GameObjectE.compManager = compManager;
            netCore = new NetCore(isServer);
            netCore.OnNetworkMessage += NetCore_OnNetworkMessage;
            renderServ.Start();
            Thread gameThread = new Thread((o) => { gameSystem.StartGame(o); });
            gameThread.Start(isServer);
            InternalUpdate();
        }

        private void NetCore_OnNetworkMessage(NetworkMessageEventArgs p)
        {
            GameUpdate();
        }

        void InternalUpdate()
        {
            while (true)
            {
                netCore.InternalUpdate();
                renderServ.InternalUpdate();
            }
        }

        void GameUpdate()
        {
            compManager.Update();
        }
    }
}
