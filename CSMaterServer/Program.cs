using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CSMaterServer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            HLMaterServer master = new HLMaterServer();
            master.RequestProcessor = new RequestProcessors.SimpleFromFile();

            master.Start();

            Console.ReadLine();
            return;


            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 27011);
            UdpClient udpSock = new UdpClient(ipep);

            while (true)
            {
                Console.WriteLine("Waiting for a client...");
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                var data = udpSock.Receive(ref sender);

                Console.WriteLine("Message received from {0}:", sender.ToString());
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

                //168.63.104.91:27015
                //FF FF FF FF 66 0A
                List<byte> rbytes = new List<byte>();

                rbytes.AddRange(new byte[] {0xff,0xff,0xff,0xff,0x66,0x0A});

                IPAddress ip = IPAddress.Parse("168.63.104.91");
                
                //ip
                rbytes.AddRange(ip.GetAddressBytes());

                //port
                rbytes.Add(0x69);
                rbytes.Add(0x87);

                
                //udpSock.Send(bt.ToArray(), bt.Count, sender);

                
                //udpSock.Send(empty, empty.Length, sender);
            }
            Console.ReadLine();
        }
    }
}
