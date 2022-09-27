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
//      Name    :       DaedalosDeviceSync.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading;
using TsakiridisDevicesDaedalos.SDK.Commands;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.Device
{
    public static class DaedalosDeviceSync
    {
        public static GetStatusPacketResponse SendGetStatusRequestSync(this DaedalosDevice device)
        {
            Exception exception = null;
            GetStatusPacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendGetStatusRequest((r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }

        public static GetLibraryInfoPacketResponse SendGetLibraryInfoRequestSync(this DaedalosDevice device)
        {
            Exception exception = null;
            GetLibraryInfoPacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendGetLibraryInfoRequest((r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }

        public static GetVersionInfoPacketResponse SendGetVersionInfoRequestSync(this DaedalosDevice device)
        {
            Exception exception = null;
            GetVersionInfoPacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendGetVersionInfoRequest((r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }

        public static GetLibraryDataPacketResponse SendGetLibraryDataRequestSync(this DaedalosDevice device,
            int entryNumber)
        {
            Exception exception = null;
            GetLibraryDataPacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendGetLibraryDataRequest(entryNumber, (r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }

        public static DisplayMessagePacketResponse SendDisplayMessageRequestSync(this DaedalosDevice device,
            LineNumber lineNumber, String text)
        {
            Exception exception = null;
            DisplayMessagePacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendDisplayMessageRequest(lineNumber, text, (r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }

        public static DisplayProgressBarPacketResponse SendDisplayProgressBarRequestSync(this DaedalosDevice device,
            LineNumber lineNumber, byte percentage)
        {
            Exception exception = null;
            DisplayProgressBarPacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendDisplayProgressBarRequest(lineNumber, percentage, (r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }

        public static GetSettingsPacketResponse SendGetSettingsRequestSync(this DaedalosDevice device)
        {
            Exception exception = null;
            GetSettingsPacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendGetSettingsRequest((r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }

        public static SetSettingsPacketResponse SendSetSettingsRequestSync(this DaedalosDevice device,
            TestSettings testSettings)
        {
            Exception exception = null;
            SetSettingsPacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendSetSettingsRequest(testSettings, (r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }

        public static StartTestPacketResponse SendStartTestRequestSync(this DaedalosDevice device)
        {
            Exception exception = null;
            StartTestPacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendStartTestRequest((r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }

        public static AbortTestPacketResponse SendAbortTestRequestSync(this DaedalosDevice device)
        {
            Exception exception = null;
            AbortTestPacketResponse response = null;

            using (var autoResetEvent = new AutoResetEvent(false))
            {
                device.SendAbortTestRequest((r, e) =>
                {
                    response = r;
                    exception = e;

                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne();
            }

            if (exception != null)
                throw exception;

            return response;
        }
    }
}
