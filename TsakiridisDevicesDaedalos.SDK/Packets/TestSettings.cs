////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   28-05-2017
//
//
//      File description :
//      Name    :       TestSettings.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using TsakiridisDevicesDaedalos.SDK.Constants;

namespace TsakiridisDevicesDaedalos.SDK.Packets
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TestSettings
    {
        public float IminMa;
        public float ImaxMa;
        public float IStepMa;
        public int TubeIdx;
        public PartToTest PartToTest;
        public int VminVolts;
        public int VmaxVolts;
        public int VStepVolts;
    }

    public static class TestSettingsExtension
    {
        public static String TestSettingsToString(this TestSettings testSettings)
        {
            var numberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberDecimalDigits = 2
            };

            return String.Format(
                "Selected Tube Index: {0}, Part to Test: {1}, Voltage: Min={2}V, Step={3}V, Max={4}V, Current: Min={5}mA, Step={6}mA, Max={7}mA",
                testSettings.TubeIdx, testSettings.PartToTest,
                testSettings.VminVolts, testSettings.VStepVolts, testSettings.VmaxVolts,
                testSettings.IminMa.ToString("N", numberFormatInfo),
                testSettings.IStepMa.ToString("N", numberFormatInfo),
                testSettings.ImaxMa.ToString("N", numberFormatInfo));
        }
    }
}
