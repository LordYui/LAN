using LAN.Engine.ECS;
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
        public Core()
        {
            netCore.OnNetworkMessage += NetCore_OnNetworkMessage;
            GameObjectE.compManager = compManager;
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
        }
    }
}
