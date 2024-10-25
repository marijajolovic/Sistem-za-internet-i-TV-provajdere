using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Packets {
    internal sealed class TVPacketBuilder : PacketBuilder {
        private Packet packet = null;

        public TVPacketBuilder() {
         
        }

        public override Packet getProduct() {
            return packet;
        }

        public override void setPacketID(int id) {
            packet.PacketID = id;
        }

        public override void setPacketName(string name) {
            packet.Name = name;
        }

        public override void setPacketPrice(double price) {
            packet.Price = price;
        }

        public override void setNumberOfChannels(int numberOfChannels) {
            packet.Data["numberOfChannels"] = numberOfChannels;
        }


        public override void setDownloadSpeed(int dSpeed) {
            // DO NOTHING
        }

        public override void setUploadSpeed(int uSpeed) {
            // DO NOTHING
        }

        public override void build(int id, string name, double price, int downloadSpeed, int uploadSpeed, int numberOfChannels) {
            packet = new Packet();
            setPacketID(id);
            setPacketName(name);
            setPacketPrice(price);
            setNumberOfChannels(numberOfChannels);
        }
    }
}
