////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   23-04-2017
//
//
//      File description :
//      Name    :       TestMessageEventArgs.cs
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
    public class TestMessageEventArgs : EventArgs
    {
        public StartTestPacketRequest Request { get; internal set; }
        public ReportMessagePacketResponse Response { get; internal set; }
        public String Message { get; internal set; }

        public TestMessageEventArgs(StartTestPacketRequest request, ReportMessagePacketResponse response)
        {
            Request = request;
            Response = response;
            Message = response.Message;
        }
    }
}
