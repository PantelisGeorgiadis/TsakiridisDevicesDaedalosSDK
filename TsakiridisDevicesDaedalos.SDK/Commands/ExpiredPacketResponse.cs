////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   23-11-2016
//
//
//      File description :
//      Name    :       ExpiredPacketResponse.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.Commands
{
    public class ExpiredPacketResponse : ResponsePacket
    {
        public ExpiredPacketResponse(RequestPacket packet)
            : base()
        {
            Command = DaedalosCommands.Expired;
            PacketNumber = packet.PacketNumber;
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}",
                PacketNumber, Command, Direction);
        }
    }
}
