namespace TsakiridisDevicesDaedalos
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetLibraryInfo = new System.Windows.Forms.Button();
            this.buttonGetVersionInfo = new System.Windows.Forms.Button();
            this.buttonGetLibraryData = new System.Windows.Forms.Button();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.buttonDisplayProgress = new System.Windows.Forms.Button();
            this.buttonDisplayMessage = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonAutoDetect = new System.Windows.Forms.Button();
            this.buttonGetStatus = new System.Windows.Forms.Button();
            this.buttonGetSettings = new System.Windows.Forms.Button();
            this.buttonSetSettings = new System.Windows.Forms.Button();
            this.buttonStartTest = new System.Windows.Forms.Button();
            this.buttonAbortTest = new System.Windows.Forms.Button();
            this.textBoxLogging = new System.Windows.Forms.TextBox();
            this.buttonSaveMeasurements = new System.Windows.Forms.Button();
            this.buttonLoadMeasurements = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGetLibraryInfo
            // 
            this.buttonGetLibraryInfo.Location = new System.Drawing.Point(387, 62);
            this.buttonGetLibraryInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGetLibraryInfo.Name = "buttonGetLibraryInfo";
            this.buttonGetLibraryInfo.Size = new System.Drawing.Size(176, 35);
            this.buttonGetLibraryInfo.TabIndex = 6;
            this.buttonGetLibraryInfo.Text = "Get Library Info";
            this.buttonGetLibraryInfo.UseVisualStyleBackColor = true;
            this.buttonGetLibraryInfo.Click += new System.EventHandler(this.OnButtonGetLibraryInfoClick);
            // 
            // buttonGetVersionInfo
            // 
            this.buttonGetVersionInfo.Location = new System.Drawing.Point(202, 62);
            this.buttonGetVersionInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGetVersionInfo.Name = "buttonGetVersionInfo";
            this.buttonGetVersionInfo.Size = new System.Drawing.Size(176, 35);
            this.buttonGetVersionInfo.TabIndex = 5;
            this.buttonGetVersionInfo.Text = "Get Version Info";
            this.buttonGetVersionInfo.UseVisualStyleBackColor = true;
            this.buttonGetVersionInfo.Click += new System.EventHandler(this.OnButtonGetVersionInfoClick);
            // 
            // buttonGetLibraryData
            // 
            this.buttonGetLibraryData.Location = new System.Drawing.Point(572, 62);
            this.buttonGetLibraryData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGetLibraryData.Name = "buttonGetLibraryData";
            this.buttonGetLibraryData.Size = new System.Drawing.Size(340, 35);
            this.buttonGetLibraryData.TabIndex = 7;
            this.buttonGetLibraryData.Text = "Get Library Info && Get Library Data";
            this.buttonGetLibraryData.UseVisualStyleBackColor = true;
            this.buttonGetLibraryData.Click += new System.EventHandler(this.OnButtonGetLibraryDataClick);
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStripMain.Location = new System.Drawing.Point(0, 795);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStripMain.Size = new System.Drawing.Size(1326, 22);
            this.statusStripMain.TabIndex = 3;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // buttonDisplayProgress
            // 
            this.buttonDisplayProgress.Location = new System.Drawing.Point(1106, 62);
            this.buttonDisplayProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDisplayProgress.Name = "buttonDisplayProgress";
            this.buttonDisplayProgress.Size = new System.Drawing.Size(176, 35);
            this.buttonDisplayProgress.TabIndex = 9;
            this.buttonDisplayProgress.Text = "Display 10%";
            this.buttonDisplayProgress.UseVisualStyleBackColor = true;
            this.buttonDisplayProgress.Click += new System.EventHandler(this.OnButtonDisplayProgressClick);
            // 
            // buttonDisplayMessage
            // 
            this.buttonDisplayMessage.Location = new System.Drawing.Point(921, 62);
            this.buttonDisplayMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDisplayMessage.Name = "buttonDisplayMessage";
            this.buttonDisplayMessage.Size = new System.Drawing.Size(176, 35);
            this.buttonDisplayMessage.TabIndex = 8;
            this.buttonDisplayMessage.Text = "Display HELLO";
            this.buttonDisplayMessage.UseVisualStyleBackColor = true;
            this.buttonDisplayMessage.Click += new System.EventHandler(this.OnButtonDisplayMessageClick);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPorts.Enabled = false;
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(20, 20);
            this.comboBoxPorts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(174, 28);
            this.comboBoxPorts.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(202, 20);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(110, 35);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.OnButtonStartClick);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(321, 20);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(110, 35);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.OnButtonStopClick);
            // 
            // buttonAutoDetect
            // 
            this.buttonAutoDetect.Enabled = false;
            this.buttonAutoDetect.Location = new System.Drawing.Point(440, 20);
            this.buttonAutoDetect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAutoDetect.Name = "buttonAutoDetect";
            this.buttonAutoDetect.Size = new System.Drawing.Size(176, 35);
            this.buttonAutoDetect.TabIndex = 3;
            this.buttonAutoDetect.Text = "Auto Detect";
            this.buttonAutoDetect.UseVisualStyleBackColor = true;
            this.buttonAutoDetect.Click += new System.EventHandler(this.OnButtonAutoDetectClick);
            // 
            // buttonGetStatus
            // 
            this.buttonGetStatus.Location = new System.Drawing.Point(18, 62);
            this.buttonGetStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGetStatus.Name = "buttonGetStatus";
            this.buttonGetStatus.Size = new System.Drawing.Size(176, 35);
            this.buttonGetStatus.TabIndex = 4;
            this.buttonGetStatus.Text = "Get Status";
            this.buttonGetStatus.UseVisualStyleBackColor = true;
            this.buttonGetStatus.Click += new System.EventHandler(this.OnButtonGetStatusClick);
            // 
            // buttonGetSettings
            // 
            this.buttonGetSettings.Location = new System.Drawing.Point(20, 106);
            this.buttonGetSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGetSettings.Name = "buttonGetSettings";
            this.buttonGetSettings.Size = new System.Drawing.Size(176, 35);
            this.buttonGetSettings.TabIndex = 10;
            this.buttonGetSettings.Text = "Get Settings";
            this.buttonGetSettings.UseVisualStyleBackColor = true;
            this.buttonGetSettings.Click += new System.EventHandler(this.OnButtonGetSettingsClick);
            // 
            // buttonSetSettings
            // 
            this.buttonSetSettings.Location = new System.Drawing.Point(204, 106);
            this.buttonSetSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSetSettings.Name = "buttonSetSettings";
            this.buttonSetSettings.Size = new System.Drawing.Size(176, 35);
            this.buttonSetSettings.TabIndex = 11;
            this.buttonSetSettings.Text = "Set Settings";
            this.buttonSetSettings.UseVisualStyleBackColor = true;
            this.buttonSetSettings.Click += new System.EventHandler(this.OnButtonSetSettingsClick);
            // 
            // buttonStartTest
            // 
            this.buttonStartTest.Location = new System.Drawing.Point(388, 106);
            this.buttonStartTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStartTest.Name = "buttonStartTest";
            this.buttonStartTest.Size = new System.Drawing.Size(176, 35);
            this.buttonStartTest.TabIndex = 12;
            this.buttonStartTest.Text = "Start Test";
            this.buttonStartTest.UseVisualStyleBackColor = true;
            this.buttonStartTest.Click += new System.EventHandler(this.OnButtonStartTestClick);
            // 
            // buttonAbortTest
            // 
            this.buttonAbortTest.Location = new System.Drawing.Point(573, 106);
            this.buttonAbortTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAbortTest.Name = "buttonAbortTest";
            this.buttonAbortTest.Size = new System.Drawing.Size(176, 35);
            this.buttonAbortTest.TabIndex = 13;
            this.buttonAbortTest.Text = "Abort Test";
            this.buttonAbortTest.UseVisualStyleBackColor = true;
            this.buttonAbortTest.Click += new System.EventHandler(this.OnButtonAbortTestClick);
            // 
            // textBoxLogging
            // 
            this.textBoxLogging.AcceptsReturn = true;
            this.textBoxLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogging.Location = new System.Drawing.Point(20, 151);
            this.textBoxLogging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLogging.Multiline = true;
            this.textBoxLogging.Name = "textBoxLogging";
            this.textBoxLogging.ReadOnly = true;
            this.textBoxLogging.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLogging.Size = new System.Drawing.Size(1286, 612);
            this.textBoxLogging.TabIndex = 16;
            // 
            // buttonSaveMeasurements
            // 
            this.buttonSaveMeasurements.Location = new System.Drawing.Point(758, 106);
            this.buttonSaveMeasurements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSaveMeasurements.Name = "buttonSaveMeasurements";
            this.buttonSaveMeasurements.Size = new System.Drawing.Size(176, 35);
            this.buttonSaveMeasurements.TabIndex = 14;
            this.buttonSaveMeasurements.Text = "Save Measurements";
            this.buttonSaveMeasurements.UseVisualStyleBackColor = true;
            this.buttonSaveMeasurements.Click += new System.EventHandler(this.OnButtonSaveMeasurementsClick);
            // 
            // buttonLoadMeasurements
            // 
            this.buttonLoadMeasurements.Location = new System.Drawing.Point(942, 106);
            this.buttonLoadMeasurements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLoadMeasurements.Name = "buttonLoadMeasurements";
            this.buttonLoadMeasurements.Size = new System.Drawing.Size(176, 35);
            this.buttonLoadMeasurements.TabIndex = 15;
            this.buttonLoadMeasurements.Text = "Load Measurements";
            this.buttonLoadMeasurements.UseVisualStyleBackColor = true;
            this.buttonLoadMeasurements.Click += new System.EventHandler(this.OnButtonLoadMeasurementsClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 817);
            this.Controls.Add(this.buttonLoadMeasurements);
            this.Controls.Add(this.buttonSaveMeasurements);
            this.Controls.Add(this.textBoxLogging);
            this.Controls.Add(this.buttonAbortTest);
            this.Controls.Add(this.buttonStartTest);
            this.Controls.Add(this.buttonSetSettings);
            this.Controls.Add(this.buttonGetSettings);
            this.Controls.Add(this.buttonGetStatus);
            this.Controls.Add(this.buttonAutoDetect);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.buttonDisplayMessage);
            this.Controls.Add(this.buttonDisplayProgress);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.buttonGetLibraryData);
            this.Controls.Add(this.buttonGetVersionInfo);
            this.Controls.Add(this.buttonGetLibraryInfo);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1339, 847);
            this.Name = "MainForm";
            this.Text = "Daedalos SDK Test";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetLibraryInfo;
        private System.Windows.Forms.Button buttonGetVersionInfo;
        private System.Windows.Forms.Button buttonGetLibraryData;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.Button buttonDisplayProgress;
        private System.Windows.Forms.Button buttonDisplayMessage;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonAutoDetect;
        private System.Windows.Forms.Button buttonGetStatus;
        private System.Windows.Forms.Button buttonGetSettings;
        private System.Windows.Forms.Button buttonSetSettings;
        private System.Windows.Forms.Button buttonStartTest;
        private System.Windows.Forms.Button buttonAbortTest;
        private System.Windows.Forms.TextBox textBoxLogging;
        private System.Windows.Forms.Button buttonSaveMeasurements;
        private System.Windows.Forms.Button buttonLoadMeasurements;
    }
}

