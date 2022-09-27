////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   17-10-2016
//
//
//      File description :
//      Name    :       GetVersionInfoPacketResponse.cs
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
    public class GetVersionInfoPacketResponse : ResponsePacket
    {
        public String Version { get; internal set; }

        public GetVersionInfoPacketResponse(byte[] data)
            : base()
        {
            Command = DaedalosCommands.GetVersionInfo;

            var payload = DisassemblePacket(data);
            if (payload != null)
                DisassemblePayload(payload);
        }

        private void DisassemblePayload(byte[] payload)
        {
            Version = Encoding.ASCII.GetString(payload).TrimEnd('\0');
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}, Version: {3}",
                PacketNumber, Command, Direction, Version);
        }
    }
}
