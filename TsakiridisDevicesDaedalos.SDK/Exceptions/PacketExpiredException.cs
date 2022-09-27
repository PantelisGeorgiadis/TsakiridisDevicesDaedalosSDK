////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   22-04-2017
//
//
//      File description :
//      Name    :       PacketExpiredException.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.Exceptions
{
    public class PacketExpiredException : Exception
    {
        public PacketExpiredException(Packet packet)
            : base()
        {

        }
    }
}
