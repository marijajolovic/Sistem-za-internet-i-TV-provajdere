using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Packets {
    public class PacketLogic {

        private Database.Database instance = null;
        private DirectorPacketBuilder director;
        private PacketBuilder internetPacketBuilder;
        private PacketBuilder tvPacketBuilder;
        private PacketBuilder combinedPacketBuilder;

        public PacketLogic() {
        
            instance = Database.Database.GetInstance();
            internetPacketBuilder = new InternetPacketBuilder();
            tvPacketBuilder = new TVPacketBuilder();
            combinedPacketBuilder = new CombinedPacketBuilder();
            director = new DirectorPacketBuilder(internetPacketBuilder);
        }

        public IEnumerable<Packet> getInternetPackets(string sql, Dictionary<string, object> parameters) {

            DataTable dt = instance.Query(sql, parameters);
            List<Packet> packets = new List<Packet>();
            director.changeBuilder(internetPacketBuilder);

            foreach (DataRow dr in dt.Rows) {
                int id = Convert.ToInt32(dr["packetid"]);
                string name = Convert.ToString(dr["name"]);
                double price = Convert.ToDouble(dr["price"]);
                int downSpeed = Convert.ToInt32(dr["downloadspeed"]);
                int upSpeed = Convert.ToInt32(dr["uploadspeed"]);

                packets.Add(director.ConstructPacket(id, name, price, downSpeed, upSpeed, -1));
            }

            return packets;

        }

        public IEnumerable<Packet> getTVPackets(string sql, Dictionary<string, object> parameters) {

            DataTable dt = instance.Query(sql, parameters);
            List<Packet> packets = new List<Packet>();
            director.changeBuilder(tvPacketBuilder);

            foreach (DataRow dr in dt.Rows) {
                int id = Convert.ToInt32(dr["packetid"]);
                string name = Convert.ToString(dr["name"]);
                double price = Convert.ToDouble(dr["price"]);
                int channels = Convert.ToInt32(dr["numberofchannels"]);

                packets.Add(director.ConstructPacket(id, name, price, -1, -1, channels));
            }

            return packets;

        }

        public IEnumerable<Packet> getCombinedPackets(string sql, Dictionary<string, object> parameters) {

            DataTable dt = instance.Query(sql, parameters);
            List<Packet> packets = new List<Packet>();
            director.changeBuilder(combinedPacketBuilder);

            foreach (DataRow dr in dt.Rows) {
                int id = Convert.ToInt32(dr["packetid"]);
                string name = Convert.ToString(dr["name"]);
                double price = Convert.ToDouble(dr["price"]);
                int channels = Convert.ToInt32(dr["numberofchannels"]);
                int downSpeed = Convert.ToInt32(dr["downloadspeed"]);
                int upSpeed = Convert.ToInt32(dr["uploadspeed"]);

                packets.Add(director.ConstructPacket(id, name, price, downSpeed, upSpeed, channels));
            }

            return packets;
        }

        public Packet getByName(string sql, Dictionary<string, object> parameters) {
            DataTable dt = instance.Query(sql, parameters);

            if(dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];
            Dictionary<string, int> data = new Dictionary<string, int>();

            return new Packet(Convert.ToInt32(dr["packetid"].ToString()), dr["name"].ToString(), Convert.ToDouble(dr["price"].ToString()), data);
        }

        public Packet getByID(int id) {
            string sql = "SELECT * FROM Packet WHERE PacketID = @param1";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("@param1", id);

            DataTable dt = instance.Query(sql, keyValuePairs);

            if(dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];
            Dictionary<string, int> data = new Dictionary<string, int>();

            return new Packet(Convert.ToInt32(dr["packetid"].ToString()), dr["name"].ToString(), Convert.ToDouble(dr["price"].ToString()), data);
        }

        public void insert(string sql, Dictionary<string, object> parameters) {
            instance.Query(sql, parameters); // moguc izuzetak ukoliko ime nije unique
        }

    }
}
