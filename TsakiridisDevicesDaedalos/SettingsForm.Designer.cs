namespace TsakiridisDevicesDaedalos
{
    partial class SettingsForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTube = new System.Windows.Forms.Label();
            this.comboBoxTube = new System.Windows.Forms.ComboBox();
            this.labelPart = new System.Windows.Forms.Label();
            this.comboBoxPart = new System.Windows.Forms.ComboBox();
            this.labelVoltage = new System.Windows.Forms.Label();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(116, 226);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnButtonOKClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(197, 226);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelTube
            // 
            this.labelTube.AutoSize = true;
            this.labelTube.Location = new System.Drawing.Point(12, 23);
            this.labelTube.Name = "labelTube";
            this.labelTube.Size = new System.Drawing.Size(35, 13);
            this.labelTube.TabIndex = 0;
            this.labelTube.Text = "Tube:";
            // 
            // comboBoxTube
            // 
            this.comboBoxTube.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTube.FormattingEnabled = true;
            this.comboBoxTube.Location = new System.Drawing.Point(53, 20);
            this.comboBoxTube.Name = "comboBoxTube";
            this.comboBoxTube.Size = new System.Drawing.Size(219, 21);
            this.comboBoxTube.TabIndex = 0;
            // 
            // labelPart
            // 
            this.labelPart.AutoSize = true;
            this.labelPart.Location = new System.Drawing.Point(12, 51);
            this.labelPart.Name = "labelPart";
            this.labelPart.Size = new System.Drawing.Size(29, 13);
            this.labelPart.TabIndex = 0;
            this.labelPart.Text = "Part:";
            // 
            // comboBoxPart
            // 
            this.comboBoxPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPart.FormattingEnabled = true;
            this.comboBoxPart.Location = new System.Drawing.Point(53, 47);
            this.comboBoxPart.Name = "comboBoxPart";
            this.comboBoxPart.Size = new System.Drawing.Size(219, 21);
            this.comboBoxPart.TabIndex = 1;
            // 
            // labelVoltage
            // 
            this.labelVoltage.AutoSize = true;
            this.labelVoltage.Location = new System.Drawing.Point(12, 80);
            this.labelVoltage.Name = "labelVoltage";
            this.labelVoltage.Size = new System.Drawing.Size(207, 13);
            this.labelVoltage.TabIndex = 0;
            this.labelVoltage.Text = "Voltage: Min=100V, Max=200V, Step=10V";
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(12, 100);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(226, 13);
            this.labelCurrent.TabIndex = 0;
            this.labelCurrent.Text = "Current: Min=1.0mA, Max=1.5mA, Step=0.5mA";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.labelVoltage);
            this.Controls.Add(this.comboBoxPart);
            this.Controls.Add(this.labelPart);
            this.Controls.Add(this.comboBoxTube);
            this.Controls.Add(this.labelTube);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Settings";
            this.Load += new System.EventHandler(this.OnSettingsFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTube;
        private System.Windows.Forms.ComboBox comboBoxTube;
        private System.Windows.Forms.Label labelPart;
        private System.Windows.Forms.ComboBox comboBoxPart;
        private System.Windows.Forms.Label labelVoltage;
        private System.Windows.Forms.Label labelCurrent;
    }
}