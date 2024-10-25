using library.AppLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Packets {
    public class Packet : IPrototype<Packet> {

        private int packetID;
        private string name;
        private double price;
        private Dictionary<string, int> data;

        public enum PacketType { INTERNET, TV, COMBINED, UNRECOGNIZED }

        public int PacketID { get => packetID; set => packetID = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public Dictionary<string, int> Data { get => data; set => data = value; }

        public Packet() {
            data = new Dictionary<string, int>();
        }

        public Packet(int packetID, string name, double price, Dictionary<string, int> data=null) { 
            this.packetID = packetID;
            this.name = name;
            this.price = price;
            this.data = data;
        }

        #region PROTOTYPE IMPLEMENTATION
        
        public Packet clone() {
            return new Packet(this);
        }

        public Packet(Packet packet) {
            this.packetID = packet.packetID;
            this.name = packet.name;
            this.price = packet.price;
            this.data = packet.data;
        }

        #endregion

        public override string ToString() {
            return this.packetID + " " + this.name + " " + this.price;
        }
    }
}
