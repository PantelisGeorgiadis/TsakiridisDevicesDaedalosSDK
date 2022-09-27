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
//      Name    :       DaedalosDeviceAsync.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading.Tasks;
using TsakiridisDevicesDaedalos.SDK.Commands;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.Packets;

namespace TsakiridisDevicesDaedalos.SDK.Device
{
    public static class DaedalosDeviceAsync
    {
        public static Task<GetStatusPacketResponse> SendGetStatusRequestAsync(this DaedalosDevice device)
        {
            var t = new TaskCompletionSource<GetStatusPacketResponse>();
            device.SendGetStatusRequest((r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }

        public static Task<GetLibraryInfoPacketResponse> SendGetLibraryInfoRequestAsync(this DaedalosDevice device)
        {
            var t = new TaskCompletionSource<GetLibraryInfoPacketResponse>();
            device.SendGetLibraryInfoRequest((r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }

        public static Task<GetVersionInfoPacketResponse> SendGetVersionInfoRequestAsync(this DaedalosDevice device)
        {
            var t = new TaskCompletionSource<GetVersionInfoPacketResponse>();
            device.SendGetVersionInfoRequest((r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }

        public static Task<GetLibraryDataPacketResponse> SendGetLibraryDataRequestAsync(this DaedalosDevice device,
            int entryNumber)
        {
            var t = new TaskCompletionSource<GetLibraryDataPacketResponse>();
            device.SendGetLibraryDataRequest(entryNumber, (r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }

        public static Task<DisplayMessagePacketResponse> SendDisplayMessageRequestAsync(this DaedalosDevice device,
            LineNumber lineNumber, String text)
        {
            var t = new TaskCompletionSource<DisplayMessagePacketResponse>();
            device.SendDisplayMessageRequest(lineNumber, text, (r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }

        public static Task<DisplayProgressBarPacketResponse> SendDisplayProgressBarRequestAsync(
            this DaedalosDevice device,
            LineNumber lineNumber, byte percentage)
        {
            var t = new TaskCompletionSource<DisplayProgressBarPacketResponse>();
            device.SendDisplayProgressBarRequest(lineNumber, percentage, (r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }

        public static Task<GetSettingsPacketResponse> SendGetSettingsRequestAsync(this DaedalosDevice device)
        {
            var t = new TaskCompletionSource<GetSettingsPacketResponse>();
            device.SendGetSettingsRequest((r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }

        public static Task<SetSettingsPacketResponse> SendGetSettingsRequestAsync(this DaedalosDevice device,
            TestSettings testSettings)
        {
            var t = new TaskCompletionSource<SetSettingsPacketResponse>();
            device.SendSetSettingsRequest(testSettings, (r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }

        public static Task<StartTestPacketResponse> SendStartTestRequestAsync(this DaedalosDevice device)
        {
            var t = new TaskCompletionSource<StartTestPacketResponse>();
            device.SendStartTestRequest((r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }

        public static Task<AbortTestPacketResponse> SendAbortTestRequestAsync(this DaedalosDevice device)
        {
            var t = new TaskCompletionSource<AbortTestPacketResponse>();
            device.SendAbortTestRequest((r, e) =>
            {
                if (e == null)
                    t.TrySetResult(r);
                else
                    t.TrySetException(e);
            });

            return t.Task;
        }
    }
}
