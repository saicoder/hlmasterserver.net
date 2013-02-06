using CSMaterServer.Request;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CSMaterServer
{
    public class HLMaterServer
    {
        private bool STOP = false;
        private System.Threading.Thread serverThread;

        public RequestProcessor RequestProcessor { get; set; }

        public HLMaterServer(){}
        public HLMaterServer(RequestProcessor rp)
        {
            RequestProcessor = rp;
        }

        public void Start()
        {
            if (RequestProcessor == null)
                throw new Exception("RequestProcessor isn't defined");
            serverThread = new System.Threading.Thread(srwTask);
            serverThread.Start();
            STOP = false;
        }

        private void srwTask(object obj)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 27011);
            UdpClient udpSock = new UdpClient(ipep);

            while (STOP == false)
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                var reqBytes = udpSock.Receive(ref sender);
                
                var request = CsRequest.FromBytes(reqBytes);
                if (request == null)
                    continue;

                var response = RequestProcessor.Process(request);
                var resBytes = response.GetBytes();

                udpSock.Send(resBytes, resBytes.Length, sender);
            }
            
        }

        
    }
}
