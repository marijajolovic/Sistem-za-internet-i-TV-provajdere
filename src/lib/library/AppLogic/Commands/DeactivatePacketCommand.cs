using library.AppLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Commands
{
    public class DeactivatePacketCommand : IPacketCommand
    {

        private Database.Database _instance;
        

        public DeactivatePacketCommand(Database.Database db)
        {
            _instance = db;
        }

        public void Execute(int clientid,int packetid)
        {
            try
            {
                string sql = "DELETE FROM ClientPacket WHERE clientID = @clientID AND packetID = @packetID";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@clientID", clientid);
                parameters.Add("@packetID", packetid);

                _instance.Query(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
