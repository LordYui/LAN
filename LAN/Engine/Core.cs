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
        NetCore netCore = new NetCore();
        ComponentManager compManager = new ComponentManager();
        RenderService renderServ = new RenderService();
        GameObjectManager goManager = new GameObjectManager();
        GameSystem gameSystem = new GameSystem();
        public Core()
        {
            netCore.OnNetworkMessage += NetCore_OnNetworkMessage;
            GameObjectE.compManager = compManager;
            renderServ.Start();
            Thread gameThread = new Thread(gameSystem.StartGame);
            gameThread.Start();
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
                netCore.Update();
                renderServ.InternalUpdate();
            }
        }

        void GameUpdate()
        {
            compManager.Update();
        }
    }
}
