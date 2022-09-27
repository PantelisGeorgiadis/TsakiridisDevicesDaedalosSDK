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
//      Name    :       TextBoxTarget.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using NLog;
using NLog.Common;
using NLog.Config;
using NLog.Targets;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TsakiridisDevicesDaedalos
{
    [Target("TextBoxControl")]
    public sealed class TextBoxTarget : TargetWithLayout
    {
        public TextBoxTarget()
        {
            Append = true;
        }

        private delegate void DelSendTheMessageToFormControl(TextBox control, string logMessage);

        [RequiredParameter] public TextBox TextBoxControl { get; set; }

        [DefaultValue(true)] public bool Append { get; set; }

        [DefaultValue(true)] public bool AddNewLine { get; set; }

        public bool ReverseOrder { get; set; }

        protected override void Write(LogEventInfo logEvent)
        {
            var logMessage = Layout.Render(logEvent);
            FindControlAndSendTheMessage(logMessage);
        }

        private void FindControlAndSendTheMessage(string logMessage)
        {
            try
            {
                TextBoxControl.BeginInvoke(new DelSendTheMessageToFormControl(SendTheMessageToFormControl),
                    TextBoxControl, logMessage);
            }
            catch (Exception ex)
            {
                InternalLogger.Warn(ex.ToString());
                if (LogManager.ThrowExceptions)
                    throw;
            }
        }

        private void SendTheMessageToFormControl(TextBox control, string logMessage)
        {
            if (Append)
            {
                if (ReverseOrder)
                    control.Text = logMessage + control.Text +
                                   (AddNewLine ? "\r\n" : String.Empty);
                else
                    control.Text += logMessage +
                                    (AddNewLine ? "\r\n" : String.Empty);
            }
            else
            {
                control.Text = logMessage +
                               (AddNewLine ? "\r\n" : String.Empty);
            }

            control.SelectionStart = control.Text.Length;
            control.ScrollToCaret();
        }
    }
}
