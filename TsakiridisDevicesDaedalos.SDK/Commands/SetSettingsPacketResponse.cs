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
//      Name    :       SetSettingsPacketResponse.cs
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
    public class SetSettingsPacketResponse : ResponsePacket
    {
        public TestSettings TestSettings { get; internal set; }

        public SetSettingsPacketResponse(byte[] data)
            : base()
        {
            Command = DaedalosCommands.DisplayMessage;

            var payload = DisassemblePacket(data);
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}",
                PacketNumber, Command, Direction);
        }
    }
}
