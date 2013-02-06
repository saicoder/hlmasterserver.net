using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace CSMaterServer.Response
{
    public class CsResponseItem
    {
        public IPAddress IPAddress{get;set;}
        public short Port { get; set; }

        public byte[] ToByteArray()
        {
            byte[] ret = new byte[6];
            Array.Copy(IPAddress.GetAddressBytes(), ret, 4);
            ret[4] = (byte)(Port >> 8);
            ret[5] = (byte)Port;
            return ret;
        }
    }
}
