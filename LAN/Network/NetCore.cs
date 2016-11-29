using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using LAN.Engine;

namespace LAN.Network
{
    class NetCore : GameObject
    {
        public event NetworkMessageHandler OnNetworkMessage;
        public delegate void NetworkMessageHandler(NetworkMessageEventArgs p);

        NetPeer peer;

        public NetCore(bool isServer)
        {
            if(isServer)
                this.AddComponent<NetServerManager>();
            else
                this.AddComponent<NetClientManager>();

            NetPeerConfiguration conf = new NetPeerConfiguration("LAN");
            conf.Port = 2555;
            //conf.EnableMessageType(NetIncomingMessageType.Data);
            peer = new NetPeer(new NetPeerConfiguration("LAN"));
            peer.Start();
        }

        public void InternalUpdate()
        {
            NetIncomingMessage msg;
            while((msg = peer.ReadMessage()) != null)
            {
                switch (msg.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        if (OnNetworkMessage != null)
                            OnNetworkMessage.Invoke(new NetworkMessageEventArgs(Packet.Deserialize(msg.Data))); // todo: deserialize packet
                        break;
                }
            }
        }
    }
}
