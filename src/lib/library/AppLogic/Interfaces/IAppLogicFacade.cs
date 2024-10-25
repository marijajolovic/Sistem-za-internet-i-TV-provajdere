using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.AppLogic.Clients;
using library.AppLogic.Packets;

namespace library.AppLogic.Interfaces {
    public interface IAppLogicFacade {

        string getProviderName();
        IEnumerable<Client> getAllClients(string like);
        IEnumerable<Packet> getPacketsForClient(int clientid);
        void registerClient(string username, string firstName, string lastName);
        IEnumerable<Packet> getPacketsByType(Packet.PacketType type);
        void createNewPacket(string name, double price, Packet.PacketType type, Dictionary<string, object> data);
        Packet getPacketByName(string name);
        void activatePacket(int clientid, int packetid);
        void deactivatePacket(int clientid, int packetid);
        void restorePreviousState();
        void redoPrevouslyRestoredState();
        Packet getPacketByID(int id);
        Client getClientByID(int id);
        Client getClientByUsername(string username);
    }
}
