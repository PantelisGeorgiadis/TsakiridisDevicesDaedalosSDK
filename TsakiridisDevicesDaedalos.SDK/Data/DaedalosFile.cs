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
//      Name    :       DaedalosFile.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Extensions;
using TsakiridisDevicesDaedalos.SDK.Packets;
using TsakiridisDevicesDaedalos.SDK.Helpers;

namespace TsakiridisDevicesDaedalos.SDK.Data
{
    public class DaedalosFile
    {
        public int Version { get; internal set; }
        public DateTime? Timestamp { get; set; }
        public String Title { get; set; }
        public int TubeIndex { get; set; }
        public String TubeName { get; set; }
        public TubeData TubeData { get; set; }
        public TestSettings TestSettings { get; set; }
        public Measurements Measurements { get; set; }

        public void Load(String filename)
        {
            var document = XDocument.Load(filename);
            XElement rootElement = document.Root;

            // File Version
            Version = rootElement.GetIntElement("Version") ?? (int) DaedalosFileVersion.V1; // Assume V1

            // Timestamp
            Timestamp = rootElement.GetDateTimeElement("Timestamp");

            // Title
            Title = rootElement.GetStringElement("Title");

            // Tube Name
            TubeName = rootElement.GetStringElement("TubeName");

            // Tube Index
            TubeIndex = rootElement.GetIntElement("TubeIndex") ?? -1;

            // Tube Data
            if (rootElement.HasElement("TubeData"))
            {
                var tubeDataElement = rootElement.Element("TubeData");

                TestSet[] testSetsArray = null;
                if (tubeDataElement.HasElement("TestSets"))
                {
                    var testSetsElement = tubeDataElement.Element("TestSets");
                    var testSets = from testSet in testSetsElement.Descendants("TestSet")
                        select new TestSet()
                        {
                            TestV = testSet.GetIntElement("TestV") ?? -1,
                            TestmA = testSet.GetFloatElement("TestmA") ?? -1f,
                            Gtyp = testSet.GetIntElement("Gtyp") ?? -1,
                            Grange = testSet.GetIntElement("Grange") ?? -1
                        };
                    testSetsArray = testSets.ToArray();
                }

                TubeData = new TubeData
                {
                    SocketNr = (sbyte) (tubeDataElement.GetIntElement("SocketNr") ?? -1),
                    IsDual = (sbyte) (tubeDataElement.GetIntElement("IsDual") ?? -1),
                    HeaterConnectedToCathode =
                        (sbyte) (tubeDataElement.GetIntElement("HeaterConnectedToCathode") ?? -1),
                    HeatingSeconds = (sbyte) (tubeDataElement.GetIntElement("HeatingSeconds") ?? -1),
                    FilamentMilliVolts = tubeDataElement.GetIntElement("FilamentMilliVolts") ?? -1,
                    FilamentMinCur = tubeDataElement.GetIntElement("FilamentMinCur") ?? -1,
                    FilamentTypCur = tubeDataElement.GetIntElement("FilamentTypCur") ?? -1,
                    FilamentMaxCur = tubeDataElement.GetIntElement("FilamentMaxCur") ?? -1,
                    MaxCathodeMa = tubeDataElement.GetFloatElement("MaxCathodeMa") ?? -1f,
                    MaxPlateVolts = tubeDataElement.GetIntElement("MaxPlateVolts") ?? -1,
                    MaxPwrMW = tubeDataElement.GetIntElement("MaxPwrMW") ?? -1,
                    Test = testSetsArray
                };
            }

            // Test Settings
            if (rootElement.HasElement("TestSettings"))
            {
                var testSettingsElement = rootElement.Element("TestSettings");
                TestSettings = new TestSettings
                {
                    IminMa = testSettingsElement.GetFloatElement("IminMa") ?? -1f,
                    ImaxMa = testSettingsElement.GetFloatElement("ImaxMa") ?? -1f,
                    IStepMa = testSettingsElement.GetFloatElement("IStepMa") ?? -1f,
                    TubeIdx = testSettingsElement.GetIntElement("TubeIdx") ?? -1,
                    PartToTest =
                        (PartToTest) (testSettingsElement.GetIntElement("PartToTest") ?? (int) PartToTest.None),
                    VminVolts = testSettingsElement.GetIntElement("VminVolts") ?? -1,
                    VmaxVolts = testSettingsElement.GetIntElement("VmaxVolts") ?? -1,
                    VStepVolts = testSettingsElement.GetIntElement("VStepVolts") ?? -1
                };
            }

            // Measurements
            if (rootElement.HasElement("Measurements"))
            {
                var measurementsElement = rootElement.Element("Measurements");
                var measurements = from measurement in measurementsElement.Descendants("Measurement")
                    select new Measurement()
                    {
                        Number = measurement.GetIntElement("Number"),
                        Voltage = measurement.GetIntElement("Voltage"),
                        VoltageUnit = measurement.GetStringElement("VoltageUnit"),
                        Current = measurement.GetFloatElement("Current"),
                        CurrentUnit = measurement.GetStringElement("CurrentUnit"),
                        Gm = measurement.GetFloatElement("Gm"),
                        GmUnit = measurement.GetStringElement("GmUnit")
                    };
                Measurements = new Measurements();
                Measurements.AddRange(measurements);
            }
        }

