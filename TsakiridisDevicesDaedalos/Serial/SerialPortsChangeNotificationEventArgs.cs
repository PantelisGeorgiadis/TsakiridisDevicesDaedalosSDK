////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos Desktop Application
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   26-10-2016
//
//
//      File description :
//      Name    :       SerialPortsChangeNotification.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;

namespace TsakiridisDevicesDaedalos
{
    public delegate void SerialPortsChangeNotificationEventHandler(SerialPortsChangeNotificationEventArgs e);

    public enum SerialPortsChangeNotificationState
    {
        Added,
        Removed
    }

    public class SerialPortsChangeNotificationEventArgs : EventArgs
    {
        public SerialPortsChangeNotificationState State { get; private set; }

        public SerialPortsChangeNotificationEventArgs(SerialPortsChangeNotificationState state)
        {
            State = state;
        }
    }
}
