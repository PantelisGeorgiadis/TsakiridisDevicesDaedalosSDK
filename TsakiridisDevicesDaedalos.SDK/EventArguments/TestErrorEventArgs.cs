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
//      Name    :       TestErrorEventArgs.cs
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
    public class TestErrorEventArgs : EventArgs
    {
        public StartTestPacketRequest Request { get; internal set; }
        public ReportErrorPacketResponse Response { get; internal set; }
        public String Message { get; internal set; }

        public TestErrorEventArgs(StartTestPacketRequest request, ReportErrorPacketResponse response)
        {
            Request = request;
            Response = response;
            Message = response.Message;
        }
    }
}
