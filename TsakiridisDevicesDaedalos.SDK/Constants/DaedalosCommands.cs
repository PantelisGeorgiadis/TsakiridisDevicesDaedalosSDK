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
//      Name    :       DaedalosCommands.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;

namespace TsakiridisDevicesDaedalos.SDK.Constants
{
    public enum DaedalosCommands : ushort
    {
        Generic = 0xAFFF,
        Expired = 0xBFFF,
        NegativeAcknowledgment = 0xFFFF,

        GetStatus = 0x0001,
        GetVersionInfo = 0x0002,
        DisplayMessage = 0x0003,
        DisplayProgressBar = 0x0004,
        ResendLast = 0x0005,

        GetLibraryInfo = 0x0010,
        GetLibraryData = 0x0011,

        SetSettings = 0x0020,
        GetSettings = 0x0021,
        StartTest = 0x0022,
        AbortTest = 0x0023,
        ReportMeasurementPoint = 0x0024,
        ReportMessage = 0x0025,
        ReportAbort = 0x0026,
        ReportError = 0x0027,
        ReportDone = 0x0028
    }
}
