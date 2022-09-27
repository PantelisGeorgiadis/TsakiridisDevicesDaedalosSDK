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
//      Name    :       PacketReceivedEventArgs.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.EventArguments
{
    public class PacketReceivedEventArgs : EventArgs
    {
        private readonly Packet _packet;

        public PacketReceivedEventArgs(Packet packet)
        {
            _packet = packet;
        }

        public Packet Packet
        {
            get { return _packet; }
        }
    }
}
