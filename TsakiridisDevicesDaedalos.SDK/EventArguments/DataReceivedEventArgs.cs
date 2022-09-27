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
//      Name    :       DataReceivedEventArgs.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;

namespace TsakiridisDevicesDaedalos.SDK.EventArguments
{
    public class DataReceivedEventArgs : EventArgs
    {
        private readonly byte[] _bytes;

        public DataReceivedEventArgs(byte[] bytes)
        {
            _bytes = bytes;
        }

        public byte[] Data
        {
            get { return _bytes; }
        }
    }
}
