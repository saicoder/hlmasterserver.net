﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSMaterServer.Request
{
    public enum RegionCode : byte
    {
        USEastCoast = 0x00,
        USWestCoast = 0x01,
        SouthAmerica = 0x02,
        Europe = 0x03,
        Asia = 0x04,
        Australia = 0x05,
        MiddleEast = 0x06,
        Africa = 0x07,
        RestOfTheWorld = 0xff
    }
}
