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
    public class ClientSocket
    {
        Byte[] bytes;
        TCPListener server;

        public ClientSocket(TCPListener server)
        {
            ClientSocket clientSocket = new ClientSocket(server);
        }



        public void Send(byte[] bytes)
        {

        }

        public byte[] GetStream()
        {
            return bytes;
        }
    }
}
