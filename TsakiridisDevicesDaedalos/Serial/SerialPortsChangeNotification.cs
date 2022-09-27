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
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TsakiridisDevicesDaedalos
{
    public class SerialPortsChangeNotification : IDisposable
    {
        private static readonly Regex _patternVid = new Regex("VID_[0-9A-Z]{4}", RegexOptions.Compiled);
        private static readonly Regex _patternPid = new Regex("PID_[0-9A-Z]{4}", RegexOptions.Compiled);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
        public class DeviceBroadcastInterface
        {
            public int Size;
            public int DeviceType;
            public int Reserved;
            public Guid ClassGuid;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public String Name;
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr RegisterDeviceNotification(
            IntPtr hwnd,
            DeviceBroadcastInterface dbi,
            uint flags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterDeviceNotification(
            IntPtr handle);

        private class DriverWindow : NativeWindow, IDisposable
        {
            private IntPtr _notificationHandle = IntPtr.Zero;

            private const int WM_DEVICECHANGE = 0x0219;
            private const int DBT_DEVICEARRIVAL = 0x8000;
            private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
            private const int DEVTYP_DEVICEINTERFACE = 0x05;
            private const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;

            private const String GUID_DEVINTERFACE_COMPORT = "86E0D1E0-8089-11D0-9CE4-08003E301F73";

            public DriverWindow()
            {
                base.CreateHandle(new CreateParams());

                _notificationHandle = RegisterDeviceNotifications(Handle,
                    Guid.Parse(GUID_DEVINTERFACE_COMPORT));
            }

            public void Dispose()
            {
                if (_notificationHandle != IntPtr.Zero)
                    UnregisterDeviceNotifications(_notificationHandle);

                base.DestroyHandle();
                GC.SuppressFinalize(this);
            }

            private static IntPtr RegisterDeviceNotifications(IntPtr hwnd, Guid classGuid)
            {
                var dbi = new DeviceBroadcastInterface();
                dbi.Size = Marshal.SizeOf(dbi);
                dbi.ClassGuid = classGuid;
                dbi.DeviceType = DEVTYP_DEVICEINTERFACE;
                dbi.Reserved = 0;
                return RegisterDeviceNotification(hwnd, dbi, DEVICE_NOTIFY_WINDOW_HANDLE);
            }

            private static void UnregisterDeviceNotifications(IntPtr handle)
            {
                UnregisterDeviceNotification(handle);
            }

            public event SerialPortsChangeNotificationEventHandler StateChanged;

            protected override void WndProc(ref Message message)
            {
                base.WndProc(ref message);

                if (message.Msg == WM_DEVICECHANGE &&
                    message.WParam != IntPtr.Zero &&
                    message.LParam != IntPtr.Zero)
                {
                    var pDbi = (DeviceBroadcastInterface) Marshal.PtrToStructure(
                        message.LParam, typeof(DeviceBroadcastInterface));

                    if (pDbi.DeviceType == DEVTYP_DEVICEINTERFACE)
                    {
                        switch (message.WParam.ToInt32())
                        {
                            case DBT_DEVICEARRIVAL:
                                SignalDeviceChange(SerialPortsChangeNotificationState.Added, pDbi);
                                break;

                            case DBT_DEVICEREMOVECOMPLETE:
                                SignalDeviceChange(SerialPortsChangeNotificationState.Removed, pDbi);
                                break;
                        }
                    }
                }
            }

            private static String GetVid(String source)
            {
                var match = _patternVid.Match(source);
                return match.Success ? match.Value : String.Empty;
            }

            private static String GetPid(String source)
            {
                var match = _patternPid.Match(source);
                return match.Success ? match.Value : String.Empty;
            }

            private void SignalDeviceChange(SerialPortsChangeNotificationState state, DeviceBroadcastInterface pDbi)
            {
                if (StateChanged != null)
                {
                    var vid = GetVid(pDbi.Name);
                    var pid = GetPid(pDbi.Name);

                    StateChanged(new SerialPortsChangeNotificationEventArgs(state));
                }
            }

        }

        private DriverWindow _window;
        private SerialPortsChangeNotificationEventHandler _handler;
        private bool _isDisposed;

        public SerialPortsChangeNotification()
        {
            _window = null;
            _handler = null;
            _isDisposed = false;
        }

        ~SerialPortsChangeNotification()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                if (_window != null)
                {
                    _window.StateChanged -= new SerialPortsChangeNotificationEventHandler(DoStateChanged);
                    _window.Dispose();
                    _window = null;
                }

                _isDisposed = true;
                GC.SuppressFinalize(this);
            }
        }

        public event SerialPortsChangeNotificationEventHandler StateChanged
        {
            add
            {
                if (_window == null)
                {
                    _window = new DriverWindow();
                    _window.StateChanged += new SerialPortsChangeNotificationEventHandler(DoStateChanged);
                }

                _handler = (SerialPortsChangeNotificationEventHandler) Delegate.Combine(_handler, value);
            }

            remove
            {
                _handler = (SerialPortsChangeNotificationEventHandler) Delegate.Remove(_handler, value);

                if (_handler == null)
                {
                    _window.StateChanged -= new SerialPortsChangeNotificationEventHandler(DoStateChanged);
                    _window.Dispose();
                    _window = null;
                }
            }
        }

        private void DoStateChanged(SerialPortsChangeNotificationEventArgs e)
        {
            if (_handler != null)
                _handler(e);
        }
    }
}
