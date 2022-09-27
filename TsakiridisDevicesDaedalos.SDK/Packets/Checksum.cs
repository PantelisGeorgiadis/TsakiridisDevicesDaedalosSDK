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
//      Name    :       Checksum.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;

namespace TsakiridisDevicesDaedalos.SDK.Packets
{
    public static class Checksum
    {
        public static ushort CalculateChecksum(byte[] data, int length)
        {
            byte w = 0, a = 0;
            for (var i = 0; i < length; i++)
            {
                a += data[i];
                w ^= a;
            }

            return ((ushort)((w << 8) + a));
        }

        public static bool CompareChecksum(byte[] data)
        {
            var length = data.Length;
            var usCheckSum = (ushort)((data[length - 2] << 8) | data[length - 1]);

            var checksumData = new byte[length - 2];
            Array.Copy(data, 0, checksumData, 0, length - 2);
            var usCheckSumCalculated = CalculateChecksum(checksumData, checksumData.Length);

            return usCheckSum == usCheckSumCalculated;
        }
    }
}
