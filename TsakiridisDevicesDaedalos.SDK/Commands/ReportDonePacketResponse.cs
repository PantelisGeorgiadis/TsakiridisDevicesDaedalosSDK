////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   29-04-2017
//
//
//      File description :
//      Name    :       ReportDonePacketResponse.cs
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
    public class ReportDonePacketResponse : ResponsePacket
    {
        public String Message { get; internal set; }

        public ReportDonePacketResponse(byte[] data)
            : base()
        {
            Command = DaedalosCommands.ReportDone;

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
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}, Done Message: {3}",
                PacketNumber, Command, Direction, Message);
        }
    }
}
