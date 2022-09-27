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
//      Name    :       ByteArrayExtensions.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;

namespace TsakiridisDevicesDaedalos.SDK.Extensions
{
    public static class ByteArrayExtensions
    {
        public static String ByteArrayToString(this byte[] bytes)
        {
            return String.Join(" ", Array.ConvertAll(bytes, b => b.ToString("X2")));
        }
    }
}
