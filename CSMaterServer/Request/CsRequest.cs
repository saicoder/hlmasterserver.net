using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSMaterServer.Request
{
    public class CsRequest
    {
        public RegionCode RegionCode { get; set; }
        public string IpAndPort { get; set; }

        public string Filters { get; set; }

        public static CsRequest FromBytes(byte[] packet)
        {
            try
            {
                if (packet[0] != '1')
                    throw new Exception("Invalid packet!");


                CsRequest req = new CsRequest();
           
                req.RegionCode = (RegionCode)packet[1];

                int stringsFrom = 2;
                req.IpAndPort = Helper.GetStringFromBytes(packet, ref stringsFrom);
                req.Filters = Helper.GetStringFromBytes(packet, ref stringsFrom);

                return req;

            }
            catch
            {
                Console.WriteLine("Invalid packet!");
                return null;
            }
        }
    }
}
