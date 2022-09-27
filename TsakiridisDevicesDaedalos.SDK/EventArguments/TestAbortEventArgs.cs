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
//      Name    :       TestAbortEventArgs.cs
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
    public class TestAbortEventArgs : EventArgs
    {
        public StartTestPacketRequest Request { get; internal set; }
        public ReportAbortPacketResponse Response { get; internal set; }
        public String Message { get; internal set; }

        public TestAbortEventArgs(StartTestPacketRequest request, ReportAbortPacketResponse response)
        {
            Request = request;
            Response = response;
            Message = response.Message;
        }
    }
}
