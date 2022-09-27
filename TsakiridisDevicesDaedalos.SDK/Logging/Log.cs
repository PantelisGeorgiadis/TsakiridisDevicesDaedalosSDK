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
//      Name    :       Log.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using NLog;

namespace TsakiridisDevicesDaedalos.SDK.Logging
{
    public static class Log
    {
        private static Logger _packetLog;
        private static Logger _serialLog;

        public static Logger PacketLog
        {
            get
            {
                if (_packetLog == null)
                    _packetLog = LogManager.GetLogger("PACKET");

                return _packetLog;
            }
            set { _packetLog = value; }
        }

        public static Logger SerialLog
        {
            get
            {
                if (_serialLog == null)
                    _serialLog = LogManager.GetLogger("SERIAL");

                return _serialLog;
            }
            set { _serialLog = value; }
        }
    }
}
