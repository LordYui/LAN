using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Network
{
    enum PacketHeader : byte
    {
        CONNECT
    }
    class Packet
    {
        public int Sender;
        public PacketHeader Header;
        public byte[] Data;

        public Packet(PacketHeader h, params byte[] data)
        {
            Header = h;
            Data = data;
        }

        public byte[] Serialize()
        {
            byte[] retArr = new byte[Data.Length + 1];
            retArr[0] = (byte)Header;
            Array.Copy(Data, 0, retArr, 1, Data.Length);
            return retArr;
        }

        public static Packet Deserialize(byte[] p)
        {
            byte[] r = new byte[p.Length - 1];
            Array.Copy(p, 1, r, 0, r.Length);
            return new Packet((PacketHeader)p[0], r);
        }
    }
}
