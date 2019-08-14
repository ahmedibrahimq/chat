using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace chat.server
{
    public class Server
    {
        public static string ip = "";
        //to distinguish clients with ID
        public static int countClients = 0;
        //make easy access to openned sockets 
        public static Socket[] clients = new Socket[2];
        //
        //mark who sends now, to prevent receiver client from executing readline() before receiving sender's msg
        //public static int token = 0;


        static void Main(string[] args)
        {
            Console.Title = "server";
            try
            {
                IPAddress localIp = Dns.GetHostAddresses(Dns.GetHostName())[5];
                // use local m/c IP address, and 
                // use the same in the client
                ip =localIp.ToString();
                // Initializes the Listener 
                TcpListener tcpListnerList = new TcpListener(localIp, 8001);
                // Start Listeneting at the specified port 
                tcpListnerList.Start();
                //
                SayHello(tcpListnerList);
                //
                AcceptSocket(tcpListnerList);
                return; //generated automatically! by refactor
                //
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }

        }

        private static void AcceptSocket(TcpListener tcpListnerList)
        {
            while (true)
            {
                Socket mySocket = tcpListnerList.AcceptSocket();
                Console.WriteLine($"Connection accepted from client{countClients}: {mySocket.RemoteEndPoint}");
                //
                Thread socketThreadForClient =
                    new Thread(
                                new ParameterizedThreadStart(receiveClient));
                //
                socketThreadForClient.Start(mySocket);

            }

            //tcpListnerList.Stop();
        }

        private static void SayHello(TcpListener tcpListnerList)
        {
            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is  :" + tcpListnerList.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");
        }

        private static void receiveClient(Object AcceptedSocket)
        {
            int id = countClients++;

            Socket mySocket = (Socket)AcceptedSocket;
            //easy access clients with id
            clients[id] = mySocket;

            while (true)
            {
                ASCIIEncoding encode = new ASCIIEncoding();
                //
                //receiving
                byte[] bytesMsg = new byte[100];
                int actualBytesMsgLen = mySocket.Receive(bytesMsg);

                //
                //logout
                if (Convert.ToChar(bytesMsg[1]) == 'q')
                {
                    //send quit signal to client program
                    mySocket.Send(encode.GetBytes("q"));
                    Console.WriteLine($"client {id} signed out");
                    countClients--;
                    break;
                }
                //
                //to receiver
                sendMyMsg(id, bytesMsg);
                //
            }

            // clean up           
            mySocket.Close();
        }

        private static void sendMyMsg(int senderId, byte[] bytesMsg)
        {
            int receiverId = (senderId == 0) ? 1 : 0; 
            clients[receiverId].Send(bytesMsg);
            Console.WriteLine($"\nSent to client {receiverId}");
        }
    }
}
