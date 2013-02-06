using CSMaterServer.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CSMaterServer.RequestProcessors
{
    public class SimpleFromFile : RequestProcessor
    {

        public Response.CsResponse Process(Request.CsRequest request)
        {
            string[] lines = File.ReadAllLines("serverlist.txt");
            CsResponse response = new CsResponse();

            foreach (var l in lines)
            {
                if (l.Trim().Length == 0 || l.Trim()[0] == '#')
                    continue;

                var ipPort = l.Trim().Split(new char[] { ':' });

                IPAddress ip;
                short port;
                if (ipPort.Length < 2 || !IPAddress.TryParse(ipPort[0], out ip) || !short.TryParse(ipPort[1], out port))
                    continue;

                response.Servers.Add(new CsResponseItem()
                {
                    IPAddress = ip,
                    Port = port
                });
            }

            return response;
        }
    }
}
