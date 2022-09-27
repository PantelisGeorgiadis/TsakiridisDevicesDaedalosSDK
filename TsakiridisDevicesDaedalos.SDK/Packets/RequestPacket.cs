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
//      Name    :       RequestPacket.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Device;

namespace TsakiridisDevicesDaedalos.SDK.Packets
{
    public abstract class RequestPacket : Packet
    {
        private readonly int MaxPacketBufferSize = 256;

        private int _packetBufferSize = 0;
        private readonly byte[] _packetBuffer = null;

        public abstract void PostResponse(DaedalosDevice device, ResponsePacket response);

        public RequestPacket(int packetNumber)
            : base(PacketDirection.Request)
        {
            PacketNumber = (ushort) packetNumber;

            _packetBufferSize = 0;
            _packetBuffer = new byte[MaxPacketBufferSize];
        }

        protected void AssemblePacket(byte[] payload)
        {
            var staggingPacketBuffer = new byte[MaxPacketBufferSize];
            int staggingPacketBufferSize = 0;

            // Add Packet Number
            var packetNumberBytes = BitConverter.GetBytes(PacketNumber);
            Array.Copy(packetNumberBytes, 0, staggingPacketBuffer, staggingPacketBufferSize, packetNumberBytes.Length);
            staggingPacketBufferSize += packetNumberBytes.Length;

            // Add Command
            var cmd = (ushort) Command;
            var commandBytes = BitConverter.GetBytes((ushort) Command);
            Array.Copy(commandBytes, 0, staggingPacketBuffer, staggingPacketBufferSize, commandBytes.Length);
            staggingPacketBufferSize += commandBytes.Length;

            // Add Payload Length
            var payloadLength = payload == null ? (ushort) 0 : (ushort) payload.Length;

            var payloadLengthdBytes = BitConverter.GetBytes(payloadLength);
            Array.Copy(payloadLengthdBytes, 0, staggingPacketBuffer, staggingPacketBufferSize,
                payloadLengthdBytes.Length);
            staggingPacketBufferSize += payloadLengthdBytes.Length;

            // Add Payload
            if (payload != null)
            {
                Array.Copy(payload, 0, staggingPacketBuffer, staggingPacketBufferSize, payloadLength);
                staggingPacketBufferSize += payloadLength;
            }

            // Assemble
            // -- Start
            _packetBufferSize = 0;
            _packetBuffer[_packetBufferSize++] = PacketMarkers.StartOfFrame;

            // -- Escape
            for (var i = 0; i < staggingPacketBufferSize; i++)
            {
                var b = staggingPacketBuffer[i];
                if (b == PacketMarkers.StartOfFrame ||
                    b == PacketMarkers.EndOfMessage ||
                    b == PacketMarkers.EscapeCharacter)
                {
                    _packetBuffer[_packetBufferSize++] = PacketMarkers.EscapeCharacter;
                    _packetBuffer[_packetBufferSize++] = (byte) (b ^ PacketMarkers.XorCharacter);
                }
                else
                {
                    _packetBuffer[_packetBufferSize++] = b;
                }
            }

            // -- Calculate Checksum
            byte ch = 0;
            var checksum = Checksum.CalculateChecksum(staggingPacketBuffer,
                staggingPacketBufferSize);

            // -- Escape high byte
            ch = (byte) ((checksum >> 8) & 0xFF);
            if (ch == PacketMarkers.StartOfFrame ||
                ch == PacketMarkers.EndOfMessage ||
                ch == PacketMarkers.EscapeCharacter)
            {
                _packetBuffer[_packetBufferSize++] = PacketMarkers.EscapeCharacter;
                _packetBuffer[_packetBufferSize++] = (byte) (ch ^ PacketMarkers.XorCharacter);
            }
            else
            {
                _packetBuffer[_packetBufferSize++] = ch;
            }

            // -- Escape low byte
            ch = (byte) (checksum & 0xFF);
            if (ch == PacketMarkers.StartOfFrame ||
                ch == PacketMarkers.EndOfMessage ||
                ch == PacketMarkers.EscapeCharacter)
            {
                _packetBuffer[_packetBufferSize++] = PacketMarkers.EscapeCharacter;
                _packetBuffer[_packetBufferSize++] = (byte) (ch ^ PacketMarkers.XorCharacter);
            }
            else
            {
                _packetBuffer[_packetBufferSize++] = ch;
            }

            // -- End
            _packetBuffer[_packetBufferSize++] = PacketMarkers.EndOfMessage;
        }

        public byte[] ToByteArray()
        {
            if (_packetBufferSize == 0)
                return null;

            var array = new byte[_packetBufferSize];
            Array.Copy(_packetBuffer, 0, array, 0, _packetBufferSize);

            return array;
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}",
                PacketNumber, Command, Direction);
        }
    }
}
