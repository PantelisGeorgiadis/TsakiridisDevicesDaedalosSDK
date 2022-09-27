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
//      Name    :       PacketMarkers.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;

namespace TsakiridisDevicesDaedalos.SDK.Constants
{
    public static class PacketMarkers
    {
        public const byte StartOfFrame = 0x7E;
        public const byte EndOfMessage = 0x7F;
        public const byte EscapeCharacter = 0x7D;
        public const byte XorCharacter = 0x20;
    }
}
