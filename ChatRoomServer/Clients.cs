using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ChatRoomServer
{
    class Clients
    {
        public string name;
        public Dictionary<string, string> clientDict = new Dictionary<string, string>();

        public Clients(string clientName)
        {
            clientName = name;
        }

    }
}
