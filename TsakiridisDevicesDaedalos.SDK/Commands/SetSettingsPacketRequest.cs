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
//      Name    :       SetSettingsPacketRequest.cs
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
    public class SetSettingsPacketRequest : RequestPacket
    {
        public delegate void ResponseDelegate(SetSettingsPacketRequest request, SetSettingsPacketResponse response);

        public ResponseDelegate OnResponseReceived;

        public TestSettings TestSettings { get; internal set; }

        public SetSettingsPacketRequest(int packetNumber, TestSettings testSettings)
            : base(packetNumber)
        {
            Command = DaedalosCommands.SetSettings;
            PacketNumber = (ushort) packetNumber;
            TestSettings = testSettings;

            var testSettingsBytes = BinaryStructHelper.ToByteArray<TestSettings>(testSettings);

            AssemblePacket(testSettingsBytes);
        }

        public override void PostResponse(DaedalosDevice device, ResponsePacket response)
        {
            if (OnResponseReceived != null)
                OnResponseReceived(this,
                    new SetSettingsPacketResponse(response.Data));
        }

        public override String ToString()
        {
            return String.Format("Packet Number: {0}, Command: {1}, Direction: {2}, Test Settings: {3}",
                PacketNumber, Command, Direction, TestSettings.TestSettingsToString());
        }
    }
}
