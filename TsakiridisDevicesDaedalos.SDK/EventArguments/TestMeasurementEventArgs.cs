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
//      Name    :       TestMeasurementEventArgs.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using TsakiridisDevicesDaedalos.SDK.Commands;
using TsakiridisDevicesDaedalos.SDK.Data;

namespace TsakiridisDevicesDaedalos.SDK.EventArguments
{
    public class TestMeasurementEventArgs : EventArgs
    {
        public StartTestPacketRequest Request { get; internal set; }
        public ReportMeasurementPointPacketResponse Response { get; internal set; }
        public Measurement Measurement { get; internal set; }

        public TestMeasurementEventArgs(StartTestPacketRequest request, ReportMeasurementPointPacketResponse response)
        {
            Request = request;
            Response = response;
            Measurement = Measurement.FromReportMeasurementPointPacketResponse(response);
        }
    }
}
