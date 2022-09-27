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
//      Name    :       ReportMessagePacketResponse.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Text;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.Commands
{
    public class ReportMessagePacketResponse : ResponsePacket
    {
        public String Message { get; internal set; }

        public ReportMessagePacketResponse(byte[] data)
            : base()
        {
            Command = DaedalosCommands.ReportMessage;

            var payload = DisassemblePacket(data);
            if (payload != null)
                DisassemblePayload(payload);
        }

        private void DisassemblePayload(byte[] payload)
        {
            Message = Encoding.ASCII.GetString(payload).TrimEnd('\0');
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}, Message: {3}",
                PacketNumber, Command, Direction, Message);
        }
    }
}
