using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using chat.server;

namespace chat.client
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                TcpClient tcpClient;
                Stream clientStream;
                //
                connect(out tcpClient, out clientStream);
                //
                //make an asynchronuous relation between sending and receiving messages 
                //parallel sending and receiving
                Thread threadSendMsg = new Thread(new ParameterizedThreadStart(transmitMsg));
                
                //end thread when user logging out (when main ends).
                threadSendMsg.IsBackground = true;
                threadSendMsg.Start(clientStream);

                //receiving
                while (true)
                {
                    //
                    byte[] incomingMsg;
                    int actualRecievedMsgLen;
                    receiveIncomingMsg(clientStream, out incomingMsg, out actualRecievedMsgLen);

                    //logout
                    if (Convert.ToChar(incomingMsg[0]) == 'q')
                    {
                        Console.WriteLine("logging out ...");
                        Thread.Sleep(1000);
                        break;
                    }

                    //print incomming msg
                    print(incomingMsg, actualRecievedMsgLen);
                }

                clientStream.Close();
                tcpClient.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }

        private static void transmitMsg(object s)
        {
            while (true)
            {
                var clientStream = (Stream)s;
                string myMsgStr = Read();

                //command -file [filePath]
                //normal msg ( ~ ), or a file( . )?
                string msgType = "~";
                bool enoughLength = myMsgStr.Length > 6; //avoid OutOFRangeException

                if (enoughLength && myMsgStr.Substring(0,5) == "-file")
                {
                    msgType = ".";

                    string path = myMsgStr.Substring(6);
                    TextReader myFile = new StreamReader(path);
                    myMsgStr = myFile.ReadToEnd();

                    myFile.Close();
                    myFile = null;
                }

                // ~ marks that this is received msg when displayed in the chat box
                // if the incomming msg begins with ., this means the msg is a file
                ASCIIEncoding encode = new ASCIIEncoding(); 
                byte[] myMsgByte = encode.GetBytes(msgType +  myMsgStr);

                //Transmitting
                int startLen = 0, end = myMsgByte.Length;
                clientStream.Write(myMsgByte, startLen, end);
            }
        }

        private static void print(byte[] incomingMsg, int actualRecievedMsgLen)
        {

            StringBuilder myIncomingMsg = new StringBuilder();
            for (int i = 0; i < actualRecievedMsgLen; i++)
                myIncomingMsg.Append(Convert.ToChar(incomingMsg[i]));

            //file?
            if (Convert.ToChar(incomingMsg[0]) == '.')
            {
                string filePath = "myfile.txt";

                saveMyFile(myIncomingMsg, filePath);

                string msg = $"~you received a file {filePath}";
                myIncomingMsg = new StringBuilder(msg);
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(myIncomingMsg.ToString());

            Console.ResetColor();
        }

        private static void saveMyFile(StringBuilder myIncomingMsg, string filePath)
        {
            if (!File.Exists(filePath))
            {
                var myFile = File.Create(filePath);

                // close the file so TextWriter can open it later again for write
                // avoid the [being used by another process] IO exception
                //https://stackoverflow.com/questions/18421932/error-on-writing-file-it-is-used-by-other-process
                myFile.Close();
            }

            try
            {
                //write to file
                TextWriter myNewFile = new StreamWriter(filePath);

                myNewFile.WriteLine(myIncomingMsg.ToString());
                myNewFile.Flush();

                myNewFile.Close();
                myNewFile = null;
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }


        }

        private static void receiveIncomingMsg(Stream clientStream, out byte[] incomingMsg, out int actualRecievedMsgLen)
        {
            int startLength = 0;
            int maxLength = 100;
            incomingMsg = new byte[maxLength];
            actualRecievedMsgLen = clientStream.Read(incomingMsg, startLength, maxLength);
        }

        private static string Read()
        {
            //Console.WriteLine();
            //Console.Write("your msg: ");

            String myMsgStr = Console.ReadLine();
            return myMsgStr;
        }

        private static void connect(out TcpClient tcpClient, out Stream clientStream)
        {
            tcpClient = new TcpClient();
            Console.WriteLine("Connecting.....");
            // use the ipaddress as in the server program 
            tcpClient.Connect(Server.ip, 8001);
            clientStream = tcpClient.GetStream();
            //
            Console.Title = $"client{Server.countClients}";
            Console.WriteLine("Connected\n-------------chat-------------");
            //
        }
    }
}
