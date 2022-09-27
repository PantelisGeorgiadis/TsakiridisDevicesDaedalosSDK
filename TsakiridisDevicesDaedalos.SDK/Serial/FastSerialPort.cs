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
//      Name    :       FastSerialPort.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.IO.Ports;
using System.Threading;
using TsakiridisDevicesDaedalos.SDK.EventArguments;

namespace TsakiridisDevicesDaedalos.SDK.Serial
{
    public class FastSerialPort : IDisposable
    {
        private String _port;
        private int _baudRate;
        private SerialPort _serialPort;
        private ThreadStart _threadStart;
        private Thread _thread;
        private double _packetsRate;
        private DateTime _lastReceive;

        // The critical frequency of communication to avoid any lag
        private const int FreqCriticalLimit = 20;

        public event EventHandler<DataReceivedEventArgs> OnDataReceived;

        public FastSerialPort(String port)
        {
            _port = port;
            _baudRate = 115200;
            _lastReceive = DateTime.MinValue;
        }

        public FastSerialPort(String port, int baudRate)
            : this(port)
        {
            _baudRate = baudRate;
        }

        public String Port
        {
            get { return _port; }
        }

        public int BaudRate
        {
            get { return _baudRate; }
        }

        public bool OpenPort()
        {
            try
            {
                if (_serialPort == null)
                    _serialPort = new SerialPort(_port, _baudRate,
                        Parity.None, 8);

                if (!_serialPort.IsOpen)
                {
                    _serialPort.ReadTimeout = -1;
                    _serialPort.WriteTimeout = -1;

                    _serialPort.Open();

                    if (_serialPort.IsOpen)
                    {
                        _threadStart = new ThreadStart(SerialReceiving);
                        _thread = new Thread(_threadStart);
                        _thread.Start();
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool OpenPort(String port, int baudRate)
        {
            _port = port;
            _baudRate = baudRate;

            return OpenPort();
        }

        public void ClosePort()
        {
            if (_serialPort != null &&
                _serialPort.IsOpen)
            {
                if (_thread != null)
                    _thread.Abort();

                _serialPort.Close();

                _thread = null;
                _threadStart = null;
            }
        }

        public bool IsPortOpen()
        {
            if (_serialPort != null &&
                _serialPort.IsOpen)
                return true;

            return false;
        }

        public bool ResetPort()
        {
            ClosePort();
            return OpenPort();
        }

        public void Transmit(byte[] packet)
        {
            _serialPort.Write(packet, 0, packet.Length);
        }

        public int Receive(byte[] bytes, int offset, int count)
        {
            var readBytes = 0;
            if (count > 0)
                readBytes = _serialPort.Read(bytes, offset, count);

            return readBytes;
        }

        public void Dispose()
        {
            ClosePort();

            if (_serialPort != null)
            {
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        private void SerialReceiving()
        {
            while (true)
            {
                var count = _serialPort.BytesToRead;

                var tmpInterval = (DateTime.Now - _lastReceive);

                var buf = new byte[count];
                var readBytes = Receive(buf, 0, count);

                if (readBytes > 0)
                    OnSerialDataReceived(buf);

                _packetsRate = ((_packetsRate + readBytes) / 2);
                _lastReceive = DateTime.Now;
                if ((double) (readBytes + _serialPort.BytesToRead) / 2 <= _packetsRate)
                {
                    if (tmpInterval.Milliseconds > 0)
                        Thread.Sleep(tmpInterval.Milliseconds > FreqCriticalLimit
                            ? FreqCriticalLimit
                            : tmpInterval.Milliseconds);
                }
            }
        }

        private void OnSerialDataReceived(byte[] res)
        {
            if (OnDataReceived != null)
                OnDataReceived(this,
                    new DataReceivedEventArgs(res));
        }
    }
}
