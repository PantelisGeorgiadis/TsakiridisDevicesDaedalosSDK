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
//      Name    :       ResponsePacket.cs
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
    public abstract class ResponsePacket : Packet
    {
        public byte[] Data { get; internal set; }

        protected ResponsePacket()
            : base(PacketDirection.Response)
        {
        }

        protected byte[] DisassemblePacket(byte[] data)
        {
            Data = data;

            byte[] payload = null;

            var buffer = new byte[2];
            var index = 0;

            // Extract Packet Number
            Array.Copy(data, index, buffer, 0, sizeof(ushort));
            index += sizeof(ushort);
            PacketNumber = BitConverter.ToUInt16(buffer, 0);

            // Extract Command
            Array.Copy(data, index, buffer, 0, sizeof(ushort));
            index += sizeof(ushort);
            Command = (DaedalosCommands) BitConverter.ToUInt16(buffer, 0);

            // Extract Payload Length
            Array.Copy(data, index, buffer, 0, sizeof(ushort));
            index += sizeof(ushort);
            var payloadLength = BitConverter.ToUInt16(buffer, 0);

            // Extract Payload
            if (payloadLength != 0)
            {
                payload = new byte[payloadLength];
                Array.Copy(data, index, payload, 0, payloadLength);
            }

            return payload;
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}",
                PacketNumber, Command, Direction);
        }
    }
}
