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
//      Name    :       GetStatusPacketResponse.cs
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
    public class GetStatusPacketResponse : ResponsePacket
    {
        public StatusCodes StatusCode { get; internal set; }

        public GetStatusPacketResponse(byte[] data)
            : base()
        {
            Command = DaedalosCommands.GetStatus;

            var payload = DisassemblePacket(data);
            if (payload != null)
                DisassemblePayload(payload);
        }

        private void DisassemblePayload(byte[] payload)
        {
            Array.Reverse(payload);
            StatusCode = (StatusCodes) BitConverter.ToUInt16(payload, 0);
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}, Status: {3}",
                PacketNumber, Command, Direction, StatusCode);
        }
    }
}
