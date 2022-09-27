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
//      Name    :       GetLibraryDataPacketResponse.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.InteropServices;
using System.Text;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Helpers;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.Commands
{
    public class GetLibraryDataPacketResponse : ResponsePacket
    {
        public TubeData TubeInfo { get; internal set; }

        public String TubeName { get; internal set; }

        public GetLibraryDataPacketResponse(byte[] data)
            : base()
        {
            Command = DaedalosCommands.GetLibraryData;

            var payload = DisassemblePacket(data);
            if (payload != null)
                DisassemblePayload(payload);
        }

        private void DisassemblePayload(byte[] payload)
        {
            TubeInfo = BinaryStructHelper.FromByteArray<TubeData>(payload);

            var legth = payload.Length;
            var legthTubeData = Marshal.SizeOf(typeof(TubeData));
            if (legth > legthTubeData)
            {
                var diff = legth - legthTubeData;
                if (diff > 0)
                {
                    var nameData = new byte[diff];
                    Array.Copy(payload, legthTubeData, nameData, 0, diff);

                    TubeName = Encoding.ASCII.GetString(nameData).TrimEnd('\0');
                }
            }
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}, Tube Name: {3} ({4})",
                PacketNumber, Command, Direction, TubeName, TubeInfo.TubeDataToString());
        }
    }
}
