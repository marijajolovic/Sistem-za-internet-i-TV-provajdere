using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Packets {
    internal sealed class InternetPacketBuilder : PacketBuilder {

        private Packet packet = null;

        public InternetPacketBuilder() {
         
        }

        public override Packet getProduct() {
            return packet;
        }

        public override void setDownloadSpeed(int dSpeed) {
            packet.Data["downloadSpeed"] = dSpeed;
        }

        public override void setUploadSpeed(int uSpeed) {
            packet.Data["uploadSpeed"] = uSpeed;
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
            // DO NOTHING
        }

        public override void build(int id, string name, double price, int downloadSpeed, int uploadSpeed, int numberOfChannels) {
            packet = new Packet();
            setPacketID(id);
            setPacketName(name);
            setPacketPrice(price);
            setDownloadSpeed(downloadSpeed);
            setUploadSpeed(uploadSpeed);
        }
    }
}
