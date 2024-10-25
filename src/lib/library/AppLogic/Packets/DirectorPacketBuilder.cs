using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Packets {
    internal sealed class DirectorPacketBuilder {

        private PacketBuilder builder;

        public DirectorPacketBuilder(PacketBuilder builder) {
            this.builder = builder;
        }

        public Packet ConstructPacket(int id, string name, double price, int downloadSpeed, int uploadSpeed, int numberOfChannels) {
            if(builder == null) {
                throw new InvalidOperationException("Builder is not set.");
            }

            builder.build(id, name, price, downloadSpeed, uploadSpeed, numberOfChannels);
            return builder.getProduct();
        }

        public void changeBuilder(PacketBuilder builder) {
            this.builder = builder;
        }

    }
}
