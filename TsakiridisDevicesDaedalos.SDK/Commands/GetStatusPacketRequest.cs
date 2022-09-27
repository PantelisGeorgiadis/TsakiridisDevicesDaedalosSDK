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
//      Name    :       GetStatusPacketRequest.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Device;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.Commands
{
    public class GetStatusPacketRequest : RequestPacket
    {
        public delegate void ResponseDelegate(GetStatusPacketRequest request, GetStatusPacketResponse response);

        public ResponseDelegate OnResponseReceived;

        public GetStatusPacketRequest(int packetNumber)
            : base(packetNumber)
        {
            Command = DaedalosCommands.GetStatus;
            PacketNumber = (ushort) packetNumber;

            AssemblePacket(null);
        }

        public override void PostResponse(DaedalosDevice device, ResponsePacket response)
        {
            if (OnResponseReceived != null)
                OnResponseReceived(this,
                    new GetStatusPacketResponse(response.Data));
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}",
                PacketNumber, Command, Direction);
        }
    }
}
