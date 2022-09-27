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
//      Name    :       DisplayProgressBarPacketRequest.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Device;
using TsakiridisDevicesDaedalos.SDK.Helpers;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.Commands
{
    public class DisplayProgressBarPacketRequest : RequestPacket
    {
        public delegate void ResponseDelegate(DisplayProgressBarPacketRequest request,
            DisplayProgressBarPacketResponse response);

        public ResponseDelegate OnResponseReceived;

        public LineNumber LineNumber { get; internal set; }

        public byte Percentage { get; internal set; }

        public DisplayProgressBarPacketRequest(int packetNumber, LineNumber lineNumber, byte percentage)
            : base(packetNumber)
        {
            Command = DaedalosCommands.DisplayProgressBar;
            PacketNumber = (ushort) packetNumber;
            LineNumber = lineNumber;
            Percentage = MathHelpers.Clamp(percentage, 0, 100);

            var payload = new byte[2];

            Array.Copy(new byte[] {(byte) LineNumber}, 0, payload, 0, 1);
            Array.Copy(new byte[] {Percentage}, 0, payload, 1, 1);

            AssemblePacket(payload);
        }

        public override void PostResponse(DaedalosDevice device, ResponsePacket response)
        {
            if (OnResponseReceived != null)
                OnResponseReceived(this,
                    new DisplayProgressBarPacketResponse(response.Data));
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}, LineNumber: {3}, Percentage: {4}",
                PacketNumber, Command, Direction, LineNumber, Percentage);
        }
    }
}