        public async Task LoadAsync(String filename)
        {
            await Task.Run(() => { Load(filename); });
        }

        public void Save(String filename)
        {
            if (String.IsNullOrWhiteSpace(TubeName))
                throw new ArgumentException("No TubeName");

            if (Measurements == null || Measurements.Count == 0)
                throw new ArgumentException("No Measurements");


            var numberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberDecimalDigits = 2
            };

            var document = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("DaedalosTestFile",
                    // File Version
                    new XElement("Version", (int) DaedalosFileVersion.V1),

                    // Timestamp
                    new XElement("Timestamp", Timestamp.HasValue ? Timestamp.Value.ToString("o") : String.Empty),

                    // Title
                    new XElement("Title", Title),

                    // Tube Name
                    new XElement("TubeName", TubeName),

                    // Tube Index
                    new XElement("TubeIndex", TubeIndex),

                    // Tube Data
                    new XElement("TubeData",
                        new XElement("SocketNr", (int) TubeData.SocketNr),
                        new XElement("IsDual", (int) TubeData.IsDual),
                        new XElement("HeaterConnectedToCathode", (int) TubeData.HeaterConnectedToCathode),
                        new XElement("HeatingSeconds", (int) TubeData.HeatingSeconds),
                        new XElement("FilamentMilliVolts", TubeData.FilamentMilliVolts),
                        new XElement("FilamentMinCur", TubeData.FilamentMinCur),
                        new XElement("FilamentTypCur", TubeData.FilamentTypCur),
                        new XElement("FilamentMaxCur", TubeData.FilamentMaxCur),
                        new XElement("MaxCathodeMa", TubeData.MaxCathodeMa.ToString("N", numberFormatInfo)),
                        new XElement("MaxPlateVolts", TubeData.MaxPlateVolts),
                        new XElement("MaxPwrMW", TubeData.MaxPwrMW),
                        new XElement("TestSets",
                            from testSet in TubeData.Test
                            select new XElement("TestSet",
                                new XElement("TestV", testSet.TestV),
                                new XElement("TestmA", testSet.TestmA.ToString("N", numberFormatInfo)),
                                new XElement("Gtyp", testSet.Gtyp),
                                new XElement("Grange", testSet.Grange)
                            )
                        )
                    ),

                    // Test Settings
                    new XElement("TestSettings",
                        new XElement("IminMa", TestSettings.IminMa.ToString("N", numberFormatInfo)),
                        new XElement("ImaxMa", TestSettings.ImaxMa.ToString("N", numberFormatInfo)),
                        new XElement("IStepMa", TestSettings.IStepMa.ToString("N", numberFormatInfo)),
                        new XElement("TubeIdx", TestSettings.TubeIdx),
                        new XElement("PartToTest", (int) TestSettings.PartToTest),
                        new XElement("VminVolts", TestSettings.VminVolts),
                        new XElement("VmaxVolts", TestSettings.VmaxVolts),
                        new XElement("VStepVolts", TestSettings.VStepVolts)
                    ),

                    // Measurements
                    new XElement("Measurements",
                        from measurement in Measurements
                        select new XElement("Measurement",
                            new XElement("Number",
                                measurement.Number.HasValue ? measurement.Number.Value.ToString() : String.Empty),

                            // Voltage
                            new XElement("Voltage",
                                measurement.Voltage.HasValue ? measurement.Voltage.Value.ToString() : String.Empty),
                            new XElement("VoltageUnit", measurement.VoltageUnit),

                            // Current
                            new XElement("Current",
                                measurement.Current.HasValue
                                    ? measurement.Current.Value.ToString("N", numberFormatInfo)
                                    : String.Empty),
                            new XElement("CurrentUnit", measurement.CurrentUnit),

                            // Gm
                            new XElement("Gm",
                                measurement.Gm.HasValue
                                    ? measurement.Gm.Value.ToString("N", numberFormatInfo)
                                    : String.Empty),
                            new XElement("GmUnit", measurement.GmUnit)
                        )
                    )
                )
            );

            document.Save(filename);
        }

        public async Task SaveAsync(String filename)
        {
            await Task.Run(() => { Save(filename); });
        }
    }
}
