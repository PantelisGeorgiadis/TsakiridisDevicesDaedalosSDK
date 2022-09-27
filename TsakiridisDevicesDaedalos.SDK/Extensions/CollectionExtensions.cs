////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   28-05-2017
//
//
//      File description :
//      Name    :       CollectionExtensions.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace TsakiridisDevicesDaedalos.SDK.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> destination,
            IEnumerable<T> source)
        {
            var list = destination as List<T>;
            if (list != null)
                list.AddRange(source);
            else
            {
                foreach (var item in source)
                    destination.Add(item);
            }
        }
    }
}
