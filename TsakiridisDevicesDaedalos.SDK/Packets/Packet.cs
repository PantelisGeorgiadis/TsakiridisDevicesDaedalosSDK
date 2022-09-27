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
//      Name    :       Packet.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using TsakiridisDevicesDaedalos.SDK.Constants;

namespace TsakiridisDevicesDaedalos.SDK.Packets
{
    public abstract class Packet
    {
        public ushort PacketNumber { get; set; }

        public DaedalosCommands Command { get; set; }

        public PacketDirection Direction { get; set; }

        protected Packet (PacketDirection direction)
        {
            Direction = direction;
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}",
                PacketNumber, Command, Direction);
        }
    }
}
