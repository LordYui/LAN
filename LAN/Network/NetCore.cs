using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using LAN.Engine;

namespace LAN.Network
{
    class NetCore
    {
        public event NetworkMessageHandler OnNetworkMessage;
        public delegate void NetworkMessageHandler(NetworkMessageEventArgs p);

        NetPeer peer;

        public NetCore()
        {
            NetPeerConfiguration conf = new NetPeerConfiguration("LAN");
            conf.Port = 2555;
            //conf.EnableMessageType(NetIncomingMessageType.Data);
            peer = new NetPeer(new NetPeerConfiguration("LAN"));
            peer.Start();
        }

        public void Update()
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
