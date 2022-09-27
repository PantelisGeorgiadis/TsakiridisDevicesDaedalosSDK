////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos Desktop Application
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   17-10-2016
//
//
//      File description :
//      Name    :       MainForm.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Data;
using TsakiridisDevicesDaedalos.SDK.Device;
using TsakiridisDevicesDaedalos.SDK.Extensions;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos
{
    public partial class MainForm : Form
    {
        private readonly DaedalosDevice _device = new DaedalosDevice();
#if !MONO
        private readonly SerialPortsChangeNotification _notification = new SerialPortsChangeNotification();
#endif
        private String _tubeName;
        private int _tubeIndex;
        private TubeData _tubeData;
        private TestSettings _testSettings;
        private readonly Measurements _measurements = new Measurements();

        public MainForm()
        {
            InitializeComponent();
            InitializeLogging();

#if !MONO
            EnableDoubleBuffering();
#endif
        }

#if !MONO
        public void EnableDoubleBuffering()
        {
            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint,
                true);
            UpdateStyles();
        }
#endif

        private void InitializeLogging()
        {
            var config = new LoggingConfiguration();

            var target = new TextBoxTarget
            {
                Layout = "${longdate} -- ${level:uppercase=true} -- ${logger} -- ${message}",
                TextBoxControl = textBoxLogging,
                Append = true,
                AddNewLine = true
            };

            config.AddTarget("txt", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));

            LogManager.Configuration = config;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
#if !MONO
            //  FTDI / USB Serial Converter
            // VID_0403 PID_6015
            // http://www.nakov.com/blog/2009/05/10/enumerate-all-com-ports-and-find-their-name-and-description-in-c/
            _notification.StateChanged += (args) =>
            {
                var __args = args;
            };
#endif

            var ports = SerialPort.GetPortNames();
            if (ports != null &&
                ports.Length > 0)
            {
                comboBoxPorts.Items.AddRange(ports);
                comboBoxPorts.SelectedIndex = 0;

                comboBoxPorts.Enabled = true;
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
                buttonAutoDetect.Enabled = true;
            }

            _device.OnTestMessageReceived += (o, args) => { System.Diagnostics.Debug.WriteLine(args.Message); };
            _device.OnTestMeasurementReceived += (o, args) =>
            {
                _measurements.Add(args.Measurement);
                Debug.WriteLine(args.Measurement.ToString());
            };
            _device.OnTestAbortReceived += (o, args) => { System.Diagnostics.Debug.WriteLine(args.Message); };
            _device.OnTestErrorReceived += (o, args) => { System.Diagnostics.Debug.WriteLine(args.Message); };
            _device.OnTestDoneReceived += (o, args) => { System.Diagnostics.Debug.WriteLine(args.Message); };
        }

        private void OnButtonStartClick(object sender, EventArgs e)
        {
            var port = (String)comboBoxPorts.SelectedItem;
            if (!String.IsNullOrWhiteSpace(port))
            {
                _device.Start(port, 115200);

                comboBoxPorts.Enabled = false;
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
                buttonAutoDetect.Enabled = false;
            }
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            if (_device.IsPortOpen)
            {
                _device.Stop();

                comboBoxPorts.Enabled = true;
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
                buttonAutoDetect.Enabled = true;
            }
        }

        private async void OnButtonAutoDetectClick(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            var portDetected = String.Empty;

            foreach (var port in ports)
            {
                var auto = new DaedalosDevice();
                if (!auto.Start(port, 115200))
                    continue;

                try
                {
                    var r = await auto.SendGetStatusRequestAsync()
                        .TimeoutAfter(TimeSpan.FromSeconds(10));
                    if (r != null &&
                        r.StatusCode == StatusCodes.Normal)
                    {
                        portDetected = port;
                        comboBoxPorts.SelectedIndex =
                            Array.IndexOf(ports, portDetected);
                    }
                }
                catch (Exception)
                {
                }

                auto.Stop();
                auto.Dispose();
            }

            if (!String.IsNullOrWhiteSpace(portDetected))
                MessageBox.Show(this, String.Format("Daedalos was found on {0}.", portDetected));
            else
                MessageBox.Show(this, "Daedalos wasn't found on any port...");
        }

        private async void OnButtonGetStatusClick(object sender, EventArgs e)
        {
            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendGetStatusRequestAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private async void OnButtonGetVersionInfoClick(object sender, EventArgs e)
        {
            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendGetVersionInfoRequestAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private async void OnButtonGetLibraryInfoClick(object sender, EventArgs e)
        {
            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendGetLibraryInfoRequestAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private async void OnButtonGetLibraryDataClick(object sender, EventArgs e)
        {
            var lt = new List<Tuple<String, TubeData>>();

            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendGetLibraryInfoRequestAsync();
                    if (r != null)
                    {
                        var entries = r.NumberOfEntries;
                        for (var i = 0; i < entries; i++)
                        {
                            var r2 = await _device.SendGetLibraryDataRequestAsync(i);
                            if (r2 != null)
                            {
                                lt.Add(new Tuple<String, TubeData>(
                                    r2.TubeName, r2.TubeInfo));
                                Debug.WriteLine(String.Format("Name: {0}, Tube Info: {1}",
                                    r2.TubeName, r2.TubeInfo.ToString()));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private async void OnButtonDisplayMessageClick(object sender, EventArgs e)
        {
            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendDisplayMessageRequestAsync(0, "HELLO");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private async void OnButtonDisplayProgressClick(object sender, EventArgs e)
        {
            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendDisplayProgressBarRequestAsync(LineNumber.Two, 10);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private async void OnButtonGetSettingsClick(object sender, EventArgs e)
        {
            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendGetSettingsRequestAsync();
                    if (r != null)
                    {
                        _testSettings = r.TestSettings;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private void OnButtonSetSettingsClick(object sender, EventArgs e)
        {
            var form = new SettingsForm(_device);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _tubeName = form.TubeName;
                _tubeIndex = form.TubeIndex;
                _tubeData = form.TubeData;
                _testSettings = form.TestSettings;
            }
        }

        private async void OnButtonStartTestClick(object sender, EventArgs e)
        {
            _measurements.Clear();

            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendStartTestRequestAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private async void OnButtonAbortTestClick(object sender, EventArgs e)
        {
            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendAbortTestRequestAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private async void OnButtonSaveMeasurementsClick(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Daedalos Measurements File|*.daedalos";
                saveFileDialog.Title = "Save a Daedalos Measurements File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK ||
                    !String.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    try
                    {
                        var file = new DaedalosFile
                        {
                            Timestamp = DateTime.Now,
                            Title = "",
                            TubeName = _tubeName,
                            TubeIndex = _tubeIndex,
                            TubeData = _tubeData,
                            TestSettings = _testSettings,
                            Measurements = _measurements
                        };

                        await file.SaveAsync(saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message);
                    }
                }
            }
        }

        private async void OnButtonLoadMeasurementsClick(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Daedalos Measurements File|*.daedalos";
                openFileDialog.Title = "Open a Daedalos Measurements File";
                if (openFileDialog.ShowDialog() == DialogResult.OK ||
                    !String.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    try
                    {
                        var file = new DaedalosFile();
                        await file.LoadAsync(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message);
                    }
                }
            }
        }
    }
}
