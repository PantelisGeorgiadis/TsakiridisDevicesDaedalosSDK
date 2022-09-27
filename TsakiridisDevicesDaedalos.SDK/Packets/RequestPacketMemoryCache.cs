////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   23-11-2016
//
//
//      File description :
//      Name    :       RequestPacketMemoryCache.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Caching;

namespace TsakiridisDevicesDaedalos.SDK.Packets
{
    public class RequestPacketMemoryCache : MemoryCache
    {
        private readonly int _expiration;
        private const String KeyFormat = "__packet_{0}";

        public event EventHandler<RequestPacket> OnPacketExpired;

        public RequestPacketMemoryCache(int expiration)
            : base("__requestpacketmemorybuffer")
        {
            _expiration = expiration;
        }

        public void AddPacket(RequestPacket packet)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration =
                    DateTimeOffset.Now.AddSeconds(_expiration),
                RemovedCallback = PacketRemovedCallback
            };

            Set(String.Format(KeyFormat, packet.PacketNumber),
                packet, policy);
        }

        public RequestPacket GetPacket(int packetNumber)
        {
            return (RequestPacket) Get(String.Format(KeyFormat, packetNumber));
        }

        public void RemovePacket(RequestPacket packet)
        {
            Remove(String.Format(KeyFormat, packet.PacketNumber));
        }

        private void PacketRemovedCallback(CacheEntryRemovedArguments args)
        {
            if (args.RemovedReason == CacheEntryRemovedReason.Expired)
            {
                if (OnPacketExpired != null)
                    OnPacketExpired(this, (RequestPacket) args.CacheItem.Value);
            }
        }
    }
}
