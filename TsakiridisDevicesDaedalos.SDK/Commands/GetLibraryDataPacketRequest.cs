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
//      Name    :       GetLibraryDataPacketRequest.cs
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
    public class GetLibraryDataPacketRequest : RequestPacket
    {
        public delegate void ResponseDelegate(GetLibraryDataPacketRequest request,
            GetLibraryDataPacketResponse response);

        public ResponseDelegate OnResponseReceived;

        public int EntryNumber { get; internal set; }

        public GetLibraryDataPacketRequest(int packetNumber, int entryNumber)
            : base(packetNumber)
        {
            Command = DaedalosCommands.GetLibraryData;
            PacketNumber = (ushort) packetNumber;
            EntryNumber = entryNumber;

            var entryNumberBytes = BitConverter.GetBytes((uint) entryNumber);

            AssemblePacket(entryNumberBytes);
        }

        public override void PostResponse(DaedalosDevice device, ResponsePacket response)
        {
            if (OnResponseReceived != null)
                OnResponseReceived(this,
                    new GetLibraryDataPacketResponse(response.Data));
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}, Entry Number: {3}",
                PacketNumber, Command, Direction, EntryNumber);
        }
    }
}
