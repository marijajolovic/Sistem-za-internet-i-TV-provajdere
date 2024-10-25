using library.AppLogic.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Interfaces {
    internal interface IPacketBuilder {

        void setPacketID(int id);
        void setPacketName(string name);
        void setPacketPrice(double price);
        void setDownloadSpeed(int dSpeed);
        void setUploadSpeed(int uSpeed);
        void setNumberOfChannels(int numberOfChannels);

    }
}
