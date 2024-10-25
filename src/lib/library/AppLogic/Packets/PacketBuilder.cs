using library.AppLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Packets {
    internal abstract class PacketBuilder : IPacketBuilder {

        public abstract void setDownloadSpeed(int dSpeed);

        public abstract void setNumberOfChannels(int numberOfChannels);

        public abstract void setPacketID(int id);

        public abstract void setPacketName(string name);

        public abstract void setPacketPrice(double price);

        public abstract void setUploadSpeed(int uSpeed);

        public abstract Packet getProduct();
        public abstract void build(int id, string name, double price, int downloadSpeed, int uploadSpeed, int numberOfChannels);
    }
}
