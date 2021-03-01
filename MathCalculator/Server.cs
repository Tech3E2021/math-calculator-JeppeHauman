using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace MathCalculator
{
    public class Server
    {
        private double _clientNumberX;
        private double _clientNumberY;
        private double _addedNumbers;
        

        public void start()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 3001;
                IPAddress localAddress = IPAddress.Loopback;
                server = new TcpListener(localAddress, port);
                server.Start();
                Console.WriteLine("This bitch started yo");

                
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException : {0}", e);
            }
        }

        private void DoClient(TcpListener server)
        {
            

            TcpClient connectionSocket = server.AcceptTcpClient();

            Console.WriteLine("We activated");
            Stream ns = connectionSocket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            sw.WriteLine("Type: Add (YourNumberX) (YourNumberY), to add two numbers");
            string[] arry = sr.ReadLine().Split(' ');
            _clientNumberX = double.Parse(arry[1]);
            _clientNumberY = Double.Parse(arry[2]);
            _addedNumbers = _clientNumberX = _clientNumberY;

            sw.WriteLine($"Your numbers added = {_addedNumbers}");

        }

    }
}
