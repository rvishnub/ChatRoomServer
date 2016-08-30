using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

//creates a listener, listens, accepts connection, sends a socket, receives data 
//and processes it, sends data back, closes connection.
//Probably need more than one class here, sounds like a lot, and I want multithread 
//which probably has to be managed by its own class.

namespace ChatRoomServer
{
    public class TCPListener
    {
        public IPAddress ipAddress;
        private static int port;
        public static Socket newSocket;

        public TCPListener server;
        public ClientSocket clientSocket;
        public NetworkStream stream;

        public TCPListener(IPAddress ipAddress, int mcastPort)
        {
            ipAddress = IPAddress.Parse("10.2.20.23");
            //port = 9218;
            port = 0;
        }
        
        public void CreateSocket()
        {
            newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }


        public void BindSocket()
        {
            //Console.Write("Enter the local IP address: ");
            //IPAddress localIPAddress = IPAddress.Parse(Console.ReadLine());
            EndPoint localEP = (EndPoint)new IPEndPoint(this.ipAddress, 0);
            newSocket.Bind(localEP);
            
            //newSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, mcastOption);

            newSocket.Listen(200);
            while (true)
            {
                server.AcceptSocket();
            }
                
        }
    

        public void AcceptSocket()
        {
            Console.WriteLine("Connection accepted.");
            string responseString = "You have successfully connected to me";
            byte[] responseBytes = stream.ConvertToBytes(responseString);
            int bytesSent = newSocket.Send(responseBytes);
            Console.WriteLine("Message Sent: {0}; {1} bytes.",  responseString, bytesSent);

        }

        public void Send()
        {
            //will use default bytes.Send method.  Convert from string first.  Returns int bytes sent.
            //returns bytesSent;
        }

        public void Close()
        {
            //do Socket.Shutdown(SocketShutdown.Both) first to make sure all data has been sent and received;
            //use default Socket.Close method;
        }

        private static void ReceiveBroadcastMessages()
        {
            bool done = false;
            byte[] bytes = new Byte[1024];
            IPEndPoint groupEP = new IPEndPoint((IPAddress.Parse("10.2.20.23")),0);
            EndPoint remoteEP = (EndPoint)new IPEndPoint(IPAddress.Any, 0);

            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for multicast packets. . . .");
                    Console.WriteLine("Enter ^C to terminate.");

                    newSocket.ReceiveFrom(bytes, ref remoteEP);
                    Console.WriteLine("Received broadcast from {0} :\n {1}\n", groupEP.ToString(), stream.ConvertToString(bytes, 0, bytes.Length));

                }

                newSocket.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
