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
//      Name    :       Measurement.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using TsakiridisDevicesDaedalos.SDK.Commands;

namespace TsakiridisDevicesDaedalos.SDK.Data
{
    public class Measurement
    {
        public DateTime TimeStamp { get; set; }
        public int? Number { get; set; }
        public int? Voltage { get; set; }
        public String VoltageUnit { get; set; }
        public float? Current { get; set; }
        public String CurrentUnit { get; set; }
        public float? Gm { get; set; }
        public String GmUnit { get; set; }

        public override String ToString()
        {
            var numberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberDecimalDigits = 2
            };

            return String.Format("Number: {0}, Voltage: {1}{2}, Current: {3}{4}, Gm: {5}{6}",
                Number.HasValue ? Number.Value.ToString() : String.Empty,
                Voltage.HasValue ? Voltage.Value.ToString() : String.Empty, VoltageUnit,
                Current.HasValue ? Current.Value.ToString("N", numberFormatInfo) : String.Empty, CurrentUnit,
                Gm.HasValue ? Gm.Value.ToString("N", numberFormatInfo) : String.Empty, GmUnit);
        }

        public static Measurement FromReportMeasurementPointPacketResponse(ReportMeasurementPointPacketResponse packet)
        {
            var measurement = new Measurement();
            if (!String.IsNullOrWhiteSpace(packet.MeasurementPoint))
            {
                var pattern = @"\[(.*?)\]";
                var matches = Regex.Matches(packet.MeasurementPoint, pattern);
                if (matches.Count == 7)
                {
                    // Number
                    var numberStr = matches[0].Groups[1].Value;
                    int number;
                    if (int.TryParse(numberStr, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out number))
                        measurement.Number = number;

                    // Voltage
                    var voltageStr = matches[1].Groups[1].Value;
                    int voltage;
                    if (int.TryParse(voltageStr, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out voltage))
                        measurement.Voltage = voltage;
                    measurement.VoltageUnit = matches[2].Groups[1].Value;

                    // Current
                    var currentStr = matches[3].Groups[1].Value;
                    float current;
                    if (float.TryParse(currentStr, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out current))
                        measurement.Current = current;
                    measurement.CurrentUnit = matches[4].Groups[1].Value;

                    // Gm
                    var gmStr = matches[5].Groups[1].Value;
                    float gm;
                    if (float.TryParse(gmStr, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out gm))
                        measurement.Gm = gm;
                    measurement.GmUnit = matches[6].Groups[1].Value;
                }
            }

            return measurement;
        }
    }
}
