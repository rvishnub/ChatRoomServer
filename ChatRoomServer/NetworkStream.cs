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
    public class NetworkStream : IDisposable
    {

        byte[] byteResponse;
        byte[] bufferBytes;
        public TCPListener server;
        public Socket newSocket;

        public NetworkStream(Socket Socket)
        {
            NetworkStream stream = new NetworkStream(newSocket);

        }

        public void CreateBuffer()
        {
            Byte[] bufferBytes = new Byte[1024];
        }

        public byte[] ConvertToBytes(string response)
        {
            //maybe a method here?
            //this is the Encoding.ASCII.GetBytes(response)
            byte[] byteResponse = Encoding.ASCII.GetBytes(response);
            return byteResponse;
        }

        public string ConvertToString(byte[] bytes, int byteIndex, int byteCount)
        {
            string message = System.Text.Encoding.ASCII.GetString(bytes, byteIndex, byteCount);
            return message;
        }

        public Task<int> ReadAsync(byte[] buffer, int offset, int count)
        {
            //can use default version
            //returns totalBytesReadIntoBuffer task
        }

        public Task WriteAsync(byte[] buffer, int offset, int count)
        {
            //can use default version, returns task
        }


        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

    }
}
