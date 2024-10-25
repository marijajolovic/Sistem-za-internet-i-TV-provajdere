using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.Database;
using library.AppLogic.Packets;

namespace library.AppLogic.Clients {
    public class ClientLogic {

        private Database.Database instance = null;

        public ClientLogic() { 
            instance = Database.Database.GetInstance();
        }

        public IEnumerable<Client> getAllClients(string sql, Dictionary<string, object> parameters) {
            List<Client> clients = new List<Client>();

            DataTable dt = instance.Query(sql, parameters);
            foreach (DataRow dr in dt.Rows) {
                int id = Convert.ToInt32(dr["clientid"]);
                string username = Convert.ToString(dr["username"]);
                string firstName = Convert.ToString(dr["firstname"]);
                string lastName = Convert.ToString(dr["lastname"]);
                clients.Add(new Client(id, username, firstName, lastName));
            }

            return clients;
        }
        
        public IEnumerable<Packet> getPacketsForClient(string sql, Dictionary<string, object> parameters) {
            
            List<Packet> packets = new List<Packet>();

            DataTable dt = instance.Query(sql, parameters);
            foreach (DataRow dr in dt.Rows) {
                int clientId = Convert.ToInt32(dr["clientid"]);
                int packetId = Convert.ToInt32(dr["packetid"]);
                string name = Convert.ToString(dr["name"]);
                double price = Convert.ToDouble(dr["price"]);

                packets.Add(new Packet(packetId, name, price));
            }

            return packets;
        }
        
        public Client getByID(int id) {
            string sql = "SELECT * FROM Client WHERE clientid = @param1";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("@param1", id);

            DataTable dt = instance.Query(sql, keyValuePairs);

            if (dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];
            Dictionary<string, int> data = new Dictionary<string, int>();
            
            return new Client(Convert.ToInt32(dr["clientid"].ToString()), dr["username"].ToString(), dr["firstname"].ToString(), dr["lastname"].ToString());
        }

        public Client getByUsername(string username) {
            string sql = "SELECT * FROM Client WHERE username = @param1";
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("@param1", username);

            DataTable dt = instance.Query(sql, keyValuePairs);

            if (dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];
            Dictionary<string, int> data = new Dictionary<string, int>();

            return new Client(Convert.ToInt32(dr["clientid"].ToString()), dr["username"].ToString(), dr["firstname"].ToString(), dr["lastname"].ToString());
        }

        public void addNewClient(string sql, Dictionary<string , object> parameters) {
            instance.Query(sql, parameters);    // u slucaju da dodje do izuzetka delegira se do prozora forme
        }

    }
}
