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
//      Name    :       DaedalosDevice.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using TsakiridisDevicesDaedalos.SDK.Commands;
using TsakiridisDevicesDaedalos.SDK.Constants;
using TsakiridisDevicesDaedalos.SDK.EventArguments;
using TsakiridisDevicesDaedalos.SDK.Exceptions;
using TsakiridisDevicesDaedalos.SDK.Extensions;
using TsakiridisDevicesDaedalos.SDK.Logging;
using TsakiridisDevicesDaedalos.SDK.Packets;
using TsakiridisDevicesDaedalos.SDK.Serial;

namespace TsakiridisDevicesDaedalos.SDK.Device
{
    public class DaedalosDevice : IDisposable
    {
        private FastSerialPort _serialPort;
        private bool _disposed = false;

        private readonly int MaxPacketBufferSize = 256;
        private int _packetBufferSize = 0;
        private readonly byte[] _packetBuffer = null;
        bool _newPacket;
        byte _escMode;
        private int _packetNumber;

        private readonly List<RequestPacket> _pending;
        private readonly object _lock;

        private StartTestPacketRequest _startTestPacketRequest;

        public event EventHandler<TestMeasurementEventArgs> OnTestMeasurementReceived;
        public event EventHandler<TestMessageEventArgs> OnTestMessageReceived;
        public event EventHandler<TestAbortEventArgs> OnTestAbortReceived;
        public event EventHandler<TestErrorEventArgs> OnTestErrorReceived;
        public event EventHandler<TestDoneEventArgs> OnTestDoneReceived;

        public DaedalosDevice()
        {
            _packetBufferSize = 0;
            _packetBuffer = new byte[MaxPacketBufferSize];
            _newPacket = false;
            _escMode = 0;
            _packetNumber = 0;
            _startTestPacketRequest = null;

            _pending = new List<RequestPacket>();
            _lock = new object();

            _serialPort = new FastSerialPort(String.Empty);
            _serialPort.OnDataReceived += OnDataReceived;
            _disposed = false;
        }

        ~DaedalosDevice()
        {
            Dispose();
        }

        #region COM Port

        public bool Start(String port, int baudRate)
        {
            return _serialPort.OpenPort(port, baudRate);
        }

        public void Stop()
        {
            _serialPort.ClosePort();
        }

        public bool IsPortOpen
        {
            get { return _serialPort.IsPortOpen(); }
        }

        #endregion

        #region Packet Out

