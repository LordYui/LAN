using LAN.Engine.ECS;
using LAN.Engine.Render;
using LAN.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine
{
    class Core
    {
        NetCore netCore = new NetCore();
        ComponentManager compManager = new ComponentManager();
        RenderService renderServ = new RenderService();
        GameObjectManager goManager = new GameObjectManager();
        public Core()
        {
            netCore.OnNetworkMessage += NetCore_OnNetworkMessage;
            GameObjectE.compManager = compManager;
            renderServ.Start();
        }

        private void NetCore_OnNetworkMessage(NetworkMessageEventArgs p)
        {
            GameUpdate();
        }

        void InternalUpdate()
        {
            netCore.Update();
        }

        void GameUpdate()
        {
            compManager.Update();
            renderServ.Update();
        }
    }
}
