////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   29-04-2017
//
//
//      File description :
//      Name    :       TestDoneEventArgs.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using TsakiridisDevicesDaedalos.SDK.Commands;

namespace TsakiridisDevicesDaedalos.SDK.EventArguments
{
    public class TestDoneEventArgs : EventArgs
    {
        public StartTestPacketRequest Request { get; internal set; }
        public ReportDonePacketResponse Response { get; internal set; }
        public String Message { get; internal set; }

        public TestDoneEventArgs(StartTestPacketRequest request, ReportDonePacketResponse response)
        {
            Request = request;
            Response = response;
            Message = response.Message;
        }
    }
}