        public void SendGetStatusRequest(
            Action<GetStatusPacketResponse, Exception> callback)
        {
            Exception exception = null;
            try
            {
                var packet = new GetStatusPacketRequest(_packetNumber++);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                        callback(response, null);
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        public void SendGetVersionInfoRequest(
            Action<GetVersionInfoPacketResponse, Exception> callback)
        {
            Exception exception = null;
            try
            {
                var packet = new GetVersionInfoPacketRequest(_packetNumber++);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                        callback(response, null);
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        public void SendGetLibraryInfoRequest(
            Action<GetLibraryInfoPacketResponse, Exception> callback)
        {
            Exception exception = null;
            try
            {
                var packet = new GetLibraryInfoPacketRequest(_packetNumber++);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                        callback(response, null);
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        public void SendGetLibraryDataRequest(int entryNumber,
            Action<GetLibraryDataPacketResponse, Exception> callback)
        {
            Exception exception = null;
            try
            {
                var packet = new GetLibraryDataPacketRequest(_packetNumber++, entryNumber);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                        callback(response, null);
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        public void SendDisplayMessageRequest(LineNumber lineNumber, String text,
            Action<DisplayMessagePacketResponse, Exception> callback)
        {
            Exception exception = null;
            try
            {
                var packet = new DisplayMessagePacketRequest(_packetNumber++, lineNumber, text);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                        callback(response, null);
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        public void SendDisplayProgressBarRequest(LineNumber lineNumber, byte percentage,
            Action<DisplayProgressBarPacketResponse, Exception> callback)
        {
            Exception exception = null;
            try
            {
                var packet = new DisplayProgressBarPacketRequest(_packetNumber++, lineNumber, percentage);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                        callback(response, null);
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        public void SendGetSettingsRequest(
            Action<GetSettingsPacketResponse, Exception> callback)
        {
            Exception exception = null;
            try
            {
                var packet = new GetSettingsPacketRequest(_packetNumber++);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                        callback(response, null);
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        public void SendSetSettingsRequest(TestSettings testSettings,
            Action<SetSettingsPacketResponse, Exception> callback)
        {
            Exception exception = null;
            try
            {
                var packet = new SetSettingsPacketRequest(_packetNumber++, testSettings);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                        callback(response, null);
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        public void SendStartTestRequest(
            Action<StartTestPacketResponse, Exception> callback)
        {
            if (_startTestPacketRequest != null)
            {
                callback(null, new TestAlreadyRunningException());
                return;
            }

            Exception exception = null;
            try
            {
                var packet = new StartTestPacketRequest(_packetNumber++);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                    {
                        callback(response, null);
                        _startTestPacketRequest = request;
                    }
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        public void SendAbortTestRequest(
            Action<AbortTestPacketResponse, Exception> callback)
        {
            if (_startTestPacketRequest == null)
            {
                callback(null, new TestNotRunningException());
                return;
            }

            Exception exception = null;
            try
            {
                var packet = new AbortTestPacketRequest(_packetNumber++);
                packet.OnResponseReceived = (request, response) =>
                {
                    Log.PacketLog.Trace(response);
                    if (response.Command != DaedalosCommands.NegativeAcknowledgment)
                    {
                        callback(response, null);
                        _startTestPacketRequest = null;
                    }
                    else
                        callback(null,
                            new PacketNegativeAcknowledgmentException(response));
                };

                Log.PacketLog.Trace(packet);
                var data = packet.ToByteArray();

                lock (_lock)
                    _pending.Add(packet);

                _serialPort.Transmit(data);
                Log.SerialLog.Trace("Data sent to {0}: {1} ({2} bytes)",
                    _serialPort.Port, data.ByteArrayToString(), data.Length);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
                callback(null, exception);
        }

        #endregion

        #region Packet In

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            var data = e.Data;
            var serialPort = (FastSerialPort) sender;

            if (data != null &&
                data.Length != 0)
            {
                Log.SerialLog.Trace("Data received from {0}: {1} ({2} bytes)",
                    serialPort.Port, data.ByteArrayToString(), data.Length);

                foreach (var b in data)
                {
                    switch (b)
                    {
                        case PacketMarkers.StartOfFrame:
                        {
                            //A new packet or a restart is received
                            _packetBufferSize = 0; //Reset pointer to buffer
                            _newPacket = false; //Nothing received yet
                            _escMode = 0;
                            continue;
                        }
                        case PacketMarkers.EscapeCharacter:
                        {
                            _escMode = PacketMarkers.XorCharacter; //Will escape the next char
                            continue; //Read the next char
                        }
                        case PacketMarkers.EndOfMessage:
                        {
                            //Break out of the loop, leaving the rest of the input unread, to go to packet processing.
                            _newPacket = true;
                            _escMode = 0;
                            break;
                        }
                        default:
                        {
                            //Store the char, with escape if set
                            if (_packetBufferSize < MaxPacketBufferSize)
                                _packetBuffer[_packetBufferSize++] =
                                    (byte) (b ^ _escMode);

                            _escMode = 0;
                            continue;
                        }
                    }

                    if (_newPacket)
                    {
                        var packetData = new byte[_packetBufferSize];
                        Array.Copy(_packetBuffer, 0, packetData, 0, _packetBufferSize);

                        if (Checksum.CompareChecksum(packetData))
                        {
                            //Packet was correct. Break out of the loop, leaving the rest of the input unread, to go to packet processing.
                            // Packet length minus the checksum is returned.
                            var packetDataMinusChecksum = new byte[_packetBufferSize - 2];
                            Array.Copy(_packetBuffer, 0, packetDataMinusChecksum, 0, _packetBufferSize - 2);
                            OnPacketReceived(packetDataMinusChecksum);
                        }
                        else
                        {
                            // Checksum was incorrect, keep reading input.
                            _newPacket = false;
                        }
                    }
                }
            }
        }

        private void OnPacketReceived(byte[] data)
        {
            var packet = new GenericPacketResponse(data);
            if (packet != null &&
                packet.Command != DaedalosCommands.Generic &&
                packet.PacketNumber >= 0)
            {
                // Report streaming
                if (packet.Command == DaedalosCommands.ReportMessage)
                {
                    var reportMessagePacket = new ReportMessagePacketResponse(packet.Data);
                    if (reportMessagePacket != null &&
                        _startTestPacketRequest != null)
                    {
                        Log.PacketLog.Trace(reportMessagePacket);
                        if (OnTestMessageReceived != null)
                            OnTestMessageReceived(this, new TestMessageEventArgs(
                                _startTestPacketRequest, reportMessagePacket));
                    }
                }
                else if (packet.Command == DaedalosCommands.ReportMeasurementPoint)
                {
                    var measurementPointPacket = new ReportMeasurementPointPacketResponse(packet.Data);
                    if (measurementPointPacket != null &&
                        _startTestPacketRequest != null)
                    {
                        Log.PacketLog.Trace(measurementPointPacket);
                        if (OnTestMeasurementReceived != null)
                            OnTestMeasurementReceived(this, new TestMeasurementEventArgs(
                                _startTestPacketRequest, measurementPointPacket));
                    }
                }
                else if (packet.Command == DaedalosCommands.ReportAbort)
                {
                    var reportAbortPacketResponse = new ReportAbortPacketResponse(packet.Data);
                    if (reportAbortPacketResponse != null &&
                        _startTestPacketRequest != null)
                    {
                        Log.PacketLog.Trace(reportAbortPacketResponse);
                        if (OnTestAbortReceived != null)
                            OnTestAbortReceived(this, new TestAbortEventArgs(
                                _startTestPacketRequest, reportAbortPacketResponse));
                        _startTestPacketRequest = null;
                    }
                }
                else if (packet.Command == DaedalosCommands.ReportError)
                {
                    var reportErrorPacketResponse = new ReportErrorPacketResponse(packet.Data);
                    if (reportErrorPacketResponse != null &&
                        _startTestPacketRequest != null)
                    {
                        Log.PacketLog.Trace(reportErrorPacketResponse);
                        if (OnTestErrorReceived != null)
                            OnTestErrorReceived(this, new TestErrorEventArgs(
                                _startTestPacketRequest, reportErrorPacketResponse));
                        _startTestPacketRequest = null;
                    }
                }
                else if (packet.Command == DaedalosCommands.ReportDone)
                {
                    var reportDonePacketResponse = new ReportDonePacketResponse(packet.Data);
                    if (reportDonePacketResponse != null &&
                        _startTestPacketRequest != null)
                    {
                        Log.PacketLog.Trace(reportDonePacketResponse);
                        if (OnTestDoneReceived != null)
                            OnTestDoneReceived(this, new TestDoneEventArgs(
                                _startTestPacketRequest, reportDonePacketResponse));
                        _startTestPacketRequest = null;
                    }
                }
                // Other packets
                else
                {
                    RequestPacket _packet = null;
                    lock (_lock)
                        _packet = _pending.FirstOrDefault(
                            p => p.PacketNumber == packet.PacketNumber);
                    if (_packet != null)
                    {
                        _packet.PostResponse(this, packet);
                        lock (_lock)
                            _pending.Remove(_packet);
                    }
                }
            }
        }

        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                Stop();
                _serialPort.Dispose();
                _serialPort = null;
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
