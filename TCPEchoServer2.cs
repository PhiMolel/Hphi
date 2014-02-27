using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SocketConcurrent
{
    public class TCPEchoServer2
    {
        public static void Main1(string[] args)
        {
            var ip = IPAddress.Parse("127.0.0.1");
            var serverSocket = new TcpListener(ip, 6789);

            //TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();


            while (true)
            {
                Socket connectionSocket = serverSocket.AcceptSocket();
                Console.WriteLine("Server activated now");
                var service = new EchoService(connectionSocket);
                var myThread = new Thread(new ThreadStart(service.DoIt));
                myThread.Start();

                //Task.Factory.StartNew(service.doIt);
                // or use delegates Task.Factory.StartNew() => service.DoIt();
             }


            serverSocket.Stop();
        } 
        
    }
}
