using library.AppLogic.Interfaces;
using library.AppLogic.Clients;
using library.AppLogic.Packets;
using library.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Management.Instrumentation;
using library.Database;
using System.Windows.Input;
using library.AppLogic.Commands;
using library.AppLogic.Memento;

namespace library.AppLogic {
    public class AppLogic : IAppLogicFacade {

        private IPacketCommand _commandActivatePacket;
        private IPacketCommand _commandDeactivatePacket;
        private string _configFilepath = "../../../../../config.txt";
        private ClientLogic _clientLogic;
        private PacketLogic _packetLogic;
        private Snapshot _snapshotMaker;

        private Database.Database instance = null;

        /* ***************************************************************
         * Konstruktor
         * *************************************************************** */
        public AppLogic() {
            instance = Database.Database.GetInstance();
            _clientLogic = new ClientLogic();
            _packetLogic = new PacketLogic();
            _commandActivatePacket=new ActivatePacketCommand(instance);
            _commandDeactivatePacket = new DeactivatePacketCommand(instance);
            _snapshotMaker = new Snapshot(instance, this);
        }

        /* ***************************************************************
         * 
         * *************************************************************** */
        public string getProviderName() {
            return TextParser.Parse(_configFilepath)["PROVIDER"];
        }
        /* ***************************************************************
         * 
         * *************************************************************** */
        public IEnumerable<Client> getAllClients(string like) {

            IEnumerable<Client> returnValue = null;

            try {
                string sql = "SELECT * FROM Client";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                
                if (like != "") {
                    sql += " WHERE username LIKE @param1";
                    parameters.Add("@param1", "%" + like + "%");
                }
                sql += " ORDER BY username ASC";
                returnValue = _clientLogic.getAllClients(sql, parameters);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return returnValue;
        }
        /* ***************************************************************
         * 
         * *************************************************************** */
        public void registerClient(string username, string firstName, string lastName) {
            string sql = "INSERT INTO Client (username, firstname, lastname) VALUES (@param1, @param2, @param3)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@param1", username);
            parameters.Add("@param2", firstName);
            parameters.Add("@param3", lastName);

            _clientLogic.addNewClient(sql, parameters); // u slucaju da dodje do izuzetka delegira se do prozora forme

            Dictionary<string, object> snapshotParameters = new Dictionary<string, object>();
            snapshotParameters.Add("type", "INSERT");
            snapshotParameters.Add("table", "CLIENT");
            snapshotParameters.Add("username", username);
            snapshotParameters.Add("firstName", firstName);
            snapshotParameters.Add("lastName", lastName);
            _snapshotMaker.CreateSnapshot(snapshotParameters); // ako iznad pukne nece doci do ovog dela
        }
        /* ***************************************************************
         * 
         * *************************************************************** */
        public IEnumerable<Packet> getPacketsByType(Packet.PacketType type) {

            IEnumerable<Packet> returnValue = null;
            string sql = "";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            switch(type) {
                case Packet.PacketType.INTERNET:
                    sql = "SELECT * FROM Packet p JOIN InternetPacket i ON p.PacketID = i.PacketID";
                    returnValue = _packetLogic.getInternetPackets(sql, parameters);
                    break;

                case Packet.PacketType.TV:
                    sql = "SELECT * FROM Packet p JOIN TVPacket t ON p.PacketID = t.PacketID";
                    returnValue = _packetLogic.getTVPackets(sql, parameters);
                    break;

                case Packet.PacketType.COMBINED:
                    sql = "SELECT * FROM packet p JOIN combpacket c JOIN internetpacket i JOIN tvpacket t on p.packetid = c.packetid AND c.InternetPacketID = i.packetid and c.TVPacketID = t.PacketID";
                    returnValue = _packetLogic.getCombinedPackets(sql, parameters);
                    break;

                default:
                    break;
            }

            return returnValue;
        }
        /* ***************************************************************
         * 
         * *************************************************************** */
        public Packet getPacketByName(string name) {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string sql = "SELECT * FROM Packet WHERE name = @param1";
            parameters.Add("@param1", name);

            return _packetLogic.getByName(sql, parameters);
        }
        /* ***************************************************************
         * 
         * *************************************************************** */
        public void createNewPacket(string name, double price, Packet.PacketType type, Dictionary<string, object> data) {
            string sql1;
            string sql2;
            Dictionary<string, object> parameters1 = new Dictionary<string, object>();
            Dictionary<string, object> parameters2 = new Dictionary<string, object>();

            sql1 = "INSERT INTO Packet (name, price) VALUES (@param1, @param2)";
            parameters1.Add("@param1", name);
            parameters1.Add("@param2", price);
            _packetLogic.insert(sql1, parameters1);   // moguc izuzetak ukoliko ime nije unique

            int newPacketID = getPacketByName(name).PacketID;

            Dictionary<string, object> snapshotParameters = new Dictionary<string, object>();
            snapshotParameters.Add("type", "INSERT");
            snapshotParameters.Add("table", "PACKET");
            snapshotParameters.Add("name", name);
            snapshotParameters.Add("price", price);
            snapshotParameters.Add("packetID", newPacketID);

            switch (type) {
                case Packet.PacketType.INTERNET:
                    sql2 = "INSERT INTO InternetPacket (packetid, downloadspeed, uploadspeed) VALUES (@param1, @param2, @param3)";
                    parameters2.Add("@param1", newPacketID);
                    parameters2.Add("@param2", data["downloadSpeed"]);
                    parameters2.Add("@param3", data["uploadSpeed"]);
                    _packetLogic.insert(sql2, parameters2);

                    snapshotParameters.Add("downloadSpeed", data["downloadSpeed"]);
                    snapshotParameters.Add("uploadSpeed", data["uploadSpeed"]);
                    snapshotParameters.Add("packetType", "INTERNET");
                    break;

                case Packet.PacketType.TV:
                    sql2 = "INSERT INTO TVPacket (packetid, numberOfChannels) VALUES (@param1, @param2)";
                    parameters2.Add("@param1", newPacketID);
                    parameters2.Add("@param2", data["numberOfChannels"]);
                    _packetLogic.insert(sql2, parameters2);

                    snapshotParameters.Add("numberOfChannels", data["numberOfChannels"]);
                    snapshotParameters.Add("packetType", "TV");
                    break;

                case Packet.PacketType.COMBINED:
                    sql2 = "INSERT INTO CombPacket (packetid, internetpacketid, tvpacketid) VALUES (@param1, @param2, @param3)";
                    parameters2.Add("@param1", newPacketID);
                    parameters2.Add("@param2", getPacketByName(data["internetpacketname"].ToString()).PacketID);
                    parameters2.Add("@param3", getPacketByName(data["tvpacketname"].ToString()).PacketID);
                    _packetLogic.insert(sql2, parameters2);

                    snapshotParameters.Add("internetPacketName", data["internetpacketname"].ToString());
                    snapshotParameters.Add("tvPacketName", data["tvpacketname"].ToString());
                    snapshotParameters.Add("packetType", "COMBINED");
                    break;

                default:
                    break;
            }

            _snapshotMaker.CreateSnapshot(snapshotParameters);
        }
        /* ***************************************************************
         * 
         * *************************************************************** */
        public IEnumerable<Packet> getPacketsForClient(int clientid) {

            IEnumerable<Packet> returnValue = null;
            try {
                string sql = "SELECT * FROM ClientPacket cp JOIN Packet p ON cp.packetid = p.packetid WHERE clientid = @id";
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                keyValuePairs.Add("@id", clientid);

                returnValue = _clientLogic.getPacketsForClient(sql, keyValuePairs);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return returnValue;
        }
        /* ***************************************************************
         * 
         * *************************************************************** */

        public Packet getPacketByID(int id) {
            return _packetLogic.getByID(id);
        }
        public Client getClientByID(int id) {
            return _clientLogic.getByID(id);
        }
        public Client getClientByUsername(string username) {
            return _clientLogic.getByUsername(username);
        }

        public void activatePacket(int clientid, int packetid) {
            _commandActivatePacket.Execute(clientid, packetid);

            Dictionary<string, object> snapshotParameters = new Dictionary<string, object>();
            snapshotParameters.Add("type", "INSERT");
            snapshotParameters.Add("table", "CLIENTPACKET");
            snapshotParameters.Add("clientName", getClientByID(clientid).Username);
            snapshotParameters.Add("packetName", getPacketByID(packetid).Name);
            _snapshotMaker.CreateSnapshot(snapshotParameters);
        }
        /* ***************************************************************
         * 
         * *************************************************************** */
        public void deactivatePacket(int clientid, int packetid) {
            _commandDeactivatePacket.Execute(clientid, packetid);
            Dictionary<string, object> snapshotParameters = new Dictionary<string, object>();
            snapshotParameters.Add("type", "DELETE");
            snapshotParameters.Add("table", "CLIENTPACKET");
            snapshotParameters.Add("clientName", getClientByID(clientid).Username);
            snapshotParameters.Add("packetName", getPacketByID(packetid).Name);
            _snapshotMaker.CreateSnapshot(snapshotParameters);
        }

        public void restorePreviousState() {
            _snapshotMaker.RestoreSnapshot();
        }

        public void redoPrevouslyRestoredState() {
            _snapshotMaker.RedoSnapshot();
        }
    }
}
