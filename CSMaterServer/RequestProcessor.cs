using CSMaterServer.Request;
using CSMaterServer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSMaterServer
{
    public interface RequestProcessor
    {
        CsResponse Process(CsRequest request);
    }
}
