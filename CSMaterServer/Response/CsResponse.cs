using System;
using System.Collections.Generic;
using System.Text;

namespace CSMaterServer.Response
{
    public class CsResponse
    {
        public CsResponse()
        {
            Servers = new List<CsResponseItem>();
        }

        public List<CsResponseItem> Servers { get; set; }

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();

            //FF FF FF FF 66 0A
            //Defined by Valve
            bytes.AddRange(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x66, 0x0A });

            Servers.ForEach(t =>
            {
                bytes.AddRange(t.ToByteArray());
            });

            //end bytes
            bytes.AddRange(new byte[6]);

            return bytes.ToArray();
        }
    }
}
