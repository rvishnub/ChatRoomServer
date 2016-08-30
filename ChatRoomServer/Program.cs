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
    public class Program
    {
        static void Main(string[] args)
        {


            try
            {
                //TURN THE SERVER ON
                TCPListener server = new TCPListener(IPAddress.Parse("10.2.20.23"), 9218);
                server.CreateSocket();
                server.BindSocket();

                //create buffer for data
                NetworkStream stream = new NetworkStream(server.newSocket);

                stream.CreateBuffer();

                //the loop for listening
                while (true)
                {
                    Console.Write("Waiting. . . .");
                }


                //accept connection
                Console.WriteLine("You have been accepted into the chat room.");

                //send message
                string response = "You have successfully connected to the server.";
                Byte[] byteMessage = stream.ConvertToBytes(response);
                byteMessage.Send();

                //get a stream object, probably form multithread pool here?

                //receive message; loop so we get all the data sent

                int i = stream.Read(bytes, 0, byteCount);
                while (i != 0)
                {
                    string data = stream.ConvertToString(bytes, 0, i);
                    Console.WriteLine("Received:  " + data);
                    data = data.ToUpper();
                    Byte[] message = stream.ConvertToBytes(data);
                    stream.BeginWrite(message, 0, message.Length);
                    Console.WriteLine("Sent:  " + data);
                    i = stream.Read(bytes, byteIndex, byteCount);
                }

                //shut down
                server.Close();
            }



            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();





        }

    }
}
    
    