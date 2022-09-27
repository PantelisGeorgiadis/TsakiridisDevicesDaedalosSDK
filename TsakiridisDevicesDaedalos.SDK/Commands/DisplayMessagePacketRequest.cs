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
//      Name    :       DisplayMessagePacketRequest.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Text;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Device;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.Commands
{
    public class DisplayMessagePacketRequest : RequestPacket
    {
        public delegate void ResponseDelegate(DisplayMessagePacketRequest request,
            DisplayMessagePacketResponse response);

        public ResponseDelegate OnResponseReceived;

        public LineNumber LineNumber { get; internal set; }

        public String Text { get; internal set; }

        public DisplayMessagePacketRequest(int packetNumber, LineNumber lineNumber, String text)
            : base(packetNumber)
        {
            Command = DaedalosCommands.DisplayMessage;
            PacketNumber = (ushort) packetNumber;
            LineNumber = lineNumber;
            Text = text;

            var textBytes = Encoding.ASCII.GetBytes(text);
            var payloadLegth = textBytes.Length + 2;
            var payload = new byte[payloadLegth];

            Array.Copy(new byte[] {(byte) LineNumber}, 0, payload, 0, 1);
            Array.Copy(textBytes, 0, payload, 1, textBytes.Length);
            Array.Copy(new byte[] {(byte) 0}, 0, payload, textBytes.Length + 1, 1);

            AssemblePacket(payload);
        }

        public override void PostResponse(DaedalosDevice device, ResponsePacket response)
        {
            if (OnResponseReceived != null)
                OnResponseReceived(this,
                    new DisplayMessagePacketResponse(response.Data));
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}, LineNumber: {3}, Text: {4}",
                PacketNumber, Command, Direction, LineNumber, Text);
        }
    }
}
