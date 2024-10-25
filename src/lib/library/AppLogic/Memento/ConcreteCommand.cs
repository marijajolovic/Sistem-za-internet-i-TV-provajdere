using library.AppLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace library.AppLogic.Memento {
    internal class ConcreteCommand : ICommandMemento {

        private Dictionary<string, object> parameters;  // type: INSERT | table: ClientPacket | clientID: 1 | packetID: 1
        private Database.Database instance;

        public ConcreteCommand(Dictionary<string, object> parameters, Database.Database instance) {
            this.parameters = parameters;
            this.instance = instance;
        }

        public void undo(IAppLogicFacade aLogic) {
            string type = parameters["type"].ToString().ToLower();
            string table = parameters["table"].ToString().ToLower();  // client, packet, clientPacket
            string sql;
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            switch(type) {
                case "insert":  // insert moze biti nad tabelom Client, Packet, ClientPacket
                    
                    if (table == "client") {
                        sql = "DELETE FROM Client WHERE username = @param1";
                        keyValuePairs.Add("@param1", parameters["username"].ToString());
                        executeSQL(sql, keyValuePairs);
                    }
                    else if(table == "packet") {

                        int id_paketa = aLogic.getPacketByName(parameters["name"].ToString()).PacketID;
                        string packetType = parameters["packetType"].ToString().ToLower();
                        string sql1;
                        string tabela;

                        if (packetType == "internet") { tabela = "internetpacket"; }
                        else if (packetType == "tv") { tabela = "tvpacket"; }
                        else if (packetType == "combined") { tabela = "combpacket"; }
                        else { tabela = "NO_TABLE"; }

                        sql = "DELETE FROM Packet WHERE PacketID = @param1";
                        sql1 = "DELETE FROM " + tabela + " WHERE packetid = @param1";
                        keyValuePairs.Add("@param1", id_paketa);

                        executeSQL(sql1, keyValuePairs);    // prvo brise iz tabele internetpacket, tvpacket, combpacket pa onda iz tabele packet
                        executeSQL(sql, keyValuePairs);
                    }
                    else if(table == "clientpacket") {
                        int packetID = aLogic.getPacketByName(parameters["packetName"].ToString()).PacketID;
                        int clientID = aLogic.getClientByUsername(parameters["clientName"].ToString()).ClientID;

                        sql = "DELETE FROM ClientPacket WHERE ClientID = @param1 AND PacketID = @param2";
                        keyValuePairs.Add("@param1", clientID);
                        keyValuePairs.Add("@param2", packetID);
                        executeSQL(sql, keyValuePairs);
                    }
                    else {
                        // ...
                    }
                    break;

                case "delete":  // delete moze biti samo nad tabelom ClientPacket
                    if(table == "clientpacket") {
                        int packetID = aLogic.getPacketByName(parameters["packetName"].ToString()).PacketID;
                        int clientID = aLogic.getClientByUsername(parameters["clientName"].ToString()).ClientID;

                        sql = "INSERT INTO ClientPacket (ClientID, PacketID) VALUES (@param1, @param2)";
                        keyValuePairs.Add("@param1", clientID);
                        keyValuePairs.Add("@param2", packetID);
                        executeSQL(sql, keyValuePairs);
                    }
                    else {
                        // ...
                    }
                    break;

                default:
                    break;
            }
        }

        public void redo(IAppLogicFacade aLogic) {
            string type = parameters["type"].ToString().ToLower();
            string table = parameters["table"].ToString().ToLower();
            string sql;
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            switch (type) {
                case "insert":

                    if (table == "client") {
                        sql = "INSERT INTO Client (username, firstname, lastname) VALUES (@param1, @param2, @param3)";
                        keyValuePairs.Add("@param1", parameters["username"].ToString());
                        keyValuePairs.Add("@param2", parameters["firstName"].ToString());
                        keyValuePairs.Add("@param3", parameters["lastName"].ToString());
                        executeSQL(sql, keyValuePairs);
                    }
                    else if (table == "packet") {
                        sql = "INSERT INTO Packet (name, price) VALUES(@param1, @param2)";
                        keyValuePairs.Add("@param1", parameters["name"].ToString());
                        keyValuePairs.Add("@param2", parameters["price"].ToString());
                        executeSQL(sql, keyValuePairs);

                        string packetType = parameters["packetType"].ToString().ToLower();
                        string sql1;
                        Dictionary<string, object> keyValuePairs1 = new Dictionary<string, object>();
                        int newPacketID = aLogic.getPacketByName(parameters["name"].ToString()).PacketID;

                        if (packetType == "internet") {
                            sql1 = "INSERT INTO InternetPacket(packetid, downloadspeed, uploadspeed) VALUES (@param1, @param2, @param3)";
                            keyValuePairs1.Add("@param1", newPacketID);
                            keyValuePairs1.Add("@param2", parameters["downloadSpeed"].ToString());
                            keyValuePairs1.Add("@param3", parameters["uploadSpeed"].ToString());
                            executeSQL(sql1, keyValuePairs1);
                        }
                        else if (packetType == "tv") {
                            sql1 = "INSERT INTO TVPacket(packetid, numberOfChannels) VALUES (@param1, @param2)";
                            keyValuePairs1.Add("@param1", newPacketID);
                            keyValuePairs1.Add("@param2", parameters["numberOfChannels"].ToString());
                            executeSQL(sql1, keyValuePairs1);
                        }
                        else if (packetType == "combined") {
                            sql1 = "INSERT INTO CombPacket(packetid, internetpacketid, tvpacketid) VALUES (@param1, @param2, @param3)";
                            keyValuePairs1.Add("@param1", newPacketID);
                            keyValuePairs1.Add("@param2", aLogic.getPacketByName(parameters["internetPacketName"].ToString()).PacketID);
                            keyValuePairs1.Add("@param3", aLogic.getPacketByName(parameters["tvPacketName"].ToString()).PacketID);
                            executeSQL(sql1, keyValuePairs1);
                        }
                        else { 
                            // ...
                        }

                    }
                    else if (table == "clientpacket") {

                        int packetID = aLogic.getPacketByName(parameters["packetName"].ToString()).PacketID;
                        int clientID = aLogic.getClientByUsername(parameters["clientName"].ToString()).ClientID;

                        sql = "INSERT INTO ClientPacket(clientid, packetid) VALUES(@param1, @param2)";
                        keyValuePairs.Add("@param1", clientID);
                        keyValuePairs.Add("@param2", packetID);
                        executeSQL(sql, keyValuePairs);
                    }
                    else {
                        // ...
                    }
                    break;

                case "delete":  // delete moze biti samo nad tabelom ClientPacket
                    if (table == "clientpacket") {
                        int packetID = aLogic.getPacketByName(parameters["packetName"].ToString()).PacketID;
                        int clientID = aLogic.getClientByUsername(parameters["clientName"].ToString()).ClientID;

                        sql = "DELETE FROM ClientPacket WHERE ClientID = @param1 AND PacketID = @param2";
                        keyValuePairs.Add("@param1", clientID);
                        keyValuePairs.Add("@param2", packetID);
                        executeSQL(sql, keyValuePairs);
                    }
                    else {
                        // ...
                    }
                    break;

                default:
                    break;
            }
        }

        private void executeSQL(string sql, Dictionary<string, object> parameters) {
            instance.Query(sql, parameters);
        }

    }
}
