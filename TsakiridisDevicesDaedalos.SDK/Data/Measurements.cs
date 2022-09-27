////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   30-04-2017
//
//
//      File description :
//      Name    :       Measurements.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TsakiridisDevicesDaedalos.SDK.Data
{
    public class Measurements : Collection<Measurement>
    {
        public Measurements()
        {
        }

        public Measurements(IList<Measurement> source)
            : base(source)
        {
        }

        public Measurements Clone()
        {
            return Clone(this);
        }

        public static Measurements Clone(Measurements measurements)
        {
            return new Measurements(measurements.ToList());
        }
    }
}
