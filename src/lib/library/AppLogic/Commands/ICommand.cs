using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Commands
{
    internal interface IPacketCommand
    {
        void Execute(int clientid, int packetid);
    }
}
