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
//      Name    :       SettingsForm.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Device;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos
{
    public partial class SettingsForm : Form
    {
        private readonly DaedalosDevice _device;

        public String TubeName { get; internal set; }
        public int TubeIndex { get; internal set; }
        public TubeData TubeData { get; internal set; }
        public TestSettings TestSettings { get; internal set; }

        public SettingsForm(DaedalosDevice device)
        {
            InitializeComponent();

            _device = device;
        }

        private async void OnSettingsFormLoad(object sender, EventArgs e)
        {
            EnableControls(false);
            await PopulateTubeComboBox();
            PopulatePartComboBox();
            EnableControls(true);
        }

        private async Task PopulateTubeComboBox()
        {
            var tubes = new List<Tuple<String, TubeData>>();

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
                                tubes.Add(new Tuple<String, TubeData>(
                                    r2.TubeName, r2.TubeInfo));
                            }
                        }

                        var index = 0;
                        foreach (var tube in tubes)
                        {
                            comboBoxTube.Items.Add(new TubeComboBoxItem(index, tube));
                            index++;
                        }

                        if (comboBoxTube.Items.Count > 0)
                            comboBoxTube.SelectedIndex = 0;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(this, e.Message);
                }
            }
        }

        private void PopulatePartComboBox()
        {
            comboBoxPart.Items.Add("First Half");
            comboBoxPart.Items.Add("Second Half");
            comboBoxPart.SelectedIndex = 0;
        }

        private void EnableControls(bool bEnable)
        {
            comboBoxTube.Enabled = bEnable;
            comboBoxPart.Enabled = bEnable;

            buttonOK.Enabled = bEnable;
            buttonCancel.Enabled = bEnable;
        }

        private async void OnButtonOKClick(object sender, EventArgs e)
        {
            var item = (TubeComboBoxItem) comboBoxTube.SelectedItem;

            var testSettings = new TestSettings
            {
                TubeIdx = comboBoxTube.SelectedIndex,
                PartToTest = (PartToTest) comboBoxPart.SelectedIndex + 1,
                VminVolts = 100,
                VmaxVolts = 200,
                VStepVolts = 10,
                IminMa = 1.0f,
                ImaxMa = 1.5f,
                IStepMa = 0.5f
            };

            EnableControls(false);
            var ret = await SetTestSettings(testSettings);
            EnableControls(true);

            if (ret)
            {
                TubeName = item.Tube.Item1;
                TubeData = item.Tube.Item2;
                TubeIndex = item.Index;
                TestSettings = testSettings;

                DialogResult = DialogResult.OK;
            }
        }

        private async Task<bool> SetTestSettings(TestSettings testSettings)
        {
            var ret = false;

            if (_device.IsPortOpen)
            {
                try
                {
                    var r = await _device.SendGetSettingsRequestAsync(testSettings);
                    ret = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(this, e.Message);
                }
            }

            return ret;
        }

        private class TubeComboBoxItem
        {
            private readonly Tuple<String, TubeData> _tube;
            private readonly int _index;

            public Tuple<String, TubeData> Tube
            {
                get { return _tube; }
            }

            public int Index
            {
                get { return _index; }
            }

            public TubeComboBoxItem(int index, Tuple<String, TubeData> tube)
            {
                _tube = tube;
                _index = index;
            }

            public override string ToString()
            {
                return String.Format("{0}: {1}", _index, _tube.Item1);
            }
        }
    }
}
