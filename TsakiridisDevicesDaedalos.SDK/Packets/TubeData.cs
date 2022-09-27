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
//      Name    :       TubeData.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace TsakiridisDevicesDaedalos.SDK.Packets
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TubeData
    {
        private IntPtr TubeName;
        private IntPtr SocketName;
        public sbyte SocketNr;
        public sbyte IsDual;
        public sbyte HeaterConnectedToCathode;
        public sbyte HeatingSeconds;
        public int FilamentMilliVolts;
        public int FilamentMinCur;
        public int FilamentTypCur;
        public int FilamentMaxCur;
        public float MaxCathodeMa;
        public int MaxPlateVolts;
        public int MaxPwrMW;

        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 5)]
        public TestSet[] Test;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TestSet
    {
        public int TestV;
        public float TestmA;
        public int Gtyp;
        public int Grange;
    }

    public static class TubeDataExtension
    {
        public static String TubeDataToString(this TubeData tubeData)
        {
            return String.Format("Is Dual: {0}, Heating Seconds: {1}, Filament Voltage: {2}mV",
                tubeData.IsDual, tubeData.HeatingSeconds, tubeData.FilamentMilliVolts);
        }

        public static String TestSetToString(this TestSet testSet)
        {
            var numberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberDecimalDigits = 2
            };

            return String.Format("TestV: {0}, TestmA: {1}, Gtyp: {2}, Grange: {3}",
                testSet.TestV, testSet.TestmA.ToString("N", numberFormatInfo),
                testSet.Gtyp, testSet.Grange);
        }
    }
}
